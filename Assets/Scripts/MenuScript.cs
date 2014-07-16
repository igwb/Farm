using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public enum utilities {
		mower,
		wateringcan,
		seeds,
		spade
	}


	public utilities activeUtility;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setUtility(utilities util) {
		
		activeUtility = util;
		
		GameObject.Find("BuildingGrid").GetComponent<SpriteRenderer>().enabled = (util == utilities.spade);
	}
	
	public utilities getActiveUtility() {
		return activeUtility;
	}
}
