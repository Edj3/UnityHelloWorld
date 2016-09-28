using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	private LineRenderer laser;
	Ray ray;
	// Use this for initialization
	void Start () {
		laser = GetComponent<LineRenderer> ();
		ray = new Ray (transform.position, transform.forward);
		InvokeRepeating("FireLaser", 0.1F, 0.03F);

	}

	float start = 0; 

	void Update () {
		

	}

	void FireLaser(){
		laser.SetPosition (0, ray.GetPoint(start));
		laser.SetPosition (1, ray.GetPoint (start + 0.2F));

		start = start + 0.02F;
		if (start >= 2) {
			start = 0;
		}
	}
}
