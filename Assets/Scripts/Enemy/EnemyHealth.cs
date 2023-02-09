using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to the zombie
public class EnemyHealth : MonoBehaviour
{
	[SerializeField]
	private float hitPoints = 10f;
	bool isDead = false;
	
	//call this method in Shoot()
	public void TakeDamage(float damage) 
	{
		//Provoke the enemy when shot
		//BroadcastMessage("OnDamageTaken");
		hitPoints -= damage;
		if(hitPoints <= 0) DeadZombie();
	}
	
	public bool IsDead() 
	{
		// Debug.Log("Dead now");
		return isDead;
	}
	
	private void DeadZombie()
	{
		if(isDead) {
			Debug.Log("Dead now");
			return;
		}
		isDead = true;
		// Play the dead animation
		//<Animator>().SetTrigger("dead");
	}
}
// todo
// create a public bool to check if its dead
//if dead, stop the animations and effects