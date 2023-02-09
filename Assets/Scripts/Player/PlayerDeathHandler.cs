using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
   public Canvas gameOver;
	void Start()
	{
		gameOver.enabled = false;
	}

	public void HandleDeath()
	{
		gameOver.enabled = true;
		Time.timeScale = 0;
		FindObjectOfType<Weapons>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
