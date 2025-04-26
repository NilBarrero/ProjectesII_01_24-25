using System.Collections;
using UnityEngine;

public class MovingIntroductionText : MonoBehaviour
{
    public GameObject text; // El GameObject de texto (UI)
    public GameObject background; // El GameObject de fondo (en el mundo 2D)
    public float endYPositions = 1000f; // Posición final en el eje Y (fuera de la pantalla)

    public float animationDuration = 1f; // Duración de la animación
    public float stayingTime = 2; // Tiempo de espera antes de iniciar la animación
    private bool isAnimating = false; // Para evitar múltiples clics durante la animación
    public bool timeIsUp = false; // Controla si ha pasado el tiempo de espera

    private void Update()
    {
        if (!timeIsUp)
        {
            StartCoroutine(TimerCoroutine()); // Llama al temporizador
        }
        else if (!isAnimating)
        {
            // Inicia la animación si no está en curso
            StartCoroutine(AnimateObjects());
        }
    }

    private IEnumerator AnimateObjects()
    {
        isAnimating = true; // Bloquear múltiples clics mientras la animación está en curso

        // Obtener los RectTransform de los objetos UI (texto)
        RectTransform textRectTransform = text.GetComponent<RectTransform>();
        // Obtener el Transform del fondo (GameObject en el mundo 2D)
        Transform backgroundTransform = background.GetComponent<Transform>();

        // Guardar las posiciones iniciales
        Vector2 textStartPosition = textRectTransform.anchoredPosition;
        Vector3 backgroundStartPosition = backgroundTransform.position;

        // La animación comienza
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            // Animar ambos objetos simultáneamente usando Lerp
            float t = elapsedTime / animationDuration;

            // Mover el texto (UI) en el eje Y
            textRectTransform.anchoredPosition = Vector2.Lerp(textStartPosition, new Vector2(textStartPosition.x, endYPositions), t);

            // Mover el fondo (GameObject 2D) en el eje Y
            backgroundTransform.position = Vector3.Lerp(backgroundStartPosition, new Vector3(backgroundStartPosition.x, endYPositions, backgroundStartPosition.z), t);

            elapsedTime += Time.deltaTime; // Incrementar el tiempo transcurrido
            yield return null; // Esperar un frame
        }

        // Asegurar que ambos objetos terminen en la posición final
        textRectTransform.anchoredPosition = new Vector2(textRectTransform.anchoredPosition.x, endYPositions);
        backgroundTransform.position = new Vector3(backgroundTransform.position.x, endYPositions, backgroundTransform.position.z);

        isAnimating = false; // Permitir nuevos clics y animaciones
    }

    private IEnumerator TimerCoroutine()
    {
        // Esperar el tiempo especificado antes de iniciar la animación
        yield return new WaitForSeconds(stayingTime);

        // Esto se ejecutará después de que pase el tiempo
        timeIsUp = true;
    }
}