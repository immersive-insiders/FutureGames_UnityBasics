using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
