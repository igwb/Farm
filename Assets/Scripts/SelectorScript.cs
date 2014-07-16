using UnityEngine;
using System.Collections;

public class SelectorScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	public void setModeCorner(bool cornerMode) {
		if(cornerMode) {
			GetComponent<SpriteRenderer>().color = Color.gray;
		} else {
			GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
