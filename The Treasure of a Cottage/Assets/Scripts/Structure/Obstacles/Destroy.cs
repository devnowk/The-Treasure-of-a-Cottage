using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Player"){
			GetComponent<Renderer>().enabled = false;
		}
	}
}
