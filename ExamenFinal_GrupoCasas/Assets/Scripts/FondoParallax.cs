using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoParallax : MonoBehaviour
{
    public float parallaxEffect = 0.5f;
    private float length;
    private float startPosition;
    private Transform camTransform;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float dist = (camTransform.position.x * parallaxEffect);
        float temp = (camTransform.position.x * (1-parallaxEffect));
        float newPos = startPosition + dist;

        transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
        
        if(temp > startPosition + length)
        {
            startPosition += length;
        }

        else if(temp < startPosition - length)
        {
            startPosition -= length;
        }

    }
}
