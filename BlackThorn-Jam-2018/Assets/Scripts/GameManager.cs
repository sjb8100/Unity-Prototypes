using System;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    
    [Header("Data Assets")]
    [SerializeField]
    private GameManagerData gmData;
    [SerializeField]
    private List<IManager>[] managerCollection;
    private string[] managerTargets;


    private void Start(){
        managerTargets = gmData.managerList;
        managerCollection = new List<IManager>[managerTargets.Length];
        for(int i = 0; i < managerTargets.Length; i++){
            managerCollection[i] = GetManagerComponents(managerTargets[i]);
        }
    }

    private void Update(){
        for(int i = 0; i < managerCollection.Length; i++){
            for(int j = 0; j < managerCollection[j].Count; j++){
                if(managerCollection[i][j].CanTick()){
                    managerCollection[i][j].Tick();
                }
            }
        }
    }

    private List<IManager> GetManagerComponents(string compName){
        return new List<IManager>(Resources.FindObjectsOfTypeAll(Type.GetType(compName)) as IManager[]);
    }

}