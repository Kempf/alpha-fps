using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Texture CrosshairImage;

	void OnGUI() {

		float xMin = (Screen.width / 2) - (CrosshairImage.width / 9);
		float yMin = (Screen.height / 2) - (CrosshairImage.height / 9);
		GUI.DrawTexture(new Rect(xMin, yMin, CrosshairImage.width/4, CrosshairImage.height/4), CrosshairImage);

	}
}
