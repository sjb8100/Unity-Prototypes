using UnityEngine;

public class InputSystem : MonoBehaviour {

    [Header("Events")]
    public GameEvent shootEvent;

    public void ProcessKey(){
        foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKeyDown(key)){
                switch(key){
                    case KeyCode.Mouse0:    shootEvent.Raise();     break;
                    case KeyCode.W:                                 break;
                    case KeyCode.A:                                 break;
                    case KeyCode.S:                                 break;
                    case KeyCode.D:                                 break;
                    case KeyCode.LeftArrow:                         break;
                    case KeyCode.RightArrow:                        break;
                    case KeyCode.UpArrow:                           break;
                    case KeyCode.DownArrow:                         break;
                    default:                NoKeybind(key);         break;
                }
                break;
            }
        }
    }

    private void NoKeybind(KeyCode key){
        print(key.ToString() + " is not bound to anything.");
    }

}