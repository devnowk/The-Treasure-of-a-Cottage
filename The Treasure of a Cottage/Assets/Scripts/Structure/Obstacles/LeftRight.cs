using UnityEngine;
using System.Collections;

public class LeftRight : MonoBehaviour {

	public float speed = 1;

	private float direction;

	// Use this for initialization
	void Start () {
		speed += Random.value * 30;
		direction = (transform.position.x>50) ? -1.0f : 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime * direction * speed;
	}

	void OnCollisionEnter(Collision c){
		direction = -direction;
	}
}
