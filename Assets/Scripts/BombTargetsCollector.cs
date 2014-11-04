using UnityEngine;
using System.Collections;

public class BombTargetsCollector : MonoBehaviour {

	bool mustCollect = false;

	ArrayList targets;

	void Start()
	{
		targets = new ArrayList();
	}

	public void StartCollect()
	{
		mustCollect = true;
	}

	public ArrayList GetTargets()
	{
		return targets;
	}

	void OnTriggerStay(Collider col)
	{
		if (mustCollect && !targets.Contains(col.gameObject)
		    && col.gameObject.CompareTag("Destroyable"))
			targets.Add(col.gameObject);
	}
}
