using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUpController : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(waiting());
        SceneManager.LoadScene("MainMenu");        
    }


    IEnumerator waiting()
    {
        yield return new WaitForSeconds(0.001f);
    }
}
