using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{
    public GameObject body;
    public HingeJoint2D joint;
    public bool isHead;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = true;
        joint.connectedBody = body.GetComponent<Rigidbody2D>();
        if (isHead)
        {
            StartCoroutine(Headfollow());
        }
        else
        {
            float bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
            float height = GetComponent<SpriteRenderer>().bounds.size.y;
            joint.anchor = new Vector2(0, (height));
            transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(0, -(height * 0.5f), 0);
        }
        StartCoroutine(JointFollow());
        
    }
    IEnumerator Headfollow()
    {
        yield return new WaitForSeconds(0.01f);
        
        float bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0,-(height * 0.5f));
        transform.position = body.transform.position + new Vector3(0, bodyHeight * 0.5f, 0) + new Vector3(0, height*0.5f,0);
    }
    IEnumerator JointFollow()
    {
        yield return new WaitForSeconds(0.03f);
        joint.autoConfigureConnectedAnchor = false;
    }

}
