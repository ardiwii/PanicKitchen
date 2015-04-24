using UnityEngine;
using System.Collections;

public class CookableScript : MonoBehaviour {

	public int startcookstate;
	public int endcookstate;
	public bool iscooking;
	MultiStateScript msscript;

	// Use this for initialization
	void Start () {
		msscript = gameObject.GetComponent<MultiStateScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool fry(){
		iscooking = true;
		if(startcookstate==msscript.cur_state){
			msscript.changeState(endcookstate);
			return true;
		}
		else{
			//fail, penalty
			return false;
		}
	}
}
