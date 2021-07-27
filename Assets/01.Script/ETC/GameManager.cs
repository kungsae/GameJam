using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //------------------------------------------------------------------------------------
    private static GameManager instance = null; //싱글톤
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new GameManager(); //C#
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }
            return instance;
        }
    }

    public int[] character = new int[8];
    public string sceneName = null;

    public bool onEnemy = false;

    public List<GameObject> bodyPrefabs = new List<GameObject>();
    public List<GameObject> headPrefabs = new List<GameObject>();
    public List<GameObject> armLPrefabs = new List<GameObject>();
    public List<GameObject> armRPrefabs = new List<GameObject>();
    public List<GameObject> legLPrefabs = new List<GameObject>();
    public List<GameObject> legRPrefabs = new List<GameObject>();
    public List<GameObject> calfLPrefabs = new List<GameObject>();
    public List<GameObject> calfRPrefabs = new List<GameObject>();

    void Awake()
    {
        if (instance != null)
        {
            //Debug.LogError("Cannot have two instances of Singletone.");
            return;
        }
        instance = this;

        //Screen.SetResolution(720, 1280, true);  //해상도 강제 세팅
        //Input.multiTouchEnabled = false;    //멀티터치 끄기
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;

        DontDestroyOnLoad(this);    //씬전환할때 사라지지 않음
    }
}