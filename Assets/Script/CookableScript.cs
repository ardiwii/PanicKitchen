using UnityEngine;
using System.Collections;

public class CookableScript : MonoBehaviour {

	public int startcookstate;
	public int endcookstate;
	public bool iscooking;
	MultiStateScript msscript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool fry(){
		msscript = gameObject.GetComponent<MultiStateScript>();
		if(msscript != null){
			iscooking = true;
			if(startcookstate==msscript.cur_state){
				msscript.changeState(endcookstate);
				if(msscript.cur_state == endcookstate && !gameObject.name.Contains("fried_")){
					gameObject.name = "fried_" + gameObject.name;
				}
				return true;
			}
		}
		return false;
	}
}
