using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {

	public GameObject selector;
	private GameObject cursor;
	
	private GameObject[] selectors;

	private bool selecting = false;

	private Vector2 selectionStart;
	private Vector2 currentField;

	// Use this for initialization
	void Start () {
		cursor = (GameObject) GameObject.Instantiate(selector);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
				
		currentField = FieldScript.GetFieldAtWorldCoords(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector2 fieldCoords = FieldScript.GetWorldCoordsAtFieldPos(currentField);
		
		cursor.GetComponent<Transform>().position = fieldCoords;

		if(Input.GetMouseButton(0)) {
			if(!selecting) {
				selectionStart = currentField;
			}
			
			selecting = true;
			
		} else {
			
			if(selecting) {
				endSelecting();
			}
		}
		
		if(selecting) {
			int selectionWidth = (int) Mathf.Floor(Mathf.Abs(selectionStart.x - currentField.x) + 1);
			int selectionHeight = (int) Mathf.Floor(Mathf.Abs(selectionStart.y - currentField.y) + 1);
			

			cursor.GetComponent<SelectorScript>().setModeCorner(selectionWidth == selectionHeight);

			
			cursor.transform.localScale = new Vector2(selectionWidth, selectionHeight);
			
			
			Vector2 startCoords = FieldScript.GetWorldCoordsAtFieldPos(selectionStart);
			Vector2 endCoords = fieldCoords;
			cursor.transform.position = new Vector2((startCoords.x + endCoords.x) / 2, (startCoords.y + endCoords.y) / 2);
		}
	}
	

	
	private void endSelecting() {
		selecting = false;
		cursor.transform.localScale = new Vector2(1, 1);
		
		Selection test = new Selection(selectionStart, currentField);

		Vector2[] fields = test.getVectorsInside();



		foreach (Vector2 v in fields) {
			GameObject field = GameObject.Find("World").GetComponent<FieldCreator>().placeField(v);

			if(field != null) {
				field.GetComponent<FieldScript>().createDirt();
			}
		}
	}
}
