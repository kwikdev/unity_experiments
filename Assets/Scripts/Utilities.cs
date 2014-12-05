using UnityEngine;
using System.Collections;

public static class Utilities {

	//Generates a random set of numbers.
	public static int[] generateNumbers(int amount, int minRange, int maxRange) {
		int[] result = new int[amount];
		for (int i = 0; i < amount; ++i) {
			result[i] = Random.Range(minRange, maxRange);
		}
		
		return result;
	}

	public static Ball.BallColor numToBallColor(int num) {
		int i = (int)num / 15;
		return (Ball.BallColor)i;
	}
}
