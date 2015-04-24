using UnityEngine;
using System.Collections;

public class BowlScript : MonoBehaviour {
	
	const int bersih_state = 1;
	const int diadonin_state = 2;
	public Sprite bersih_sprite;
	public Sprite diadonin_sprite;
	int curstate;
	ArrayList isi;
	
	// Use this for initialization
	void Start () {
		curstate = 1;
		isi = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		isBerubahState ();
	}
	
	public void diadonin(){
		curstate = 2;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = diadonin_sprite;
	}
	
	public void masukinBahan(GameObject bahan){
		isi.Add(bahan.name);
	}
	
	public void isBerubahState(){
		bool adaTelur = false;
		bool adaLada = false;
		bool adaGaram = false;
		bool adaSusu = false;
		bool adaLain = false;
		
		for (int i = 0; i < isi.Count ; i++) {
			switch (isi[i].ToString()){
			case "Telur": adaTelur = true; break;
			case "Lada": adaLada = true; break;
			case "Garam": adaGaram = true; break;
			case "Susu": adaSusu = true; break;
			default : adaLain = true;break;
			}
		}
		if (adaTelur && adaLada && adaGaram && adaSusu) {
			diadonin ();
		}
	}
}
