using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    int a = 0;

    [Header("캐릭터 부위 관련 (0 : Left, 1 : Right)")]
    public GameObject body;
    public GameObject head;
    public GameObject[] arms = new GameObject[2];
    public GameObject[] thighs = new GameObject[2];
    public GameObject[] calfs = new GameObject[2];

    [Header("캐릭터 부위 선택 관련")]
    public RectTransform[] selectParts = new RectTransform[8];
    public SpriteRenderer[] charParts = new SpriteRenderer[8];
    public List<Button> selectBtns = new List<Button>();

    [Header("캐릭터 부위 프리팹")]
    public List<Image> partPrefabs = new List<Image>();

    void Start()
    {
        // 몸통버튼 제외 비활성화
        for (int i = 1; i < selectBtns.Count; i++)
        {
            selectBtns[i].interactable = false;
        }
    }

    public float IntRound(float Value, int Digit)
    {
        float Temp = Mathf.Pow(10.0f, Digit);
        return Mathf.Round(Value * Temp) / Temp;
    }


    public void Custom(int n)
    {
        // 몸통버튼 제외 모두 활성화
        for (int i = 1; i < selectBtns.Count; i++)
        {
            selectBtns[i].interactable = true;
        }

        float bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;//o

        if (n == 1)
        {
            float headHeight = head.GetComponent<SpriteRenderer>().bounds.size.y;
            head.transform.position = body.transform.position + new Vector3(0, bodyHeight * 0.5f, 0) + new Vector3(0, headHeight * 0.5f, 0);//o
        }
        else if (n == 2)
        {
            float armLHeight = arms[0].GetComponent<SpriteRenderer>().bounds.size.y;
            arms[0].transform.position = body.transform.position + new Vector3(-(bodyHeight * 0.5f), 0, 0) + new Vector3(-(armLHeight * 0.5f), 0, 0);
        }
        else if (n == 3)
        {
            float armRHeight = arms[1].GetComponent<SpriteRenderer>().bounds.size.y;
            arms[1].transform.position = body.transform.position + new Vector3(bodyHeight * 0.5f, 0, 0) + new Vector3(armRHeight * 0.5f, 0, 0);
        }
        else if (n == 4)
        {
            float thighLHeight = thighs[0].GetComponent<SpriteRenderer>().bounds.size.y;
            thighs[0].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(-(thighLHeight * 0.5f), -(thighLHeight * 0.5f), 0);
        }
        else if (n == 5)
        {
            float thighRHeight = thighs[1].GetComponent<SpriteRenderer>().bounds.size.y;
            thighs[1].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(thighRHeight * 0.5f, -(thighRHeight * 0.5f), 0);
        }
        else if (n == 6)
        {
            float calfLHeight = calfs[0].GetComponent<SpriteRenderer>().bounds.size.y;
            calfs[0].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(-(calfLHeight * 0.5f), -(calfLHeight * 1.5f), 0);
        }
        else if (n == 7)
        {
            float calfRHeight = calfs[1].GetComponent<SpriteRenderer>().bounds.size.y;
            calfs[1].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(calfRHeight * 0.5f, -(calfRHeight * 1.5f), 0);
        }
    }

    public void SelectLPart(int n)
    {
        // if (((int)selectParts[n].position.x + 301) % 10 == 0)
        // {
        //     a = ((int)selectParts[n].position.x + 301) / 240;
        //     Debug.Log(a);
        // }
        // else
        // {
        //     a = ((int)selectParts[n].position.x + 302) / 240;
        //     Debug.Log(a);
        // }
        Debug.Log(((int)selectParts[n].position.x + 301));  
        a = (int)IntRound((int)selectParts[n].position.x + 301, -1) / 240;
        Debug.Log(a);

        charParts[n].sprite = partPrefabs[-a + 3].sprite;
        GameManager.Instance.character[n] = (-a + 3);
    }

    public void SelectRPart(int n)
    {
        // if (((int)selectParts[n].position.x + 364) % 10 == 0)
        // {
        //     Debug.Log(((int)selectParts[n].position.x + 364));
        //     a = (((int)selectParts[n].position.x + 364) / 2) / 240;
        //     Debug.Log(a);
        // }
        // else
        // {
        //     Debug.Log(((int)selectParts[n].position.x + 365));
        //     a = (((int)selectParts[n].position.x + 365) / 2) / 240;
        //     Debug.Log(a);
        // }

        Debug.Log(IntRound(((int)selectParts[n].position.x), -1));
        a = (int)IntRound(((int)selectParts[n].position.x - 360), -1) / 240;
        Debug.Log(a);

        charParts[n].sprite = partPrefabs[-a + 3].sprite;
        GameManager.Instance.character[n] = (-a + 3);
    }
}
