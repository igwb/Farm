using UnityEngine;
using System.Collections;

public class FieldScript : MonoBehaviour {

	public static float FIELD_SIZE = 0.64f;

	public GameObject dirt;
	private Vector2 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Instantiate(Vector2 position) {
		
		this.position = position;
		transform.position = GetWorldCoordsAtFieldPos(this.position);
		this.name = this.position.ToString();
	}
	
	public void createDirt() {
		
		GameObject theDirt = (GameObject)GameObject.Instantiate(dirt);
		theDirt.transform.parent = transform;
		theDirt.name = "dirt";
		theDirt.GetComponent<DirtScript>().Instantiate(position);	
		
	}
	
	public static Vector2 GetWorldCoordsAtFieldPos(Vector2 pos) {
		
		Vector2 fieldCoords = pos;
		
		fieldCoords.x = (fieldCoords.x * FIELD_SIZE) + (FIELD_SIZE / 2.0f);
		fieldCoords.y = (fieldCoords.y * FIELD_SIZE) + (FIELD_SIZE / 2.0f);
		
		return fieldCoords;
	}
	
	public static Vector2 GetFieldAtWorldCoords(Vector3 pos) {
		
		return new Vector2(Mathf.Floor (pos.x / FieldScript.FIELD_SIZE), Mathf.Floor(pos.y / FieldScript.FIELD_SIZE));
	}
}
