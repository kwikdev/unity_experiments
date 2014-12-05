using UnityEngine;
using System.Collections.Generic;

public class NewBallHopper : MonoBehaviour {

	public GameObject ballPrefab;
	public GameObject winningsPrefab;
//	private List<GameObject> _spawnedBalls = new List<GameObject>();
	private float _callBallTime;
	private int _currentBall;
	private int[] _balls;
	private float _winningsDelay;

	public int currentBall {
		get { return _balls[_currentBall]; }
	}
	public int[] balls {
		get { return _balls; }
	}

	//Returns true if the passed ballNum has been called.
	public bool hasCalledBall(int ballNum) {
		for (uint i = 0; i < _currentBall; ++i) {
			if (_balls[i] == ballNum)
				return true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		//GameObject model = GameObject.Find("BingoModelObject");
		//print ("BingoModel:" + model.GetComponent<BingoModel>().betAmount);
		_callBallTime = 0.0f;
		_winningsDelay = 6.0f;
		_currentBall = 0;
		_balls = Utilities.generateNumbers(75, 1, 75);
		_callBallTime = 0.01f;
		Invoke("CallBall", _callBallTime);
	}

	// Update is called once per frame
	void CallBall() {
		++_currentBall;
		_callBallTime = 0.1f;
		print (currentBall);
		//spawn ball
		GameObject spawnedBall = Instantiate(ballPrefab) as GameObject;
		TextMesh textMesh = spawnedBall.transform.GetChild(0).GetComponent<TextMesh>();
		textMesh.text = _balls[_currentBall].ToString();
		Ball ball = spawnedBall.GetComponent<Ball>();
		ball.color = Utilities.numToBallColor(_balls[_currentBall]);
		if (_currentBall < _balls.Length - 1)
			Invoke("CallBall", _callBallTime);
		else
			Invoke("ShowWinnings", _winningsDelay);
	}

	private void ShowWinnings() {
		print ("show winnings");
		GameObject winningsPanel = Instantiate(winningsPrefab) as GameObject;
		winningsPanel.transform.position = transform.position;
	}
}
