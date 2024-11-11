using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;
    [SerializeField] private Transform leftPos, rightPos;
    private GameObject spawnedMonster;

    int randomIndex;
    int randomSide;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
        
    }

    IEnumerator SpawnMonster() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            
            if(randomSide == 0) {
                Debug.Log(leftPos.position);
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(2, 7);
            }
            else {
                Debug.Log(rightPos.position);
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(2, 7);
                spawnedMonster.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }
}
