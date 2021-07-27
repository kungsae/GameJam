using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void SelectScene(string sceneName)
    {
        SceneManager.LoadScene("02.Select");
        GameManager.Instance.sceneName = sceneName;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(GameManager.Instance.sceneName);
    }
}
