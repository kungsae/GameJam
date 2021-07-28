using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject[] stageBtns = new GameObject[3];

    private AudioSource audioSource;

    bool isSetting = false;

    void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
        settingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainScene()
    {
        GameManager.Instance.dead = false;
        GameManager.Instance.onEnemy = false;
        isSetting = false;
        SceneManager.LoadScene("01.Main");
    }

    public void Setting()
    {
        isSetting = !isSetting;
        settingPanel.SetActive(isSetting);

        if (stageBtns[0] != null)
        {
            for (int i = 0; i < stageBtns.Length; i++)
            {
                stageBtns[i].GetComponent<Button>().interactable = !isSetting;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Setting();
        }

        if (isSetting)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (audioSource != null)
        {
            if (GameManager.Instance.dead)
            {
                Destroy(audioSource.gameObject);
            }
        }
    }
}
