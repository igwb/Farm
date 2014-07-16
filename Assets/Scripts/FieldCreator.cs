using UnityEngine;
using System.Collections;

public class FieldCreator : MonoBehaviour {

	public GameObject field;


	private ArrayList fields;

	// Use this for initialization
	void Start () {
		fields = new ArrayList();
	}
	
	public GameObject placeField(Vector2 position) {
	
		if(!fields.Contains(position)) {
			GameObject theField = (GameObject)GameObject.Instantiate(field);
			theField.transform.parent = transform;
			theField.GetComponent<FieldScript>().Instantiate(position);
			
			fields.Add(position);
			
			return theField;
		} else {
		
			return null;
		}
	}
}
