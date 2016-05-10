using UnityEngine;
using System.Collections;

public class KamikazeBahaviour: MonoBehaviour {

	public float removeDist;
	public float health = 100;
	public GameObject explosion;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Cockpit"); 
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.z < player.transform.position.z - removeDist) {
			Destroy (gameObject);
		}

		Vector3 toPlayer = player.transform.position - gameObject.transform.position;
		Quaternion lookDirection = Quaternion.LookRotation(toPlayer);

		gameObject.transform.rotation = lookDirection;
		gameObject.GetComponent<Rigidbody> ().velocity = gameObject.transform.forward * 65;

		if (health <= 0) {
			Destroy (gameObject);
			Controller.score+=190;
			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);
		}
	}

	// Collision Detection
	void OnTriggerEnter (Collider other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.tag == "Player") 
		{
			Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
			Controller.health-=10;
			Controller.inflictDamage(5);
		}
	}
}
