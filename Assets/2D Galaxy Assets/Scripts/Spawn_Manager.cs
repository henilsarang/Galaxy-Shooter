using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour {

    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;
    private GameManager gamemanager;

	// Use this for initialization
	void Start () {
        StartCoroutine(EnamySpawn());
        StartCoroutine(PowerUpSpawnRoutine());
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartSpawnRoutines()
    {
        StartCoroutine(EnamySpawn());
        StartCoroutine(PowerUpSpawnRoutine());
    }
    IEnumerator EnamySpawn()
    {
        while (gamemanager.GameOver == false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);

            yield return new WaitForSeconds(3.0f);
        }

    }

   IEnumerator PowerUpSpawnRoutine()
    {
        while (gamemanager.GameOver == false) { 

            int randomPowerUp = Random.Range(0,3);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);  
            yield return new WaitForSeconds(3.0f); 

        }
    }
}
