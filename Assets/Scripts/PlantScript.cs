using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour {

	private PlotScript parent;

	public string plantName;
	public Sprite[] sprites;
	public float growthTime;
	
	private ExtendedBool drySince;

	public float waterNeedGrowing = 1;
	public float waterNeedLiving = 0.25f;
	public float dryDieTime = 10;
	public float totalFertilizerNeed;

	public Range graphicsOffsetX;
	public Range graphicsOffsetY;
	
	private float lifeLength;

	private float growthPercentage;

	void Start () {
		
		parent = (PlotScript) GetComponentInParent<PlotScript>();
		lifeLength = 0;
		drySince = new ExtendedBool();
	}
	
	void Update () {
		
		age(Time.deltaTime);

		GetComponent<SpriteRenderer>().sprite = sprites[(int)((sprites.Length - 1) * growthPercentage)];
	}

	private void age(float time) {
		lifeLength += time;

		drySince.state = (parent.useWater(waterNeedLiving * time) > 0);

		if(drySince.state && growthPercentage < 1) {
			drySince.state = parent.useWater(waterNeedGrowing * time) > 0;
		}

		if(!drySince.state) {
			growthPercentage = Mathf.Min(1, (time / growthTime) + growthPercentage);
		}

		if(drySince.state && Time.timeSinceLevelLoad - drySince.lastChange >= dryDieTime) {
			GameObject.Destroy(gameObject);
		}
	}
}
