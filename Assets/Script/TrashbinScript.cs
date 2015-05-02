using UnityEngine;
using System.Collections;

public class TrashbinScript : MonoBehaviour {

	public uLink.NetworkView v;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void throwItem(GameObject item){
		Debug.Log("talenan diklik");
		if(item.name.EndsWith("(Clone)")){
			GameObject.Destroy(item);
			if(item.GetComponent<ItemScript>().onNampan){
				v.RPC("removeItem", uLink.RPCMode.Others);
			}

		}
	}
}
