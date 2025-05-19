// Mede o quão habitável está Marte com base em objetos ativados

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HabitabilityTracker : MonoBehaviour
{
    public Slider taxaHabitavel; // Slider que mostra o progresso
    public List<GameObject> objetosParaAtivar; // Objetos que devem ser ativados

    void Update()
    {
        AtualizarTaxaHabitavel();
    }

    void AtualizarTaxaHabitavel()
    {
        int ativos = 0;

        // Conta quantos objetos estão ativos
        foreach (GameObject obj in objetosParaAtivar)
            if (obj.activeSelf)
                ativos++;

        // Calcula a porcentagem de habitabilidade
        float porcentagem = (float)ativos / objetosParaAtivar.Count * 100f;
        taxaHabitavel.value = porcentagem;

        if (porcentagem >= 100f)
        {
            SceneManager.LoadScene("congrats");
        }
    }
}



