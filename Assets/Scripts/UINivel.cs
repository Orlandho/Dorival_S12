using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UINivel : MonoBehaviour
{
    public TextMeshProUGUI textoNivel;
    public TextMeshProUGUI textoTiempo;
    
    private float tiempoRestante = 30f;
    private bool juegoActivo = true;
    
    void Start()
    {
        textoNivel.text = SceneManager.GetActiveScene().name;
    }
    
    void Update()
    {
        if (!juegoActivo) return;
        
        tiempoRestante -= Time.deltaTime;
        textoTiempo.text = $"Tiempo: {Mathf.CeilToInt(tiempoRestante)}";
        
        if (tiempoRestante <= 0)
        {
    juegoActivo = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}