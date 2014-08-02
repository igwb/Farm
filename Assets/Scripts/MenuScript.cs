using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public float activeY;
	public float inactiveY;

	public enum utilities {
		mower,
		wateringcan,
		seedbag,
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
		
		foreach(Transform t in GetComponentInChildren<Transform>()) {
			t.position = new Vector2(t.position.x, inactiveY);
		}

		Transform active = transform.Find(util.ToString());
		active.position = new Vector2(active.position.x, activeY);
	}
	
	public utilities getActiveUtility() {
		return activeUtility;
	}
}
