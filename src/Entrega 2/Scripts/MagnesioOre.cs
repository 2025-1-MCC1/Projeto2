using UnityEngine;

public class MagnesioOre : MonoBehaviour
{
    public int amountToGive = 15; // Quantidade de magn�sio a ser coletado

    private bool playerNearby = false; // Se o jogador est� perto

    void Update()
    {
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se o jogador est� com a picareta
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                hotbar.AddMagnesio(amountToGive); // Adiciona magn�sio � hotbar
                Destroy(gameObject); // Remove o min�rio da cena
            }
            else
            {
                Debug.Log("Voc� precisa estar com a picareta selecionada!");
            }
        }
    }

    // Quando o jogador entra na �rea do min�rio
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Quando o jogador sai da �rea do min�rio
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
