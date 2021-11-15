using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour {

	private Color colorT;

	public string nextSceneName = "";

	// Use this for initialization
	void Start () {
		colorT = guiTexture.color;
		colorT.a = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		colorT.a += Time.deltaTime;
		guiTexture.color = colorT;

		if(colorT.a > 1.0f)
			Application.LoadLevel(nextSceneName);
	}
}
