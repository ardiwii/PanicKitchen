using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bowlFishChip : MonoBehaviour {
	
	const int bersih_state = 1;
	const int diadonin_state = 2;
	public Sprite bersih_sprite;
	public Sprite diadonin_sprite;
	int curstate;
	public List<string> isi;
	public bool readytoadon;
	
	// Use this for initialization
	void Start () {
		curstate = 1;
		readytoadon = false;
		isi = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		isBerubahState ();
	}
	
	public void prepareAdonan(){
		curstate = 2;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = diadonin_sprite;
		readytoadon = true;
	}
	
	public void masukinBahan(GameObject bahan){
		isi.Add(bahan.name);
	}

	public void diadon(GameObject bahan){
		if(readytoadon){
			AdonableScript adonscr =  bahan.GetComponent<AdonableScript>();
			if(adonscr != null){
				adonscr.adon();
			}
		}
	}
	
	public void isBerubahState(){
		bool adaTelur = false;
		//bool adaIkan = false;
		bool adaTepung = false;
		bool adaLain = false;
		
		for (int i = 0; i < isi.Count; i++) {
			switch (isi[i]){
			case "Telur": adaTelur = true; break;
			//case "Ikan": adaIkan = true; break;
			case "Flour": adaTepung = true; break;
			default : adaLain = true; break;
			}
		}
		if (adaTelur /*&& adaIkan*/ && adaTepung) {
			prepareAdonan();
		}
	}
}
