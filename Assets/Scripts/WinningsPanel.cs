using UnityEngine;
using System.Collections;

public class WinningsPanel : MonoBehaviour {

	public GameObject winningsTxt;
	private BingoModel model;
	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		model = BingoModel.instance;
		textMesh = winningsTxt.GetComponent<TextMesh>();
		textMesh.text = model.winnings.ToString();
	}
}
