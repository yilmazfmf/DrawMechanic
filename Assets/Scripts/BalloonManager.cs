using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    ObjectPooler OP;
    public float scalingFactor = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        OP = ObjectPooler.SharedInstance;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject GO = ObjectPooler.SharedInstance.GetPooledObject(0);
        if (Input.GetMouseButtonDown(0))
        {
            GO.SetActive(true);
        }

        if (Input.GetKey("space"))
        {
            Debug.Log("imhere");
            GO.SetActive(false);
        }

    }
}
