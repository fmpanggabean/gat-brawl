using UnityEngine;
using UnityEngine.Events;

namespace Apps.Scripts
{
    public class Health : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int max;
        [SerializeField] private int current;

        [Header("Events")]
        public UnityEvent OnHit;

        public UnityEvent OnRecover;
    
        public void TakeDamage(int damage)
        {
            current -= damage;
            if (current <= 0)
                current = 0;
            OnHit?.Invoke();
        }

        public void Recover(int value)
        {
            current += value;
            if (current >= max)
                current = max;
            OnRecover?.Invoke();
        }
    }
}