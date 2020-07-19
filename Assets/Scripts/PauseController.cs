using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseController : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject quitObj;
    public GameObject HelpObj;
    public Text pointsText;
    void Start()
    {
        HelpObj.SetActive(true);
    }
    void Update()
    {
        pointsText.text = PlayerController.pointsCounter.ToString() + " / " + PlayerController.pointsObjects.ToString();
        if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused == true)
        {
            Resume();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            PlayerPrefs.SetString("SavedScene", SceneManager.GetActiveScene().name);
            Application.Quit();
        }
    }

    public void Resume()
    {
        HelpObj.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
        pauseMenu.SetActive(false);
    }

    public void Retry()
    {
        HelpObj.SetActive(true);
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void Pause()
    {
        HelpObj.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("SavedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        pauseMenu.SetActive(false);
        quitObj.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        pauseMenu.SetActive(true);
        quitObj.SetActive(false);
    }
}
