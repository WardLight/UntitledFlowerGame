using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public KeyCode grabKey;

    private bool hold;
    void Update()
    {
        

        if (Input.GetKey(grabKey))
        {
            hold = true;
        }
        else
        {
            hold = false;
            Destroy(GetComponent<FixedJoint>());
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (hold)
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            fj.connectedBody = rb;
        }
    }
}