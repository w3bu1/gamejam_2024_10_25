using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "Collection/Coin")]
public class Coin : ScriptableObject
{
    [Header("Coin Settings")]
    public string coinTag = "Coin";
    public GameObject coinPrefab;
    public int coinValue = 1;
    public AudioSource collectSound;

    private void Awake()
    {
        if (coinPrefab == null)
        {
            Debug.LogError("Coin prefab is not set!");
        }
        // Set the tag of the coin prefab
        coinPrefab.tag = coinTag;
        // Add rigidbody to the coin prefab
        Rigidbody rb = coinPrefab.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        // Add collider to the coin prefab
        SphereCollider collider = coinPrefab.AddComponent<SphereCollider>();
        collider.isTrigger = true;
    }

}
