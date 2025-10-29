using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public KeyCode grabKey;

    private bool hold;
    private bool holding = false;
    void Update()
    {
        

        if (Input.GetKey(grabKey))
        {
            hold = true;
        }
        else
        {
            hold = false;
            holding = false;
            Destroy(GetComponent<FixedJoint>());
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Movable")
        {
            if (hold && !holding)
            {
                holding = true;
                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = rb;
            }
        }

    }
}