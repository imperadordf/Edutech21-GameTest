using Game.Shared.Interactable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public IInteractable CurrentInteractable { get; private set; }
        public bool HasClick { get; private set; }

        public bool EnabledInput;

        public Vector3 ClickPosition { get; private set; }

        [SerializeField] private Camera cam;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask interactLayer;
        private InputSystem_Actions inputActions;

        private void Awake()
        {
            inputActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            inputActions.Enable();

            inputActions.Player.Click.performed += OnClick;
        }

        private void OnDisable()
        {
            inputActions.Player.Click.performed -= OnClick;

            inputActions.Disable();
        }

        private void LateUpdate()
        {
            HasClick = false;
        }

        private void OnClick(InputAction.CallbackContext ctx)
        {
            if (!EnabledInput)
            {
                return;
            }


            Vector2 screenPos =
                inputActions.Player.Position.ReadValue<Vector2>();

            Ray ray = cam.ScreenPointToRay(screenPos);

            // INTERACTABLE
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, interactLayer))
            {
                IInteractable interactable =
                    hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    CurrentInteractable = interactable;

                    ClickPosition =
                        interactable.GetTransform().position;

                    HasClick = true;

                    return;
                }
            }

            // GROUND
            if (Physics.Raycast(ray, out hit, 1000f, groundLayer))
            {
                CurrentInteractable = null;

                ClickPosition = hit.point;

                HasClick = true;
            }
        }
    }
}

