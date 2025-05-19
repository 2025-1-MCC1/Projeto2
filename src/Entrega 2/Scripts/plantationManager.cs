using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class plantationManager : MonoBehaviour
{
    // Lista das planta��es que ser�o ativadas
    public List<GameObject> plantations;

    // �ndice atual da planta��o a ser ativada
    private int currentIndex = 0;

    // Refer�ncias ao bot�o de ativar e ao texto de mensagem
    public Button activateButton;
    public TMP_Text messageText;

    // Refer�ncia ao sistema de invent�rio/recursos
    private HotbarManager hotbarManager;

    void Start()
    {
        hotbarManager = FindObjectOfType<HotbarManager>();
        activateButton.onClick.AddListener(ActivateNextPlantation);
        messageText.gameObject.SetActive(false);
    }

    // Ativa a pr�xima planta��o se houver recursos
    void ActivateNextPlantation()
    {
        if (currentIndex >= plantations.Count)
            return;

        if (HasRequiredResources())
        {
            DeductResources();
            plantations[currentIndex].SetActive(true);
            currentIndex++;
            StartCoroutine(ShowMessage("Planta��o criada com sucesso!", 1f));
        }
        else
        {
            StartCoroutine(ShowMessage("Recursos insuficientes!", 1f));
        }
    }

    // Verifica se o jogador tem os recursos necess�rios
    bool HasRequiredResources()
    {
        return hotbarManager.HasResources(3, 3, 3, 2);
    }

    // Deduz os recursos usados
    void DeductResources()
    {
        hotbarManager.DeductResources(3, 3, 3, 2);
    }

    // Mostra uma mensagem tempor�ria na tela
    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        messageText.gameObject.SetActive(false);
    }
}


