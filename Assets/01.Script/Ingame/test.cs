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
        partTest[0] = GameManager.Instance.bodyPrefabs[GameManager.Instance.character[0]];
        partTest[1] = GameManager.Instance.legLPrefabs[GameManager.Instance.character[4]];   
        partTest[2] = GameManager.Instance.calfLPrefabs[GameManager.Instance.character[6]];   
        partTest[3] = GameManager.Instance.legRPrefabs[GameManager.Instance.character[5]];
        partTest[4] = GameManager.Instance.calfRPrefabs[GameManager.Instance.character[7]];   
        partTest[5] = GameManager.Instance.armRPrefabs[GameManager.Instance.character[3]];   
        partTest[6] = GameManager.Instance.armLPrefabs[GameManager.Instance.character[2]];
        partTest[7] = GameManager.Instance.headPrefabs[GameManager.Instance.character[1]];

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
            parts[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
