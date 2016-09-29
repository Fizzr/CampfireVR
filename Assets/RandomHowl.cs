using UnityEngine;
using System.Collections;

public class RandomHowl : MonoBehaviour {

	private float howlTimeout;
	private GvrAudioSource sound;

	// Use this for initialization
	void Start () 
	{
		howlTimeout = 10;
		sound = GetComponent<GvrAudioSource>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(howlTimeout <= 0)
		{
			float x = Random.Range(15f, 25f);
			float z = Random.Range(15f, 25f);
			x = x * (Random.Range(-1f, 1f)> 0? 1f : -1f);
			z = z * (Random.Range(-1f, 1f)> 0? 1f : -1f);
			transform.position = new Vector3(x, transform.position.y, z);
			howlTimeout = Random.Range(30, 60);
			sound.Play();
		}

		howlTimeout -= Time.deltaTime;
	}
}
