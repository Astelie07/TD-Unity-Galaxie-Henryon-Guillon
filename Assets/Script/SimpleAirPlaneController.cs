using UnityEngine;

namespace HeneGames.Airplane
{
    public class SimpleAirPlaneController : MonoBehaviour
    {
        [Header("Flight")]
        [SerializeField] private float defaultSpeed = 20f;
        [SerializeField] private float turboSpeed = 40f;
        [SerializeField] private float accelerating = 5f;
        [SerializeField] private float deaccelerating = 3f;
        [SerializeField] private float yawSpeed = 50f;
        [SerializeField] private float pitchSpeed = 100f;
        [SerializeField] private float rollSpeed = 200f;

        [Header("Turbo")]
        [SerializeField] private float turboHeat = 0f;
        [SerializeField] private float turboHeatRate = 20f;
        [SerializeField] private float turboCoolRate = 10f;
        [SerializeField] private float turboOverheatLimit = 100f;
        [SerializeField] private float turboRecoverThreshold = 40f;

        private float currentSpeed;
        private bool turboOverheat;

        // Inputs
        private float inputH, inputV;
        private bool inputTurbo, inputYawLeft, inputYawRight;

        private void Start()
        {
            currentSpeed = defaultSpeed;
        }

        private void Update()
        {
            HandleInputs();
            MovePlane();
        }

        private void HandleInputs()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");
            inputYawLeft = Input.GetKey(KeyCode.Q);
            inputYawRight = Input.GetKey(KeyCode.E);
            inputTurbo = Input.GetKey(KeyCode.LeftShift);
        }

        private void MovePlane()
        {
            // Rotation
            transform.Rotate(Vector3.forward * -inputH * rollSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * inputV * pitchSpeed * Time.deltaTime);
            if (inputYawRight) transform.Rotate(Vector3.up * yawSpeed * Time.deltaTime);
            else if (inputYawLeft) transform.Rotate(-Vector3.up * yawSpeed * Time.deltaTime);

            // Turbo
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

            // Avance
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }
}
