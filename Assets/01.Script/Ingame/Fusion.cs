using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{
    public GameObject body;
    public HingeJoint2D joint;
    public string part;
    float bodyHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        if (part == "Body")
        {
            gameObject.name = "Body";
        }
        else
        {
            body = GameObject.Find("Body");
            Debug.Log(body);
            joint = GetComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = true;

            bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
            Debug.Log(bodyHeight);
            switch (part)
            {
                case "Head":
                    gameObject.name = "Head";
                    StartCoroutine(Headfollow());
                    break;
                case "LegR":
                    gameObject.name = "LegR";
                    StartCoroutine(LegFollow());
                    break;
                case "LegL":
                    gameObject.name = "LegL";
                    StartCoroutine(LegFollow());
                    break;
                case "CalfR":
                    gameObject.name = "CalfR";
                    StartCoroutine(CalfFollow("LegR"));
                    break;
                case "CalfL":
                    gameObject.name = "CalfL";
                    StartCoroutine(CalfFollow("LegL"));
                    break;
                case "Arm":
                    StartCoroutine(ArmFollow());
                    gameObject.name = "Arm";
                    break;
                default:
                    Debug.LogError("어느 파츠에도 포함되지 않습니다");
                    break;
            }
            
            StartCoroutine(JointFollow());
        }
    }
	IEnumerator LegFollow()
    {
        yield return new WaitForSeconds(0.01f);
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0, (height));
        transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(0, -(height * 0.5f), 0);
    }
    IEnumerator Headfollow()
    {
        yield return new WaitForSeconds(0.02f);
        
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0,-(height * 0.5f));
        transform.position = body.transform.position + new Vector3(0, bodyHeight * 0.5f, 0) + new Vector3(0, height*0.5f,0);
    }
    IEnumerator CalfFollow(string legName)
    {
        yield return new WaitForSeconds(0.03f);
        FindLeg(legName);
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0, height);
        transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(0, -(height * 0.5f), 0);

    }
    IEnumerator ArmFollow()
    {
        yield return new WaitForSeconds(0.02f);

        float height = GetComponent<SpriteRenderer>().bounds.size.x;
        joint.anchor = new Vector2(-(height*0.5f),0);
        transform.position = body.transform.position + new Vector3(height*0.5f, (bodyHeight * 0.4f), 0);
    }
    IEnumerator JointFollow()
    {
        yield return new WaitForSeconds(0.05f);
        joint.connectedBody = body.GetComponent<Rigidbody2D>();
        joint.autoConfigureConnectedAnchor = false;
        if (part == "CalfL" || part == "CalfR")
        {
            joint.connectedAnchor = new Vector2(0, -0.5f);
        }
    }
    private void FindLeg(string legName)
    {
        body = GameObject.Find(legName);
    }

}
