using UnityEngine;

public class silicioOre : MonoBehaviour
{
    // Quantidade de sil�cio que ser� adicionada ao invent�rio ao minerar
    public int amountToGive = 12;

    // Indica se o jogador est� pr�ximo do min�rio
    private bool playerNearby = false;

    void Update()
    {
        // Verifica se o jogador est� perto e clicou com o bot�o esquerdo do mouse
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            // Procura o HotbarManager na cena
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se o HotbarManager existe e se o jogador est� com a picareta selecionada
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                // Adiciona sil�cio ao invent�rio
                hotbar.AddSilicio(amountToGive);

                // Destroi o objeto do min�rio ap�s a coleta
                Destroy(gameObject);
            }
            else
            {
                // Mensagem de aviso se a picareta n�o estiver selecionada
                Debug.Log("Voc� precisa estar com a picareta selecionada!");
            }
        }
    }

    // Detecta quando o jogador entra na �rea de coleta do min�rio (collider com isTrigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Detecta quando o jogador sai da �rea de coleta do min�rio
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}

