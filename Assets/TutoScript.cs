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
	[SerializeField] private Image _prev;
	[SerializeField] private Image _next;
	[SerializeField] private Image _done;
	[SerializeField] private Image _skip;
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
		if (_tutoIndex == 0)
			_prev.gameObject.SetActive(false);
		else
			_prev.gameObject.SetActive(true);
		if (_tutoIndex == _tutoImage.Length - 1)
		{
			_next.gameObject.SetActive(false);
			_done.gameObject.SetActive(true);
		}
		else
		{
			_next.gameObject.SetActive(true);
			_done.gameObject.SetActive(false);
		}
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Next();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Previous();
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
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

	private void quitTuto()
	{
		_tutoPanel.SetActive(false);
		Time.timeScale = 1;
	}
}
