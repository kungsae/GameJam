using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFusion : MonoBehaviour
{
    public GameObject body;

    public void Custom( bool isHead)
    {
        if (isHead)
        {   
            float bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
            float height = GetComponent<SpriteRenderer>().bounds.size.y;
            transform.position = body.transform.position + new Vector3(0, bodyHeight * 0.5f, 0) + new Vector3(0, height * 0.5f, 0);
        }
        else
        {
            float bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
            float height = GetComponent<SpriteRenderer>().bounds.size.y;
            transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(0, -(height * 0.5f), 0);
        }
    }
}
    