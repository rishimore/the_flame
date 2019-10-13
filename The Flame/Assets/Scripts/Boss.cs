using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public int health;
	public Enemy[] enemies;
	public float spawnOffset;

	int halfHealth;
	Animator anim;

	public int damage;

	void Start()
	{
		halfHealth = health / 2;
		anim = GetComponent<Animator> ();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		if (health <= 0) 
		{
			Destroy (this.gameObject);
		}

		if (health <= halfHealth) 
		{
			anim.SetTrigger ("stage2");
		}

		Enemy randomEnemy = enemies[Random.Range(0,enemies.Length)];
		Instantiate (randomEnemy,transform.position + new Vector3(spawnOffset,spawnOffset,0),transform.rotation);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") 
		{
			collision.GetComponent<Player> ().TakeDamage (damage);
		}
	}
}
