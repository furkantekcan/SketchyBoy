using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUiManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public int currentLevelNo = 1;
    public Text thisLevelNo;

    private void Awake()
    {
        print(SceneManager.sceneCountInBuildSettings-1 +"BuildSettings");
        Time.timeScale = 1;

        //thisLevelNo.text = "Level " + PlayerPrefs.GetInt("LevelNo", 1).ToString();
       
        currentLevelNo = PlayerPrefs.GetInt("LevelNo", 1);
        Debug.Log(currentLevelNo);
    }

    public void Next()
    {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("LevelNo", currentLevelNo + 1);

        SceneManager.LoadScene(currentLevelNo + 1);
    }

    public void RetryGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            print("ResetGame");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
