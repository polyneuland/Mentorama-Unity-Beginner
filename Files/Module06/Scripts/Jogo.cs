using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Biblioteca para permitir o controle das cenas

public class Jogo : MonoBehaviour
{
    public void ReiniciarJogo() //Método para reiniciar o jogo
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Pega as informações da cena que está aberta, ID da cena e a Unity carrega a cena com esse ID
    }
}