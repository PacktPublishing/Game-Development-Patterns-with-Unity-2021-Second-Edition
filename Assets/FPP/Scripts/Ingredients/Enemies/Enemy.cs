using UnityEngine;
using FPP.Scripts.Enums;

namespace FPP.Scripts.Ingredients.Enemies
{
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "Ingredients/Enemy", order = 1)]
    public class Enemy : ScriptableObject
    {
        public float health;
        public float attack;
        public GameObject prefab;
        public EnemyType enemyType;
        public float isDestructible;
    }
}