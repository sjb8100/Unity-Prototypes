using UnityEngine;
using Unity.Entities;

public class InputSystem : ComponentSystem{
	
	private struct Data{
		public readonly int Length;
		public ComponentArray<InputComponent> InputComponents;
	}

	[Inject] private Data _data;


	protected override void OnUpdate(){
		float horizontal =  Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		for(int i = 0; i < _data.Length; i++){
			_data.InputComponents[i].Horizontal = horizontal;
			_data.InputComponents[i].Vertical = vertical;
		}
	}
}