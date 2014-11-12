using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	PlayerInfos playerInfos;

	float smoothingDistance = 5f;

	// Use this for initialization
	void Start () {
		playerInfos = GetComponent<PlayerInfos>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!photonView.isMine)
		{
			// If it's another player, we need to smoothly move it

			if (Vector3.Distance(realPosition, transform.position) < smoothingDistance)
			{
				// We only transition smoothly if the new position is close enough
				transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
				transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
			}
			else
			{
				// Else, we teleport. This avoids crossing half the map on spawn and destroying everithing
				transform.position = realPosition;
				transform.rotation = realRotation;
			}
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// This is our player. Send position over network

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(playerInfos.GetTeam());
		}
		else
		{
			// Other players. Reveive position and update our version

			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
			playerInfos.SetTeamInitializeIFN((SpawnManager.ETeam)stream.ReceiveNext());
		}
	}
}
