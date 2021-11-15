using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public AudioClip spawn;
	public GameObject spike;

	private float timer = 0.0f;
	private Vector3 rot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rot = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
		timer += Time.deltaTime;
		if(timer > 2.0f){
			timer = 0.0f;
			audio.PlayOneShot(spawn);
			Instantiate(spike, transform.position, Quaternion.LookRotation (rot));
		}
	}
}