using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	public float mod = 3;

	public  float MAX_DIST = 0.2f;
	public  float TIME_MAX = 0.1f;
	public  float TIME_MIN = 0f;
	public  float MAX_MOVE = 0.3f;
	public float flameTimeout = 0.5f;
	private float flameAim = 0f;
	private float timeX = 0;
	private float timeY = 0;
	private float timeZ = 0;
	private float xDist = 0;
	private float yDist = 0;
	private float zDist = 0;

	private Light flame; 

	// Use this for initialization
	void Start () 
	{
		flame = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( timeX <= 0 )
		{
			timeX = Random.Range(TIME_MIN, TIME_MAX);
			if(transform.localPosition.x > MAX_DIST)
			{
				xDist = -MAX_MOVE;
			}
			else if(transform.localPosition.x < -MAX_DIST)
			{
				xDist = MAX_MOVE;
			}
			else
			{
				xDist = Random.Range(-MAX_MOVE,MAX_MOVE);
			}
		}
		if( timeY <= 0 )
		{
			timeY = Random.Range(TIME_MIN, TIME_MAX);
			if(transform.localPosition.y > MAX_DIST)
			{
				yDist = -MAX_MOVE;
			}
			else if(transform.localPosition.y < -MAX_DIST)
			{
				yDist = MAX_MOVE;
			}
			else
			{
				yDist = Random.Range(-MAX_MOVE,MAX_MOVE);
			}	
		}	
		if( timeZ <= 0 )
		{
			timeZ = Random.Range(TIME_MIN, TIME_MAX);
			if(transform.localPosition.z > MAX_DIST)
			{
				zDist = -MAX_MOVE;
			}
			else if(transform.localPosition.z < -MAX_DIST)
			{
				zDist = MAX_MOVE;
			}
			else
			{
				zDist = Random.Range(-MAX_MOVE,MAX_MOVE)/2;
			}
		}
		if(flameTimeout <= 0)
		{
			flameAim = Random.Range(4f, 5f);
			flameTimeout = Random.Range(0.3f, 0.7f);
		}

		if(flame.intensity < flameAim)
			flame.intensity += Time.deltaTime*2;
		if(flame.intensity > flameAim)
			flame.intensity -= Time.deltaTime*2;

		transform.localPosition = new Vector3(transform.localPosition.x + xDist * Time.deltaTime * mod, transform.localPosition.y + yDist * Time.deltaTime * mod, transform.localPosition.z + zDist * Time.deltaTime * mod);

		timeX -= Time.deltaTime;
		timeY -= Time.deltaTime;
		timeZ -= Time.deltaTime;
		flameTimeout -= Time.deltaTime;
	}

/*	private float GetDist (float axis)
	{
		if(Mathf.Abs(axis) > MAX_DIST)
		{
			return MAX_DIST/2;
		}
		return Random.Range(-MAX_DIST, MAX_DIST);
	}*/
}
