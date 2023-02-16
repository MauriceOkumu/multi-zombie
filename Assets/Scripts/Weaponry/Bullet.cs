using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Tooltip("The damage depends on the type of bullet")]
	[SerializeField] private float damage = 1f;
	[Tooltip("The score points depends on the type of bullet")]
	EnemyHealth enemyHealth;											
	void Start()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
		
	}

	private void OnCollisionEnter(Collision target) {
		if(target.gameObject.tag == "Enemy") 
		{
			if (enemyHealth != null) {
				enemyHealth.TakeDamage(damage);
			}
		}
	}
	
}