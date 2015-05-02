using UnityEngine;
using System.Collections;

public class MovableScript : MonoBehaviour {

	public GameObject containedOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move(GameObject targetContainer){
		if(containedOn!=null){
			Debug.Log("moving: "+ this.gameObject.name);
			ContainerScript containscr = containedOn.GetComponent<ContainerScript>();
			if(containscr!=null && this.gameObject.name.EndsWith("(Clone)")){
				Debug.Log("disini");
				containscr.containing = null;
				containscr.isContaining = false;
			}
		}
		ContainerScript containscr2 = targetContainer.GetComponent<ContainerScript>();
		if(containscr2!=null){
			containscr2.PutItem(this.gameObject);
			containedOn = containscr2.gameObject;
			//containscr2.isContaining = true;
		}
	}
}
