using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manoeuvre
{
    public class gc_StateManager : MonoBehaviour
    {
        public PlayerStates currentPlayerState;

        [HideInInspector]
        public GameObject sensorCollider;
        [Range(0f, 30f)]
        [HideInInspector]
        public float sensorRadius = 5f;

        [HideInInspector]
        public float radiusWhileRunning;
        [HideInInspector]
        public float radiusWhileShooting;

        public static gc_StateManager Instance;
        [FormerlySerializedAs("Player")] [SerializeField]
        ManoeuvreFPSController _player;

        // Use this for initialization
        void Awake()
        {
            Instance = this;
        }

    }
}