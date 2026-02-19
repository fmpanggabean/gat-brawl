using System;
using UnityEngine;

namespace Apps.Scripts
{
    public class MovementAction : MonoBehaviour, ICharacterAction<Vector2>
    {
        // attributes
        [SerializeField, Range(0, 30)] private float movementSpeed;
        
        // component references
        private Rigidbody _rb;
        private Vector3 _direction;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (_rb is null) Debug.LogWarning("No Rigidbody attached to the object", this);
        }

        private void FixedUpdate()
        {
            _direction.y = _rb.linearVelocity.y;
            _rb.linearVelocity = _direction;
        }

        public void Execute(Vector2 info)
        {
            _direction.x = info.x * movementSpeed;
            _direction.z = info.y * movementSpeed;
        }
    }
}