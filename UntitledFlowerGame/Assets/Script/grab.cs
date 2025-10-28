using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public bool hold;
    public KeyCode grabKey; 
    public bool canGrab;


    /*
    void Update()
    {
        
        if (canGrab)
        {
            if (Input.GetKey(grabKey))
            {
                hold = true;
                transform.position = new Vector3(transform.position.x + (1f * Time.deltaTime), transform.position.y, transform.position.z);
            }
            else
            {
                hold = false;
                Destroy(GetComponent<FixedJoint>());
            }
        }
    }
    */
    void Update()
    {
        if (!hold)
        {
            Destroy(GetComponent<FixedJoint>());
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        print("hey");
        if (hold && col.transform.tag != "Player")
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = rb;
            }
            else
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            }
        }
    }
}