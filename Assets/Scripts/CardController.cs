using UnityEngine;
using System.Collections.Generic;

public class CardController : MonoBehaviour {

	public GameObject cardCell;
	public GameObject ballHopperGO;
	public GameObject bingoFanfare;
	public NewBallHopper ballHopper {
		get { return ballHopperGO.GetComponent<NewBallHopper>(); }
	}
	private const int _CARD_SIZE = 5;
	private const float _CELL_SIZE = 0.55f;
	private List<GameObject> _spawnedCells;
	public List<GameObject> spawnedCells {
		get { return _spawnedCells; }
	}
	private List<GameObject> daubedCells = new List<GameObject>();
	private uint[] daubed = new uint[25];
	private NewCardModel cardModel;

	// Use this for initialization
	void Start () {
		_spawnedCells = new List<GameObject>();
	}

	public void init(int[] numbers) {
		daubed[Mathf.FloorToInt(_CARD_SIZE * _CARD_SIZE * 0.5f)] = 1;
		for (int i = 0; i < _CARD_SIZE * _CARD_SIZE; ++i) {
			//skip free cell
			if (i == Mathf.FloorToInt(_CARD_SIZE * _CARD_SIZE * 0.5f))
				continue;
			GameObject spawnedCell = Instantiate(cardCell) as GameObject;
			spawnedCell.transform.parent = transform;
			spawnedCell.transform.localPosition = new Vector3(-1.1f + (i % _CARD_SIZE) * _CELL_SIZE, 0.9f - (i / _CARD_SIZE) * _CELL_SIZE, 0f);
			//set the number/index for the cell
			CardCellController cellController = spawnedCell.gameObject.GetComponent<CardCellController>();
			cellController.number = numbers[i];
			cellController.index = i;
			cellController.card = gameObject;
			spawnedCells.Add(spawnedCell);
		}
		cardModel = new NewCardModel();
		cardModel.clearNumbers();
	}

	public void onDaub(CardCellController cell) {
		//check bingos
		Debug.Log("onDaub: " + cell.index);

		cardModel.setDaubed(cell.index);

		int bingoCount 		= 0,
			highestBingo 	= 0;
		int oldCount				 = cardModel.numBingos;
		List<NewBingoDataVO> bingoLines = cardModel.getBingoLines();

		foreach (NewBingoDataVO bdvo in bingoLines) 
		{
			if (bdvo.type == NewCardModel.BINGO_TYPE_STD)
			{
				bingoCount++;
			}
		}

		Debug.Log("oldCount: " + oldCount);
		if (bingoCount > oldCount)
		{
			Debug.Log("Got a new bingo: " + bingoCount + " " + oldCount);
			// if we increased the number of bingos on the card, announce it
			cardModel.numBingos = bingoCount;
			
			if (bingoCount > highestBingo)
			{
				highestBingo = bingoCount;
			}

			BingoModel.instance.winnings += (bingoCount + 1) * BingoModel.instance.betAmount;

			print (bingoCount);
			switch (bingoCount)
			{
				case 0:
					break;
				case 1: default:
					SpriteRenderer renderer = GetComponent<SpriteRenderer>();
					GameObject spawnedFanfare = Instantiate(bingoFanfare) as GameObject;
					spawnedFanfare.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
					print(transform.localPosition.x + "," + spawnedFanfare.transform.localPosition.x);
					print(renderer.sprite.bounds.size.x + "," + renderer.sprite.bounds.size.y);
	//				soundToPlay = SOUND_INDEX_BINGO;
					break;
/*				case 2:
	//				soundToPlay = SOUND_INDEX_DOUBLE_BINGO;
					break;
				case 3:
	//				soundToPlay = SOUND_INDEX_TRIPLE_BINGO;
					break;
				default:
	//				soundToPlay = SOUND_INDEX_MEGA_BINGO;
					break;
*/			} //switch
			
//			bingoWinAmount = card.bingoWinnings;
//			if (bingoWinAmount > bestBingoWinAmount)
//			{
//				bestBingoWinAmount = bingoWinAmount;
//			}
		}
	}
}
