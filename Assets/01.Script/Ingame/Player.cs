using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    Rigidbody2D body;
    private Rigidbody2D[] leg = new Rigidbody2D[4];
    private HingeJoint2D[] legJoint = new HingeJoint2D[4];
    private Rigidbody2D[] arm = new Rigidbody2D[2];
    public float time = 0.1f;
    public float power;
    public float jupPower;
    public float armPower;
    bool isGround = true;
    bool isGround2 = true;
    bool isDead = false;
    Vector3 legPos;
    JointAngleLimits2D limit;
	private void Awake()
	{
      
	}
	void Start()
    {
        FindParts();
        body = GameObject.Find("Body").GetComponent<Rigidbody2D>();
        rig = GetComponent<Rigidbody2D>();
        legPos = new Vector3(0,leg[3].GetComponent<SpriteRenderer>().bounds.size.y);
        
        StartCoroutine(stand());
        limit.min = 0;
        for (int i = 0; i < leg.Length; i++)
		{
            legJoint[i] = leg[i].GetComponent<HingeJoint2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            isGround = Physics2D.Raycast(leg[3].transform.position - legPos, Vector2.down, 0.1f, 7);
            isGround2 = Physics2D.Raycast(leg[2].transform.position - legPos, Vector2.down, 0.1f, 7);


            if (Input.GetKey(KeyCode.D))
            {
                jointMax(0,60);
                leg[0].AddTorque(power);
                leg[1].AddTorque(-power);
            }
            if (Input.GetKey(KeyCode.F))
            {
                jointMax(0, 60);
                leg[0].AddTorque(-power);
                leg[1].AddTorque(power);
            }
            if (Input.GetKey(KeyCode.A))
            {
                jointMax(-120, -30);


                leg[0].AddTorque(power);
                leg[1].AddTorque(-power);
            }
            if (Input.GetKey(KeyCode.S))
            {
                jointMax(-120, -30);

                leg[0].AddTorque(-power);
                leg[1].AddTorque(power);
            }
           

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                arm[0].AddTorque(armPower);
                arm[1].AddTorque(armPower);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                arm[0].AddTorque(-armPower);
                arm[1].AddTorque(-armPower);
            }


            if (Input.GetKey(KeyCode.Space))
            {
            }
            if (Input.GetKeyUp(KeyCode.Space) && (isGround|| isGround2))
            {
                rig.AddForce(Vector2.up * jupPower);
            }

            if (transform.position.y < -10)
            {
                Dead();
            }
        }
    }
    IEnumerator stand()
    {   while (true)
        {
            yield return new WaitForSeconds(time);
            if (!isDead)
            {
                rig.MoveRotation(0);
                body.MoveRotation(0);
                leg[0].MoveRotation(0);
                leg[1].MoveRotation(0);
                leg[2].MoveRotation(0);
                leg[3].MoveRotation(0);
            }
        }
    }
    private void FindParts()
    {
        leg[0] = GameObject.Find("LegR").gameObject.GetComponent<Rigidbody2D>();
        leg[1] = GameObject.Find("LegL").gameObject.GetComponent<Rigidbody2D>();
        leg[2] = GameObject.Find("CalfR").gameObject.GetComponent<Rigidbody2D>();
        leg[3] = GameObject.Find("CalfL").gameObject.GetComponent<Rigidbody2D>();
        arm[0] = GameObject.Find("ArmL").gameObject.GetComponent<Rigidbody2D>();
        arm[1] = GameObject.Find("ArmR").gameObject.GetComponent<Rigidbody2D>();
    }
    public void jointMax(float min,float max)
    {
        
        limit.max = max;
        limit.min = min;
        legJoint[2].limits = limit;
		legJoint[3].limits = limit;
	}
    private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            Dead();
        }
	}
    public void Dead()
    {
        isDead = true;
        Debug.Log("Dead");
    }

}
