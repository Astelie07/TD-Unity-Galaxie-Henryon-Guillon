using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnAsteroid : MonoBehaviour
{
    public Transform sun;
    public GameObject asteroidPrefab;
    public float spawnRadius = 15f;
    private InputAction leftMouseClick;

    private void Awake() {
        leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
        leftMouseClick.performed += ctx => LeftMouseClicked();
        leftMouseClick.Enable();
    }

    private void LeftMouseClicked()
    {
        print("LeftMouseClicked");
        Vector3 randomPos = sun.position + Random.onUnitSphere * spawnRadius;
        randomPos.y = Mathf.Clamp(randomPos.y, -spawnRadius / 2f, spawnRadius / 2f);

        GameObject asteroid = Instantiate(asteroidPrefab, randomPos, Random.rotation);
        asteroid.AddComponent<RotateSelf>();
    }

}
