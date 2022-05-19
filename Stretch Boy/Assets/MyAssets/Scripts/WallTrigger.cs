using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public delegate void TriggerAction();
    public static event TriggerAction OnTriggerIn;
    public static event TriggerAction OnTriggerOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Lava"))
        {
            OnTriggerIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Lava"))
        {
            Destroy(this.gameObject);
        }
    }
}
