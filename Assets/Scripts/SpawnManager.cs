using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject globalCamera;
	public GameObject[] team1Points;
	public GameObject[] team2Points;

	public GUIToolbar guiToolbar;
	public ScoreManager guiScore;


	public enum ETeam
	{
		Uninitialized,
		Red,
		Blue
	}

	public void SpawnPlayer(ETeam team)
	{
		Transform pos;
		if (team == ETeam.Red)
			pos = team1Points[Random.Range(0, team1Points.Length)].transform;
		else
			pos = team2Points[Random.Range(0, team2Points.Length)].transform;

		GameObject playerLocalInstance = PhotonNetwork.Instantiate("Player", pos.position, pos.rotation, 0);

		playerLocalInstance.GetComponent<MouseLook>().enabled = true;
		((MonoBehaviour)playerLocalInstance.GetComponent("CharacterMotor")).enabled = true;
		((MonoBehaviour)playerLocalInstance.GetComponent("FPSInputController")).enabled = true;
		playerLocalInstance.GetComponent<BlockCreator>().enabled = true;
		playerLocalInstance.GetComponent<DebugControls>().enabled = true;
		playerLocalInstance.GetComponent<ManagersInfoHarvester>().enabled = true;
		playerLocalInstance.GetComponent<ToolSelector>().enabled = true;
		playerLocalInstance.GetComponent<ToolSelector>().Initialize(guiToolbar);
		playerLocalInstance.GetComponent<PlayerInfos>().SetTeamInitializeIFN(team);

		guiToolbar.gameObject.SetActive(true);
		guiScore.gameObject.SetActive(true);
		globalCamera.gameObject.SetActive(false);
		playerLocalInstance.transform.FindChild("Main Camera").gameObject.SetActive(true);

		StateManager.SetState(StateManager.State.Standard);
	}
}
