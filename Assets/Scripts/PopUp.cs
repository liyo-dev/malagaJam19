using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopUp : MonoBehaviour
{
    public static PopUp Instance; // Singleton para acceso global

    [Header("Popup Components")]
    [SerializeField] private TextMeshProUGUI titleText; // Título del popup
    [SerializeField] private TextMeshProUGUI subtitleText; // Subtítulo del popup
    [SerializeField] private Button yesButton; // Botón "Sí"
    [SerializeField] private Button noButton; // Botón "No"

    private Action onYes; // Acción a ejecutar cuando el jugador presione "Sí"
    private Action onNo; // Acción a ejecutar cuando el jugador presione "No"

    private void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Ocultar popup al inicio
        gameObject.SetActive(false);

        // Configurar listeners iniciales
        yesButton.onClick.AddListener(() => OnYesButtonClicked());
        noButton.onClick.AddListener(() => OnNoButtonClicked());
    }

    /// <summary>
    /// Configura el popup con título, subtítulo y acciones para los botones.
    /// </summary>
    /// <param name="title">Título del popup</param>
    /// <param name="subtitle">Subtítulo del popup</param>
    /// <param name="onYesAction">Acción para el botón "Sí"</param>
    /// <param name="onNoAction">Acción para el botón "No"</param>
    public void Show(string title, string subtitle, Action onYesAction, Action onNoAction)
    {
        // Configurar texto
        titleText.text = title;
        subtitleText.text = subtitle;

        // Configurar acciones
        onYes = onYesAction;
        onNo = onNoAction;

        // Mostrar popup
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Oculta el popup.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnYesButtonClicked()
    {
        onYes?.Invoke(); // Ejecutar acción asociada
        Hide(); // Ocultar popup
    }

    private void OnNoButtonClicked()
    {
        onNo?.Invoke(); // Ejecutar acción asociada
        Hide(); // Ocultar popup
    }
}
