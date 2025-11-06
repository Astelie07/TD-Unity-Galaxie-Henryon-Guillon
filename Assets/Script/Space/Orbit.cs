using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform refTarget;
    public Vector3 orbitAxis = Vector3.up;
    public Vector3 selfSpinAxis = Vector3.up;
    public float orbitSpeed = 45f;
    public float selfSpinSpeed = 90f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - refTarget.position;

        if (orbitAxis == Vector3.zero) orbitAxis = Vector3.up;
        if (selfSpinAxis == Vector3.zero) selfSpinAxis = Vector3.up;
    }

    void Update()
    {
        transform.RotateAround(refTarget.position, orbitAxis.normalized, orbitSpeed * Time.deltaTime);

        transform.Rotate(selfSpinAxis.normalized, selfSpinSpeed * Time.deltaTime, Space.Self);

    }
}
