using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
	[SerializeField]
	protected float maxHealth;
	protected float currentHealth;
	[SerializeField]
	protected float damage;
	[SerializeField]
	protected float speed;

	[SerializeField]
	//protected SpriteRenderer spriteRenderer;

	//public Image healthBar;

	//private Vector2 screenBounds;

	protected virtual void Awake()
	{
		//spriteRenderer = GetComponent<SpriteRenderer>();
		currentHealth = maxHealth;
		//if (healthBar != null)
		//	healthBar.fillAmount = 1.0f;
	}

	protected void Start()
	{
		//screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}
	protected void Update()
	{
		Move();
		Attack();
	}

	public abstract void Move();
	public abstract void Attack();

	public virtual void TakeDamage(float value)
	{
		currentHealth -= value;
		//if (healthBar != null)
		//	healthBar.fillAmount = currentHealth / maxHealth;

		//Debug.Log(string.Format("{0}'s health is {1}/{2}", gameObject.name, currentHealth, maxHealth));
		
		if (currentHealth <= 0)
		{
			if (gameObject.name == "Player")
			{
				
			}
			Destroy(this.gameObject);
		}
	}
}
