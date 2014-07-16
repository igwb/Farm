using UnityEngine;
using System.Collections;

public class DirtScript : MonoBehaviour {

	public GameObject plant;

	public GameObject defaultPlant;
	public float minGrowthDelay = 10;
	public float maxGrowthDelay = 20;


	private float currentGrowthDelay;
	private float emptySince = -1;

	// Use this for initialization
	void Start () {
		currentGrowthDelay = Random.Range(minGrowthDelay, maxGrowthDelay);
	}
	
	// Update is called once per frame
	void Update () {
		if(plant == null) {
			if(emptySince == -1) {
				emptySince = Time.timeSinceLevelLoad;
			} else if(Time.timeSinceLevelLoad - emptySince >= currentGrowthDelay) {
				Plant(defaultPlant);
			}
		}
	}
	
	
	public void Instantiate(Vector2 position) {
		
		transform.position = FieldScript.GetWorldCoordsAtFieldPos(position);
	}
	
	private void Plant(GameObject plantThis) {

		
		
		GameObject thePlant = (GameObject) Instantiate(plantThis);
		//thePlant.GetComponent<Transform>().position = transform.position;
		
		plant = thePlant;
		plant.transform.parent = transform;
		
		PlantScript plantScript = plant.GetComponent<PlantScript>();
		
		plant.GetComponent<Transform>().position = new Vector3(Random.Range(-1f * plantScript.maxGraphicsOffsetX, plantScript.maxGraphicsOffsetX) + transform.position.x, Random.Range(0, plantScript.maxGraphicsOffsetY) + transform.position.y - (GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2), 0);
		plant.GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100f);
		emptySince = -1;
		currentGrowthDelay = Random.Range(minGrowthDelay, maxGrowthDelay);
	}
}
