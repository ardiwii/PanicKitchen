using UnityEngine;
using System.Collections;

public class ClicktoSelect : MonoBehaviour {

	public Camera camera;
	public GameObject activeObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("click");
			RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x,camera.ScreenToWorldPoint(Input.mousePosition).y),Vector2.zero);
			if(hitInfo!=null){
				if((hitInfo.collider.gameObject.tag=="selectable"  || hitInfo.collider.gameObject.tag=="tools" || hitInfo.collider.gameObject.tag=="pisau") &&activeObject==null){
					Debug.Log ("object clicked: " + hitInfo.collider.gameObject.name);
					activeObject = hitInfo.collider.gameObject;
				}
				else if(hitInfo.collider.gameObject.tag=="selectable" && activeObject.name=="Pisau"){
					CutableScript cutscr = hitInfo.collider.gameObject.GetComponent<CutableScript>();
					if(cutscr!=null){
						if(cutscr.ontalenan){
							cutscr.cut ();
						}
					}
				}
				else if(hitInfo.collider.gameObject.tag=="container"){
					if(activeObject==null){
						Debug.Log("container clicked");
						//hitInfo.collider.gameObject cek yang dicontain bisa diambil apa ga
					}
					else if(activeObject.tag=="pisau"){
						hitInfo.collider.gameObject.GetComponent<ContainerScript>().PutItem(activeObject);
					}
					else if(activeObject.tag=="selectable"){
						Debug.Log (activeObject.name + " ke " + hitInfo.collider.gameObject.name);
						hitInfo.collider.gameObject.GetComponent<ContainerScript>().PutItem(activeObject);
						activeObject = null;
					}
					else{
					}
				}
				else if(hitInfo.collider.gameObject.tag=="background"){
					Debug.Log("background clicked");
					activeObject = null;
				}
			}
		}
	}
}
