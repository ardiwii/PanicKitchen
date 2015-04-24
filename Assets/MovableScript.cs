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
			ContainerScript containscr = containedOn.GetComponent<ContainerScript>();
			if(containscr!=null){
				containscr.containing = null;
			}
		}
		ContainerScript containscr2 = targetContainer.GetComponentInParent<ContainerScript>();
		if(containscr2!=null){
			containscr2.PutItem(this.gameObject);
			containedOn = containscr2.gameObject;
		}
	}
}
