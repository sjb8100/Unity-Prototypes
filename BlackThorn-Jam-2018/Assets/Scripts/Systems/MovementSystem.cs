using UnityEngine;

public class MovementSystem : MonoBehaviour {

    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private Rigidbody2D playerRb;
    private Vector2 moveVelocity;


    public void Tick(){
        DoMovement();
    }

    private void DoMovement(){
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput.normalized * playerData.moveSpeed;
        playerRb.MovePosition(playerRb.position + moveVelocity * Time.fixedDeltaTime);
    }

}