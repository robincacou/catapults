using UnityEngine;
using System.Collections;

public class TeamSelector : MonoBehaviour {

	public SpawnManager spawnManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, Screen.width / 2.0f - 20f, Screen.height - 20f), "Red Team"))
		{
			spawnManager.SpawnPlayer(SpawnManager.ETeam.Red);
			enabled = false;
		}

		if (GUI.Button(new Rect((Screen.width / 2.0f) + 10f, 10, Screen.width / 2.0f - 20f, Screen.height - 20f), "Blue Team"))
		{
			spawnManager.SpawnPlayer(SpawnManager.ETeam.Blue);
			enabled = false;
		}
	}
}
