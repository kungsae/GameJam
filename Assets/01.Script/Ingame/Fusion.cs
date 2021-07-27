using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{
    public GameObject body;
    public HingeJoint2D joint;
    public string part;

	private void Awake()
	{
        if (part == "Body")
        {
            gameObject.name = "Body";
        }

    }
	void Start()
    {
        if(part != "Body")
        {
            body = GameObject.Find("Body");
            Debug.Log(body);
            joint = GetComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedBody = body.GetComponent<Rigidbody2D>();
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
                case "ArmR":
                    gameObject.name = "ArmR";
                    StartCoroutine(ArmFollow()); 
                    break;
                case "ArmL":
                    gameObject.name = "ArmL";
                    StartCoroutine(ArmFollow());
                    break;
                default:
                    Debug.LogError("��� �������� ���Ե��� �ʽ��ϴ�");
                    break;
            }
        }
    }
	IEnumerator LegFollow()
    {
        yield return new WaitForSeconds(0.01f);
        //joint.anchor = new Vector2(0, 0.5f);
        joint.anchor = new Vector2(0,gameObject.GetComponent<SpriteRenderer>().bounds.size.y*0.5f);
        joint.connectedAnchor = new Vector2(0, -body.gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f);
    }
    IEnumerator Headfollow()
    {
        yield return new WaitForSeconds(0.02f);
        joint.anchor = new Vector2(0, -gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f);
        joint.connectedAnchor = new Vector3(0, body.GetComponent<SpriteRenderer>().bounds.size.y * 0.437f, 0);   
    }
    IEnumerator CalfFollow(string legName)
    {
        yield return new WaitForSeconds(0.03f);
        FindLeg(legName);
        joint.connectedBody = body.GetComponent<Rigidbody2D>();
        joint.anchor = new Vector2(0, gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f);
        joint.connectedAnchor = new Vector2(0, -body.gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f);
    }
    IEnumerator ArmFollow()
    {
        yield return new WaitForSeconds(0.02f);

        joint.anchor = new Vector2(0, -gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f);
        joint.connectedAnchor = new Vector2(0, body.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f);
	}
    private void FindLeg(string legName)
    {
        body = GameObject.Find(legName);
    }
}
