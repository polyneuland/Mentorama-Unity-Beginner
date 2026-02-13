using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Permite que a classe apareça e seja editável no Inspector
public class Enigma
{
    //Faz todos esses campos aparecerem no Inspector e guardam os textos do enigma
    [SerializeField] public string pergunta;
    [SerializeField] public string respostaCorreta;
    [SerializeField] public string respostaErrada1;
    [SerializeField] public string respostaErrada2;
    [SerializeField] public string respostaErrada3;
    
}