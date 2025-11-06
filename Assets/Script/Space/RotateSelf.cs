using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public Vector3 selfSpinAxis = Vector3.up;
    public float selfSpinSpeed = 90f;


    void Start()
    {
        if (selfSpinAxis == Vector3.zero) selfSpinAxis = Vector3.up;
    }

    void Update()
    {
        transform.Rotate(selfSpinAxis.normalized, selfSpinSpeed * Time.deltaTime, Space.Self);

    }
}
