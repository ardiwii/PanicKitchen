using UnityEngine;
using System.Collections;

public class NampanScript : MonoBehaviour {

	public static int KENTANG = 0;
	public static int OIL = 1;
	public static int PEPPER = 2;
	public static int SALT = 3;
	public static int IKAN = 4;
	public static int TARTAR = 5;
	public static int FLOUR = 6;
	public static int TELUR = 7;
	public static int LEMON = 8;
	public static int BAWANG = 9;
	public static int AIR = 10;

	public GameObject kentang, oil, pepper, salt, ikan, tartar, flour, telur, lemon, bawang, air;
	public GameObject obj;

	[RPC]
	void sendItem(int itemCode, int state, string name){
		Debug.Log("item: " + itemCode + " " + name + " state: " + state);
		if(itemCode == KENTANG)
			obj = Instantiate(kentang, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == OIL)
			obj = Instantiate(oil, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == PEPPER)
			obj = Instantiate(pepper, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == SALT)
			obj = Instantiate(salt, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == IKAN)
			obj = Instantiate(ikan, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == TARTAR)
			obj = Instantiate(tartar, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == FLOUR)
			obj = Instantiate(flour, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == TELUR)
			obj = Instantiate(telur, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == LEMON)
			obj = Instantiate(lemon, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == BAWANG)
			obj = Instantiate(bawang, transform.position, new Quaternion()) as GameObject;
		else if(itemCode == AIR)
			obj = Instantiate(air, transform.position, new Quaternion()) as GameObject;

		if(obj != null && obj.GetComponent<ItemScript>() != null){
			obj.GetComponent<ItemScript>().onNampan = true;
			obj.name = name;
			if(obj.GetComponent<MultiStateScript>() != null) 
			{
				obj.GetComponent<MultiStateScript>().changeState(state);
			}
		}

	}

	[RPC]
	void removeItem(){
		Destroy(obj);
	}
}
