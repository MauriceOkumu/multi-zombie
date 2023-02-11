using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
	[SerializeField] Canvas slash;
	[SerializeField]float impactTime = .3f;
	void Start()
	{
		slash.enabled = false;
	}

	IEnumerator Slashed() 
	{
		slash.enabled = true;
		yield return new WaitForSeconds(impactTime);
		slash.enabled = false;
	}
	public void ShowSlash() 
	{
		StartCoroutine(Slashed());
	}
}
