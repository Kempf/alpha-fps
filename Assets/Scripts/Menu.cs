using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public int MenuNum = 0;
	
	void OnGUI() {
		Rect Pos1 = new Rect (60, 20, 260, 22);
			
		if (MenuNum == 0) {
			if (GUI.Button (Pos1, "Load"))
				Application.LoadLevel("TestMap");
		}
	}
}
