using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public TeamSelector teamSelector;

	void Start () {
		Connect();
	}
	
	void Connect()
	{
		PhotonNetwork.ConnectUsingSettings("Pre-Alpha:0.01");
	}

	void OnGUI()
	{

	}

	void OnJoinedLobby()
	{
		RoomOptions options = new RoomOptions();
		options.isOpen = true;
		options.isVisible = true;
		options.maxPlayers = 0; // No Limit

		TypedLobby typedLobby = new TypedLobby("Lobby", LobbyType.Default);

		PhotonNetwork.JoinOrCreateRoom("MainRoom", options, typedLobby);
	}

	void OnPhotonJoinFailed()
	{
		Debug.LogError("Could not join a room...");
	}

	void OnJoinedRoom()
	{
		Debug.Log("Joined Room!");

		teamSelector.gameObject.SetActive(true);
	}
}
