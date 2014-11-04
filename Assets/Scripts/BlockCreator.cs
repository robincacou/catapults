using UnityEngine;
using System.Collections;

public class BlockCreator : MonoBehaviour {

	//public GameObject blockPrefab;
	public GameObject ghostPrefab;

	public float SpawnDistance = 2f;

	GhostBlock ghost;

	bool drawGhost = false;

	void Update ()
	{
		if (Input.GetMouseButtonDown(1))
		{
			drawGhost = true;
			ghost = ((GameObject)Instantiate(ghostPrefab)).GetComponent<GhostBlock>();
		}

		if (drawGhost)
		{
			SpawnDistance += Input.GetAxis("Mouse ScrollWheel");

			Vector3 offset = Camera.main.transform.forward * SpawnDistance;

			ghost.transform.position = this.transform.position + new Vector3(0, 2, 0) + offset;
			if (Input.GetMouseButtonUp(1))
			{
				if (!ghost.IsColliding())
					PhotonNetwork.Instantiate("Block", this.transform.position + new Vector3(0, 2, 0) + offset, Quaternion.identity, 0);

				Destroy(ghost.gameObject);
				drawGhost = false;
			}
		}
	}
}
