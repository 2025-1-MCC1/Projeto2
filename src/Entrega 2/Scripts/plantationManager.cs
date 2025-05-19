using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class plantationManager : MonoBehaviour
{
    // Lista das plantações que serão ativadas
    public List<GameObject> plantations;

    // Índice atual da plantação a ser ativada
    private int currentIndex = 0;

    // Referências ao botão de ativar e ao texto de mensagem
    public Button activateButton;
    public TMP_Text messageText;

    // Referência ao sistema de inventário/recursos
    private HotbarManager hotbarManager;

    void Start()
    {
        hotbarManager = FindObjectOfType<HotbarManager>();
        activateButton.onClick.AddListener(ActivateNextPlantation);
        messageText.gameObject.SetActive(false);
    }

    // Ativa a próxima plantação se houver recursos
    void ActivateNextPlantation()
    {
        if (currentIndex >= plantations.Count)
            return;

        if (HasRequiredResources())
        {
            DeductResources();
            plantations[currentIndex].SetActive(true);
            currentIndex++;
            StartCoroutine(ShowMessage("Plantação criada com sucesso!", 1f));
        }
        else
        {
            StartCoroutine(ShowMessage("Recursos insuficientes!", 1f));
        }
    }

    // Verifica se o jogador tem os recursos necessários
    bool HasRequiredResources()
    {
        return hotbarManager.HasResources(3, 3, 3, 2);
    }

    // Deduz os recursos usados
    void DeductResources()
    {
        hotbarManager.DeductResources(3, 3, 3, 2);
    }

    // Mostra uma mensagem temporária na tela
    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        messageText.gameObject.SetActive(false);
    }
}


