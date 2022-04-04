using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public float TimeDelay = 2f;
    public GameObject thing;

    public void DelayLoadScene()
    {
        thing.SetActive(true);
        StartCoroutine(LoadSceneCR());
    }

    private IEnumerator LoadSceneCR()
    {
        yield return new WaitForSeconds(TimeDelay);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        if (SceneName != null)
            SceneManager.LoadScene(SceneName);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
