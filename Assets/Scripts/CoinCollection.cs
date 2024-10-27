using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    [Header("Coin Collection Settings")]
    [SerializeField] private string coinTag = "Coin";
    [SerializeField] private int coinValue = 1;
    [SerializeField] private TextMesh coinText;
    [SerializeField] private AudioClip collectSound;

    private int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag(coinTag))
        {
            coinCount += coinValue;
            if (coinText != null)
                coinText.text = coinCount.ToString();
            SoundManager.instance.PlaySoundFXClip(collectSound, transform, 1f);
            Destroy(other.gameObject);
        }
    }
}
