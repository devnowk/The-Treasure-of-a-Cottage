using UnityEngine;
using System.Collections;

public class Notice : MonoBehaviour {

	public GUISkin skin;
	public string contents;
	public float timeLimit = 30.0f;

	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		//guiText.transform.position.x = 1.0f;
	}
	
	// Update is called once per frame
	void OnGUI () {
		int sw = Screen.width;
		int sh = Screen.height;
		
		GUI.skin = skin;
		GUI.Label(new Rect(sw/5,sh*1/7,sw*3/5,sh*1/7), contents, "Title");
		//guiText.transform.position.x -= Time.deltaTime;
		if (timer > timeLimit) {
			this.enabled = false;
		}
		timer += Time.deltaTime;
	}
}
