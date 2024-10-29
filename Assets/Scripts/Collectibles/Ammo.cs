using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, IInteractable
{
    [SerializeField] private int maxAmmo = 15;
    [SerializeField] private int minAmmo = 5;
    [SerializeField] private int ammo = 0;

    void Start()
    {
        ammo = Random.Range(minAmmo, maxAmmo);
    }

    public virtual void Interact(GameObject instigator)
    {
        PocketBullets pocketBullets = GameObject.FindGameObjectWithTag("Consumables").GetComponent<PocketBullets>();
        pocketBullets.AddOrRmvBullets(ammo);
        Destroy(gameObject);
    }
}
