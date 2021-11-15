using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	public float speed = 1;
	public float maxY = 2.6f;
	public float minY = 0.4f;

	// Use this for initialization
	void Start () {
		speed += Random.value * 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > maxY)
			speed = -speed;
		else if(transform.position.y < minY)
			speed = -speed;
		transform.position += Vector3.up * Time.deltaTime * speed;
	}
}
