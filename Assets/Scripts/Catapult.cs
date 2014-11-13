using UnityEngine;
using System.Collections;

public class Catapult : MonoBehaviour {

	public GameObject thingyContainer;
	public GameObject spawnPoint;
	public MeshCollider thingyCollider;
	public float maxDraggingSpeed = 2f;
	public float throwMovementSpeed = 5f;
	public int throwPower = 5000;
	public float minPowerToSpawn = 0.2f;

	public AudioSource throwSfx;

	bool pulling = false;
	bool throwing = false;
	float timerToEnableCollider = 1f;

	const int maxPullAngle = 355;
	const int minPullAngle = 270;

	void Start ()
	{
	}

	void Update ()
	{
		if (timerToEnableCollider > 0)
		{
			timerToEnableCollider -= Time.deltaTime;
			if (timerToEnableCollider < 0)
				thingyCollider.enabled = true;
		}

		if (pulling)
		{
			float angle = Input.GetAxis("Mouse Y");

			if (angle > 0 && angle > maxDraggingSpeed)
				angle = maxDraggingSpeed;

			if (angle < 0 &&  - angle > maxDraggingSpeed)
				angle = - maxDraggingSpeed;

			thingyContainer.transform.Rotate(new Vector3(0, 0, - angle));

			if (thingyContainer.transform.rotation.eulerAngles.z > maxPullAngle)
				thingyContainer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, maxPullAngle));
			if (thingyContainer.transform.rotation.eulerAngles.z < minPullAngle)
				thingyContainer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, minPullAngle));
		}

		if (throwing)
		{
			thingyContainer.transform.Rotate(new Vector3(0, 0, - throwMovementSpeed));
			if (thingyContainer.transform.rotation.eulerAngles.z < minPullAngle)
			{
				throwing = false;
				thingyContainer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, minPullAngle));
				timerToEnableCollider = 1f;
			}
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (!col.CompareTag("Player"))
			return;

		if (StateManager.CurrentState() != StateManager.State.Standard
		    && StateManager.CurrentState() != StateManager.State.CatapultAiming)
			return;

		// TODO Test the player facing the catapult
		if (Input.GetButtonDown("Fire1"))
		{
			pulling = true;
			MouseLookManager.SetCatapultsMouseLookActivated(false);
			StateManager.SetState(StateManager.State.CatapultAiming);
		}
		else if (pulling && Input.GetButtonUp("Fire1"))
		{
			float powerPercentage = (thingyContainer.transform.rotation.eulerAngles.z - minPullAngle) / (maxPullAngle - minPullAngle);

			if (powerPercentage >= minPowerToSpawn)
			{
				thingyCollider.enabled = false;
				GameObject bombInstance = (GameObject)PhotonNetwork.Instantiate("Bomb", spawnPoint.transform.position, Quaternion.identity, 0);
				bombInstance.rigidbody.AddForce(spawnPoint.transform.forward * throwPower * powerPercentage);

				throwSfx.Play();
			}

			pulling = false;
			throwing = true;
			MouseLookManager.SetCatapultsMouseLookActivated(true);
			StateManager.SetState(StateManager.State.Standard);
		}
	}
}
