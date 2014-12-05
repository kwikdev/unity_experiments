using UnityEngine;
using System.Collections.Generic;

public class CardNumberGenerator : MonoBehaviour {

	public List<GameObject> cards = new List<GameObject>();

	// Use this for initialization
	void Start () {
		foreach (GameObject card in cards) {
			CardController cardController = card.gameObject.GetComponent<CardController>();
			int[] numbers = Utilities.generateNumbers(25, 1, 75);
			cardController.init(numbers);
		}
	}
}
