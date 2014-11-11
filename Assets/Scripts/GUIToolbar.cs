using UnityEngine;
using System.Collections;

public class GUIToolbar : MonoBehaviour {

	public GUITexture background;
	public GUITexture selector;
	public GameObject icons;

	const float initialXOffset = 5f;
	const float initialYOffset = 14f;
	const float initialIconsXOffset = 8f;
	const float initialIconsYOffset = 10f;

	Vector3 startPos;

	void Start ()
	{
		background.transform.position = new Vector3(((Screen.width - background.pixelInset.width) / 2.0f) / Screen.width, 0, 0);
		selector.transform.position = new Vector3(background.transform.position.x + (initialXOffset / Screen.width), (initialYOffset / Screen.width), 1);
		startPos = selector.transform.position;

		float currentIconPos = startPos.x + (initialIconsXOffset / Screen.width);
		GUITexture[] iconsTextures = icons.GetComponentsInChildren<GUITexture>();
		foreach (GUITexture icon in iconsTextures)
		{
			icon.transform.position = new Vector3(currentIconPos, (selector.pixelInset.height - ((icon.pixelInset.height / 2.0f) + initialIconsYOffset))  / Screen.width, 0.5f);
			currentIconPos += ((background.pixelInset.width - 7f)/ 6.0f) / Screen.width;
		}
	}

	public void UpdateSelectorPosition(int index)
	{
		Vector3 offset = new Vector3(((background.pixelInset.width - 7f)/ 6.0f) / Screen.width, 0, 0);
		selector.transform.position = startPos + (offset * index);
	}
}
