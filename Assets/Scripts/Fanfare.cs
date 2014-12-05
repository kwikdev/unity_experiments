using UnityEngine;
using System.Collections;

public class Fanfare : MonoBehaviour {

	public void AnimationComplete() {
		print ("AnimationComplete");
		Destroy(gameObject);
	}
}
