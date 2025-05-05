using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour
{
    public Slider Vida, Stamina, Fome;
    public FirstPersonController character;
    private float SpeedInicial, RunInicial;
    void Start()
    {
        Vida.value = 100f;
        Stamina.value = 100f;
        Fome.value = 100f;
        SpeedInicial = character.MoveSpeed;
        RunInicial = character.SprintSpeed;
    }

    
    void Update()
    {
        taxaFome();
        if (Input.GetAxis("Horizontal") != 0 && Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Vertical") != 0)
        {
            Stamina.value -= Time.deltaTime * 2;
        } else
        {
            Stamina.value += Time.deltaTime;
        }

        if (Stamina.value < 0.1f)
        {
            character.SprintSpeed = SpeedInicial;
        }
        else
        {
            character.SprintSpeed = RunInicial;
        }
    }

    void taxaFome ()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Vertical") != 0)
        {
            Fome.value -= Time.deltaTime * 1.5f;
        } else
        {
            Fome.value -= Time.deltaTime;
        }
    }
}
