using UnityEngine;
using System.Collections;

public class FryPanScript : MonoBehaviour {

	public bool readyToFry;
	MultiStateScript msscript;

	// Use this for initialization
	void Start () {
		readyToFry = false;
		msscript = gameObject.GetComponent<MultiStateScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void diminyakin(){
		if(!readyToFry){
			readyToFry = true;
			msscript.changeState(msscript.cur_state+1);
			gameObject.name = "oiled_" + gameObject.name;
		}
	}
}
