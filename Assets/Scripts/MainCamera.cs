using UnityEngine;
using System.Collections.Generic;

public class MainCamera : MonoBehaviour {

	public GameObject card;
	private CardController cardController;

	// Use this for initialization
	void Start () {
		cardController = card.GetComponent<CardController>();
	}

	#if UNITY_EDITOR
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.3f, 60f, 30f), "Mark all")) {
			List<GameObject> spawnedCells = cardController.spawnedCells;
			foreach (GameObject cell in spawnedCells) {
				CardCellController cellController = cell.GetComponent<CardCellController>();
				cellController.OnMouseDown();
			}
		}
	}
	#endif

	// Update is called once per frame
	void Update () {
	
	}
}
