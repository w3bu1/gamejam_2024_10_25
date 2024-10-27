using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFXScript : MonoBehaviour
{
	public AudioClip hoverSound;
	public AudioClip clickSound;

	public void HoverSound()
	{
		SoundManager.instance.PlaySoundFXClip(hoverSound, transform, .3f);
		// audioSource.PlayOneShot(hoverSound);
	}

	public void ClickSound()
	{
		SoundManager.instance.PlaySoundFXClip(clickSound, transform, .3f);

		// audioSource.PlayOneShot(clickSound);
	}
}
