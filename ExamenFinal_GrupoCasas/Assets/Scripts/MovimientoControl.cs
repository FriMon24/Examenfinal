using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoControl : MonoBehaviour
{
    public float velocidad = 5f;
    public float saltofuerza = 7f;
    private Animator Animator;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimiento horizontal
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, -1.0f);

        Animator.SetBool("Correr", horizontal != 0.0f);
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * velocidad;

        // Salto
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0, saltofuerza), ForceMode2D.Impulse);
        }
    }
}
