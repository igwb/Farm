using UnityEngine;
using System.Collections;

public class PlotScript : MonoBehaviour {

	public GameObject plant;
	public GameObject defaultPlant;

	public Range growthDelayRange;

	private float growthDelay;
	private float emptySince = -1;

	// Use this for initialization
	void Start () {

		Debug.Log(growthDelayRange.min + "|" + growthDelayRange.max);
		growthDelay = growthDelayRange.Random();
	}
	
	public void Instantiate(Vector2 position) {
		
		transform.position = FieldScript.GetWorldCoordsAtFieldPos(position);
	}

	// Update is called once per frame
	void Update () {
		if(plant == null) {
			if(emptySince == -1) {
				emptySince = Time.timeSinceLevelLoad;
			} else if(Time.timeSinceLevelLoad - emptySince >= growthDelay) {
				Plant(defaultPlant);
			}
		}
	}
	
	private void Plant(GameObject plantThis) {
		
		plant = (GameObject) Instantiate(plantThis);;
		plant.transform.parent = transform;
		
		PlantScript plantScript = plant.GetComponent<PlantScript>();
		
		Vector3 plantPosition = new Vector3(transform.position.x, transform.position.y - (GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2), transform.position.z);

		plant.GetComponent<Transform>().position = new Vector3(plantPosition.x + plantScript.graphicsOffsetX.Random(), plantPosition.y + plantScript.graphicsOffsetY.Random(), plantPosition.z);
		plant.GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100f);
		emptySince = -1;
		growthDelay = growthDelayRange.Random();
	}
}
