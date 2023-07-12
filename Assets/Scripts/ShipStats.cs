using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipStats : MonoBehaviour
{
    [Range(1f, 5f)]
    public int MaxHealth;

    [HideInInspector] public int CurrentHealth;
    [HideInInspector] public int MaxLifes = 3;
    [HideInInspector] public int CurrentLifes = 3;

    public float ShipSpeed;
    public float FireRate;
}
