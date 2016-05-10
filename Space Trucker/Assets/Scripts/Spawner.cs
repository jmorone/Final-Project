using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject player;
	public float enemyDelay = 0.75f;
	public float spawnRange = 250;
	public float enemyRange = 19;
	public float kamikazeRange = 35;


	private float lastEnemyTime = 0f;

	public float kamikazeDelay = 5f;
	private float lastKamikazeTime = 0f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		lastEnemyTime += Time.deltaTime;
		lastKamikazeTime += Time.deltaTime;
		if (lastEnemyTime > enemyDelay ) {
			float xOffset = Random.Range (-enemyRange, enemyRange);
			float yOffset = Random.Range (-enemyRange, enemyRange);
			float zOffset = spawnRange;//Random.Range (spawnRange, 100F);
			GameObject enemy = (GameObject)Instantiate(enemies[0], 
				player.transform.position + new Vector3(xOffset, yOffset, zOffset),
				Quaternion.AngleAxis(180, Vector3.up));
			
			Color newColor = new Color( 0.69f, 0.69f, .91f, 1.0f );
			// apply it on current object's material
			enemy.GetComponent<Renderer>().material.color = newColor;
			enemy.GetComponent<Rigidbody>().velocity = enemy.transform.forward*19;
			lastEnemyTime = 0;
		}

		if (lastKamikazeTime > kamikazeDelay ) {
			float xOffset = Random.Range (-kamikazeRange, kamikazeRange);
			float yOffset = Random.Range (-kamikazeRange, kamikazeRange);
			float zOffset = spawnRange;//Random.Range (19F, spawnRange);
			GameObject enemy = (GameObject)Instantiate(enemies[1], 
				player.transform.position + new Vector3(xOffset, yOffset, zOffset),
				Quaternion.AngleAxis(180, Vector3.up));

			Color newColor = new Color( 0.91f, 0, 0, 1.0f );
			// apply it on current object's material
			enemy.GetComponent<Renderer>().material.color = newColor;
			enemy.GetComponent<Rigidbody>().velocity = enemy.transform.forward*19;
			lastKamikazeTime = 0;
		}
	}
}
