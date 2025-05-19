using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sateliteManager : MonoBehaviour
{
    // Lista de satélites que serão ativados um por um
    public List<GameObject> satelite;

    // Índice atual do satélite a ser ativado
    private int currentIndex = 0;

    // Botão que o jogador clica para ativar satélites
    public Button activateButton;

    // Texto da UI para exibir mensagens ao jogador
    public TMP_Text messageText;

    // Referência ao HotbarManager para controle de recursos
    private HotbarManager hotbarManager;

    void Start()
    {
        // Encontra o HotbarManager na cena
        hotbarManager = FindObjectOfType<HotbarManager>();

        // Associa o botão ao método que ativa os satélites
        activateButton.onClick.AddListener(ActivateNextSatelite);

        // Oculta o texto de mensagem inicialmente
        messageText.gameObject.SetActive(false);
    }

    // Ativa o próximo satélite da lista, se houver recursos
    void ActivateNextSatelite()
    {
        if (currentIndex >= satelite.Count)
            return;

        if (HasRequiredResources())
        {
            DeductResources();
            satelite[currentIndex].SetActive(true);
            currentIndex++;
            StartCoroutine(ShowMessage("Satélite criado com sucesso!", 1f));
        }
        else
        {
            StartCoroutine(ShowMessage("Recursos insuficientes!", 1f));
        }
    }

    // Verifica se o jogador tem os recursos necessários
    bool HasRequiredResources()
    {
        return hotbarManager.HasResources(3, 2, 2, 1); // (exemplo: ferro, silício, cobre, etc.)
    }

    // Deduz os recursos necessários do inventário do jogador
    void DeductResources()
    {
        hotbarManager.DeductResources(3, 2, 2, 1);
    }

    // Mostra uma mensagem por um tempo na tela
    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        messageText.gameObject.SetActive(false);
    }
}


