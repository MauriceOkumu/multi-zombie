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
	[Tooltip("The delay between shots")]
	[SerializeField]private float timeBetweenShots = .3f;
	[Tooltip("The speed of the bullet")]
	[SerializeField]private float bulletSpeed = 100f;
	[Tooltip("How far the bullet goes")]
	public float range = 100f;
	bool canShoot = true;
	private StarterAssetsInputs input;
	
	void Start()
	{
		input = transform.root.GetComponent<StarterAssetsInputs>();
	}
	private void OnEnable() {
		canShoot = true;
	}

	// Update is called once per frame
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
		ProcessShot();
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
		// GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
		// Add force and direction
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
		Debug.DrawRay(bulletPoint.transform.position,bulletPoint.transform.forward * hit.distance, Color.red);
		//destroy the bullet after a while
		Debug.Log("Shot the thing");
		// Destroy(bullet, 1);
		}
	}
}
