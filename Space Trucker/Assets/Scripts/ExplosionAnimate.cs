using UnityEngine;
using System.Collections;

public class ExplosionAnimate : MonoBehaviour {

	public float loopDuration = 2;
	public float rangeMax = (float)0.1;
	public float rangeMin = (float)0.1;
	public float scaleRate = (float)0.2;
	public float rangeRate = (float)1.1;
	public float finalRange = (float)10;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () 
	{
		float r = Mathf.Sin((Time.time / loopDuration) * (2 * Mathf.PI)) * 0.5f + 0.25f;
		float g = Mathf.Sin((Time.time / loopDuration + 0.33333333f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float b = Mathf.Sin((Time.time / loopDuration + 0.66666667f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float correction = 1 / (r + g + b);
		r *= correction;
		g *= correction;
		b *= correction;
		GetComponent<Renderer>().material.SetVector("_ChannelFactor", new Vector4(r,g,b,0));
		GetComponent<Renderer>().material.SetVector("_Range", new Vector4(rangeMin,rangeMax,0,0));
		transform.localScale += new Vector3(scaleRate,scaleRate,scaleRate);
		GetComponent<Light>().range += 3*scaleRate;
		GetComponent<Light>().intensity += 3*scaleRate;
		GetComponent<Light>().range *= (1 - (rangeMax / finalRange));
		GetComponent<Light> ().intensity *= (1 - (rangeMax / finalRange));
		if(rangeMax>0.5)
			rangeMin *= (float)rangeRate;
		rangeMax *= (float)rangeRate;
		if (rangeMax > finalRange)
			Destroy (gameObject);
		//renderer.material.SetFloat ("_Range.y", (renderer.material.GetFloat ("_Range.y")+rangeStep));
	}
}
