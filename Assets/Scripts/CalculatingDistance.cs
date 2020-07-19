using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CalculatingDistance : MonoBehaviour
{
    public static float maxDistance;
    public float startPosition;
    public static float startTime;
    public GameObject Player;
    public static string previousScene;
    void Start()
    {        
        startPosition = Player.transform.position.x;
        StartCoroutine(calculatePoints());
    }

    void Update() 
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "StartUp"
            && SceneManager.GetActiveScene().name != "GameOver" && SceneManager.GetActiveScene().name != "LevelComplete")
        {
            startTime += Time.deltaTime;
            previousScene = SceneManager.GetActiveScene().name;
        }
    }

    IEnumerator calculatePoints()
    {
        float position = Player.transform.position.z;
        float tempMaxDistance = 0.0f;
        maxDistance = 0.0f;
        startTime = 0.0f;
        while (true)
        {
            position = Player.transform.position.z;
            yield return new WaitForEndOfFrame();
            float tempPosition = Player.transform.position.z;
            if (tempPosition > position)
            {
                tempMaxDistance = tempPosition - startPosition;
            }
            else if (tempPosition < position)
            {
                tempMaxDistance = position - startPosition;
            }
            if (maxDistance < tempMaxDistance)
            {
                maxDistance = tempMaxDistance;
            }
        }
    }

}
