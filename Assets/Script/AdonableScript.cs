using UnityEngine;
using System.Collections;

public class AdonableScript : MonoBehaviour {

	public int startadonstate;
	public int endadonstate;
	MultiStateScript msscript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool adon(){
		msscript = gameObject.GetComponent<MultiStateScript>();
		if(msscript != null){
			if(startadonstate==msscript.cur_state){
				msscript.changeState(endadonstate);
				if(msscript.cur_state == endadonstate && !gameObject.name.Contains("adoned_")){
					gameObject.name = "adoned_" + gameObject.name;
				}
				return true;
			}
		}
		return false;
	}
}
