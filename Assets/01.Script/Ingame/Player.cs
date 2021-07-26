using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    public Rigidbody2D[] leg;
    private HingeJoint2D[] legJoint = new HingeJoint2D[4];
    public Rigidbody2D[] arm;
    public float time = 0.1f;
    public float power;
    public float jupPower;
    public float armPower;
    bool isGround = true;
    bool isDead = false;
    Vector3 legPos;
    JointAngleLimits2D limit;
    void Start()
    {
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
    void Update()
    {
        if (!isDead)
        {
            isGround = Physics2D.Raycast(leg[3].transform.position - legPos, Vector2.down, 0.1f, 7);

            if (Input.GetKey(KeyCode.A))
            {
                limit.max = -60;
                legJoint[2].limits = limit;
                legJoint[3].limits = limit;
                leg[0].AddTorque(power);
                leg[1].AddTorque(-power);
            }
            if (Input.GetKey(KeyCode.S))
            {
                limit.max = -60;
                legJoint[2].limits = limit;
                legJoint[3].limits = limit;
                leg[0].AddTorque(-power);
                leg[1].AddTorque(power);
            }
            if (Input.GetKey(KeyCode.D))
            {
                limit.max = 60;
                legJoint[2].limits = limit;
                legJoint[3].limits = limit;


                leg[0].AddTorque(power);
                leg[1].AddTorque(-power);
            }
            if (Input.GetKey(KeyCode.F))
            {
                limit.max = 60;
                legJoint[2].limits = limit;
                legJoint[3].limits = limit;

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
                leg[0].AddTorque(power);
                leg[1].AddTorque(power);
                leg[2].AddTorque(-power);
                leg[3].AddTorque(-power);
            }
            if (Input.GetKeyUp(KeyCode.Space) && isGround)
            {
                rig.AddForce(Vector2.up * jupPower);
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
                leg[0].MoveRotation(0);
                leg[1].MoveRotation(0);
                leg[2].MoveRotation(0);
                leg[3].MoveRotation(0);
            }
        }
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isDead = true;
            Debug.Log("Dead");
        }
	}

}
