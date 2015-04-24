﻿using UnityEngine;
using System.Collections;

public class fryingPanFishChip : MonoBehaviour {
	
	const int bersih_state = 1;
	const int diminyakin_state = 2;
	const int kentanggoreng_state = 3;
	const int fishchipgoreng_state = 4;
	public Sprite bersih_sprite;
	public Sprite diminyakin_sprite;
	public Sprite kentanggoreng_sprite;
	public Sprite fishchipgoreng_sprite;
	int curstate;
	ArrayList isi;
	
	// Use this for initialization
	void Start () {
		curstate = bersih_state;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void diminyakin(){
		curstate = diminyakin_state;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = diminyakin_sprite;
	}
	
	public void masukinBahan(GameObject bahan){
		isi.Add(bahan.name);
	}
	
	public void gorengKentang(){
		bool adaKentang = false;
		bool adaLain = false;
		
		for (int i = 0; i < isi.Count; i++) {
			switch (isi[i].ToString()){
			case "Kentang": adaKentang = true; break;
			default : adaLain = true; break;
			}
		}
		
		if (adaKentang && curstate == diminyakin_state) {
			curstate = kentanggoreng_state;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = kentanggoreng_sprite;
		}
	}
	
	public void gorengFishChip(){
		bool adaIkan = false;
		bool adaLain = false;
		
		for (int i = 0; i < isi.Count; i++) {
			switch (isi[i].ToString()){
			case "Ikan": adaIkan = true; break;
			default : adaLain = true; break;
			}
		}
		
		if (adaIkan && curstate == diminyakin_state) {
			curstate = fishchipgoreng_state;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = kentanggoreng_sprite;
		}
	}
	
	public void ambilKentang(){
		curstate = bersih_state;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = bersih_sprite;
		isi = new ArrayList ();
	}
	
	public void ambilFishChip(){
		curstate = bersih_state;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = bersih_sprite;
		isi = new ArrayList ();
	}
	
	
}
