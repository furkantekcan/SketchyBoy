using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaceDetect : MonoBehaviour
{
    public FaceCollider[] faceColliders;
    public GameObject winPanel;
    public GameObject retryPanel;
    public GameObject commingSoonPanel;
    public GameObject winParticle;

    private void Start()
    {
        commingSoonPanel = GameManager.Instance.commingSoonPanel;
    }

    void Update()
    {
        if (faceColliders[0].faceDetect && faceColliders[1].faceDetect && faceColliders[2].faceDetect && faceColliders[3].faceDetect)
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1 && commingSoonPanel.activeSelf == false) 
            {         
                  commingSoonPanel.SetActive(true);
            }
            else if (winPanel.activeSelf == false && retryPanel.activeSelf == false && commingSoonPanel.activeSelf == false)
            {
                winParticle.SetActive(true);
                Invoke("InvokeWinGame", 1);
            }
        }
    }

    public void InvokeWinGame()
    {
        print("Failed");
        winPanel.SetActive(true);
    }
}
