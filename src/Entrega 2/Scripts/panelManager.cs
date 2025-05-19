using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public List<GameObject> solarPanels; // Lista dos pain�is solares dispon�veis
    private int currentIndex = 0;        // Qual painel ser� ativado em seguida

    public Button activateButton;        // Bot�o da interface para ativar painel
    public TMP_Text messageText;         // Mensagem de feedback ao jogador
    private HotbarManager hotbarManager; // Acesso aos recursos do jogador

    void Start()
    {
        hotbarManager = FindObjectOfType<HotbarManager>();
        activateButton.onClick.AddListener(ActivateNextPanel); // Quando clicar, ativa painel
        messageText.gameObject.SetActive(false); // Oculta o texto no in�cio
    }

    // Ativa o pr�ximo painel da lista
    void ActivateNextPanel()
    {
        if (currentIndex >= solarPanels.Count)
            return;

        if (HasRequiredResources())
        {
            DeductResources();
            solarPanels[currentIndex].SetActive(true); // Liga o painel
            currentIndex++;
            StartCoroutine(ShowMessage("Painel criado com sucesso!", 1f));
        }
        else
        {
            StartCoroutine(ShowMessage("Recursos insuficientes!", 1f));
        }
    }

    // Mostra mensagem tempor�ria
    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        messageText.gameObject.SetActive(false);
    }

    // Verifica se o jogador tem os recursos necess�rios
    bool HasRequiredResources()
    {
        return hotbarManager.HasResources(2, 2, 1, 1);
    }

    // Retira os recursos ap�s ativar o painel
    void DeductResources()
    {
        hotbarManager.DeductResources(2, 2, 1, 1);
    }
}


