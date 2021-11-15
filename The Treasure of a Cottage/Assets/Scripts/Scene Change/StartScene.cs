using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	private Color colorT;

	// Use this for initialization
	void Start () {
		enabled = true;
		colorT = guiTexture.color;
		colorT.a = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		colorT.a -= Time.deltaTime;
		guiTexture.color = colorT;
		
		if (colorT.a < 0.0f)
		enabled = false;
	}
}
