using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {
	
	public float velocity = 20.0f;
	public float timer = 0.0f;

	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Vector3 direction = (player.transform.position - transform.position).normalized;
		rigidbody.AddForce(direction * velocity, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		if(timer>5.0){
			Destroy(this.gameObject);
		}
		timer += Time.deltaTime;
	}
}
