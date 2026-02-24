using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destino : MonoBehaviour
{
    public GameObject painelVitoria; //Variável para guardar o painel

    void OnTriggerEnter(Collider other) //Método chamado quando detecta a sobreposição de dois objetos
    {
        if (other.CompareTag("Player")) //Verifica se o objeto que entrou na colisão tenha a etiqueta especificada
        {
            painelVitoria.SetActive(true); //Ativa o painel na tela
        }
    }
}