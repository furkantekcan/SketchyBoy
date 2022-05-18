using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 vec;
    public float speed;
    public bool positive, negative, loopX, loopY;

    public float delta = 1.5f;  // Amount to move left and right from the start point
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (negative)
        {
            if (transform.position.x > vec.x)
            {
                transform.Translate(vec * speed * Time.deltaTime);
            }
        }

        if (positive)
        {
            if (transform.position.x < vec.x)
            {
                transform.Translate(vec * speed * Time.deltaTime);
            }
        }

        if (loopX)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }

        if (loopY)
        {
            Vector3 v = startPos;
            v.y += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
    }
}
