using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    //Referências aos objetos de UI que representam os painéis
    public GameObject mainMenu;
    public GameObject setupPanel;
    public GameObject musicPanel;

    void Start()
    {
        ShowMainMenu(); //Assim que iniciar, o menu principal é a primeira tela
    }

    public void ShowMainMenu() //Função para ativar o menu principal
    {
        DisableAll(); //Primeiro apaga tudo
        mainMenu.SetActive(true); //Depois liga só o principal
    }

    public void ShowSetupPanel() //Função para ativar o painel de dificuldade
    {
        DisableAll();
        setupPanel.SetActive(true); //Mostra o painel
    }

    public void ShowMusicPanel() //Função para ativar o painel de música
    {
        DisableAll();
        musicPanel.SetActive(true);
    }

    void DisableAll() //Função para desligar todos os painéis de uma vez
    {
        mainMenu.SetActive(false);
        setupPanel.SetActive(false);
        musicPanel.SetActive(false);
    }
}