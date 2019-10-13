using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {

	Player playerScript;
	Vector2 targetPosition;

	public float speed;
	public int damage;

	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		targetPosition = playerScript.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector2.Distance (transform.position, targetPosition) > .1f) {
			transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
		} 
		else 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") 
		{
			playerScript.TakeDamage (damage);
			Destroy (gameObject);
		}
	}
}
