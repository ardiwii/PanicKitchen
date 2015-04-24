using UnityEngine;
using System.Collections;

public class CutableScript : MonoBehaviour {

	public bool multicut;
	public bool ontalenan;
	public int startcutstate;
	public int endcutstate;
	MultiStateScript msscript;

	// Use this for initialization
	void Start () {
		msscript = gameObject.GetComponent<MultiStateScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool cut(){
		if(startcutstate==msscript.cur_state){
			if(multicut){
				if(startcutstate<endcutstate){
					msscript.changeState(startcutstate+1);
					startcutstate++;
				}
				else{
					//fail, penalty
				}
			}
			else{
				msscript.changeState(endcutstate);
			}
			//success
			return true;
		}
		else{
			//fail, penalty
			return false;
		}
	}
}
