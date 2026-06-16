using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public int numero;
    private TextMeshPro textoNumerico;
    
    void Start()
    {
        textoNumerico = GetComponentInChildren<TextMeshPro>();
        if (textoNumerico != null)
            textoNumerico.text = numero.ToString();
    }
 
    public void Interactuar()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        int nivelActual = ObtenerNivel(escenaActual);
        int numeroCorrecto = ObtenerFibonacci(nivelActual);
        
        if (numero == numeroCorrecto)
        {
            // Avanzar al siguiente nivel
            int siguiente = nivelActual + 1;
            if (siguiente <= 5)
                SceneManager.LoadScene("Nivel" + siguiente);
            else
                SceneManager.LoadScene("Victoria");
        }
        else
        {
            // Volver al nivel 1
            SceneManager.LoadScene("Nivel1");
        }
    }
    
    int ObtenerNivel(string nombre)
    {
        switch(nombre)
        {
            case "Nivel1": return 1;
            case "Nivel2": return 2;
            case "Nivel3": return 3;
            case "Nivel4": return 4;
            case "Nivel5": return 5;
            default: return 1;
        }
    }
    
    int ObtenerFibonacci(int nivel)
    {
        int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
        return fibonacci[nivel];
    }
}