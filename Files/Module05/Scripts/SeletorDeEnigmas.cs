using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeletorDeEnigmas : MonoBehaviour
{
    [SerializeField] ListaDeEnigmas lista; //Guarda todas as perguntas do quiz

    //Textos das perguntas, respostas, pontuação e recorde
    [SerializeField] Text perguntaTexto;
    [SerializeField] Text botao1Texto;
    [SerializeField] Text botao2Texto;
    [SerializeField] Text botao3Texto;
    [SerializeField] Text botao4Texto;
    [SerializeField] Text scoreTexto;
    [SerializeField] Text recordTexto;
    [SerializeField] int totalPerguntas = 3; //Quantidsade máxima de perguntas por partida

    //Botões de resposta
    [SerializeField] Button botao1;
    [SerializeField] Button botao2;
    [SerializeField] Button botao3;
    [SerializeField] Button botao4;

    //Referência os painéis
    [SerializeField] GameObject painelInicial;
    [SerializeField] GameObject painelFinal;

    //Textos mostrados no final do jogo
    [SerializeField] Text pontuacaoFinalTexto;
    [SerializeField] Text mensagemFinalTexto;

    List<string> respostasPossiveis = new List<string>(); //Lista temporária para embaralhar as respostas
    List<Enigma> perguntasRestantes = new List<Enigma>(); //Lista com perguntas que ainda não foram usadas

    //Variáveis para a pergunta atual, pontuação e recorde
    int index;
    int score;
    int record;
    int perguntasRespondidas = 0; //Contador de perguntas já respondidas

    void Start()
    {
        perguntasRestantes = new List<Enigma>(lista.listaDeEnigmas); //Copia todas as perguntas para a lista de perguntas restantes

        record = PlayerPrefs.GetInt("record", 0); //Pega o recorde salvo no computador (se não existir, começa com 0)
        recordTexto.text = "RECORD: " + record; //Atualiza o texto
        scoreTexto.text = "PONTOS: 0"; //Inicia com 0 pontos

        GerarEnigma(); //Gera a primeira pergunta
    }

    void GerarEnigma()
    {
        if (perguntasRestantes.Count == 0) //Se não houver mais perguntas
        {
            painelInicial.SetActive(false); //Esconde o painel inicial do jogo
            painelFinal.SetActive(true); //Mostra o painel final
            pontuacaoFinalTexto.text = "PONTUAÇÃO FINAL: " + score; //Pontuação final
            return; //A execução encerra aqui
        }

        respostasPossiveis.Clear(); //Limpa a lista de respostas para não misturar com a anterior

        index = Random.Range(0, perguntasRestantes.Count); //Escolhe uma pergunta aleatória

        Enigma perguntaSorteada = perguntasRestantes[index]; //Guarda a pergunta sorteada

        perguntaTexto.text = perguntaSorteada.pergunta; //Mostra o texto da pergunta na tela

        //Garante que todos os botões estejam ativos
        botao1.gameObject.SetActive(true);
        botao2.gameObject.SetActive(true);
        botao3.gameObject.SetActive(true);
        botao4.gameObject.SetActive(true);

        //Adiciona todas as respostas na lista temporária
        respostasPossiveis.Add(perguntaSorteada.respostaCorreta);
        respostasPossiveis.Add(perguntaSorteada.respostaErrada1);
        respostasPossiveis.Add(perguntaSorteada.respostaErrada2);
        respostasPossiveis.Add(perguntaSorteada.respostaErrada3);

        Text[] botoes = { botao1Texto, botao2Texto, botao3Texto, botao4Texto }; //Array com os textos dos botões

        for (int i = 0; i < botoes.Length; i++) //Embaralha as respostas nos botões
        {
            int indexAleatorio = Random.Range(0, respostasPossiveis.Count); //Pega uma resposta aleat[oria da lista
            botoes[i].text = respostasPossiveis[indexAleatorio]; //Coloca essa resposta no botão
            respostasPossiveis.RemoveAt(indexAleatorio); //Remove para não repetir
        }
    }

    public void Clicar(Text textoBotao)
    {
        Enigma perguntaAtual = perguntasRestantes[index];

        if (textoBotao.text == perguntaAtual.respostaCorreta) //Se a resposta estiver certa, soma pontos
        {
            score += 5;
            scoreTexto.text = "PONTOS: " + score;

            if (score > record) //Atualiza o recorde se necessário
            {
                record = score;
                recordTexto.text = "RECORD: " + record;
                PlayerPrefs.SetInt("record", record);
            }
        }

        //Remove a pergunta atual, independente de acertar ou errar
        perguntasRestantes.RemoveAt(index);
        perguntasRespondidas++;

        //Verifica fim do jogo
        if (perguntasRespondidas >= totalPerguntas || perguntasRestantes.Count == 0)
        {
            painelInicial.SetActive(false);
            painelFinal.SetActive(true);
            pontuacaoFinalTexto.text = "PONTUAÇÃO FINAL: " + score;
            AtualizarMensagemFinal();
        }
        else
        {
            GerarEnigma();
        }
    }

public void UsarCoracao() //Método para remover uma resposta errada
    {
        string respostaCorreta = perguntasRestantes[index].respostaCorreta; //Pega a resposta correta

        Button[] botoes = { botao1, botao2, botao3, botao4 };

        List<Button> respostasErradas = new List<Button>(); //Guarda os botões errados

        foreach (Button b in botoes) //Percorre todos os botões
        {
            string textoBotao = b.GetComponentInChildren<Text>().text; //Pega o texto do botão

            if (textoBotao != respostaCorreta && b.gameObject.activeSelf) //Se for errado e estiver ativo
            {
                respostasErradas.Add(b);
            }
        }

        if (respostasErradas.Count > 0) //Se existir pelo menos uma errada
        {
            int randomIndex = Random.Range(0, respostasErradas.Count); //Escolhe uma errada aleatória
            respostasErradas[randomIndex].gameObject.SetActive(false); //Desativa
        }
    }

    void AtualizarMensagemFinal() //Método chamado quando o jogo finalizar
    {
        switch (score) //Avalia o valor atual da variável score
        {
            case 0: //Se o jogo finalizar com 0 pontos, define o texto que aparece na tela
                mensagemFinalTexto.text =
                    "Parece que o mistério foi maior dessa vez... Não desista!";
                break;

            case 5:
                mensagemFinalTexto.text =
                    "Bom começo! Você já entende muito sobre o mundo dos games!";
                break;

            case 10:
                mensagemFinalTexto.text =
                    "Impressionante! Sua mente está afiada no mundo dos jogos!";
                break;

            case 15:
                mensagemFinalTexto.text =
                    "Incrível! Você alcançou a perfeição!\n O troféu de ouro é oficialmente seu!";
                break;

            default: //Se nenhum dos valores acima for atendido, mostra uma mensagem e encerra o switch
                mensagemFinalTexto.text = 
                    "Não desista e continue jogando!";
                break;
        }
    }
}