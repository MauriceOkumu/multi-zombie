using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] GameObject hitEffect;
	 ContactPoint contact;
	 Quaternion rotation;
	 Vector3 position;
	
	void Start()
	{
		
	}

	private void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") 
		{
			contact = collision.contacts[0];
			rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
			position = contact.point;
			GameObject hit = Instantiate(hitEffect, position, rotation);
			Destroy(hit, 1);
		}
	}
}
