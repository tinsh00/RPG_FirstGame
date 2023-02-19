using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] PlayerInput playerInput;
	[SerializeField] float moveSpeed = 7f;
	float rotateSpeed = 10f;
	private bool isWalking;
	public bool IsWalking ()=> isWalking;
	private void Update()
	{
		Vector2 inputVector = Vector2.zero;
		inputVector = playerInput.GetMovementDirection();
		Vector3 dirMovement = new Vector3(inputVector.x, 0, inputVector.y);
		transform.position += dirMovement * moveSpeed * Time.deltaTime;
		if (inputVector != Vector2.zero)
		{
			transform.forward = Vector3.Lerp(transform.forward, dirMovement, rotateSpeed * Time.deltaTime);
			isWalking = true;
		}
		else
			isWalking = false;
	}
}
