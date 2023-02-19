using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
	Animator playerAnim;
	[SerializeField] Player player;
	private const string IS_WALKING = "IsWalking";
	private void Awake()
	{
		playerAnim = GetComponent<Animator>();
	}
	private void Update()
	{
		playerAnim.SetBool(IS_WALKING, player.IsWalking());
	}
}
