using UnityEngine;
using System.Collections;

	/**
	 * BingoDataVO is used for tracking bingo progress.
	 * 
	 * Member variables:
	 * id
	 * Each possible bingo in the game (12 standard,
	 * 5 extra, 4 bonus) has a unique id.
	 * 
	 * code
	 * The bingo code is a binary representation of the card
	 * cells that comprise the bingo (25 cells, 25 bits).
	 * A bit value of 0 indicates the cell at that index is
	 * not required for completing the bingo, a bit value of
	 * 1 indicates the cell is required. The code member variable
	 * should not be modified--it serves as a reference point
	 * for the bits member variable.
	 * 
	 * type
	 * Standard, extra, or bonus, as defined in BingoCardModel:
	 * BingoCardModel.BINGO_TYPE_STD
	 * BingoCardModel.BINGO_TYPE_EXTRA
	 * BingoCardModel.BINGO_TYPE_BONUS
	 * 
	 * bits
	 * This BitField is used for tracking the bingo completion.
	 * Initially, the value of the field matches the bingo code.
	 * If a cell is daubed that corresponds to one of the bits
	 * in this bingo's code, the bit is unset so that only the
	 * bits for yet-undaubed cells remain.
	 * 
	 * @author Bart Seaman
	 */
	public class NewBingoDataVO {
		public BitField bits;
		public uint code;
		public int id;
		public int type;
		
		public NewBingoDataVO(int idx, uint bingoCode, int bingoType) {
			id = idx;
			code = bingoCode;
			type = bingoType;
			bits = new BitField(code);
		}
		
		/**
		 * @return a clone of the BingoDataVO.
		 */
		public NewBingoDataVO clone() {
			NewBingoDataVO vo = new NewBingoDataVO(id, code, type);
			vo.bits.field = bits.field;
			return vo;
		}
}