using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [NonSerialized] public Transform desiredTransform;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        var position = rb.transform.position;
        var position1 = desiredTransform.position;
        rb.MovePosition(Vector3.Lerp(position, new Vector3((position.x+position1.x)/2, position1.y, (position.z+position1.z)/2), Time.deltaTime*5));
    }
}
