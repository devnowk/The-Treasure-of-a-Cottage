using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	bool isEnter = false;
	GameObject objPlayer;

	// Use this for initialization
	void Start () {
		objPlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnter) {
			objPlayer.transform.Translate(new Vector3(0, -Time.deltaTime * 3, 0));
			this.transform.GetChild(0).GetComponent<EndScene>().enabled = true;
		}
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Player"){
			isEnter = true;
		}
	}
}
