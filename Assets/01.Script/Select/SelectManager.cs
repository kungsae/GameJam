using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [Header("캐릭터 부위 관련 (0 : Left, 1 : Right)")]
    public GameObject body;
    public GameObject head;
    public GameObject[] arms = new GameObject[2];
    public GameObject[] thighs = new GameObject[2];
    public GameObject[] calfs = new GameObject[2];

    [Header("캐릭터 부위 선택 관련")]
    public SpriteRenderer[] charParts = new SpriteRenderer[8];

    [Header("캐릭터 부위 프리팹")]
    public List<Image> partImages = new List<Image>();
    public List<Image> partPrefabs = new List<Image>();

    int[] partsValue = new int[8];

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            partImages[i].sprite = partPrefabs[0].sprite;
            charParts[i].sprite = partPrefabs[0].sprite;
            GameManager.Instance.character[i] = (0);
            Custom(i);
        }
    }

    public void Custom(int n)
    {
        float bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;//o
        float headHeight = head.GetComponent<SpriteRenderer>().bounds.size.y;
        float armLHeight = arms[0].GetComponent<SpriteRenderer>().bounds.size.y;
        float armRHeight = arms[1].GetComponent<SpriteRenderer>().bounds.size.y;
        float thighLHeight = thighs[0].GetComponent<SpriteRenderer>().bounds.size.y;
        float thighRHeight = thighs[1].GetComponent<SpriteRenderer>().bounds.size.y;
        float calfLHeight = calfs[0].GetComponent<SpriteRenderer>().bounds.size.y;
        float calfRHeight = calfs[1].GetComponent<SpriteRenderer>().bounds.size.y;

        head.transform.position = body.transform.position + new Vector3(0, bodyHeight * 0.5f, 0) + new Vector3(0, headHeight * 0.5f, 0);//o
        arms[0].transform.position = body.transform.position + new Vector3(-(bodyHeight * 0.5f), 0, 0) + new Vector3(-(armLHeight * 0.5f), 0, 0);
        arms[1].transform.position = body.transform.position + new Vector3(bodyHeight * 0.5f, 0, 0) + new Vector3(armRHeight * 0.5f, 0, 0);
        thighs[0].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(-(thighLHeight * 0.5f), -(thighLHeight * 0.5f), 0);
        thighs[1].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(thighRHeight * 0.5f, -(thighRHeight * 0.5f), 0);
        calfs[0].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(-(calfLHeight * 0.5f), -(calfLHeight * 1.5f), 0);
        calfs[1].transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(calfRHeight * 0.5f, -(calfRHeight * 1.5f), 0);
    }

    public void RMoveParts(int n)
    {
        partsValue[n]++;

        if (partsValue[n] > partPrefabs.Count - 1)
        {
            partsValue[n] = 0;
        }

        GameManager.Instance.character[n] = partsValue[n];
        partImages[n].sprite = partPrefabs[partsValue[n]].sprite;
        charParts[n].sprite = partPrefabs[partsValue[n]].sprite;
        Custom(partsValue[n]);
    }

    public void LMoveParts(int n)
    {
        partsValue[n]--;

        if (partsValue[n] < 0)
        {
            partsValue[n] = partPrefabs.Count - 1;
        }
        
        GameManager.Instance.character[n] = partsValue[n];
        partImages[n].sprite = partPrefabs[partsValue[n]].sprite;
        charParts[n].sprite = partPrefabs[partsValue[n]].sprite;
        Custom(partsValue[n]);
    }
}
