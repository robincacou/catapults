using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] team1Points;
	public GameObject[] team2Points;

	public GameObject gui;
	public GUIToolbar guiToolbar;

	public enum ETeam
	{
		Team1,
		Team2
	}

	public void SpawnPlayer(ETeam team)
	{
		Transform pos;
		if (team == ETeam.Team1)
			pos = team1Points[Random.Range(0, team1Points.Length)].transform;
		else
			pos = team2Points[Random.Range(0, team2Points.Length)].transform;

		GameObject playerLocalInstance = PhotonNetwork.Instantiate("Player", pos.position, pos.rotation, (int)team);

		playerLocalInstance.GetComponent<MouseLook>().enabled = true;
		((MonoBehaviour)playerLocalInstance.GetComponent("CharacterMotor")).enabled = true;
		((MonoBehaviour)playerLocalInstance.GetComponent("FPSInputController")).enabled = true;
		playerLocalInstance.GetComponent<BlockCreator>().enabled = true;
		playerLocalInstance.GetComponent<DebugControls>().enabled = true;
		playerLocalInstance.GetComponent<ManagersInfoHarvester>().enabled = true;
		playerLocalInstance.GetComponent<ToolSelector>().enabled = true;
		playerLocalInstance.GetComponent<ToolSelector>().Initialize(guiToolbar);
		gui.SetActive(true);

		playerLocalInstance.transform.FindChild("Main Camera").gameObject.SetActive(true);

		StateManager.SetState(StateManager.State.Standard);
	}
}
