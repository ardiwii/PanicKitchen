using UnityEngine;
using System.Collections;

public class MultiStateScript : MonoBehaviour {

	public int cur_state;
	public Sprite[] alternateArt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void jumpState(int newState){
		
	}

	public void changeState(int newState){
		//cur_state = newState;
//		CutableScript cutscr = gameObject.GetComponent<CutableScript>();
//		if(cutscr!=null){
//			if (newState>cutscr.endcutstate){
//				cur_state = cutscr.startcutstate;
//				//cutscr.cut();
//				cutscr.startcutstate = cutscr.endcutstate;
//			}
//		}
//		CookableScript cookscr = gameObject.GetComponent<CookableScript>();
//		if(cookscr!=null){
//			if (newState>cookscr.endcookstate){
//				cur_state = cookscr.startcookstate;
//				cookscr.fry();
//			}
//		}
//		AdonableScript adonscr = gameObject.GetComponent<AdonableScript>();
//		if(adonscr!=null){
//			if (newState>adonscr.endadonstate){
//				cur_state = adonscr.startadonstate;
//				adonscr.adon();
//			}
//		}
		this.gameObject.GetComponent<SpriteRenderer>().sprite = alternateArt[newState];
		cur_state = newState;
	}
}
