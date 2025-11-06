using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform refTarget;
    public Vector3 orbitAxis = Vector3.up;
    public float orbitSpeed = 45f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - refTarget.position;

        if (orbitAxis == Vector3.zero) orbitAxis = Vector3.up;
    }

    void Update()
    {
        transform.RotateAround(refTarget.position, orbitAxis.normalized, orbitSpeed * Time.deltaTime);
    }
}
