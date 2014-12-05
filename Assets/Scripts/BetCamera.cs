using UnityEngine;
using System.Collections;

public class BetCamera : MonoBehaviour {

	public GUIStyle playButton;

	// Use this for initialization
	void Start () {
	
	}

#if UNITY_EDITOR
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 100f, 100f), "Play")) {
			Application.LoadLevel("BingoCard");
		}
	}
#endif
}
