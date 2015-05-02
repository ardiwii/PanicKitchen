using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	private float score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateScore(float incrementScore){
		score += incrementScore;
		Debug.Log (score);
		GetComponent<Text> ().text = score.ToString();
	}
}
