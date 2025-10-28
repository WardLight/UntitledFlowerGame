using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Transform cameraTransform;
    Vector3 cameraOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        cameraOffset = playerTransform.position - cameraTransform.position;
        cameraOffset.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(playerTransform.position.x, 
                                       cameraTransform.position.y, 
                                       playerTransform.position.z) 
                                    - cameraOffset; 
    }
}
