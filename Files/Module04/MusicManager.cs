using UnityEngine;
using UnityEngine.UI; //Biblioteca para manipular os componentes de UI
using TMPro; //Biblioteca para manipular o TextMeshPro

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Toggle toggle; //Permite que arraste o Toggle no Editor
    public TextMeshProUGUI text; //Referência o componente de texto que será alterado

    void Start()
    {
        toggle.onValueChanged.AddListener(ChangeValue); //Sempre que o valor do Toggle mudar, a função é chamada
    }

    private void ChangeValue(bool isOn) //Recebe um booleano enviado automaticamente pelo Toggle
    {
        if (isOn) //Verifica o estado do Toggle para decidir qual texto mostrar
        {
            text.text = "MUSIC OFF"; //Checkmark aparece
        }
        else
        {
            text.text = "MUSIC ON"; //Checkmark some
        }
    }
}