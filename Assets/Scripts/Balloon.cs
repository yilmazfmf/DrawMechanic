using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private GameObject balloon;
    private Rigidbody rb;
    public Transform desired;
    public float scalingFactor = .5f;
    public float floatingSpeed = 5f;
    float growingTime = 0;


    private void Start()
    {
        balloon = GetComponent<GameObject>();
        rb = GetComponentInChildren<Rigidbody>();
    }



    private void Update()
    {
        
        
            //rb.MovePosition(Vector3.MoveTowards(rb.transform.position, new Vector3(desiredPos.x, transform.position.y, desiredPos.z), Time.deltaTime * 1f));
            rb.MovePosition(Vector3.Lerp(rb.transform.position, new Vector3((rb.transform.position.x)/2f, desired.localPosition.y, (rb.transform.position.z )/2f), Time.deltaTime * 5f));
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
        

         
            if(growingTime < 2)
            {
                growingTime += Time.deltaTime;
                growByTime();
            }
            
        
    }


    void growByTime()
    {
            transform.localScale = new Vector3(transform.localScale.x + transform.localScale.x * scalingFactor * Time.deltaTime, transform.localScale.y + transform.localScale.y * scalingFactor * Time.deltaTime, transform.localScale.z + transform.localScale.z * scalingFactor * Time.deltaTime);
    }
   
}
