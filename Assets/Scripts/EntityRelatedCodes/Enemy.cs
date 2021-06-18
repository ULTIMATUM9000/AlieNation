using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
	public float minAttackInterval = 0.5f, maxAttackInterval = 3.0f;
	public float scoreValue;
	float attackInterval;
	float elapsedTime;

	//private ScoreTracker scoreTracker;

	private Rigidbody2D rb;

	protected override void Awake()
	{
		base.Awake();
		attackInterval = Random.Range(minAttackInterval, maxAttackInterval);
		//scoreTracker = GameObject.FindObjectOfType<ScoreTracker>();
	}

	public override void Move()
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(0, -speed);
	}

	public override void Attack()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= attackInterval)
		{
			//GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			//bulletObject.GetComponent<Bullet>().damage = this.damage;
			elapsedTime = 0;
			attackInterval = Random.Range(minAttackInterval, maxAttackInterval);
		}
	}

	public override void TakeDamage(float value)
	{
		base.TakeDamage(value);
		if (currentHealth <= 0)
		{
			//scoreTracker.AddScore(scoreValue);
		}
	}
}
