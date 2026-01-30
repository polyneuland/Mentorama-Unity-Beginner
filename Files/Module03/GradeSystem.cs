using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeSystem : MonoBehaviour
{
    [SerializeField] double[] notes = new double[10]; //A variável aparece no Inspector, o valor pode ser editado diretamente pelo Editor

    //Declaração e inicialização de variáveis
    double total = 0;
    double average = 0;

    void Start()
    {
        for(int i = 0; i < notes.Length; i++) //Percorre todas as notas
        {
            total += notes[i]; //Acumula os valores das notas ao longo do loop
            ClassifyStudent(notes[i], i + 1); //Envia a nota do aluno e envia qual aluno é
        }
        average = total / notes.Length; //Calcula a média
        Debug.Log($"Média da turma: {average:F2}"); //Mostra no console
    }

    void ClassifyStudent(double grade, int studentNumber) //Recebe a nota e o número do aluno
    {
        if(grade >= 7) //Verifica se a nota é maior que 7
        {
            Debug.Log($"Aluno {studentNumber} - Nota: {grade:F1} - Aprovado");
        }
        else if (grade >= 5 && grade < 7) //Verifica se a nota está entre 5 e 7
        {
            Debug.Log($"Aluno {studentNumber} - Nota: {grade:F1} - Recuperação");
        }
        else //Caso não seja nenhuma das condições acima, executa esse bloco de código
        {
            Debug.Log($"Aluno {studentNumber} - Nota: {grade:F1} - Reprovado");
        }
    }
}