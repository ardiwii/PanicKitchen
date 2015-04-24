using UnityEngine;
using System.Collections;

public class ContainerScript : MonoBehaviour {

	//container adalah objek yang bisa memuat objek lain yang biasanya adalah bahan-bahan masakan

	//containing adalah benda aktif yang sedang dimuat dalam container
	public GameObject containing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PutItem(GameObject item){
		GameObject itemontalenan;

		//nampan dan talenan
		if(containing==null){
			if(this.gameObject.name=="Nampan"){
				itemontalenan = null;
				if(item.name.EndsWith("(Clone)")){
					item.transform.position = this.gameObject.transform.position;
					itemontalenan = item;
					containing = item;
				}
				else{
					GameObject newitem = (GameObject) Instantiate (item, this.transform.position, new Quaternion ());
					itemontalenan = newitem;
					containing = newitem;
				}
				if(itemontalenan!=null){
					CutableScript cutscr = itemontalenan.GetComponent<CutableScript>();
					if(cutscr!=null){
						cutscr.ontalenan = false;
					}
				}
			}
			if(this.gameObject.name=="Talenan"){
				itemontalenan = null;
				if(item.name.EndsWith("(Clone)")){
					item.transform.position = this.gameObject.transform.position;
					itemontalenan = item;
					containing = item;
				}
				else{
					MovableScript movscr = item.GetComponent<MovableScript>();
					if(movscr!=null){
						containing = null;
						GameObject newitem = (GameObject) Instantiate (item, this.transform.position, new Quaternion ());
						itemontalenan = newitem;
						newitem.GetComponent<MovableScript>().move(this.gameObject);
						containing = newitem;
					}
				}
				if(itemontalenan!=null){
					CutableScript cutscr = itemontalenan.GetComponent<CutableScript>();
					if(cutscr!=null){
						cutscr.ontalenan = true;
					}
				}
			}
			//newitem.GetComponent<Rigidbody2D> ().Sleep ();

			//frying pan
			FryPanScript frypan = this.GetComponent<FryPanScript>();
			if(frypan != null){
				CutableScript cutscr = item.GetComponent<CutableScript>();
				if(cutscr!=null){
					cutscr.ontalenan = false;
				}
				if(item.name=="Oil")
					frypan.diminyakin();
				else if(item.GetComponent<CookableScript>()!=null && frypan.readyToFry){
					item.GetComponent<CookableScript>().fry();
					item.transform.position = frypan.gameObject.transform.position - new Vector3(2f,0,0);
				}
			}

			//bowl
			bowlFishChip bowl = this.GetComponent<bowlFishChip>();
			if(bowl!=null){
				bowl.masukinBahan(item);
			}
		}
	}
}
