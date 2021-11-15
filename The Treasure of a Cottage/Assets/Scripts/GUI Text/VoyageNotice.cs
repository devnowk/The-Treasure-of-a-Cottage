using UnityEngine;
using System.Collections;

public class VoyageNotice : MonoBehaviour {

	public GUISkin skin;

	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void OnGUI () {
		int sw = Screen.width;
		int sh = Screen.height;

		GUI.skin = skin;
		GUI.Label(new Rect(sw/5,sh*1/7,sw*3/5,sh*1/7), "섬에 도착하시오", "Title");
		//guiText.alignment = TextAlignment.Center;

		if (timer > 30.0) {
			this.enabled = false;
		}
		timer += Time.deltaTime;
	}
}
