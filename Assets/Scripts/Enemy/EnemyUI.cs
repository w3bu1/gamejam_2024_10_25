using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
	[Header("GUI")]
	[SerializeField] private Transform cam;
	[SerializeField] private Slider healthBar;

	public void LateUpdate()
	{
		transform.LookAt(cam);
	}
}
