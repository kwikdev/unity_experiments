using UnityEngine;
using System.Collections.Generic;

public class Ball : MonoBehaviour {

	public enum BallColor { Red, Orange, Green, Blue, Purple };
	public List<Sprite> ballSprites;
	private Animator _anim;
	private int _rollOutHash = Animator.StringToHash("RollOut");
	private float _lifeSpan;
	private BallHopper ballHopper;

	public BallColor color {
		set {
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			int index = (int)value;
			renderer.sprite = ballSprites[index];
		}
	}
	
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
		_lifeSpan = Time.time + 3.0f;	//3 seconds until ball rolls out
	}

	public void endRollOut()
	{
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		//AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);	//Get information from the current animator state
		if (Time.time >= _lifeSpan) {
			_anim.SetTrigger(_rollOutHash);
		}
	}
}
