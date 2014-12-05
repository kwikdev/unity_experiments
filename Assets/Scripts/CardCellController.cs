using UnityEngine;
using System.Collections.Generic;

public class CardCellController : MonoBehaviour {

	public GameObject daub;
	public GameObject card;
	private GameObject _spawnedDaub;

	private int _number;
	public int number
	{
		set { 
			_number = value;
			TextMesh textMesh = gameObject.GetComponent<TextMesh>();
			textMesh.text = _number.ToString();
		}
		get { return _number; }
	}
	private int _index;
	public int index
	{
		set { _index = value; }
		get { return _index; }
	}
	
	// Player has clicked the mouse button
	public void OnMouseDown () {
		Debug.Log("OnMouseDown");
		NewBallHopper ballHopper = card.GetComponent<CardController>().ballHopper;
		if (ballHopper.hasCalledBall(_number)) {
	//		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	//		Vector3 localPosition = transform.InverseTransformPoint(mousePosition);
	//		Debug.Log(mousePosition.x + " " + mousePosition.y + " " + localPosition.x + " " + localPosition.y);
			_spawnedDaub = Instantiate(daub) as GameObject;
			_spawnedDaub.transform.parent = transform;
			_spawnedDaub.transform.localPosition = new Vector3();
			//notify the card the cell has been daubed
			CardController cardController = transform.parent.gameObject.GetComponent<CardController>();
			cardController.onDaub(this);
			gameObject.collider2D.enabled = false;
		} else {
			Debug.Log("Incorrect number");
		}
	}

	// Update is called once per frame
/*	void Update () {
		if (Input.GetMouseButton(0)) {		//left click
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collider = Physics2D.OverlapPoint(mousePosition);
			
			print(mousePosition.x + "," + mousePosition.y);

			if (collider){
				print("Clicked "+collider.transform.name+" x"+collider.transform.position.x+" y "+collider.transform.position.y);   
			}
		}
	} */
}
