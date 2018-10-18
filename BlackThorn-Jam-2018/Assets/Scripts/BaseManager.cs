using UnityEngine;
using System.Collections.Generic;

public abstract class BaseManager : MonoBehaviour, IManager {

    public virtual void InitManager(object obj){}

    public virtual string GetManagerType(){
		return this.GetType().ToString();
	}

    public virtual bool CanTick(){
        return this.isActiveAndEnabled;
    }

    public virtual void Tick(){}

}