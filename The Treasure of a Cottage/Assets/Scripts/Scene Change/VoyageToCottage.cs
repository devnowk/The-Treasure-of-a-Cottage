using UnityEngine;
using System.Collections;

public class VoyageToCottage : MonoBehaviour {
	
	private bool isChangeScene = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(isChangeScene) // after OnTriggerEnter
			this.GetComponent<EndScene>().enabled = true;
	}

	void OnTriggerEnter (Collider trigger){
		if(trigger.gameObject.tag == "Player"){
			isChangeScene = true;
		}
	}
}
