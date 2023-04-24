using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
   public float jumpforce;
   public float movimiento;
   Rigidbody2D rb; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(rb.velocity.y, movimiento);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-rb.velocity.y, movimiento);
        }
    }
}
