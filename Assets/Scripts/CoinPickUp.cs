using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, IPickUpObject
{
    [SerializeField] int count;
    public void OnPickup(Character character)
    {
        character.coins.Add(count);
    }
}

