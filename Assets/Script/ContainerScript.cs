using UnityEngine;
using System.Collections;

public class ContainerScript : MonoBehaviour {

	//container adalah objek yang bisa memuat objek lain yang biasanya adalah bahan-bahan masakan

	//containing adalah benda aktif yang sedang dimuat dalam container
	public GameObject containing;
	public uLink.NetworkView v;
	public bool isContaining;
	private ItemScript itemScript;

	// Use this for initialization
	void Start () {
		isContaining = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<FryPanScript>() != null){
			if(!isContaining && GetComponent<Animator>().GetBool("isGoyang")){
				GetComponent<Animator>().SetBool("isGoyang", false);
			}else if(isContaining && !GetComponent<Animator>().GetBool("isGoyang")){
				GetComponent<Animator>().SetBool("isGoyang", true);
			}
		}
	}

	public void containing_toString(){
		if(containing!=null){

		}
	}

	public void PutItem(GameObject item){
		GameObject itemontalenan;

		//if(containing != null){
		if(containing==null){
			//nampan
			itemScript = item.GetComponent<ItemScript>();
			if(item.transform.parent != null){
				item.transform.parent.GetComponent<ContainerScript>().isContaining = false;
				item.transform.parent = null;
			}


			if(this.gameObject.name=="Nampan"){
				itemontalenan = null;
				isContaining = true;
				if(itemScript != null){
					itemScript.onNampan = true;
					itemScript.onWajan = false;
				}
				if(item.name.EndsWith("(Clone)")){
					item.transform.position = this.gameObject.transform.position;
					itemontalenan = item;
					containing = item;
					GetComponent<NampanScript>().obj = item;
					sendItem(item);
					item.transform.parent = gameObject.transform;
				}
				else{
					GameObject newitem = (GameObject) Instantiate (item, this.transform.position, new Quaternion ());
					itemontalenan = newitem;
					containing = newitem;
					GetComponent<NampanScript>().obj = newitem;
					sendItem(newitem);
					newitem.transform.parent = gameObject.transform;
				}
				if(itemontalenan!=null){
					CutableScript cutscr = itemontalenan.GetComponent<CutableScript>();
					if(cutscr!=null){
						cutscr.ontalenan = false;
					}
				}

			}

			//talenan
			if(this.gameObject.name=="Talenan"){
				Debug.Log("masukin barang ke talenan");
				itemontalenan = null;
				isContaining = true;
				if(itemScript != null){
					if(itemScript.onNampan == true){
						itemScript.onNampan = false;
						v.RPC("removeItem", uLink.RPCMode.Others);
					}
					itemScript.onWajan = false;
				}

				if(item.name.EndsWith("(Clone)")){
					MovableScript movscr = item.GetComponent<MovableScript>();
					if(movscr!=null){
						item.transform.position = this.gameObject.transform.position;
						//movscr.move(this.gameObject);
						itemontalenan = item;
						containing = item;
						item.transform.parent = gameObject.transform;
					}
				}
				else{
					MovableScript movscr = item.GetComponent<MovableScript>();
					if(movscr!=null){
						Debug.Log("new item instantiated");
						GameObject newitem = (GameObject) Instantiate (item, this.transform.position, new Quaternion ());
						itemontalenan = newitem;
						newitem.GetComponent<MovableScript>().containedOn = this.gameObject;
						containing = newitem;
						newitem.transform.parent = gameObject.transform;
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
				if(item.name=="Oil"||item.name=="Oil(Clone)")
					frypan.diminyakin();
				else if(item.GetComponent<CookableScript>()!=null && frypan.readyToFry){
					isContaining = true;
					containing = item;
					item.GetComponent<CookableScript>().fry();
					item.transform.position = frypan.gameObject.transform.position - new Vector3(2f,0,0);
					item.transform.parent = gameObject.transform;
					if(itemScript != null){
						if(itemScript.onNampan == true){
							itemScript.onNampan = false;
							v.RPC("removeItem", uLink.RPCMode.Others);
						}
						itemScript.onWajan = true;
					}
				}
			}

			//bowl
			bowlFishChip bowl = this.GetComponent<bowlFishChip>();
			if(bowl!=null){
				item.transform.parent = gameObject.transform;
				if(itemScript != null){
					if(itemScript.onNampan == true){
						itemScript.onNampan = false;
						v.RPC("removeItem", uLink.RPCMode.Others);
					}
					itemScript.onWajan = false;
				}
				if(bowl.readytoadon){
					if(item.name.EndsWith("(Clone)")){
						MovableScript movscr = item.GetComponent<MovableScript>();
						if(movscr!=null){
							item.transform.position = this.gameObject.transform.position;
							//movscr.move(this.gameObject);
							//itemontalenan = item;
							containing = item;
							isContaining = true;
							bowl.diadon(containing);
						}
					}
				}
				else{
					bowl.masukinBahan(item);
				}
			}

			//plate
			plateFishChip plate = this.GetComponent<plateFishChip>();
			if(plate!=null){
				isContaining = true;
				if(itemScript != null){
					if(itemScript.onNampan == true){
						itemScript.onNampan = false;
						v.RPC("removeItem", uLink.RPCMode.Others);
					}
					itemScript.onWajan = false;
				}
				if(plate.checkMenu(item)){
					if(item.name.EndsWith("(Clone)")){
						item.transform.position = this.gameObject.transform.position;
						itemontalenan = item;
						item.transform.parent = this.gameObject.transform;
						MovableScript mov =  item.GetComponent<MovableScript>();
						Destroy(mov);
						Destroy(item.GetComponent<BoxCollider2D>());
						//containing = item;
					}
					else{
						GameObject newitem = (GameObject) Instantiate (item, this.transform.position, new Quaternion ());
						itemontalenan = newitem;
						newitem.transform.parent = this.gameObject.transform;
						MovableScript mov =  newitem.GetComponent<MovableScript>();
						Destroy(mov);
						Destroy(item.GetComponent<BoxCollider2D>());
						//containing = newitem;
					}
					if(itemontalenan!=null){
						CutableScript cutscr = itemontalenan.GetComponent<CutableScript>();
						if(cutscr!=null){
							cutscr.ontalenan = true;
						}
					}
				}
				plate.masukinBahan(item);
			}
		}
		else{
			Debug.Log ("masuk else");
		}
	}

	private void sendItem(GameObject item){
		MultiStateScript msscr = item.GetComponent<MultiStateScript>();
		int state;
		if(msscr!=null){
			state = msscr.cur_state;
		}
		else{
			state = 0;
		}
		if(item.name.Contains("Kentang")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.KENTANG, state, item.name);
		}else if(item.name.Contains("Air")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.AIR, state, item.name);
		}else if(item.name.Contains("Bawang")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.BAWANG, state, item.name);
		}else if(item.name.Contains("Flour")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.FLOUR, state, item.name);
		}else if(item.name.Contains("Ikan")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.IKAN, state, item.name);
		}else if(item.name.Contains("Lemon")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.LEMON, state, item.name);
		}else if(item.name.Contains("Oil")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.OIL, state, item.name);
		}else if(item.name.Contains("Pepper")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.PEPPER, state, item.name);
		}else if(item.name.Contains("Salt")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.SALT, state, item.name);
		}else if(item.name.Contains("Tartar")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.TARTAR, state, item.name);
		}else if(item.name.Contains("Telur")){
			v.RPC("sendItem", uLink.RPCMode.Others , NampanScript.TELUR, state, item.name);
		}
		Debug.Log(item.name + " " + item.GetComponent<MultiStateScript>().cur_state + " " + item.name);
	}
}
