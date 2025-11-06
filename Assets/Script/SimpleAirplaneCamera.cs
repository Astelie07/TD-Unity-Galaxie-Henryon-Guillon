using UnityEngine;
using Cinemachine;

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
            // Si le turbo est actif → zoom
            if (Input.GetKey(KeyCode.LeftShift))
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
    }
}
