using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{

    private Rigidbody carRig; //Variável que guarda o componente da física do carro
    public float velocidade; //Força de aceleração
    public float rotacao; //Velocidade da curva

    void Start()
    {
        carRig = GetComponent<Rigidbody>(); //Busca o componente Rigidbody que está anexado ao mesmo objeto que este script
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //Se a tecla W estiver pressionada
        {
            carRig.AddForce(transform.forward * velocidade * Time.deltaTime, ForceMode.Impulse); //Adiciona força para frente, Impulse dá um "empurrão"
        }

        if (Input.GetKey(KeyCode.S))
        {
            carRig.AddForce(transform.forward * -velocidade * Time.deltaTime, ForceMode.Impulse); //Adiciona força para trás, por isso o sinal de menos
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotacao, 0); //Gira o objeto para a esquerda
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotacao, 0); //Gira o objeto para a direita
        }
    }
}