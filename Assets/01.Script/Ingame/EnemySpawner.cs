using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;
    public GameObject[] parts;
    public List<GameObject> partsList = new List<GameObject>();
    public int enemyNum;
    public int EnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(EnemyCount));
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy(int enemyCount)
    {
        for (int j = 0; j < enemyCount; j++)
        {
            yield return new WaitForSeconds(0.02f);
            enemyNum++;
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY),0);
            for (int i = 0; i < parts.Length; i++)
            {
                Rigidbody2D rig = parts[i].GetComponent<Rigidbody2D>();
                rig.gravityScale = 0;
                rig.velocity = Vector2.zero;
            }
            for (int i = 0; i < parts.Length; i++)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(0.01f);
                GameObject part = Instantiate(parts[i],transform.position,transform.rotation);
                partsList.Add(part);          
            }
            for (int i = 0; i < partsList.Count; i++)
            {
                partsList[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
}
