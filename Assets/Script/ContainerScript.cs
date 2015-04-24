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
		containing = item;
		if(this.gameObject.name=="Nampan"){
			GameObject newitem = (GameObject) Instantiate (containing, this.transform.position, new Quaternion ());
		}
		if(this.gameObject.name=="Talenan"){
			GameObject newitem = (GameObject) Instantiate (containing, this.transform.position, new Quaternion ());
			CutableScript cutscr = newitem.GetComponent<CutableScript>();
			if(cutscr!=null){
				cutscr.ontalenan = true;
			}
		}
		//newitem.GetComponent<Rigidbody2D> ().Sleep ();
		FryPanScript frypan = this.GetComponent<FryPanScript>();
		if(frypan != null){
			if(item.name=="Oil")
				frypan.diminyakin();
			else if(item.GetComponent<CookableScript>()!=null && frypan.readyToFry){
				item.GetComponent<CookableScript>().fry();
				item.transform.position = frypan.gameObject.transform.position - new Vector3(2f,0,0);
			}
		}
		bowlFishChip bowl = this.GetComponent<bowlFishChip>();
		if(bowl!=null){
			bowl.masukinBahan(item);
		}
	}
}
