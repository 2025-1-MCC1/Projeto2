using UnityEngine;

public class IronOre : MonoBehaviour
{
    public int amountToGive = 20;  // Quantidade de ferro que esse min�rio fornece

    private bool playerNearby = false; // Detecta se o jogador est� perto

    void Update()
    {
        // Se o jogador est� perto e clicou com o bot�o esquerdo
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se a picareta est� selecionada
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                hotbar.AddIron(amountToGive); // Adiciona ferro ao invent�rio
                Destroy(gameObject);         // Destroi o min�rio
            }
            else
            {
                Debug.Log("Voc� precisa estar com a picareta selecionada!");
            }
        }
    }

    // Ativa detec��o quando o jogador entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Desativa detec��o ao sair do trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}


