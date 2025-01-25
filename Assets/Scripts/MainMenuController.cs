using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button[] buttons; // Asigna los botones desde el Inspector

    private bool isSceneChanging = false; // Para bloquear interacción mientras se cambia de escena

    void Start()
    {
        // Deshabilitar los botones al inicio
        SetButtonsInteractable(false);
    }

    void Update()
    {
        // Si la escena está cambiando, bloquear interacciones
        if (isSceneChanging)
        {
            return; // No permitir interacción
        }

        // Si no hay toques o clics activos, habilitar los botones
        if (!IsTouchOrClickActive())
        {
            SetButtonsInteractable(true); // Habilitar los botones
        }
        else
        {
            SetButtonsInteractable(false); // Deshabilitar los botones mientras se toca o se hace clic
        }
    }

    private bool IsTouchOrClickActive()
    {
        // Detecta si el ratón está presionado o si hay toques en pantalla
        return Input.GetMouseButton(0) || Input.touchCount > 0;
    }

    private void SetButtonsInteractable(bool state)
    {
        // Cambiar el estado de los botones
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }
    }

    public void ChangeScene(string sceneName)
    {
        // Activamos la protección de clics durante la carga de la escena
        isSceneChanging = true;

        // Iniciar la carga de la escena
        SceneManager.LoadScene(sceneName);
    }

    // Llamado al finalizar la carga de una nueva escena
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Una vez la escena esté completamente cargada, deshabilitamos la protección
        isSceneChanging = false;
        SetButtonsInteractable(false); // Asegúrate de que los botones estén deshabilitados al principio
    }
}
