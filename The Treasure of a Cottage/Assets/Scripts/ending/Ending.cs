using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

	public GUISkin skin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")){
			this.GetComponent<EndScene>().enabled = true;
		}
	}
	
	void OnGUI(){
		GUI.skin = skin;
		
		int sw = Screen.width;
		int sh = Screen.height;
		
		GUI.Label (new Rect(0, sh/2, sw, sh/2), "Press Space To Replay", "MainTitle");
	}
}