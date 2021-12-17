using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalloonCreator : MonoBehaviour
{
    public GameObject balloon;
    public Transform DesireTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           var tempBalloon = Instantiate(balloon, transform.position, transform.rotation);
           tempBalloon.GetComponent<Balloon>().desiredTransform=DesireTransform;
        }
    }
}
