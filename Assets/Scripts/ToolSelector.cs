using UnityEngine;
using System.Collections;

public class ToolSelector : MonoBehaviour {

	public BlockCreator blockCreator;
	public BombGun bombGun;

	ArrayList tools;

	int selectedTool = 0;

	void Start ()
	{
		tools = new ArrayList();
		tools.Add(blockCreator);
		tools.Add(bombGun);
	}

	void Update ()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			selectedTool++;
			if (selectedTool >= tools.Count)
				selectedTool = 0;

			print (selectedTool);

			UpdateToolsState();
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			selectedTool--;
			if (selectedTool < 0)
				selectedTool = tools.Count;

			print (selectedTool);

			UpdateToolsState();
		}
	}

	void UpdateToolsState()
	{
		for (int i = 0; i < tools.Count; ++i)
			((MonoBehaviour)(tools[i])).enabled = (i == selectedTool);
	}
}
