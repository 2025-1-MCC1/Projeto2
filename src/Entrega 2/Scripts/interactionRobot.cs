using UnityEngine;

public class interactionRobot : MonoBehaviour
{
    public GameObject menuCanvas;      // Menu que aparece ao apertar "E"
    public GameObject messageCanvas;   // Mensagem do tipo "Aperte E para interagir"

    private bool interaction = false;  // Se o jogador est� na �rea de intera��o

    void Update()
    {
        // Se o jogador est� perto e apertou "E"
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            menuCanvas.SetActive(true);              // Mostra o menu principal
            Time.timeScale = 0f;                     // Pausa o jogo
            Cursor.visible = true;                   // Mostra o cursor
            Cursor.lockState = CursorLockMode.None;  // Libera o cursor
        }
    }

    // Quando o jogador entra na �rea do rob�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction = true;
            messageCanvas.SetActive(true); // Mostra a mensagem "Aperte E"
        }
    }

    // Quando o jogador sai da �rea
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction = false;
            messageCanvas.SetActive(false); // Esconde a mensagem
        }
    }
}


