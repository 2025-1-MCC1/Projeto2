// Gerencia os slots da hotbar (UI) e os recursos coletados no jogo

using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public RawImage[] slots; // Imagens dos slots na UI
    public GameObject pickaxeObject; // Picareta visível na mão do jogador
    public int pickaxeSlotIndex = 0; // Índice do slot da picareta

    private int selectedIndex = 0; // Slot atualmente selecionado

    // Textos da UI para mostrar os recursos
    public TMP_Text ironText;
    public TMP_Text magnesioText;
    public TMP_Text silicioText;
    public TMP_Text titanioText;

    // Contadores internos dos recursos
    private int ironCount = 0;
    private int magnesioCount = 0;
    private int silicioCount = 0;
    private int titanioCount = 0;

    void Start()
    {
        UpdateSelection(); // Inicializa com o slot 0 selecionado
    }

    void Update()
    {
        // Checa se uma tecla numérica foi pressionada para trocar o slot
        for (int i = 0; i < slots.Length; i++)
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                selectedIndex = i;
                UpdateSelection();
            }
    }

    void UpdateSelection()
    {
        // Atualiza as cores dos slots (destaque o selecionado)
        for (int i = 0; i < slots.Length; i++)
            slots[i].color = (i == selectedIndex) ? Color.yellow : Color.white;

        // Ativa ou desativa a picareta dependendo do slot selecionado
        pickaxeObject.SetActive(selectedIndex == pickaxeSlotIndex);
    }

    public int GetSelectedSlotIndex()
    {
        return selectedIndex;
    }

    // Métodos para adicionar e atualizar recursos
    public void AddIron(int amount)
    {
        ironCount += amount;
        UpdateIronUI();
    }
    void UpdateIronUI() => ironText.text = ironCount.ToString();

    public void AddMagnesio(int amount)
    {
        magnesioCount += amount;
        UpdateMagnesioUI();
    }
    void UpdateMagnesioUI() => magnesioText.text = magnesioCount.ToString();

    public void AddSilicio(int amount)
    {
        silicioCount += amount;
        UpdateSilicioUI();
    }
    void UpdateSilicioUI() => silicioText.text = silicioCount.ToString();

    public void AddTitanio(int amount)
    {
        titanioCount += amount;
        UpdateTitanioUI();
    }
    void UpdateTitanioUI() => titanioText.text = titanioCount.ToString();

    // Verifica se o jogador tem recursos suficientes
    public bool HasResources(int iron, int silicio, int magnesio, int titanio)
    {
        return ironCount >= iron &&
               silicioCount >= silicio &&
               magnesioCount >= magnesio &&
               titanioCount >= titanio;
    }

    // Deduz recursos após usar para construir algo, por exemplo
    public void DeductResources(int iron, int silicio, int magnesio, int titanio)
    {
        ironCount -= iron;
        silicioCount -= silicio;
        magnesioCount -= magnesio;
        titanioCount -= titanio;

        // Atualiza a UI
        UpdateIronUI();
        UpdateSilicioUI();
        UpdateMagnesioUI();
        UpdateTitanioUI();
    }
}



