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

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool cut(){
		msscript = gameObject.GetComponent<MultiStateScript>();
		if(msscript){
			if(startcutstate==msscript.cur_state){
				if(startcutstate<endcutstate){
					if(multicut){
						msscript.changeState(startcutstate+1);
						startcutstate++;					
					}
					else{
						msscript.changeState(endcutstate);
					}
					if(msscript.cur_state == endcutstate && !gameObject.name.Contains("sliced_")){
						gameObject.name = "sliced_" + gameObject.name;
					}
				}
				else{
				}

				//success
				return true;
			}
			else{
				//fail, penalty
				return false;
			}
		}
		return false;
	}
}
