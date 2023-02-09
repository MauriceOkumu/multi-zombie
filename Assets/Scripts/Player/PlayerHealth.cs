using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[Header("This script handles the players' health")]
	[Tooltip("The amount of damage that the player receives with enemy attack")]
	[SerializeField] float hitPoints = 1f;
	
	public void TakeDamage( float damage) 
	{
		hitPoints -= damage;
		if(hitPoints <= 0) 
		{
			GetComponent<PlayerDeathHandler>().HandleDeath();
		}
	}
}
