using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed = 7f;
	float rotateSpeed = 10f;
	private void Update()
	{
		Vector3 dirMovement = new Vector3(0,0,0);
		if (Input.GetKey(KeyCode.W))
		{
			dirMovement.z = 1;
		}
		if (Input.GetKey(KeyCode.S))
		{
			dirMovement.z = -1;
		}
		if (Input.GetKey(KeyCode.A))
		{
			dirMovement.x = -1;
		}
		if (Input.GetKey(KeyCode.D))
		{
			dirMovement.x = 1;
		}
		transform.position += dirMovement * moveSpeed * Time.deltaTime;
		if(dirMovement != new Vector3(0,0,0))
			transform.forward = Vector3.Lerp(transform.forward,dirMovement, rotateSpeed*Time.deltaTime);
	}
}
