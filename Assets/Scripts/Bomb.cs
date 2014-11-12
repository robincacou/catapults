using UnityEngine;
using System.Collections;

public class Bomb : Photon.MonoBehaviour {

	public float lifespan = 5f;
	public BombTargetsCollector targetsCollector;
	public GameObject explosionPrefab;

	float collisionTimer = 0.2f;
	bool collided = false;

	void OnCollisionEnter(Collision col)
	{
		// TODO Maybe start the collect only on the initially created bomb (not the networked ones)
		// And instanciate the explosion over the network

		if (!collided)
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		collided = true;
		targetsCollector.StartCollect();
	}

	void Update ()
	{
		// We only compute the explosion if we are the one who created the bomb
		if (!photonView.isMine)
			return;

		if (collided)
		{
			collisionTimer -= Time.deltaTime;

			if (collisionTimer <= 0)
			{
				foreach(GameObject target in targetsCollector.GetTargets())
					PhotonNetwork.Destroy(target); // TODO Maybe we should be the own owning the cube, not the bomb?
				PhotonNetwork.Destroy(gameObject);
			}
		}

		lifespan -= Time.deltaTime;
		if (lifespan <= 0)
			PhotonNetwork.Destroy(gameObject);
	}
}
