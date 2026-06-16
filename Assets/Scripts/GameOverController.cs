using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void LoadNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
