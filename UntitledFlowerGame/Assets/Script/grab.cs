using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public KeyCode grabKey;
    [SerializeField] AudioSource grabSound;
    [SerializeField] GameObject grabAnchor;

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
            if (holding)
            {
                holding = false;
                Destroy(GetComponent<FixedJoint>());
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Movable")
        {
            if (hold && !holding)
            {
                holding = true;
                if (grabSound != null)
                    grabSound.Play();
                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.3f, other.transform.position.z);
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                
                fj.connectedBody = rb;
            }
        }

    }
}