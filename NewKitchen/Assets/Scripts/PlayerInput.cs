using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	PlayerInputActions inputActions;
	private void Awake()
	{
		inputActions = new PlayerInputActions();
		inputActions.Player.Enable();
	}
	public Vector2 GetMovementDirection()
	{
		Vector2 inputVector = Vector2.zero; 
		inputVector = inputActions.Player.Move.ReadValue<Vector2>();
		inputVector = inputVector.normalized;
		return inputVector;
	}
}
