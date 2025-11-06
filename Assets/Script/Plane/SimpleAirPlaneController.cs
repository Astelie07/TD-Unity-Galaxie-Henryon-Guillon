using UnityEngine;
using UnityEngine.InputSystem;

namespace HeneGames.Airplane
{
    public class SimpleAirPlaneController : MonoBehaviour
    {
        [Header("Flight")]
        [SerializeField] private float defaultSpeed = 20f;
        [SerializeField] private float turboSpeed = 40f;
        [SerializeField] private float accelerating = 5f;
        [SerializeField] private float deaccelerating = 3f;
        [SerializeField] private float turnSpeed = 100f;  
        [SerializeField] private float pitchSpeed = 100f;

        [Header("Turbo")]
        [SerializeField] private float turboHeat = 0f;
        [SerializeField] private float turboHeatRate = 20f;
        [SerializeField] private float turboCoolRate = 10f;
        [SerializeField] private float turboOverheatLimit = 100f;
        [SerializeField] private float turboRecoverThreshold = 40f;

        private float currentSpeed;
        private bool turboOverheat;

        // Input system
        private InputAction pitchAction;   // W/S ou stick vertical
        private InputAction turnAction;    // A/D ou stick horizontal
        private InputAction turboAction;   // Souris droite

        private void Awake()
        {
            // Pitch
            pitchAction = new InputAction("Pitch", InputActionType.Value);
            pitchAction.AddBinding("<Keyboard>/w").WithProcessor("scale(factor=1)");
            pitchAction.AddBinding("<Keyboard>/s").WithProcessor("scale(factor=-1)");
            pitchAction.AddBinding("<Gamepad>/leftStick/y");

            // Turn (roll + yaw)
            turnAction = new InputAction("Turn", InputActionType.Value);
            turnAction.AddBinding("<Keyboard>/a").WithProcessor("scale(factor=-1)");
            turnAction.AddBinding("<Keyboard>/d").WithProcessor("scale(factor=1)");
            turnAction.AddBinding("<Gamepad>/leftStick/x");

            // Turbo
            turboAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/rightButton");

            pitchAction.Enable();
            turnAction.Enable();
            turboAction.Enable();
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
            // Entrées
            float inputV = pitchAction.ReadValue<float>();       // Pitch
            float horizontal = turnAction.ReadValue<float>();    // Roll + Yaw
            bool inputTurbo = turboAction.IsPressed();

            // Rotation combinée roll + yaw
            Vector3 targetEuler = transform.eulerAngles;

            // Pitch (montée/descente)
            targetEuler.x += inputV * pitchSpeed * Time.deltaTime;

            // Yaw (rotation horizontale)
            targetEuler.y += horizontal * turnSpeed * Time.deltaTime;

            // Roll (inclinaison)
            float targetRoll = -horizontal * 45f; // Inclinaison maximale ±45°
            float currentRoll = transform.eulerAngles.z;
            if (currentRoll > 180f) currentRoll -= 360f; // Correction pour angles >180°
            float newRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * 3f);
            targetEuler.z = newRoll;

            transform.eulerAngles = targetEuler;

            // Turbo / vitesse
            if (inputTurbo && !turboOverheat)
            {
                turboHeat += turboHeatRate * Time.deltaTime;
                if (turboHeat >= turboOverheatLimit)
                {
                    turboHeat = turboOverheatLimit;
                    turboOverheat = true;
                }
                currentSpeed = Mathf.Lerp(currentSpeed, turboSpeed, accelerating * Time.deltaTime);
            }
            else
            {
                turboHeat -= turboCoolRate * Time.deltaTime;
                if (turboHeat <= turboRecoverThreshold) turboOverheat = false;
                turboHeat = Mathf.Clamp(turboHeat, 0f, turboOverheatLimit);
                currentSpeed = Mathf.Lerp(currentSpeed, defaultSpeed, deaccelerating * Time.deltaTime);
            }

            // Déplacement
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            pitchAction.Disable();
            turnAction.Disable();
            turboAction.Disable();
        }
    }
}
