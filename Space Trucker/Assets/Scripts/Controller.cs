using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour {

	public static float score = 0;
	public static float health = 100;
	public static float maxHealth = 100;
	public static float maxShield = 100;
	public static float shield = maxShield;

	public Text scoreText;
	/*public Text healthText;
	public Text shieldText; */
	public Text messageText;
	public Image healthBar;
	public Image shieldBar;

	private static float lastDamageTime = 0f;
	public float shieldDelay = 0.5f;

	// Use this for initialization
	void Start () {
		messageText.text = "";

		score = 0;
		health = 100;
		maxShield = 100;
		shield = maxShield;
		lastDamageTime = 0f;

	}

	// Update is called once per frame
	void Update () {

		if (lastDamageTime > shieldDelay && shield < maxShield) {
			shield += Time.deltaTime;
		}
		lastDamageTime += Time.deltaTime;

		if (health <= 0) 
		{
			SceneManager.LoadScene ("gameOver");
		}
	}

	public static void inflictDamage (float howMuch) {
		if (shield > 0) {
			shield -= howMuch;
			if (shield < 0) {
				health += shield;
				shield = 0;
			}
		} else {
			health -= howMuch;
		}

		lastDamageTime = 0;


	}

	void OnGUI() {
		healthBar.fillAmount = health / maxHealth;
		shieldBar.fillAmount = shield / maxShield;

		scoreText.text = "Score: " + score;
		/*healthText.text = "Health: " + health;
		shieldText.text = "Shield: " + shield; */
	}
}
