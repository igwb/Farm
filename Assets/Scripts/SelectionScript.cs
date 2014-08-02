using UnityEngine;
using System.Collections;

public class SelectionScript : MonoBehaviour {

	public GameObject selectorPrefab;
	private GameObject cursor;

	private Selection sel = null;
	private Vector2 selectionStart;
	private Vector2 currentField;

	// Use this for initialization
	void Start () {

		cursor = (GameObject) GameObject.Instantiate(selectorPrefab);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		currentField = FieldScript.GetFieldAtWorldCoords(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector2 fieldWorldCoords = FieldScript.GetWorldCoordsAtFieldPos(currentField);
		
		cursor.GetComponent<Transform>().position = fieldWorldCoords;

		if(Input.GetMouseButton(0)) {
			if(sel == null) {
				sel = new Selection(currentField, currentField);
			}
			
		} else {
			
			if(sel != null) {
				endSelecting();
			}
		}

		
		if(sel != null) {
			sel.setEnd(currentField);

			Vector2 startCoords = FieldScript.GetWorldCoordsAtFieldPos(sel.getStart());
			Vector2 endCoords = FieldScript.GetWorldCoordsAtFieldPos(sel.getEnd());

			cursor.transform.localScale = new Vector2(sel.getWidth(), sel.getHeight());
			cursor.transform.position = new Vector2((startCoords.x + endCoords.x) / 2, (startCoords.y + endCoords.y) / 2);

			cursor.GetComponent<SelectionRenderer>().setModeCorner(sel.isSquare());
		}
	}
	
	private void actionSpade(Vector2[] selectedFields) {
		foreach (Vector2 v in selectedFields) {
			GameObject field = GameObject.Find("World").GetComponent<FieldCreator>().placeField(v);

			if(field != null) {
				field.GetComponent<FieldScript>().createDirt();
			}
		}
	}
	
	private void actionWateringcan(Vector2[] selectedFields) {
		foreach (Vector2 v in selectedFields) {
			GameObject field = GameObject.Find(v.ToString());

			if(field != null) {
				field.GetComponentInChildren<PlotScript>().water += 25;
			}
		}
	}
	
	private void endSelecting() {
		
		Vector2[] selectedFields = sel.getVectorsInside();

		switch (GameObject.Find("Menu_Utilities").GetComponent<MenuScript>().getActiveUtility().ToString()) {
			case "mower":
			break;
			case "spade":
				actionSpade(selectedFields);
			break;
			case "wateringcan":
				actionWateringcan(selectedFields);
			break;
			case "seedbag":
			break;
		}

	
		cursor.transform.localScale = new Vector2(1, 1);
		sel = null;
	}
}
