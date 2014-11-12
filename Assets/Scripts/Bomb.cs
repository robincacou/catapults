using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float lifespan = 5f;
	public BombTargetsCollector targetsCollector;
	public GameObject explosionPrefab;

	//float initialTimer = 1f;
	float collisionTimer = 0.2f;
	bool collided = false;

	void OnCollisionEnter(Collision col)
	{
		//if (initialTimer > 0)
		//	return;

		if (!collided)
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		collided = true;
		targetsCollector.StartCollect();
	}

	void Update ()
	{
		//if (initialTimer > 0)
		//	initialTimer -= Time.deltaTime;

		if (collided)
		{
			collisionTimer -= Time.deltaTime;

			if (collisionTimer <= 0)
			{
				foreach(GameObject target in targetsCollector.GetTargets())
					Destroy(target);
				PhotonNetwork.Destroy(gameObject);
			}
		}

		lifespan -= Time.deltaTime;
		if (lifespan <= 0)
			PhotonNetwork.Destroy(gameObject);
	}
}
