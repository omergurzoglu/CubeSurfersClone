
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool GameOverCalled=false,RotateCameraCheck=false;
    public GameObject GameOverText,PressToPlayText,TotalScoreText;
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            if (Time.timeScale == 0)
            {
                PressToPlayText.gameObject.SetActive(false);
                Time.timeScale = 2f;
            }

            if (GameOverCalled)
            {
                if (Input.anyKey)
                {
                    Restart();
                    GameOverCalled = false;
                }
            }
        }
    }

    public void GameOver()
    {
        GameOverCalled = true;
        GameOverText.gameObject.SetActive(true);
    }

    public void Won()
    {
        GameOverCalled = true;
        RotateCameraCheck = true;
        TotalScoreText.gameObject.SetActive(true);
        TotalScoreText.GetComponent<TextMeshProUGUI>().text = "Token Score=" + TokenBehavior.Score+"\n"+"Step Bonus="+Camera2.staticFloat+"\n"+"Total Score="+TokenBehavior.Score*Camera2.staticFloat;
    }

    public void Restart()
    {
        RotateCameraCheck = false;
        Camera2.staticFloat = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
