using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoScript : MonoBehaviour
{
	// [SerializeField] private GameObject _tutoPanel;
	// get the text title in ui canva
	[SerializeField] private GameObject _tutoPanel;
	[SerializeField] private Image[] _tutoImage;
	private int _tutoIndex = 0;

	// Start is called before the first frame update
	void Start()
	{
		_tutoPanel.SetActive(true);
		//pause the game
		Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Next();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Previous();
		}
		else if (Input.GetKeyDown(KeyCode.Backspace))
		{
			quitTuto();
		}
	}

	public void Next()
	{
		if (_tutoIndex < _tutoImage.Length - 1)
		{
			_tutoImage[_tutoIndex].gameObject.SetActive(false);
			_tutoIndex++;
			_tutoImage[_tutoIndex].gameObject.SetActive(true);
		}
		else
		{
			quitTuto();
		}
	}

	public void Previous()
	{
		if (_tutoIndex > 0)
		{
			_tutoImage[_tutoIndex].gameObject.SetActive(false);
			_tutoIndex--;
			_tutoImage[_tutoIndex].gameObject.SetActive(true);
		}
	}

	public void quitTuto()
	{
		_tutoPanel.SetActive(false);
		Time.timeScale = 1;
	}
}
