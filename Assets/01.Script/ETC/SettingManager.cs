using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject[] stageBtns = new GameObject[3];

    bool isSetting = false;

    void Awake()
    {
        settingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        isSetting = !isSetting;
        settingPanel.SetActive(isSetting);

        if(stageBtns[0] != null)
        {
            for(int i = 0; i < stageBtns.Length; i++)
            {
                stageBtns[i].GetComponent<Button>().interactable = !isSetting;
            }
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Setting();
        }
    }
}
