using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSystem : MonoBehaviour
{
    //FUNCIONES PARA LOS BOTONES DEL MENU

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
