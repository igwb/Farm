using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	
	public Transform followThis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = followThis.position;
	}
}
