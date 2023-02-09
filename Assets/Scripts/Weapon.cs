using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
	[Header("Bullet actions and controls")]
	[Tooltip("Bullet/ray spawn point")]
	[SerializeField]private Transform bulletPoint;
	[Tooltip("Type of bullet")]
	[SerializeField]private GameObject bulletPrefab;
	[Tooltip("Weapon Muzzle flash")]
	[SerializeField]private ParticleSystem muzzleFlash;
	[Tooltip("The delay between shots")]
	[SerializeField]private float timeBetweenShots = .3f;
	[Tooltip("The speed of the bullet")]
	[SerializeField]private float bulletSpeed = 100f;
	[Tooltip("Ammo type ")]
	[SerializeField]private AmmoType ammoType;
	[Tooltip("Ammo slot")]
	[SerializeField]public Ammo ammoSlot;
	[Tooltip("How far the bullet goes")]
	public float range = 100f;
	[Tooltip("The damage the bullet does")]
	public float damage = 1f;
	bool canShoot = true;
	private StarterAssetsInputs input;
	
	
	void Start()
	{
		input = transform.root.GetComponent<StarterAssetsInputs>();
	}
	private void OnEnable() {
		canShoot = true;
	}

	void Update()
	{
		if (input.shoot && canShoot)
		{
			StartCoroutine(Shoot());
			input.shoot = false;
		} 
	}
	
	IEnumerator Shoot() 
	{
		canShoot = false;
		if(ammoSlot.AmmoRemaining(ammoType) > 0) 
		{	
			ProcessShot();
			muzzleFlash.Play();
			ammoSlot.ReduceAmmo(ammoType);
		}
		yield return new WaitForSeconds(timeBetweenShots);
		canShoot = true;
	}
	
	private void ProcessShot()
	{
		RaycastHit hit;
		if(Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range))
		{
			
		// instantiate the bullet
		GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);
		// Add force and direction
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
		Debug.DrawRay(bulletPoint.transform.position,bulletPoint.transform.forward * hit.distance, Color.red);
		//destroy the bullet after a while
		Destroy(bullet, 1);
		} else 
		{
			return;
		}
	}
}
