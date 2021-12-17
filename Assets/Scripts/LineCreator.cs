using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineCreator : MonoBehaviour
{

    ObjectPooler OP;
    private string selectableTag = "Selectable";
    private LineRenderer lineRenderer;
    [NonSerialized]
    public List<Vector3> points = new List<Vector3>();


    public Action<IEnumerable<Vector3>> OnNewLineCreated = delegate { };


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        OP = ObjectPooler.SharedInstance;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                points.Clear();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                OnNewLineCreated(points);
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    var selection = hitInfo.transform;
                    if (selection.CompareTag(selectableTag))
                    {
                        if (DistanceToLastPoint(hitInfo.point) > .2f)
                        {
                            points.Add(hitInfo.point);
                            lineRenderer.positionCount = points.Count;
                            lineRenderer.SetPositions(points.ToArray());
                            CreateMesh(hitInfo.point);
                        }
                    }

                }
            }

        }


    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
            return Mathf.Infinity;
        return Vector3.Distance(points.Last(), point);
    }


    void CreateMesh(Vector3 pos)
    {
        GameObject GO = ObjectPooler.SharedInstance.GetPooledObject(0);
        GO.SetActive(true);
        GO.transform.position = pos + (Vector3.up * 3);
    }



}
