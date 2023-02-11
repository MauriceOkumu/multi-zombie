using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Tooltip("The damage depends on the type of bullet")]
	[SerializeField] private float damage = 1f;
	EnemyHealth enemyHealth;
	void Start()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
	}

	private void OnCollisionEnter(Collision target) {
		if(target.gameObject.tag == "Enemy") 
		{
			if (enemyHealth != null) enemyHealth.TakeDamage(damage);
			Debug.Log("I hit the zombie");
		}
	}
	
}
//todo
// give the bullet damage power
//update the score accordingly