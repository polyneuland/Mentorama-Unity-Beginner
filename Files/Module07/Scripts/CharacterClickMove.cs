using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClickMove : MonoBehaviour
{
    public Transform alvo;
    public float velocidade = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        Vector3 novaPosicao = Vector3.MoveTowards(rb.position, alvo.position, velocidade * Time.fixedDeltaTime);
        rb.MovePosition(novaPosicao);
    }
}
