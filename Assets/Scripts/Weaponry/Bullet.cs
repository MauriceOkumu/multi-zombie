using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Tooltip("The damage depends on the type of bullet")]
	[SerializeField] private float damage = 1f;
	[Tooltip("The score points depends on the type of bullet")]
	public int scorePoint = 0;
	public Score score;
	EnemyHealth enemyHealth;											
	void Start()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
		score = FindObjectOfType<Score>();
	}

	private void OnCollisionEnter(Collision target) {
		if(target.gameObject.tag == "Enemy") 
		{
			if (enemyHealth != null) enemyHealth.TakeDamage(damage);
			scorePoint++;
			score.updateScore(scorePoint);
		}
		Debug.Log(target.gameObject.tag);
	}
	
}