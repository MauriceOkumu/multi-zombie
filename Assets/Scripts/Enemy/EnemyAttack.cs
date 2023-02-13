using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[Header("Enemy attack controls")]
	[Tooltip("Enemy target")]
	 public float damage = 1f;
	PlayerHealth target;
	
	void Start()
	{
		target = FindObjectOfType<PlayerHealth>();
	}

	public void AttackHitEvent()
	{
		if(target == null) return;
		target.TakeDamage(damage);
		target.GetComponent<Slash>().ShowSlash();
	}
}
