using UnityEngine;

public class titanioOre : MonoBehaviour
{
    // Quantidade de tit�nio que ser� adicionada ao invent�rio ao minerar
    public int amountToGive = 9;

    // Indica se o jogador est� pr�ximo do min�rio
    private bool playerNearby = false;

    void Update()
    {
        // Verifica se o jogador est� perto e clicou com o bot�o esquerdo do mouse
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            // Procura o HotbarManager na cena
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se a picareta est� selecionada
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                // Adiciona tit�nio ao invent�rio e destr�i o min�rio da cena
                hotbar.AddTitanio(amountToGive);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Voc� precisa estar com a picareta selecionada!");
            }
        }
    }

    // Detecta quando o jogador entra na �rea do min�rio
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Detecta quando o jogador sai da �rea do min�rio
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}

