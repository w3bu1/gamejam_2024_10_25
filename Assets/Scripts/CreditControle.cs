using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditControle : MonoBehaviour
{
	public float scrollSpeed = 70f;

	private RectTransform rectTransform;

	// Start is called before the first frame update
	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
	}
}
