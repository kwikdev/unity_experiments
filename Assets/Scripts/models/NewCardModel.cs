using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewCardModel {
	public const int BINGO_TYPE_STD		= 0;
	// PRE-COMPUTED BINGO CODES
	// (Note #1: the ordering is B1, B2, B3 ... O4, O5 from RIGHT to LEFT to support bit storage indexing)
	// (Note #2: the center position is always 0--it's the free square)
	// standard patterns
	private static uint[] bingoCodesStd = {
	                                                            1082401	// 0000100001000010000100001	1st row
	                                                            ,  2164802	// 0001000010000100001000010	2nd row
	                                                            ,  4325508	// 0010000100000000010000100	3rd row
	                                                            ,  8659208	// 0100001000010000100001000	4th row
	                                                            , 17318416	// 1000010000100001000010000	5th row
	                                                            ,       31	// 0000000000000000000011111	"B" col
	                                                            ,      992	// 0000000000000001111100000	"I" col
	                                                            ,    27648	// 0000000000110110000000000	"N" col
	                                                            ,  1015808	// 0000011111000000000000000	"G" col
	                                                            , 32505856	// 1111100000000000000000000	"O" col
	                                                            , 17039425	// 1000001000000000001000001	diag down
	                                                            ,  1114384	// 0000100010000000100010000	diag up
	};


	protected BitField _daubed;
	private List<NewBingoDataVO> _bingoDataVOs;
	private int _numBingos;
	public int numBingos {
		get { return _numBingos; }
		set { _numBingos = value; }
	}

	/**
	 * Safe getter for BingoDataVO vector. If necessary, inits vector before returning.
	 * @return Vector.<BingoDataVO>
	 */
	protected List<NewBingoDataVO> bingoDataVOs {
		get {
			if (_bingoDataVOs == null) {
				// create vector
				_bingoDataVOs = new List<NewBingoDataVO>();
				int i;
				int idOffset;
				// populate with standard bingo codes
				uint[] codes = bingoCodesStd;
				for (i = 0; i < codes.Length; ++i) {
					// use code index for the BingoDataVO id (id is used to match the vo to the bingo lines art)
					_bingoDataVOs.Add(new NewBingoDataVO(i, codes[i], BINGO_TYPE_STD));
				}
			}
			Debug.Log("bingoDataVOS:" + _bingoDataVOs.ToString());
		
		return _bingoDataVOs;
		}
	}

	public void clearNumbers() {
		_daubed 			= new BitField(0);
		_daubed.setBit(12);	// center square

		_numBingos 		= 0;
	}

	public void setDaubed(int index) {
		_daubed.setBit(index);

		// update bingo progress
		foreach (NewBingoDataVO bd in bingoDataVOs) {
			bd.bits.unsetBit(index);
		}
	}

	/**
	 * @return a Vector of BingoDataVOs for bingos that have been fully daubed
	 */
	public List<NewBingoDataVO> getBingoLines() {
		var matches = new List<NewBingoDataVO>();
		foreach (NewBingoDataVO bd in bingoDataVOs) {
			// a value of 0 indicates there are no more cells to daub to get the bingo
			if (bd.bits.field == 0) {
				matches.Add(bd);
			}
		}
		return matches;
	}

}
