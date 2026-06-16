using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}