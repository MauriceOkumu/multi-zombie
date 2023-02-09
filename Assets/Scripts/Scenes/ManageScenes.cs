using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
	public void Play() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Time.timeScale = 1;
	 }
	public void Restart() {
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	 }

	 public void Quit() {
		 Application.Quit();
	 }
}
