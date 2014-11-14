using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	GUIText text;

	Hashtable scoresForTeam;

	void Start () {
		text = GetComponent<GUIText>();

		scoresForTeam = new Hashtable();
		ReinitializeScores();
	}

	void Update () {
		// TODO Make that more generic
		text.text = "Red : " + scoresForTeam[SpawnManager.ETeam.Red] + "\nBlue: " + scoresForTeam[SpawnManager.ETeam.Blue];
	}

	public void ReinitializeScores()
	{
		scoresForTeam.Add(SpawnManager.ETeam.Red, 0);
		scoresForTeam.Add(SpawnManager.ETeam.Blue, 0);
	}

	public void IncrementScoreForTeam(SpawnManager.ETeam team, long score)
	{
		scoresForTeam.Add(team, score);
	}
}
