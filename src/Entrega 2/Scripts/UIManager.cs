using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Refer�ncia ao canvas principal da interface
    public GameObject mainCanvas;

    // Refer�ncia ao canvas da hist�ria
    public GameObject historiaCanvas;

    // Refer�ncia ao canvas do construtor
    public GameObject constructorCanvas;

    // Refer�ncia ao canvas "Como Jogar"
    public GameObject comoJogar;

    void Start()
    {
        // M�todo vazio - pode ser usado no futuro se necess�rio
    }

    void Update()
    {
        // M�todo vazio - pode ser usado para intera��es cont�nuas
    }

    // Exibe o canvas da hist�ria e torna o cursor vis�vel
    public void OpenHistory()
    {
        historiaCanvas.SetActive(true);
        Cursor.visible = true;
    }

    // Exibe o canvas do construtor e torna o cursor vis�vel
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

    // Exibe o canvas "Como Jogar" e torna o cursor vis�vel
    public void ComoJogar()
    {
        comoJogar.SetActive(true);
        Cursor.visible = true;
    }
}

