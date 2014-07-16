using UnityEngine;
using System.Collections;

public class UtilityScript : MonoBehaviour {

	public MenuScript.utilities utility;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		
		GameObject.Find("Menu_Utilities").GetComponent<MenuScript>().setUtility(utility);
	}
}
