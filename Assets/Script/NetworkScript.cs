using UnityEngine;
using System.Collections;

public class NetworkScript : MonoBehaviour {

	public string IP;
	public string port;
	public bool isServer;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		IP = GUI.TextField(new Rect(10,10,100,30), IP);
		port = GUI.TextField(new Rect(110, 10, 100, 30), port);
		if(GUI.Button(new Rect(10,40,60,30),"Start Server")){
			isServer = true;
			uLink.Network.InitializeServer(3, 8000);
		}
		if(GUI.Button(new Rect(80,40,60,30),"Connect")){
			isServer = false;
			uLink.Network.Connect(IP, int.Parse(port));
		}
	}

	void uLink_OnServerInitialized(){
		Debug.Log("Server initialized");
	}

	void uLink_OnPlayerConnected(){
		Debug.Log("Player Connected");
	}
}
