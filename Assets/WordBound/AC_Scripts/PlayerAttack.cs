using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

    [System.Serializable]
    public class PlayerAttack : Action
    {


        public override ActionCategory Category { get { return ActionCategory.Custom; } }
        public override string Title { get { return "Player Attack Enemy"; } }
        public override string Description { get { return "Allows the player to attack an enemy and deal damage."; } }

        public GameObject enemyPrefab;
        public float damageAmount;

        public override float Run()
        {
            if (enemyPrefab != null)
            {
                Health enemyHealth = enemyPrefab.GetComponent<CurrentHP>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }
            }
            return 0f;
        }

#if UNITY_EDITOR

        public override void ShowGUI()
        {
            enemyPrefab = (GameObject)EditorGUILayout.ObjectField("Enemy Prefab:", enemyPrefab, typeof(GameObject), true);
            damageAmount = EditorGUILayout.FloatField("Damage Amount:", damageAmount);
        }

#endif
    }
}