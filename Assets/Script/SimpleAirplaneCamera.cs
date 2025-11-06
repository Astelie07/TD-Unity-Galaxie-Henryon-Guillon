using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem; 

namespace HeneGames.Airplane
{
    public class SimpleAirplaneCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SimpleAirPlaneController airPlaneController;
        [SerializeField] private CinemachineFreeLook freeLook;

        [Header("Camera values")]
        [SerializeField] private float cameraDefaultFov = 60f;
        [SerializeField] private float cameraTurboFov = 40f;

        private InputAction turboAction;

        private void Awake()
        {
            // Turbo avec "Shift gauche"
            turboAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/leftShift");
            turboAction.Enable();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            CameraFovUpdate();
        }

        private void CameraFovUpdate()
        {
            // Si la touche Turbo est pressée → zoom
            if (turboAction.IsPressed())
            {
                ChangeCameraFov(cameraTurboFov);
            }
            else
            {
                ChangeCameraFov(cameraDefaultFov);
            }
        }

        private void ChangeCameraFov(float _fov)
        {
            float _delta = Time.deltaTime * 10f;
            freeLook.m_Lens.FieldOfView = Mathf.Lerp(freeLook.m_Lens.FieldOfView, _fov, _delta);
        }

        private void OnDestroy()
        {
            turboAction.Disable();
        }
    }
}
