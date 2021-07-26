using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : MonoBehaviour
{
    Rigidbody2D rig;
    public Rigidbody2D[] leg;
    public float time = 0.1f;
    public float power;
    bool isGround = true;
    bool isDead = false;
    Vector3 legPos;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        legPos = new Vector3(0,leg[3].GetComponent<SpriteRenderer>().bounds.size.y);
        StartCoroutine(stand());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            isGround = Physics2D.Raycast(leg[3].transform.position - legPos, Vector2.down, 0.1f, 7);
            if (Input.GetKey(KeyCode.A))
            {
                leg[0].AddTorque(power);
                leg[1].AddTorque(-power);
            }
            if (Input.GetKey(KeyCode.D))
            {
                leg[0].AddTorque(-power);
                leg[1].AddTorque(power);
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
                rig.AddForce(Vector2.up * power * 375);
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
