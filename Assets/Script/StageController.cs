using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StageController : MonoBehaviour {
	public ScoreScript scoreScript;
	public List<Checkpoint> allCheckpoints;
	private float langkahsalah = 0;
	private float langkahtotal = 0;

	public void Start(){
		foreach(Checkpoint currentCP in gameObject.GetComponentsInChildren<Checkpoint> ()){
			allCheckpoints.Add(currentCP);
			langkahtotal++;
		}
	}

	[RPC]
	public void checkCombination(string g1, string g2){
		// Create checkpoint combination
		Checkpoint com1 = new Checkpoint();
		com1.addObject (g1);
		com1.addObject (g2);

		Debug.Log ("check : " + g1 + " " + g2);

		bool contains = false;
		int i = 0;
		foreach (Checkpoint cp in allCheckpoints) {
			if(com1.StartsWith(cp)){
				contains = true;
				break;
			}
			i++;
		}
		if (contains) {
			allCheckpoints.RemoveAt (i);
			Debug.Log(getFactor());
			scoreScript.updateScore(getFactor() * 10f);
		} 
		else {
			langkahsalah++;
		}
	}

	public void updateCheckpoints(){

	}

	public float getFactor(){
		return (langkahtotal - langkahsalah) / langkahtotal;
	}
}
