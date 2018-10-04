using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public bool IsPlayerVisible { get; private set; }
        private void OnTriggerEnter(Collider other)
        {
            if (TagUtils.IsPlayer(other))
            {
                IsPlayerVisible = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (TagUtils.IsPlayer(other))
            {
                IsPlayerVisible = false;
            }
        }
    }
    
}