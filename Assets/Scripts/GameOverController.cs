using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{
    public Text levelName;
    public GameObject gameOverObject;
    public GameObject gameOverTextObj;
    public GameObject quitObject;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            gameOverTextObj.SetActive(true);
            levelName.text = CalculatingDistance.previousScene;
            gameOverObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(CalculatingDistance.previousScene);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("SavedScene", CalculatingDistance.previousScene);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        gameOverObject.SetActive(false);
        quitObject.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        gameOverObject.SetActive(true);
        quitObject.SetActive(false);
    }
}
