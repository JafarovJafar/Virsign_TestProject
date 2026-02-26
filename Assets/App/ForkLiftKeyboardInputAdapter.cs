using UnityEngine;
using UnityEngine.InputSystem;

namespace Virsign
{
    public class ForkLiftKeyboardInputAdapter : MonoBehaviour
    {
        [SerializeField] private InputActionAsset asset;
        [SerializeField] private InputActionReference ignitionAction;
        [SerializeField] private InputActionReference gasAction;
        [SerializeField] private InputActionReference reverseAction;
        [SerializeField] private InputActionReference brakeAction;
        [SerializeField] private InputActionReference steeringAction;
        [SerializeField] private InputActionReference forkHeightAction;

        private ForkLift _forkLift;
        private bool _isActive;
        private bool _canSendInput;

        private void Awake()
        {
            asset.Enable();
            ignitionAction.action.Enable();
            gasAction.action.Enable();
            reverseAction.action.Enable();
            brakeAction.action.Enable();
            steeringAction.action.Enable();
            forkHeightAction.action.Enable();
        }

        public void SetForkLift(ForkLift forkLift)
        {
            _forkLift = forkLift;
            UpdateActiveness();
        }

        public void Activate()
        {
            _isActive = true;
            UpdateActiveness();
        }

        public void DeActivate()
        {
            _isActive = false;
            UpdateActiveness();
        }

        private void UpdateActiveness()
        {
            if (_isActive == true && _forkLift != null)
            {
                _canSendInput = true;

                ignitionAction.action.performed += OnIgnitionPerformed;
                ignitionAction.action.canceled += OnIgnitionPerformed;

                gasAction.action.performed += OnGasPerformed;
                gasAction.action.canceled += OnGasPerformed;

                reverseAction.action.performed += OnReversePerformed;
                reverseAction.action.canceled += OnReversePerformed;

                brakeAction.action.performed += OnBrakePerformed;
                brakeAction.action.canceled += OnBrakePerformed;

                steeringAction.action.performed += OnSteeringPerformed;
                steeringAction.action.canceled += OnSteeringPerformed;

                forkHeightAction.action.performed += OnForkHeightPerformed;
                forkHeightAction.action.canceled += OnForkHeightPerformed;
                return;
            }

            _canSendInput = false;

            ignitionAction.action.performed -= OnIgnitionPerformed;
            ignitionAction.action.canceled -= OnIgnitionPerformed;

            gasAction.action.performed -= OnGasPerformed;
            gasAction.action.canceled -= OnGasPerformed;

            reverseAction.action.performed -= OnReversePerformed;
            reverseAction.action.canceled -= OnReversePerformed;

            steeringAction.action.performed -= OnSteeringPerformed;
            steeringAction.action.canceled -= OnSteeringPerformed;

            forkHeightAction.action.performed -= OnForkHeightPerformed;
            forkHeightAction.action.canceled -= OnForkHeightPerformed;
        }

        private void OnIgnitionPerformed(InputAction.CallbackContext ctx)
        {
            if (_canSendInput == false)
                return;

            var ignition = ctx.ReadValue<float>() > 0.5f;
            _forkLift.Input.IsIgnitionPressed.SetValue(ignition);
        }

        private void OnGasPerformed(InputAction.CallbackContext ctx)
        {
            if (_canSendInput == false)
                return;

            _forkLift.Input.Gas.SetValue(ctx.ReadValue<float>());
        }

        private void OnReversePerformed(InputAction.CallbackContext ctx)
        {
            if (_canSendInput == false)
                return;

            _forkLift.Input.Reverse.SetValue(ctx.ReadValue<float>());
        }

        private void OnBrakePerformed(InputAction.CallbackContext ctx)
        {
            if (_canSendInput == false)
                return;

            var brake = ctx.ReadValue<float>();
            _forkLift.Input.Brake.SetValue(brake);
        }

        private void OnSteeringPerformed(InputAction.CallbackContext ctx)
        {
            if (_canSendInput == false)
                return;

            _forkLift.Input.Steering.SetValue(ctx.ReadValue<float>());
        }

        private void OnForkHeightPerformed(InputAction.CallbackContext ctx)
        {
            if (_canSendInput == false)
                return;

            _forkLift.Input.ForkHeightDelta.SetValue(ctx.ReadValue<float>());
        }
    }
}