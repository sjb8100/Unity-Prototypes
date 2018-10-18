using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : BaseManager {

	[SerializeField]
	private EnemyData enemyData;

	private Transform playerRef;
	public GameObject enemyPrefab;
	public Transform[] spawnPoints;
	private float timeBtwSpawns;

	private List<Enemy> allEnemies;


	private void Awake() {
		allEnemies = new List<Enemy>();
		InitManager(null);
	}

	public override void InitManager(object obj){
		playerRef = FindObjectOfType<PlayerManager>().GetComponent<Transform>();
	}

	public override void Tick(){
		if(timeBtwSpawns <= 0.0f && allEnemies.Count < enemyData.maxEnemies){
			allEnemies.Add(SpawnEnemy());
		} else{
			timeBtwSpawns -= Time.deltaTime;
		}
		for(int i = 0; i < allEnemies.Count; i++){
			if(allEnemies[i].CanTick()){
				allEnemies[i].Tick();
			} else{
				allEnemies.RemoveAt(i);
			}
		}
	}

	private Enemy SpawnEnemy(){
		int randPos = Random.Range(0, spawnPoints.Length);
		Enemy newEnemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity).GetComponent<Enemy>();
		newEnemy.Init(playerRef);
		timeBtwSpawns = enemyData.spawnInterval;
		return newEnemy;
	}
	

}
