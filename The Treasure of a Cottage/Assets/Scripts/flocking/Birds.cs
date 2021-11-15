using UnityEngine;
using System.Collections;

public class Birds : MonoBehaviour {

	public AudioClip bird;
	private float dist;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position);
		if (dist < 20.0) {
			audio.PlayOneShot(bird);
			this.GetComponent<BirdsFlock>().enabled = true;
		}
	}
}
