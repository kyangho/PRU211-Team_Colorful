using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entity.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        public float range;

        public static float ATK = 100;

        public GameObject FirePoint { get; set; }


    }
}