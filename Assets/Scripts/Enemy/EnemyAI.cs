using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
	[Header("Zombie behaviour and movement")]
	[Tooltip("Zombie will move and attack this target")]
	[SerializeField] Transform target;
	[Tooltip("The chase range of the zombie")]
	[SerializeField] float chaseRange = 8f;
	[Tooltip("The distance to the target")]
	float targetDistance = Mathf.Infinity;
	 UnityEngine.AI.NavMeshAgent agent;
	 Animator animator;
	 EnemyHealth health;
	 public Score score;
	 bool isProvoked = false;
	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();
		health = GetComponent<EnemyHealth>();
		 score = FindObjectOfType<Score>();
	}

	// Update is called once per frame
	void Update()
	{
		if(health.IsDead()) 
		{
			enabled = false;
			agent.enabled = false;
		} else 
		{
			
		
			targetDistance = Vector3.Distance(target.position, transform.position);
			if(isProvoked) 
			{
				EngageTarget();
			}
			//See if the player is in attack range
			else if(targetDistance <= chaseRange)
			{
				isProvoked = true;
			}
		}
		
		// if(targetDistance <= chaseRange) agent.SetDestination(target.position);
	}
	private void EngageTarget () 
	{
		if (targetDistance >= agent.stoppingDistance) 
		{
			
			ChaseTarget();
		}
		else if (targetDistance <= agent.stoppingDistance) 
		{
		
			AttackTarget();
		}
	}
	private void ChaseTarget () 
	{
		//should be a bool false
		// animator.SetTrigger("attack");
		animator.SetTrigger("move");
		 agent.SetDestination(target.position);
	}
	private void AttackTarget () 
	{
		//should be a bool true
		animator.SetTrigger("attack");
		Debug.Log("Attacking the player");
	}
	 private void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1, 1, 0, 0.75F);
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
	
	//provoke the enemy when shot
	public void OnDamageTaken() 
	{
		isProvoked = true;
		Globals.target_hit++;
        score.updateScore(Globals.target_hit);
	}
	
	
}

//todo
//disable the enemyAi and navmesh agent if the enemy is dead
