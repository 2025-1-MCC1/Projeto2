using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sateliteManager : MonoBehaviour
{
    // Lista de sat�lites que ser�o ativados um por um
    public List<GameObject> satelite;

    // �ndice atual do sat�lite a ser ativado
    private int currentIndex = 0;

    // Bot�o que o jogador clica para ativar sat�lites
    public Button activateButton;

    // Texto da UI para exibir mensagens ao jogador
    public TMP_Text messageText;

    // Refer�ncia ao HotbarManager para controle de recursos
    private HotbarManager hotbarManager;

    void Start()
    {
        // Encontra o HotbarManager na cena
        hotbarManager = FindObjectOfType<HotbarManager>();

        // Associa o bot�o ao m�todo que ativa os sat�lites
        activateButton.onClick.AddListener(ActivateNextSatelite);

        // Oculta o texto de mensagem inicialmente
        messageText.gameObject.SetActive(false);
    }

    // Ativa o pr�ximo sat�lite da lista, se houver recursos
    void ActivateNextSatelite()
    {
        if (currentIndex >= satelite.Count)
            return;

        if (HasRequiredResources())
        {
            DeductResources();
            satelite[currentIndex].SetActive(true);
            currentIndex++;
            StartCoroutine(ShowMessage("Sat�lite criado com sucesso!", 1f));
        }
        else
        {
            StartCoroutine(ShowMessage("Recursos insuficientes!", 1f));
        }
    }

    // Verifica se o jogador tem os recursos necess�rios
    bool HasRequiredResources()
    {
        return hotbarManager.HasResources(3, 2, 2, 1); // (exemplo: ferro, sil�cio, cobre, etc.)
    }

    // Deduz os recursos necess�rios do invent�rio do jogador
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


