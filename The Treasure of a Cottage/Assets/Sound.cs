using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public AudioClip sound;
	private float timer = 0.0f;
	private bool isTouch = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isTouch){
			timer += Time.deltaTime;
			if(timer > 1.0)
				Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player") {
			audio.PlayOneShot(sound);
			isTouch = true;
		}
	}
}
