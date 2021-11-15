using UnityEngine;
using System.Collections;

public class CottageNotice : MonoBehaviour {
	
	public GUISkin skin;
	
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
		GUI.Label(new Rect(sw/5,sh*1/7,sw*3/5,sh*1/7), "길을 따라 오두막집으로 가시오", "Title");
		//guiText.transform.position.x -= Time.deltaTime;
		if (timer > 30.0) {
			this.enabled = false;
		}
		timer += Time.deltaTime;
	}
}
