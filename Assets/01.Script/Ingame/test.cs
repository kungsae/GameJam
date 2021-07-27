using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed;
    public GameObject body;
    public GameObject[] partTest;
    public List<GameObject> parts = new List<GameObject>();

	private void Awake()
	{
        //Instantiate(body);

    }
	private void Start()
	{
        StartCoroutine(create());
	}
    IEnumerator create()
    {
        for (int i = 0; i < partTest.Length; i++)
        {
            Rigidbody2D rig = partTest[i].GetComponent<Rigidbody2D>();
            rig.gravityScale = 0;
            rig.velocity = Vector2.zero;
        }
        for (int i = 0; i < partTest.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject part = Instantiate(partTest[i]);
            parts.Add(part);
        }
        for (int i = 0; i < parts.Count; i++)
        {
            parts[i].GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
	void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
    }
}
