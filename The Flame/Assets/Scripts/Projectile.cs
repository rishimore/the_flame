using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float lifeTime;

	public GameObject explosion;

	public int damage;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyProjectile", lifeTime);	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.up * speed * Time.deltaTime);
	}

	void DestroyProjectile()
	{
		Instantiate (explosion,transform.position,Quaternion.identity);
		Destroy (gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			other.GetComponent<Enemy> ().TakeDamage (damage);
			DestroyProjectile ();
		}

		if (other.tag == "boss") 
		{
			other.GetComponent<Enemy> ().TakeDamage (damage);
			DestroyProjectile ();
		}
	}
}
