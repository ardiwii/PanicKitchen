using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class plateFishChip : MonoBehaviour {
	const int bersih_state = 1;
	const int siap_state = 2;
	public Sprite bersih_sprite;
	public Sprite siap_sprite;
	int curstate;
	
	bool adaKentang = false;
	bool adaIkan = false;
	bool adaTarTar = false;
	bool adaLemon = false;
	bool adaLain = false;
	public List<string> isi;

	// Use this for initialization
	void Start () {
		isi = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void masukinBahan(GameObject bahan){
		isi.Add(bahan.name);
		isBerubahState();
	}

	public bool checkMenu(GameObject bahan){
		return ((bahan.name.Equals("fried_adoned_sliced_Ikan(Clone)")&&!adaIkan) 
			|| (bahan.name.Contains("Tartar")&&!adaTarTar)
		    	|| (bahan.name.Equals("sliced_Lemon(Clone)")&&!adaLemon)
		        	|| (bahan.name.Equals("fried_sliced_Kentang(Clone)")&&!adaKentang));			
	}

	public void isBerubahState(){
		
		for (int i = 0; i < isi.Count; i++) {
			switch (isi[i].ToString()){
			case "fried_adoned_sliced_Ikan(Clone)": adaIkan = true; break;
			case "Tartar": adaTarTar = true; break;
			case "Tartar(Clone)": adaTarTar = true; break;
			case "sliced_Lemon(Clone)": adaLemon = true; break;
			case "fried_sliced_Kentang(Clone)": adaKentang = true; break;
			default : adaLain = true; break;
			}
		}
		
		if (adaIkan && adaTarTar && adaLemon && adaKentang) {
			int count = transform.childCount;
			for(int i = count-1; i>=0;i--){
				Destroy(transform.GetChild(i).gameObject);
			}
			curstate = siap_state;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = siap_sprite;
		}
	}
}
