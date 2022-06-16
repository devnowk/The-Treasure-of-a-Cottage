using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    //Explosion Effect
    public GameObject Explosion;

    public float Speed = 1.0f;
    public float LifeTime = 3.0f;
    //public int damage = 50;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.position += 
			transform.forward * Speed * Time.deltaTime;       
    }

	public AudioClip touch;
    void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.tag == "Player"){
			audio.PlayOneShot(touch);
            // bullet을 맞으면 health가 깎이지 않고 respawn point로 이동하게된다.
			collision.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
			this.GetComponent<Notice>().enabled = true;
		}
        //ContactPoint contact = collision.contacts[0];
        //Instantiate(Explosion, contact.point, Quaternion.identity);
        Destroy(gameObject);
    }
}