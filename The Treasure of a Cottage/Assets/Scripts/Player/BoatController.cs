using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour {

	public float speed = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.inputString != "") { // 아무 키나 입력 받는다.
			transform.Translate(Vector3.forward * Time.deltaTime * speed);   
		}	
	}
}
