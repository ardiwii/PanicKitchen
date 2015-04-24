using UnityEngine;
using System.Collections;

public class FryPanScript : MonoBehaviour {

	public bool readyToFry;
	MultiStateScript msscript;

	// Use this for initialization
	void Start () {
		msscript = gameObject.GetComponent<MultiStateScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void diminyakin(){
		readyToFry = true;
		msscript.changeState(msscript.cur_state+1);
	}
}
