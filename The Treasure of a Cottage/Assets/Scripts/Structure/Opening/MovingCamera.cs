using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {
	public float timer;
	public float speed;
	// Use this for initialization
	void Start () {
		timer = 60.0f;
		speed = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer > 0.0) {
			if(transform.position.z > -1000 && transform.position.z < 0){
				transform.Translate(Vector3.right * Time.deltaTime * speed);
			}
			if(timer < 25.0)
				transform.GetChild(0).GetComponent<Opening>().enabled = true;
		}
	}
}