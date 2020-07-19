using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuObj;
    public GameObject quitObj;
    public GameObject optionsObj;
    public GameObject levelSelectorObj;
    void Start()
    {
        mainMenuObj.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Play()
    {
        try
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("SavedScene"));
        }
        catch
        {
            mainMenuObj.SetActive(false);
            levelSelectorObj.SetActive(true);
        }
    }

    public void LevelSelector()
    {
        mainMenuObj.SetActive(false);
        levelSelectorObj.SetActive(true);
    }

    public void SelectLevel()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        switch (name)
        {
            case "Level1Button":
                SceneManager.LoadScene("Level 1");
                break;
            case "Level2Button":
                SceneManager.LoadScene("Level 2");
                break;
            case "Level3Button":
                SceneManager.LoadScene("Level 3");
                break;
            case "Level4Button":
                SceneManager.LoadScene("Level 4");
                break;
            case "Level5Button":
                SceneManager.LoadScene("Level 5");
                break;
            case "Level6Button":
                SceneManager.LoadScene("Level 6");
                break;
            case "Level7Button":
                SceneManager.LoadScene("Level 7");
                break;
            default:
                break;
        }
    }

    public void Options()
    {
        mainMenuObj.SetActive(false);
        optionsObj.SetActive(true);
    }

    public void Option1()
    {
        //
    }

    public void Option2()
    {
        //
    }

    public void Back()
    {
        mainMenuObj.SetActive(true);
        optionsObj.SetActive(false);
        levelSelectorObj.SetActive(false);
    }

    public void Quit()
    {
        mainMenuObj.SetActive(false);
        quitObj.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        mainMenuObj.SetActive(true);
        quitObj.SetActive(false);
    }
}