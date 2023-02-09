using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Weapons : MonoBehaviour
{
	[Header("Weapons")]
	[SerializeField] int currentWeapon = 0;
	private StarterAssetsInputs input;
	
	void Start()
	{
		input = transform.root.GetComponent<StarterAssetsInputs>();
		SetWeaponActive();
	}
	void SetWeaponActive()
	{
		int weaponIndex = 0;
		foreach (Transform weapon in transform)
		{
			if(weaponIndex == currentWeapon) 
			{
				weapon.gameObject.SetActive(true);
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			weaponIndex++;
		}
	}
	
	void Update()
	{
		int previousWeapon = currentWeapon;
		ProcessInputKey();
	
		if(previousWeapon != currentWeapon)
		{
			SetWeaponActive();
		}
	}
	// change weapon using numbers
	private void ProcessInputKey()
	{
		if (input.shot) currentWeapon = 1;
	}
}
