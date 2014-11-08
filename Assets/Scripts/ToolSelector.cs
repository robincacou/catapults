using UnityEngine;
using System.Collections;

public class ToolSelector : MonoBehaviour {

	public BlockCreator blockCreator;
	public BombGun bombGun;

	GUIToolbar toolbar;
	ArrayList tools;

	int selectedTool = 0;

	public void Initialize(GUIToolbar toolbar)
	{
		this.toolbar = toolbar;
	}

	void Start ()
	{
		tools = new ArrayList();
		tools.Add(blockCreator);
		tools.Add(bombGun);
	}

	void Update ()
	{
		if (StateManager.CurrentState() != StateManager.State.Standard)
			return;

		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			selectedTool++;
			if (selectedTool >= tools.Count)
				selectedTool = 0;

			UpdateToolsState();
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			selectedTool--;
			if (selectedTool < 0)
				selectedTool = tools.Count - 1;

			UpdateToolsState();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedTool = 0;
			UpdateToolsState();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			selectedTool = 1;
			UpdateToolsState();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			selectedTool = 2;
			UpdateToolsState();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			selectedTool = 3;
			UpdateToolsState();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			selectedTool = 4;
			UpdateToolsState();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			selectedTool = 5;
			UpdateToolsState();
		}
	}

	void UpdateToolsState()
	{
		for (int i = 0; i < tools.Count; ++i)
			((MonoBehaviour)(tools[i])).enabled = (i == selectedTool);
		toolbar.UpdateSelectorPosition(selectedTool);
	}
}
