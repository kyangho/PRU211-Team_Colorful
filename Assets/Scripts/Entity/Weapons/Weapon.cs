using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entity.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        public float range;

        [SerializeField]
        public float ATK;

        public GameObject FirePoint { get; set; }


    }
}