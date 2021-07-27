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
    public bool isBattle = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(EnemyCount));
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy(int enemyCount)
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            for (int j = 0; j < enemyCount; j++)
            {
                transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
                yield return new WaitForSeconds(0.01f);
                enemyNum++;
                for (int i = 0; i < parts.Length; i++)
                {
                    Rigidbody2D rig = parts[i].GetComponent<Rigidbody2D>();
                    rig.gravityScale = 0;
                    rig.velocity = Vector2.zero;
                    rig.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                for (int i = 0; i < parts.Length; i++)
                {
                    yield return new WaitForSeconds(0.5f);
                    GameObject part = Instantiate(parts[i], transform.position, transform.rotation);
                    partsList.Add(part);
                }
                for (int i = 0; i < partsList.Count; i++)
                {
                    partsList[i].GetComponent<Rigidbody2D>().gravityScale = 1;
                    partsList[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                }
            }
            if (!isBattle)
            {
                break;
            }
        }
    }
}
