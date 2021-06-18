using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
	public float shootFrequency = 0.2f;
	private float elapsedTime;


	protected override void Awake()
	{
		base.Awake();
		elapsedTime = shootFrequency;
	}

	public override void Move()
	{

	}

	public override void Attack()
	{
		//if (Input.GetKey(KeyCode.Space))
	}
}
