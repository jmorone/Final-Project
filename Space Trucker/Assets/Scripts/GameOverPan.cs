using UnityEngine;
using System.Collections;

public class GameOverPan : MonoBehaviour {

	public float rate = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation *= Quaternion.AngleAxis (Time.deltaTime*rate, Vector3.up);
	}
}
