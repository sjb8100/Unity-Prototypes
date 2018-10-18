using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : BaseManager {
    
    [Header("Events")]
    public GameEvent inputEvent;

    private Transform systemsObj;
    private Transform systemListenersObj;

    private MovementSystem movementSystem;


    private void Awake() {
        systemsObj = this.transform.Find("Systems");
        systemListenersObj = this.transform.Find("System Listeners");
        movementSystem = systemsObj.GetComponent<MovementSystem>();
    }

    public override void Tick(){
        CheckInput();
        movementSystem.Tick();
    }

    private void CheckInput(){
        if(Input.anyKeyDown){
            inputEvent.Raise();
        }
    }
}