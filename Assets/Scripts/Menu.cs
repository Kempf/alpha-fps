using UnityEngine;
using System.Collections;

// TODO: Move all the network code to network manager
// Use GameObject.Find("ObjectName").GetComponent<YourScriptName>().yourPublicVariable; to access

public class Menu : MonoBehaviour {
	
	public int MenuNum = 0;
	
	public string IPAddress = "Enter IP Address";
	
	public int ConNum = 4;
	
	void StartServer(){
		Network.InitializeServer (ConNum, 25565, false);
		Network.sendRate = 15;
		Debug.Log ("Server Started");
	}
	
	void ConnectToServer () {
		Network.Connect(IPAddress, 25565);
		MenuNum = 2;	
	}
	
	void OnGUI() {
		Rect Pos1 = new Rect (60, 20, 260, 22);
		Rect Pos2 = new Rect (60, 50, 240, 22);
		Rect Pos3 = new Rect (60, 80, 220, 22);
		Rect Pos4 = new Rect (60, 110, 200, 22);
		
		if (MenuNum == 0) {
			if (GUI.Button (Pos1, "Join Server"))
				MenuNum = 1;
			
			if (GUI.Button (Pos2, "Host Server"))
				StartServer ();
			
			if (GUI.Button (Pos3, "Settings" ))
				// IT'S A TRAP
				// MenuNum = 3;
			
			if (GUI.Button (Pos4, "Exit"))
				Application.Quit ();      
		}
		
		if (MenuNum == 1) {
			
			IPAddress = GUI.TextArea (Pos1, IPAddress); 
			
			if (GUI.Button (Pos2, "Join Server"))
				ConnectToServer();
			
			if (GUI.Button (Pos3, "Back"))
				MenuNum = 0;     
			
		}
		
		if (MenuNum == 2) {
					if (Network.peerType == NetworkPeerType.Client) {
						Debug.Log ("Connected");

					if (GUI.Button (Pos1, "Start Game"))
						Application.LoadLevel ("TestMap");
					
					if (GUI.Button (Pos2, "Back"))
						MenuNum = 1;
					}
		}
	}
}
