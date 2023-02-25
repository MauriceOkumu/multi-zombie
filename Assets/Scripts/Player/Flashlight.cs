using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
	[Tooltip("Rate for the decay of light brightness/ intensity")]
	[SerializeField] float lightDecay = .1f;
	[Tooltip("Rate for the decay of light angle")]
	[SerializeField] float angleDecay = .2f;
	[SerializeField] float minAngle = 20f;
	
	Light flashLight;
	void Start()
	{
		flashLight = GetComponent<Light>();
	}
	void Update()
	{
		DecreaseLightIntensity();
		DecreaseLightAngle();
	}
	
	private void DecreaseLightIntensity() 
	{
		flashLight.intensity -= lightDecay * Time.deltaTime;
	}
	private void DecreaseLightAngle() 
	{
		if(flashLight.spotAngle <= minAngle ) 
		{
			return;
		} else 
		{
			flashLight.spotAngle -= minAngle * Time.deltaTime;
		}
	}
}
