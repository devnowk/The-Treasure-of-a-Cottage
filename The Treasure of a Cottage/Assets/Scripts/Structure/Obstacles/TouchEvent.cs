using UnityEngine;
using System.Collections;

public class TouchEvent : MonoBehaviour {

	public AudioClip touch;
	public Transform respawnPoint;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Player"){
			audio.PlayOneShot(touch);
			player.transform.position = respawnPoint.position;
			this.GetComponent<Notice>().enabled = true;
		}
	}

	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "Player"){
			audio.PlayOneShot(touch);
			player.transform.position = respawnPoint.position;
			this.GetComponent<Notice>().enabled = true;
		}
	}
}
