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

	public void changeState(int newState){
		cur_state = newState;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = alternateArt[newState];
	}
}
