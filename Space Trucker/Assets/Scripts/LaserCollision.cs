using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {

	public float removeDist;
	public GameObject hitExplosion;

	private GameObject player;

	// Find Player Object
	void Start () {
		player = GameObject.Find("Cockpit"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, gameObject.transform.position) > removeDist) {
			Destroy (gameObject);
		}
	}

	// Collision Detection
	void OnTriggerEnter (Collider other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.tag == "Enemy") {
			otherObject.GetComponent<EnemyBehaviour> ().health -= 25;
			Destroy (gameObject);

		} 
		else if (otherObject.tag == "Kamikaze") {
			otherObject.GetComponent<KamikazeBahaviour> ().health -= 25;
			Vector3 offset = -gameObject.GetComponent<Rigidbody>().velocity*0.25f;
			Instantiate(hitExplosion, gameObject.transform.position+offset, gameObject.transform.rotation);
			Controller.score+=10;
			Destroy (gameObject);
		}
		else if (otherObject.tag == "Player") 
		{
			Controller.inflictDamage(10);
		}
	}
}
