using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Data", menuName = "ScriptableObjects/Heal Data")]

public class SOHeal : ScriptableObject
{
    [SerializeField] private int healAmount;
    
    public int HealAmount { get => healAmount; set => healAmount = value;}
    
    
}
