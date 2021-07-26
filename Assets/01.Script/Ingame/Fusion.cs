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
        joint = GetComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = true;
        joint.connectedBody = body.GetComponent<Rigidbody2D>();
        bodyHeight = body.GetComponent<SpriteRenderer>().bounds.size.y;
		switch (part)
		{
            case "Head":
                StartCoroutine(Headfollow());
                break;
            case "Leg":
                LegFollow();
                break;
            case "Calf":
                StartCoroutine(CalfFollow());
                break;
            case "Arm":
                StartCoroutine(ArmFollow());
                break;
            default:
                Debug.LogError("어느 파츠에도 포함되지 않습니다");
				break;
		}
        StartCoroutine(JointFollow());
        
    }
    public void LegFollow()
    {
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0, (height));
        transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(0, -(height * 0.5f), 0);
    }
    IEnumerator Headfollow()
    {
        yield return new WaitForSeconds(0.01f);
        
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0,-(height * 0.5f));
        transform.position = body.transform.position + new Vector3(0, bodyHeight * 0.5f, 0) + new Vector3(0, height*0.5f,0);
    }
    IEnumerator CalfFollow()
    {
        yield return new WaitForSeconds(0.01f);

        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        joint.anchor = new Vector2(0, height);
        transform.position = body.transform.position + new Vector3(0, -(bodyHeight * 0.5f), 0) + new Vector3(0, -(height * 0.5f), 0);
    }
    IEnumerator ArmFollow()
    {
        yield return new WaitForSeconds(0.01f);

        float height = GetComponent<SpriteRenderer>().bounds.size.x;
        joint.anchor = new Vector2(-(height*0.5f),0);
        transform.position = body.transform.position + new Vector3(height*0.5f, (bodyHeight * 0.4f), 0);
    }
    IEnumerator JointFollow()
    {
        yield return new WaitForSeconds(0.05f);
        joint.autoConfigureConnectedAnchor = false;
    }

}
