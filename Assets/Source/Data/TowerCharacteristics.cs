using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "TowerCharacteristic", fileName = "Tower")]
public class TowerCharacteristics : ScriptableObject
{
    [SerializeField] private List<TowerCharacteristic> _characteristics;
    public IReadOnlyList<TowerCharacteristic> Characteristics => _characteristics;
    public int UpdateCount => _characteristics.Count;
    public TowerCharacteristic this[int value]
    {
        get => _characteristics[value];
    }
}

[Serializable]
public struct TowerCharacteristic
{
    [field: SerializeField, Range(0, 100)] public int Damage { get; private set; }
    [field: SerializeField, Range(0, 100)] public int AttackRadius { get; private set; }
    [field: SerializeField, Range(0, 10)] public float Reload { get; private set; }
    [field: SerializeField, Range(0, 20)] public int Cost { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}
