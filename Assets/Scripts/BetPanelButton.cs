using UnityEngine;
using System.Collections;

public class BetPanelButton : MonoBehaviour {

	public GameObject betAmountText;
	public int betChange;
	private BingoModel model;

	// Use this for initialization
	void Start () {
		model = BingoModel.instance;
		TextMesh textMesh = betAmountText.GetComponent<TextMesh>();
		textMesh.text = model.betAmount.ToString();
	}
	
	void OnMouseDown() {
		model.betAmount += betChange;
		TextMesh textMesh = betAmountText.GetComponent<TextMesh>();
		textMesh.text = model.betAmount.ToString();
	}

}
