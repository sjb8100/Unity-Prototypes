using Unity.Entities;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem{
	
	private struct Filter{
		public Rigidbody Rigidbody;
		public InputComponent InputComponent;
	}

	protected override void OnUpdate(){
		float deltaTime = Time.deltaTime;
		float speed = 3.0f;

		foreach (var entity in GetEntities<Filter>()){
			Vector3 moveVector = new Vector3(entity.InputComponent.Horizontal, 0.0f, entity.InputComponent.Vertical);
			Vector3 movePosition = entity.Rigidbody.position + moveVector.normalized * speed * deltaTime;
			entity.Rigidbody.MovePosition(movePosition);
		}
	}

}