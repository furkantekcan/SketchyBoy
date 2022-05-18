using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCollider : MonoBehaviour
{
    public bool faceDetect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            faceDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            faceDetect = false;
        }
    }
}
