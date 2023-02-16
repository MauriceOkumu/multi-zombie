using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
	private Vector3 currentRotaion;
	private Vector3 targetRotaion;
	[SerializeField] private float recoilX = -2f;
	[SerializeField] private float recoilY = 2f;
	[SerializeField] private float recoilZ = .35f;
	[SerializeField] private float snappiness = 6f;
	[SerializeField] private float returnSpeed = 2f;
	
	void Start()
	{
		
	}

	
	void Update()
	{
		targetRotaion = Vector3.Lerp(targetRotaion, Vector3.zero, returnSpeed * Time.deltaTime);
		currentRotaion = Vector3.Slerp(currentRotaion, targetRotaion, snappiness * Time.fixedDeltaTime);
		transform.localRotation = Quaternion.Euler(currentRotaion);
	}
	public void RecoilFire() 
	{
		targetRotaion += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
	}
}
