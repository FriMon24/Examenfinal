using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
     public GameObject[] platformPrefabs; // Array de prefabs de plataformas
    public GameObject[] destroyablePlatforms; // Array de plataformas que se destruyen
    public Transform generationPoint; // Punto de generación de la siguiente plataforma
    public float distanceBetween; // Distancia entre cada plataforma
    public float distanceBetweenDestroyable; // Distancia entre las plataformas que se destruyen
    public float destroyableProbability; // Probabilidad de que aparezca una plataforma que se destruye
    public float platformWidth; // Ancho de la plataforma
    public float minX; // Posición mínima en el eje X
    public float maxX; // Posición máxima en el eje X
    public float minHeight; // Altura mínima de la plataforma
    public float maxHeight; // Altura máxima de la plataforma
    public float maxHeightChange; // Cambio máximo en la altura de la plataforma
    public float moveSpeed; // Velocidad de movimiento de la plataforma móvil
    public Transform platformParent; // Objeto padre de las plataformas

    private float heightChange;
    private bool movingPlatformRight;
    private float minXPos;
    private float maxXPos;
    private GameObject lastPlatform;

    // Start is called before the first frame update
    private void Start()
    {
        minXPos = minX;
        maxXPos = maxX;
        lastPlatform = platformPrefabs[0];

        // Generar las primeras plataformas para iniciar el nivel
        GenerateInitialPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateInitialPlatforms() {
        // Generar las primeras 3 plataformas para iniciar el nivel
        Vector3 startPosition = transform.position;
        for (int i = 0; i < 3; i++)
        {
            GameObject newPlatform = Instantiate(platformPrefabs[0], startPosition, Quaternion.identity);
            newPlatform.transform.parent = platformParent;
            startPosition.y -= distanceBetween;
            lastPlatform = newPlatform;
        }

        // Generar las primeras plataformas móviles
        GenerateMovingPlatforms();
    }

    private void GenerateMovingPlatforms() {
        // Generar una plataforma móvil al azar cada cierta distancia
        if (Random.Range(0f, 1f) < 0.3f) {
            GameObject newPlatform = Instantiate(platformPrefabs[1], lastPlatform.transform.position + new Vector3(0f, distanceBetween, 0f), Quaternion.identity);
            newPlatform.transform.parent = platformParent;
            lastPlatform = newPlatform;
        }
    }
    
    public void GenerateNextPlatform() {
        // Calcular la posición de la siguiente plataforma
        float newX = transform.position.x + Random.Range(minXPos, maxXPos);
        float newY = transform.position.y + Random.Range(heightChange - maxHeightChange, heightChange + maxHeightChange);
    }
}
