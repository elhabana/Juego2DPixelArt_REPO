using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSystem : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Escena Gamplay");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliste del Juego");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
