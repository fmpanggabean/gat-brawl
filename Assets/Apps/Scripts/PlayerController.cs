using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        // attributes
        private MovementAction _movementAction;

        private void Awake()
        {
            _movementAction = GetComponent<MovementAction>();
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            if (_movementAction is null)
            {
                Debug.LogWarning("Component MovementAction is not attached to the object", this);
                return;
            }
        
            if (ctx.performed || ctx.canceled)
            {
                _movementAction.Execute(ctx.ReadValue<Vector2>());
            }
        }
    }
}
