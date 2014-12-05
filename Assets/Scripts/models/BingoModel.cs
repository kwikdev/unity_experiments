using UnityEngine;
using System.Collections;

public class BingoModel : MonoBehaviour {

	public static BingoModel instance { get; private set; }
	private int _betAmount;
	public int betAmount {
		get { return _betAmount; }
		set { _betAmount = value >= 0 ? value : 0; }
	}
	public int winnings;

	void Awake () {
		print ("Awake");
		betAmount = 1000;
		winnings = 0;
		if (!instance) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	public void Reset() {
		betAmount = 1000;
		winnings = 0;
	}
}
