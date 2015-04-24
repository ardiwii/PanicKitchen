using UnityEngine;
using System.Collections;

public class plateFishChip : MonoBehaviour {
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
		bool adaKentang = false;
		bool adaIkan = false;
		bool adaTarTar = false;
		bool adaLemon = false;
		bool adaLain = false;
		
		for (int i = 0; i < isi.Count; i++) {
			switch (isi[i].ToString()){
			case "Ikan": adaIkan = true; break;
			case "TarTar": adaTarTar = true; break;
			case "Lemon": adaLemon = true; break;
			case "Kentang": adaKentang = true; break;
			default : adaLain = true; break;
			}
		}
		
		if (adaIkan && adaTarTar && adaLemon && adaKentang) {
			curstate = siap_state;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = siap_sprite;
		}
	}
}
