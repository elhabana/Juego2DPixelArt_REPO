using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSystem : MonoBehaviour
{
    public GameObject PanelOptions;

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

    public void OpenOptionsPanel()
    {
        PanelOptions.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        PanelOptions.SetActive(false);
    }
}
