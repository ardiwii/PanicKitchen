using UnityEngine;
using System.Collections;

public class ClicktoSelect : MonoBehaviour {

	public Camera camera;
	public GameObject activeObject;
	public StageController stageController;
	public uLink.NetworkView v;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("click");
			RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x,camera.ScreenToWorldPoint(Input.mousePosition).y),Vector2.zero);
			if(hitInfo!=null){
				if(activeObject!=null){
					activeObject.GetComponent<SpriteRenderer>().color = Color.white;
				}
				if((hitInfo.collider.gameObject.tag=="selectable"  || hitInfo.collider.gameObject.tag=="tools" || hitInfo.collider.gameObject.tag=="pisau") && activeObject==null){
					Debug.Log ("object clicked: " + hitInfo.collider.gameObject.name);
					activeObject = hitInfo.collider.gameObject;
					if(activeObject.tag == "pisau"){
						activeObject.GetComponent<Animator>().SetBool("isPotong", true);
					}
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
					else if(activeObject.tag=="selectable"){
						Debug.Log (activeObject.name + " ke " + hitInfo.collider.gameObject.name);
						MovableScript movscr = activeObject.GetComponent<MovableScript>();
						if(movscr!=null){
							movscr.move(hitInfo.collider.gameObject);
						}
						else{
							hitInfo.collider.gameObject.GetComponentInParent<ContainerScript>().PutItem(activeObject);
						}
						if(v.gameObject.GetComponent<NetworkScript>().isServer){
							stageController.checkCombination(activeObject.name, hitInfo.collider.gameObject.name);
						}else{
							v.RPC ("checkCombination", uLink.RPCMode.Others, activeObject.name, hitInfo.collider.gameObject.name);
						}
					}
					else{
					}
				}
				else if(hitInfo.collider.gameObject.tag=="trashbin"){
					hitInfo.collider.gameObject.GetComponent<TrashbinScript>().throwItem(activeObject);
				}
				else if(hitInfo.collider.gameObject.tag=="background"){
					Debug.Log("background clicked");
					if(activeObject!=null)
						activeObject.GetComponent<SpriteRenderer>().color = Color.white;
					if(activeObject.tag=="pisau")
						activeObject.GetComponent<Animator>().SetBool("isPotong", false);
					activeObject = null;
				}

				if(activeObject!=null){
					activeObject.GetComponent<SpriteRenderer>().color = Color.cyan;
				}
			}
		}
	}
}
