using UnityEngine;
using System.Collections;

public class EndingCredit : MonoBehaviour {

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
		GUI.Label(new Rect(sw*1/10,sh*1/71,sw*4/5,sh*6/7), "축하합니다!!\n" +
			"당신은 보물을 모두 찾았습니다\n 보물은 바로 IT MEDIA!\n " +
			"당신은 이제 아미몬이 될 수 있습니다!\n 멋져요!", "Credit");
		//guiText.alignment = TextAlignment.Center;
		if (timer >= 4.0)
			this.enabled = true;
		//if(timer < 4.0)
		//	this.enabled = false;

		if (timer > 13.0) {
			this.enabled = false;
		}
		timer += Time.deltaTime;
	}
}