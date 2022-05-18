using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
	public static GameManager Instance;
	private Obi.ObiRope[] obiRopeS;
	private Drag[] hands;
	public GameObject retryPanel;
	public GameObject winPanel;
	public GameObject commingSoonPanel;
	private int handsStick;
	public GameObject hand;
	public Material fixedHandColor;
	public Material handsMat;

	private void Start()
	{
	}

	private void Awake()
    {
		if (Instance == null)
		{
			Instance = this;
		}
		commingSoonPanel = FindObjectOfType<Canvas>().transform.GetChild(5).gameObject;

		obiRopeS = FindObjectsOfType<Obi.ObiRope>();
		hands = FindObjectsOfType<Drag>();

		CheckHandCollision();
	}

    private void Update()
    {
		if (obiRopeS[0].isTear || obiRopeS[1].isTear || obiRopeS[2].isTear || obiRopeS[3].isTear || obiRopeS[4].isTear)
		{
			RetryGame();
		}

		if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
	public void CheckHandCollision()
    {
        for (int i = 0; i < hands.Length; i++)
        {
            if (hands[i].GetComponent<Rigidbody>().isKinematic)
            {
                handsStick++;
                print(handsStick + "under");
            }
            print("UpperLoop");
        }

        if (handsStick > 1)
		{
			if (hand)
			{
				print("ColorHand");
				hand.GetComponent<MeshRenderer>().material = handsMat;
				hand.GetComponent<Drag>().enabled = true;
				hand.GetComponent<Drag>().tag = "Hand";
			}

		}

		if (handsStick == 1)
        {
			for (int i = 0; i < hands.Length; i++)
			{
				if (hands[i].GetComponent<Rigidbody>().isKinematic)
				{
					hand = hands[i].gameObject;

					hand.GetComponent<MeshRenderer>().material = fixedHandColor;
					hand.GetComponent<Drag>().enabled = false;
					hand.GetComponent<Drag>().tag = "Untagged";
					handsStick = 0;

					print("handColored");
				}
			}
			print("DownLoop");
		}
		else
        {
			handsStick = 0;
        }

		print(handsStick + "Last");
	}

	public void RetryGame()
	{
		if (retryPanel.activeSelf == false && winPanel.activeSelf == false && commingSoonPanel.activeSelf == false)
		{
			Invoke("InvokeRetryGame", 2);
		}
	}

	public void InvokeRetryGame()
    {
		print("Failed");
		retryPanel.SetActive(true);
	}
}
