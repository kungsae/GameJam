using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetContent : MonoBehaviour
{
    public SelectManager selectM;

    void Start()
    {
        for(int i = 0; i < selectM.partPrefabs.Count; i++)
        {
            Instantiate(selectM.partPrefabs[i], transform);
            Debug.Log("IN");
        }
    }
}
