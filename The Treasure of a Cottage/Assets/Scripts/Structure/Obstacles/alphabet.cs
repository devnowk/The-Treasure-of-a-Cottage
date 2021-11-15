using UnityEngine;
using System.Collections;

public class alphabet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (GameObject.FindGameObjectWithTag("Finish") != null) {
			this.GetComponent<Notice>().enabled = true;
		}else{
			this.transform.GetChild (0).GetComponent<EndScene>().enabled = true;
		}
	}
}
