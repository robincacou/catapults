using UnityEngine;
using System.Collections;

public class BombGun : MonoBehaviour {

	public GameObject bombPrefab;
	public int power = 10;

	void Start () {
	
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			Vector3 initialBombPos = transform.position +  (Camera.main.transform.forward * 2) + Vector3.up;

			GameObject bombInstance = (GameObject)PhotonNetwork.Instantiate("Bomb", initialBombPos, Quaternion.identity, 0);
			bombInstance.rigidbody.AddForce(Camera.main.transform.forward * power);
		}
	}
}
