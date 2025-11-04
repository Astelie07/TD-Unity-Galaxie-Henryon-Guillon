using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform refTarget;
    public Vector3 orbitAxis = Vector3.up;
    public Vector3 selfSpinAxis = Vector3.up;
    public float orbitRadius = 0f;
    public float orbitSpeed = 45f;
    public float selfSpinSpeed = 90f;
    public bool lookAtTarget = false;

    private Vector3 offset;

    void Start()
    {
        if (refTarget == null)
        {
            Debug.LogWarning($"{nameof(Orbit)}: donnez l'élément référence pour '{gameObject.name}'. Script désactivé.", this);
            enabled = false;
            return;
        }

        offset = transform.position - refTarget.position;

        if (orbitRadius > 0f)
        {
            offset = offset.normalized * orbitRadius;
            transform.position = refTarget.position + offset;
        }

        if (orbitAxis == Vector3.zero) orbitAxis = Vector3.up;
        if (selfSpinAxis == Vector3.zero) selfSpinAxis = Vector3.up;
    }

    void Update()
    {
        transform.RotateAround(refTarget.position, orbitAxis.normalized, orbitSpeed * Time.deltaTime);

        if (orbitRadius > 0f)
        {
            Vector3 dir = (transform.position - refTarget.position).normalized;
            transform.position = refTarget.position + dir * orbitRadius;
        }

        transform.Rotate(selfSpinAxis.normalized, selfSpinSpeed * Time.deltaTime, Space.Self);

        if (lookAtTarget)
        {
            transform.LookAt(refTarget);
        }
    }
}
