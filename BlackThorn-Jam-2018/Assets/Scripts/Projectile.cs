using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float destroyThreshold = 0.2f;
	private Vector2 target;

	private void Start(){
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	private void FixedUpdate() {
		this.transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
		
		if(Vector2.Distance(this.transform.position, target) < destroyThreshold){
			Destroy(this.gameObject);
		}
	}

}
