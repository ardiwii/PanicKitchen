using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Checkpoint : MonoBehaviour {
	public string stage;
	public List<string> objects;

	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	public void setStage(string stage_){
		stage = stage_;
	}

	public string getStage(){
		return stage;
	}

	public void addObject(string go){
		if (objects == null)
			objects = new List<string> ();
		if (objects.Count < 2) {
			objects.Add (go);
			Debug.Log("add : " + go + " size : " + objects.Count);
		}
	}

	public bool StartsWith(Checkpoint p){
		Debug.Log (p.objects [0] + " " + p.objects [1] + "<");
		Debug.Log (objects [0] + " " + objects [1] + "<");
		bool equals = false;
			if((objects[0].StartsWith(p.objects[0]) && objects[1].StartsWith(p.objects[1])) || 
		   		(objects[1].StartsWith(p.objects[0]) && objects[0].StartsWith(p.objects[1])) ){
				equals = true;
			}
		return equals;
	}
}
