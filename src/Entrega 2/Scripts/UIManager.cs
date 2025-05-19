using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Referência ao canvas principal da interface
    public GameObject mainCanvas;

    // Referência ao canvas da história
    public GameObject historiaCanvas;

    // Referência ao canvas do construtor
    public GameObject constructorCanvas;

    // Referência ao canvas "Como Jogar"
    public GameObject comoJogar;

    void Start()
    {
        // Método vazio - pode ser usado no futuro se necessário
    }

    void Update()
    {
        // Método vazio - pode ser usado para interações contínuas
    }

    // Exibe o canvas da história e torna o cursor visível
    public void OpenHistory()
    {
        historiaCanvas.SetActive(true);
        Cursor.visible = true;
    }

    // Exibe o canvas do construtor e torna o cursor visível
    public void OpenConstructor()
    {
        constructorCanvas.SetActive(true);
        Cursor.visible = true;
    }

    // Fecha todos os canvases e reseta o cursor e o tempo do jogo
    public void FecharTodos()
    {
        mainCanvas.SetActive(false);
        historiaCanvas.SetActive(false);
        constructorCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    // Exibe o canvas "Como Jogar" e torna o cursor visível
    public void ComoJogar()
    {
        comoJogar.SetActive(true);
        Cursor.visible = true;
    }
}

