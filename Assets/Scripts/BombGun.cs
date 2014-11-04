using UnityEngine;
using System.Collections;

public class BombGun : MonoBehaviour {

	public GameObject bombPrefab;
	public int power = 10;

	void Start () {
	
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(1))
		{
			GameObject bomb = (GameObject)Instantiate(bombPrefab);

			Vector3 forward = Camera.main.transform.forward;

			bomb.transform.position = transform.position + (forward * 2) + Vector3.up;

			bomb.rigidbody.AddForce(forward * power);
		}
	}
}
