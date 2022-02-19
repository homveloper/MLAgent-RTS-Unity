using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MLRTS.Unit
{
    public enum UnitType
    {
        Citizen,
        Warrior,
        Healer,
        Archor
    }

    [CreateAssetMenu(fileName ="New Unit", menuName ="Unit/New Unit")]
    public class UnitData : ScriptableObject
    {
        public UnitType unitType;
        public string unitName;
        public GameObject unitPrefab;
        public int cost;
        public float maxHealth;
        public int damage;
        public int armor;
        public int moveSpeed;
    }
}


