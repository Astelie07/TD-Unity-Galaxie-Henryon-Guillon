using UnityEngine;
using UnityEngine.InputSystem;

namespace HeneGames.Airplane
{
    public class SimpleAirPlaneController : MonoBehaviour
    {
        [Header("Flight")]
        [SerializeField] private float defaultSpeed = 20f;
        [SerializeField] private float slowSpeed = 10f;
        [SerializeField] private float accelerating = 5f;
        [SerializeField] private float deaccelerating = 3f;
        [SerializeField] private float turnSpeed = 100f;  
        [SerializeField] private float pitchSpeed = 100f;

        private float currentSpeed;

        private InputAction pitchAction; 
        private InputAction turnAction;    
        private InputAction slowAction;

        private void Awake()
        {
            pitchAction = new InputAction("Pitch", InputActionType.Value);
            pitchAction.AddBinding("<Keyboard>/w").WithProcessor("scale(factor=1)");
            pitchAction.AddBinding("<Keyboard>/s").WithProcessor("scale(factor=-1)");
            pitchAction.AddBinding("<Gamepad>/leftStick/y");

            turnAction = new InputAction("Turn", InputActionType.Value);
            turnAction.AddBinding("<Keyboard>/a").WithProcessor("scale(factor=-1)");
            turnAction.AddBinding("<Keyboard>/d").WithProcessor("scale(factor=1)");
            turnAction.AddBinding("<Gamepad>/leftStick/x");

            slowAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/space");

            pitchAction.Enable();
            turnAction.Enable();
            slowAction.Enable();
        }

        private void Start()
        {
            currentSpeed = defaultSpeed;
        }

        private void Update()
        {
            MovePlane();
        }

        private void MovePlane()
        {
            float inputV = pitchAction.ReadValue<float>();
            float horizontal = turnAction.ReadValue<float>();
            bool inputSlow = slowAction.IsPressed();

            Vector3 targetEuler = transform.eulerAngles;
            targetEuler.x += inputV * pitchSpeed * Time.deltaTime;
            targetEuler.y += horizontal * turnSpeed * Time.deltaTime;

            float targetRoll = -horizontal * 45f;
            float currentRoll = transform.eulerAngles.z;
            if (currentRoll > 180f) currentRoll -= 360f;
            float newRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * 3f);
            targetEuler.z = newRoll;
            transform.eulerAngles = targetEuler;

            float targetSpeed = inputSlow ? slowSpeed : defaultSpeed;
            float lerpRate = inputSlow ? deaccelerating : accelerating;
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, lerpRate * Time.deltaTime);

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            pitchAction.Disable();
            turnAction.Disable();
            slowAction.Disable();
        }
    }
}
