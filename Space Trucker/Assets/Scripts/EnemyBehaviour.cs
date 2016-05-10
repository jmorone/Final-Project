using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float removeDist;
	public float health = 25;
	public GameObject explosion;

	public GameObject laser;
	public float laserSpread = 2F;
	private bool right = false;

	private GameObject player;

	public float attackDelay = 0.75f;
	private float lastAttackTime = 0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Cockpit"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.z < player.transform.position.z - removeDist) {
			Destroy (gameObject);
		}

		lastAttackTime += Time.deltaTime;
		if (lastAttackTime > attackDelay) {
			Vector3 projectileSpawn;
			Quaternion projectileRotation;
			float xSpin = Random.Range (-laserSpread, laserSpread);
			float ySpin = Random.Range (-laserSpread, laserSpread);
			float zSpin = Random.Range (-laserSpread, laserSpread);
			Quaternion offSet = Quaternion.Euler(xSpin, ySpin, zSpin );

			Vector3 toPlayer = player.transform.position - gameObject.transform.position;
			projectileRotation = Quaternion.LookRotation(toPlayer)*offSet;

			if (right) {
				projectileSpawn = gameObject.transform.position + gameObject.transform.right + gameObject.transform.forward*2;
			} 
			else {
				projectileSpawn = gameObject.transform.position + gameObject.transform.right * -1 + gameObject.transform.forward*2;
			}
			GameObject projectile = (GameObject)Instantiate(laser, projectileSpawn, projectileRotation);
			projectile.GetComponent<Renderer>().material.SetColor("_EmisColor", new Color( 0.19f, 0.19f, 1.0f, 1.0f ));
			projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward*100;
			right = !right;
			lastAttackTime = 0;
		}

		if (health <= 0) {
			Destroy (gameObject);
			Controller.score+=100;
			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);
		}
	}
}
