using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType
{
    round,
    lazer,
    beam,
    RPG
}

[System.Serializable]
public class Invader
{
    [SerializeField] public string name;
    [SerializeField] public float health;
    [SerializeField] public float speed;
    [SerializeField] public float resources;
    [SerializeField] public float fireRate;
    [SerializeField] public int fireMode;
    [SerializeField] public FireType fireType;

}
