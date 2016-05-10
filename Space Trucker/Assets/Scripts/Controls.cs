using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controls : MonoBehaviour {

	public GameObject laser;
	private bool right = false;
	public float laserSpread = 1f;
	public static float maxAmmo = 25;
	public float ammo = maxAmmo;
	public float chargeRate = 5;

	public Image ammoBar;

	private static float lastFireTime = 0f;
	public float reloadDelay = 1f;

	private Camera view;
	public float zoomRate = 250;

	// Use this for initialization
	void Start () {
		view = gameObject.GetComponentInChildren<Camera>();
		//gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {

		if(lastFireTime > reloadDelay && ammo < maxAmmo) {
			ammo += Time.deltaTime * chargeRate;

			if (ammo > maxAmmo)
				ammo = maxAmmo;
		}

		if (Input.GetMouseButton (1)) {
			if (view.fieldOfView > 40)
				view.fieldOfView-=Time.deltaTime*zoomRate;
		} else {
			if (view.fieldOfView < 90)
				view.fieldOfView+=Time.deltaTime*zoomRate;
		}

		if (Input.GetMouseButtonDown (0) && ammo > 0 ) {
			ammo--;
			Vector3 projectileSpawn;
			Quaternion projectileRotation;
			float xSpin = Random.Range (-laserSpread, laserSpread);
			float ySpin = Random.Range (-laserSpread, laserSpread);
			float zSpin = Random.Range (-laserSpread, laserSpread);
			Quaternion offSet = Quaternion.Euler(xSpin, ySpin, zSpin );

			if (right) {
				projectileSpawn = gameObject.transform.position + gameObject.transform.right + gameObject.transform.forward*2;
				projectileRotation = gameObject.transform.rotation*Quaternion.AngleAxis(-2, Vector3.up)*offSet;
			} 
			else {
				projectileSpawn = gameObject.transform.position + gameObject.transform.right * -1 + gameObject.transform.forward*2;
				projectileRotation = gameObject.transform.rotation*Quaternion.AngleAxis(2, Vector3.up)*offSet;
			}
			GameObject projectile = (GameObject)Instantiate(laser, projectileSpawn, projectileRotation);
			projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward*100;
			right = !right;
			lastFireTime = 0;
		}

		lastFireTime += Time.deltaTime;
	}

	void OnGUI() {
		ammoBar.fillAmount = ammo / maxAmmo;
	}
}
