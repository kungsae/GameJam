using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
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
    bool isDead = false;
    Vector3 legPos;
    JointAngleLimits2D limit;
    EnemySpawner spawner;
    private int num;
    Player player;
    void Start()
    { 
        
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<EnemySpawner>();
        num = spawner.enemyNum;
        FindParts();
        body = GameObject.Find("Body"+ num).GetComponent<Rigidbody2D>();
        rig = GetComponent<Rigidbody2D>();
        legPos = new Vector3(0, leg[3].GetComponent<SpriteRenderer>().bounds.size.y);

        StartCoroutine(stand());
        limit.min = 0;
        for (int i = 0; i < leg.Length; i++)
        {
            legJoint[i] = leg[i].GetComponent<HingeJoint2D>();
        }
        StartCoroutine(chageWalk());
        legJoint[2].useLimits = false;
        legJoint[3].useLimits = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            leg[0].AddTorque(power);
            leg[1].AddTorque(-power);
            arm[0].AddTorque(armPower);
            arm[1].AddTorque(-armPower);
            if (transform.position.x > player.transform.position.x)
            {
                jointMax(-120, -30);

            }
            else
            {
                jointMax(0, 60);
            }
        }
    }
    IEnumerator stand()
    {
        while (true)
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
        Debug.Log(spawner.enemyNum);
        Debug.Log(num);
        leg[0] = GameObject.Find("LegR"+ num).gameObject.GetComponent<Rigidbody2D>();
        leg[1] = GameObject.Find("LegL" +num).gameObject.GetComponent<Rigidbody2D>();
        leg[2] = GameObject.Find("CalfR"+ num).gameObject.GetComponent<Rigidbody2D>();
        leg[3] = GameObject.Find("CalfL"+ num).gameObject.GetComponent<Rigidbody2D>();
        arm[0] = GameObject.Find("ArmL" +num).gameObject.GetComponent<Rigidbody2D>();
        arm[1] = GameObject.Find("ArmR" + num).gameObject.GetComponent<Rigidbody2D>();
    }
    IEnumerator chageWalk()
    {
        while (true)
        {
            if (isDead)
            {
                break;
            }
            yield return new WaitForSeconds(0.5f);
            power = -power;
        }
      
    }
    public void jointMax(float min, float max)
    {
        limit.max = max;
        limit.min = min;
        legJoint[2].useLimits = true;
        legJoint[3].useLimits = true;
        legJoint[2].limits = limit;
        legJoint[3].limits = limit;
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
