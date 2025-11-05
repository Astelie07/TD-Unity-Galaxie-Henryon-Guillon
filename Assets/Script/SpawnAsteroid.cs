using UnityEngine;
using UnityEngine.InputSystem; 

public class SpawnAsteroid : MonoBehaviour
{
    public Transform sun; // Le Soleil
    public GameObject asteroidPrefab; 
    public float spawnRadius = 15f; // distance max de Soleil

    void Update()
    {
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (sun == null || asteroidPrefab == null) return;

        Vector3 randomPos = sun.position + Random.onUnitSphere * spawnRadius;
        randomPos.y = Mathf.Clamp(randomPos.y, -spawnRadius/2f, spawnRadius/2f); 

        GameObject asteroid = Instantiate(asteroidPrefab, randomPos, Random.rotation);
        asteroid.AddComponent<RotateSelf>(); 
    }
}
