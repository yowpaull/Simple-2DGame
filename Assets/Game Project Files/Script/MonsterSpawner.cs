using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, RightPos;

    private int randomIndex;
    private int randomSide;


    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            SpawnSingleMonster();

            while (spawnedMonster != null)
            {
                if (spawnedMonster.transform.position.x > RightPos.position.x + 2f ||
                    spawnedMonster.transform.position.x < leftPos.position.x - 2f)
                {
                    Destroy(spawnedMonster); 
                }


                yield return null; 
            }

            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    void SpawnSingleMonster()
    {
        randomIndex = Random.Range(0, monsterReference.Length);
        randomSide = Random.Range(0, 2);

        spawnedMonster = Instantiate(monsterReference[randomIndex]);

        if (randomSide == 0)
        {
            spawnedMonster.transform.position = leftPos.position;
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(2f, 4f);
            spawnedMonster.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            spawnedMonster.transform.position = RightPos.position;
            spawnedMonster.GetComponent<Monster>().speed = -Random.Range(2f, 4f);
            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}