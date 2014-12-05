using UnityEngine;
using System.Collections;

public class BingoModelCreator : MonoBehaviour {

	public GameObject bingoModelObject;
	public static GameObject bingoModelInstance;
	public BingoModel bingoModel;

	// Use this for initialization
	void Awake () {
		print ("awake");
		if (!bingoModelInstance) {
			bingoModelInstance = Instantiate(bingoModelObject) as GameObject;
		}
		bingoModel = bingoModelInstance.GetComponent<BingoModel>();
		bingoModel.Reset();
	}	
}
