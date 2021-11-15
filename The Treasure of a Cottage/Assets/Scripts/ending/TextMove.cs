using UnityEngine;
using System.Collections;

public class TextMove : MonoBehaviour {

	public float Speed = 1.5f; //왕복하는 속도
	public float Trans_Time = 1.0f;//편도 시간 값 
	float timer = 0; 
	void Update () { 
		timer += Time.deltaTime; 
		if(timer < Trans_Time) { 
			transform.Translate(Vector3.down * Speed * Time.deltaTime); 
		} 
		else if(timer > Trans_Time) { 
			transform.Translate(Vector3.up * Speed * Time.deltaTime); 
			if(timer > Trans_Time * 2) { timer = 0; }
		} 
	}
}