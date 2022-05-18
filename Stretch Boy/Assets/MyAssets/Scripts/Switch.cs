using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject switchBtn;
    public Move[] moveObjects;
    public int value;
    private bool playAudio = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            if (playAudio)
            {
                this.GetComponent<AudioSource>().Play();
                playAudio = false;
            }

            switchBtn.transform.rotation = Quaternion.Euler(0, 0, value);

            for(int i = 0; i < moveObjects.Length; i++)
            {
                moveObjects[i].enabled = true;
            }
        }
    }
}
