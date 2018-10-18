using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private EnemyData enemyData;
	private Transform playerPos;
	public GameObject deathEffect;


	public void Tick(){
		DoMovement();
	}

	public bool CanTick(){
		return (this != null && this.isActiveAndEnabled);
	}

	private void DoMovement(){
		this.transform.position = Vector2.MoveTowards(this.transform.position, playerPos.position, enemyData.speed * Time.deltaTime);
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.GetComponent<PlayerManager>()){
			this.GetComponent<SpriteRenderer>().enabled = false;
			this.GetComponent<BoxCollider2D>().enabled = false;
			StartCoroutine(DeathEffect());
			//Player health logic??
		}
		if(other.GetComponent<Projectile>()){
			Destroy(other.gameObject);
			this.GetComponent<SpriteRenderer>().enabled = false;
			this.GetComponent<BoxCollider2D>().enabled = false;
			StartCoroutine(DeathEffect());
		}	
	}

	IEnumerator DeathEffect(){
		GameObject effect = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(2.0f);
		Destroy(effect);
		Destroy(this.gameObject);
	}

	public void Init(object obj){
		playerPos = obj as Transform;
	}
}
