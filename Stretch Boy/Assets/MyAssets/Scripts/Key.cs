﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LockDoor"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
