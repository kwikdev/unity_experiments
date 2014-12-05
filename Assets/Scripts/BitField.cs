using UnityEngine;
using System.Collections;
using System;

/**
 * Common flag storage.
 *
 * @author bseaman
 * */
public class BitField {

	protected uint _field;

	public uint field {
		get { return _field; }
		set { _field = value; }
	}

	public BitField(uint val) {
		_field = val;
	}
	
	public void setBit(int bit) {
		_field |= (1u << bit);
	}
	
	public void unsetBit(int bit) {
		_field &= ~(1u << bit);
	}
	
	public bool issetBit(int bit) {
		return (_field & (1u << bit)) > 0;
	}
	
	override public string ToString() {
		return Convert.ToString(_field, 2);
	}
}