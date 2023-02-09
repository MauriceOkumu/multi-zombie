using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	public TMP_Text scoretext;
	public static int score = 0;
	string newScore = "SCORE : ";

	void Start() {
	   scoretext = GetComponent<TMP_Text>();
	   scoretext.text = newScore;
	}
	 private void Update() {
	   
		scoretext.text = newScore + score.ToString();
	}

	public void updateScore(int amount){
		score = amount;
	   
	}
	 void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

}
