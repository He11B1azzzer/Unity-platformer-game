using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class LevelCompleteController : MonoBehaviour
{
    public Text levelName;
    public Text stars;
    public int numberOfStars;
    public float result = 0.0f;
    public GameObject levelCompleteMenuObj;
    public GameObject levelCompleteObj;
    public GameObject quitObj;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LevelComplete")
        {
            if (PlayerController.pointsCounter < PlayerController.pointsObjects)
            {
                result +=  CalculatingDistance.maxDistance / CalculatingDistance.startTime - 4.0f;
            }
            else
            {
                result += CalculatingDistance.maxDistance / CalculatingDistance.startTime + PlayerController.points;
            }
            if (result >= 1.0f && result < 2.0f)
            {
                numberOfStars = 1;
            }
            else if (result >= 2.0f && result < 3.0f)
            {
                numberOfStars = 2;
            }
            else if (result >= 3.0f)
            {
                numberOfStars = 3;
            }
            result = 0.0f;
            levelCompleteMenuObj.SetActive(true);
            levelCompleteObj.SetActive(true);
            if (numberOfStars < 1)
            {
                levelName.text = "TRY AGAIN!";
            }
            else if (numberOfStars >= 1)
            {
                levelName.text = CalculatingDistance.previousScene + " completed";
                if (numberOfStars == 1)
                {
                    stars.text = "PATHETIC";
                }
                else if (numberOfStars == 2)
                {
                    stars.text = "BAD";
                }
                else if (numberOfStars >= 3)
                {
                    stars.text = "NOT BAD";
                }
                if (numberOfStars >= 1)
                {
                    levelName.text = CalculatingDistance.previousScene + " completed";
                }
            }
        }
        else
        {
            levelName.text = "";
            stars.text = "";
            result = 0.0f;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(CalculatingDistance.previousScene);
    }

    public void NextLevel()
    {
        int number;
        string nextScene;
        string lastChar = CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 1);
        if (CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 1) == 9.ToString()
            && CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 2) != " ")
        {
            int.TryParse(CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 2), out number);
            number += 1;
            nextScene = CalculatingDistance.previousScene.Replace(CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 2), number.ToString());
            nextScene = CalculatingDistance.previousScene.Replace(9.ToString(), 0.ToString());
        }
        else if (CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 1) == 9.ToString()
            && CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 2) == " ")
        {
            nextScene = CalculatingDistance.previousScene.Replace(9.ToString(), 1.ToString()) + 0.ToString();
        }
        else
        {
            int.TryParse(CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 1), out number);
            number += 1;
            nextScene = CalculatingDistance.previousScene.Replace(CalculatingDistance.previousScene.Substring(CalculatingDistance.previousScene.Length - 1), number.ToString());
        }
        SceneManager.LoadScene(nextScene);
        
    }

    public void Menu()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("SavedScene", CalculatingDistance.previousScene);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        levelCompleteMenuObj.SetActive(false);
        levelCompleteObj.SetActive(false);
        quitObj.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        levelCompleteMenuObj.SetActive(true);
        levelCompleteObj.SetActive(true);
        quitObj.SetActive(false);
    }
}
