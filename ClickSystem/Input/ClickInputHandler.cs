// Ubicación del archivo: Assets/Scripts/ClickSystem/Input/ClickInputHandler.cs

using UnityEngine;
using UnityEngine.InputSystem; // Requiere el paquete 'Input System'
using ClickSystem.Logic;       // Referencia a nuestra lógica
using ClickSystem.Data;        // Referencia a nuestros datos

namespace ClickSystem.Input
{
    /// <summary>
    /// Controlador principal del sistema.
    /// Detecta el input del usuario, lanza rayos (Raycast) y coordina la extracción y envío de datos.
    /// </summary>
    public class ClickInputHandler : MonoBehaviour
    {
        [Header("Configuración Principal")]
        /// <summary>
        /// Referencia a la cámara principal para convertir coordenadas de pantalla a mundo.
        /// </summary>
        [SerializeField] private Camera _mainCamera;

        /// <summary>
        /// Referencia al script que ejecutará la lógica final.
        /// </summary>
        [SerializeField] private LogicExecutor _executor;

        [Header("Filtros")]
        /// <summary>
        /// Capas (Layers) que serán detectadas por el click. Útil para ignorar UI o fondos.
        /// </summary>
        [SerializeField] private LayerMask _targetLayers;

        /// <summary>
        /// Método de Unity: Se llama al inicializar el script.
        /// </summary>
        private void Awake()
        {
            // Si no se asignó cámara en el inspector, buscamos la cámara principal etiquetada como MainCamera.
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }
        }

        /// <summary>
        /// Método de Unity: Se llama en cada frame.
        /// </summary>
        private void Update()
        {
            // Verificamos si se presionó el botón izquierdo del ratón en este frame.
            // Usamos Mouse.current del nuevo Input System.
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                // Leemos la posición del puntero en pantalla (píxeles).
                Vector2 mousePos = Mouse.current.position.ReadValue();
                
                // Iniciamos el proceso de manejo del click.
                HandleClick(mousePos);
            }
        }

        /// <summary>
        /// Procesa la lógica del click: Raycast -> Extracción -> Ejecución.
        /// </summary>
        /// <param name="screenPosition">Posición del cursor en la pantalla.</param>
        private void HandleClick(Vector2 screenPosition)
        {
            // 1. Convertir posición de pantalla a posición de mundo 2D.
            Vector2 worldPoint = _mainCamera.ScreenToWorldPoint(screenPosition);

            // 2. Lanzar Raycast 2D en ese punto.
            // Usamos Vector2.zero como dirección porque es un punto exacto, no una línea.
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 0f, _targetLayers);

            // 3. Verificar si golpeamos algo con Collider2D.
            if (hit.collider != null)
            {
                // Obtenemos el GameObject golpeado.
                GameObject hitObject = hit.collider.gameObject;

                // --- CONFIGURACIÓN DE LA PLANTILLA ---
                // Aquí decides qué componente quieres extraer para este proyecto.
                // Por ejemplo, aquí buscamos un 'SpriteRenderer'. 
                // En el futuro, cambiarías <SpriteRenderer> por tu propio script, ej: <EnemyBehavior>.
                
                InspectionPayload payload = PropertyMiner.MineProperties<SpriteRenderer>(hitObject);

                // 4. Enviar los datos al ejecutor.
                _executor.Execute(payload);
            }
        }
    }
}