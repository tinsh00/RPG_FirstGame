using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] PlayerInput playerInput;
	[SerializeField] float moveSpeed = 7f;
	[SerializeField] float playerHeigh = 2f;
	[SerializeField] float playerSize = 0.7f;
	float rotateSpeed = 10f;
	private bool isWalking;
	public bool canMove;
	public bool IsWalking ()=> isWalking;

    private void Update()
	{
		HandleMovevement();
	}
    private void HandleMovevement()
	{
		Vector2 inputVector = playerInput.GetMovementDirection();
		Vector3 dirMovement = new Vector3(inputVector.x, 0, inputVector.y);
		float amountMovement = moveSpeed * Time.deltaTime;
		canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigh, playerSize, dirMovement, amountMovement);
		if (!canMove)
		{
			Vector3 dirMoveX = new Vector3(inputVector.x, 0, 0);
			canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigh, playerSize, dirMoveX, amountMovement);
			if (canMove) dirMovement = dirMoveX;
			else
			{
				Vector3 dirMoveZ = new Vector3(0, 0, inputVector.y);
				canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigh, playerSize, dirMoveZ, amountMovement);
				if (canMove) dirMovement = dirMoveZ;
			}
		}
		if (canMove)
			transform.position += dirMovement * amountMovement;
		if (canMove && inputVector != Vector2.zero)
		{
			transform.forward = Vector3.LerpUnclamped(transform.forward, dirMovement, rotateSpeed * Time.deltaTime);
		}

		isWalking = dirMovement != Vector3.zero;
	}
}
