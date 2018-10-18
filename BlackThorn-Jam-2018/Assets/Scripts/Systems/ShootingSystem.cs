using UnityEngine;
using System.Collections.Generic;

public class ShootingSystem : MonoBehaviour {

	[SerializeField]
    private GameObject shot;
	private List<Transform> shots;
	private int maxShots = 4;

	private void Start() {
		shots = new List<Transform>();	
	}

    public void Shoot(){
		for(int i = 0; i < shots.Count; i++){
			if(shots[i] == null){
				shots.RemoveAt(i);
			}
		}
		if(shots.Count < maxShots){
			shots.Add(Instantiate(shot, this.transform.position, Quaternion.identity).transform);
		}
    }
}