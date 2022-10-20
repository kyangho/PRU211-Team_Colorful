using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entity.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        public float range;

        public GameObject FirePoint { get; set; }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}