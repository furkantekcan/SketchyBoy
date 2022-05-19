using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 1.0f;

    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void FixedUpdate()
    {
        transform.position += movement * cameraSpeed * Time.fixedDeltaTime;
    }
}
