using UnityEngine;
using System.Collections;

public class Birds : MonoBehaviour {

	public AudioClip bird;
	private float dist;
	// Use this for initialization
	void Start () {
	
	}
	
	// 새는 가까이 가면 날아가는 행동을 한다. 따라서 우선 BirdsFlock.cs를 enabled false로 설정하고 
	// 프리팹에 Birds.cs라는 코드를 넣어서 플레이어와의 거리를 측정하고 20보다 가까우면 
	// BirdsFlock.cs를 다시 enabled true하여 새가 날라가게하여 새의 움직임을 실제처럼 표현하였다.
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position);
		if (dist < 20.0) {
			audio.PlayOneShot(bird);
			this.GetComponent<BirdsFlock>().enabled = true;
		}
	}
}
