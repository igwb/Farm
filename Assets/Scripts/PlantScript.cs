using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour {

	public string plantName;
	public Sprite[] sprites;
	public float growthTime;
	
	public float maxGraphicsOffsetX;
	public float maxGraphicsOffsetY;
	
	private float plantTime;

	// Use this for initialization
	void Start () {
		plantTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<SpriteRenderer>().sprite = sprites[(int)((sprites.Length - 1) * Mathf.Min(1, (Time.timeSinceLevelLoad - plantTime) / growthTime))];
	}
}
