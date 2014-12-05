using UnityEngine;
using System.Collections;

public class BallHopper : MonoBehaviour {

	private float _callBallTime;
	private int _currentBall;
	public int currentBall {
		get { return _balls[_currentBall]; }
	}
	private int[] _balls;
	public int[] balls {
		get { return _balls; }
	}

	//Returns true if the passed ballNum has been called.
	public bool hasCalledBall(uint ballNum) {
		for (uint i = 0; i < _currentBall; ++i) {
			if (_balls[i] == ballNum)
				return true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		_callBallTime = 0.0f;
		_currentBall = 0;
		_balls = Utilities.generateNumbers(100, 1, 75);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _callBallTime) {
			++_currentBall;
			_callBallTime = Time.time + 0.01f;
			Debug.Log("current ball: " + _balls[_currentBall].ToString());
			//spawn ball
		}
	}
}
