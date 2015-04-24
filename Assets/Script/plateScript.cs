using UnityEngine;
using System.Collections;

public class plateScript : MonoBehaviour {
	const int bersih_state = 1;
	const int siap_state = 2;
	public Sprite bersih_sprite;
	public Sprite siap_sprite;
	int curstate;
	ArrayList isi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void masukinBahan(GameObject bahan){
		isi.Add(bahan.name);
	}

	public void isBerubahState(){
		bool adaOmelete = false;
		bool adaKentang = false;
		bool adaLain = false;
		
		for (int i = 0; i < isi.Count; i++) {
			switch (isi[i].ToString()){
			case "Omelete": adaOmelete = true; break;
			case "Kentang": adaKentang = true; break;
			default : adaLain = true; break;
			}
		}
		
		if (adaOmelete && adaKentang) {
			curstate = siap_state;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = siap_sprite;
		}
	}
}
