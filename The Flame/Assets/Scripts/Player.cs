using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;
	private Animator anim;

	private Vector2 moveAmount;

	public int health;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"),(Input.GetAxisRaw("Vertical")));
		moveAmount = moveInput.normalized * speed;

		if (moveInput != Vector2.zero) {
			anim.SetBool ("IsRunning", true);
		} 
		else 
		{
			anim.SetBool ("IsRunning",false);
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition (rb.position + moveAmount * Time.fixedDeltaTime);
	}

	public void TakeDamage(int damageAmount){

		health -= damageAmount;
		UpdateHealthUI (health);

		if (health <= 0) 
		{
			Destroy (gameObject);	
		}
	}

	public void ChangeWeapon(Weapon weaponToEquip){
		Destroy (GameObject.FindGameObjectWithTag ("Weapon"));
		Instantiate (weaponToEquip, transform.position, transform.rotation, transform);
	}

	void UpdateHealthUI(int currentHealth){

		for (int i = 0; i < hearts.Length; i++) {
			if (i < currentHealth) {
				hearts [i].sprite = fullHeart;
			} else {
				hearts [i].sprite = emptyHeart;
			}
		}
	}

	public void Heal(int healAmount)
	{
		if (health + healAmount > 5) {
			health = 5;
		} 
		else 
		{
			health += healAmount;
		}
		UpdateHealthUI (health);
	}
}
