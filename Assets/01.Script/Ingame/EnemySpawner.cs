using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;


    public GameObject[] partsBody;
    public GameObject[] partsLegL;
    public GameObject[] partsLegR;
    public GameObject[] partsCalfL;
    public GameObject[] partsCalfR;
    public GameObject[] partsArmR;
    public GameObject[] partsArmL;
    public GameObject[] partsHead;

    public GameObject[] parts;
    public List<GameObject> partsList = new List<GameObject>();
    public int enemyNum;
    public int EnemyCount;
    public float stageDelay;

    BattleRoyalScore score;
    public bool isBattleRoyal;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<BattleRoyalScore>();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy(int enemyCount)
    {
        while (true)
        {
            yield return new WaitForSeconds(stageDelay);
            if (!GameManager.Instance.onEnemy|| isBattleRoyal)
            {
                if (isBattleRoyal)
                {
                    if (score.score % 10 == 0)
                    {
                        enemyCount++;
                    }
                    score.scoreUpdate();
                }
                for (int j = 0; j < enemyCount; j++)
                {
                    
                    RandomParts();
                    transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
                    yield return new WaitForSeconds(0.01f);
                    enemyNum++;
                    GameObject _gameObject = new GameObject("Enemy"+enemyNum);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        Rigidbody2D rig = parts[i].GetComponent<Rigidbody2D>();
                        rig.gravityScale = 0;
                        rig.velocity = Vector2.zero;
                        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                    for (int i = 0; i < parts.Length; i++)
                    {
                        yield return new WaitForSeconds(0.25f);
                        GameObject part = Instantiate(parts[i], transform.position, transform.rotation, _gameObject.transform);
                        part.layer = 8;
                        EnemyFusion fusion = part.AddComponent<EnemyFusion>();
                        switch (i)
                        {
                            case 0:
                                fusion.part = "Body";
                                part.name = "Body" + enemyNum;
                                break;
                            case 1:
                                fusion.part = "LegL";
                                part.name = "LegL" + enemyNum;
                                break;
                            case 2:
                                fusion.part = "LegR";
                                part.name = "LegR" + enemyNum;
                                break;
                            case 3:
                                fusion.part = "CalfL";
                                part.name = "CalfL" + enemyNum;
                                break;
                            case 4:
                                fusion.part = "CalfR";
                                part.name = "CalfR" + enemyNum;
                                break;
                            case 5:
                                fusion.part = "ArmR";
                                part.name = "ArmR" + enemyNum;
                                break;
                            case 6:
                                fusion.part = "ArmL";
                                part.name = "ArmL" + enemyNum;
                                break;
                            case 7:
                                Destroy(part.GetComponent<Player>());
                                part.AddComponent<EnemyMove>();
                                fusion.part = "Head";
                                part.name = "Head" + enemyNum;
                                break;
                            default:
                                break;
                        }
                        partsList.Add(part);
                    }
                    for (int i = 0; i < partsList.Count; i++)
                    {   
                        partsList[i].GetComponent<Rigidbody2D>().gravityScale = 1;
                        partsList[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    }
                    int a = partsList.Count;
					for (int i = 0; i < a; i++)
					{
                        partsList.RemoveAt(0);
					}


                    GameManager.Instance.onEnemy = true;
                }
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(SpawnEnemy(EnemyCount));
    }
    private void RandomParts()
    {
        parts[0] = partsBody[Random.Range(0, partsBody.Length)];
        parts[1] = partsLegL[Random.Range(0, partsLegL.Length)];
        parts[2] = partsLegR[Random.Range(0, partsLegR.Length)];
        parts[3] = partsCalfL[Random.Range(0, partsCalfL.Length)];
        parts[4] = partsCalfR[Random.Range(0, partsCalfR.Length)];
        parts[5] = partsArmR[Random.Range(0, partsArmR.Length)];
        parts[6] = partsArmL[Random.Range(0, partsArmL.Length)];
        parts[7] = partsHead[Random.Range(0, partsHead.Length)];
    }
}
