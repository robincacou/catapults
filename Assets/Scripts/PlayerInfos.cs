using UnityEngine;
using System.Collections;

public class PlayerInfos : MonoBehaviour {

	public Material bluePlayerMaterial;
	public Material redPlayerMaterial;

	SpawnManager.ETeam team = SpawnManager.ETeam.Uninitialized;

	public SpawnManager.ETeam GetTeam()
	{
		return team;
	}

	public void SetTeamInitializeIFN(SpawnManager.ETeam team)
	{
		if (this.team != team)
		{
			this.team = team;
			InitializeTeam(team);
		}
	}

	public void InitializeTeam(SpawnManager.ETeam team)
	{
		this.team = team;
			
		GameObject graphics = transform.FindChild("Graphics").gameObject;
		MeshRenderer playerRenderer = graphics.GetComponent<MeshRenderer>();
		
		if (team == SpawnManager.ETeam.Blue)
			playerRenderer.material = bluePlayerMaterial;
		else
			playerRenderer.material = redPlayerMaterial;

	}
}
