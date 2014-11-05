using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!photonView.isMine)
		{
			// If it's another player, we need to smoothly move it
			// TODO Correct the amount of Lerping according to time passed
			// We could also send the velocity and use it to predict the next place it's going to be
			// But for now it should be fine
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// This is our player. Send position over network

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else
		{
			// Other players. Reveive position and update our version

			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
