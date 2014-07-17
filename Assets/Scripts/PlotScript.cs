using UnityEngine;
using System.Collections;

public class PlotScript : MonoBehaviour {

	public GameObject plant;
	public GameObject defaultPlant;

	public Range growthDelayRange;

	private float growthDelay;
	private ExtendedBool readySince;

	public float water;
	public float fertilizer;

	// Use this for initialization
	void Start () {

		growthDelay = growthDelayRange.Random();
		readySince = new ExtendedBool();
	}
	
	public void Instantiate(Vector2 position) {
		
		transform.position = FieldScript.GetWorldCoordsAtFieldPos(position);
	}

	// Update is called once per frame
	void Update () {

		readySince.state = (plant == null && water > 0);

		if(readySince.state && Time.timeSinceLevelLoad - readySince.lastChange >= growthDelay) {
			Plant(defaultPlant);
		}
	}
	
	private void Plant(GameObject plantThis) {
		
		plant = (GameObject) Instantiate(plantThis);;
		plant.transform.parent = transform;
		
		PlantScript plantScript = plant.GetComponent<PlantScript>();
		
		Vector3 plantPosition = new Vector3(transform.position.x, transform.position.y - (GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2), transform.position.z);

		plant.GetComponent<Transform>().position = new Vector3(plantPosition.x + plantScript.graphicsOffsetX.Random(), plantPosition.y + plantScript.graphicsOffsetY.Random(), plantPosition.z);
		plant.GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100f);

		growthDelay = growthDelayRange.Random();
	}

	public float useWater(float amount) {

		if(water >= amount) {
			water -= amount;
			return 0;
		} else {
			float notAvailable = amount - water;
			water = 0;
			return notAvailable;
		}


	}
}
