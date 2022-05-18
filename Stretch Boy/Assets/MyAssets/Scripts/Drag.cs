using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool wallCollision;
    public Obi.ObiRope rope;

    void OnMouseUp()
    {
        if (this.GetComponent<Drag>().enabled)
        {
            if (wallCollision)
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }

            r.velocity = Vector3.zero;

            GameManager.Instance.CheckHandCollision();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallCollision = true;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            wallCollision = true;
            this.transform.parent = collision.gameObject.transform.GetChild(0).transform;
        }

        if (collision.gameObject.CompareTag("Blade"))
        {
            GameManager.Instance.GetComponent<AudioSource>().Play();
            print("Blade");
            rope.tearResistanceMultiplier = 1;
            GameManager.Instance.RetryGame();
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.transform.parent = this.transform;
        }

        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Lava"))
        {
            GameManager.Instance.GetComponent<AudioSource>().Play();
            print("Spike");
            GameManager.Instance.RetryGame();
            Destroy(this.GetComponent<MeshRenderer>());
            Destroy(this.GetComponent<Obi.ObiCollider>());
            Destroy(this.GetComponent<SphereCollider>());
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            wallCollision = false;
        }
    }

    public float distanceFromCamera;
    Rigidbody r;

    private void Awake()
    {
        //this.GetComponent<Rigidbody>().isKinematic = false;

        distanceFromCamera = Vector3.Distance(this.transform.position, FindObjectOfType<Camera>().transform.position);
        r = this.GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        if (this.GetComponent<Drag>().enabled)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = FindObjectOfType<Camera>().ScreenToWorldPoint(pos);
            r.velocity = (pos - this.transform.position) * 10;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
