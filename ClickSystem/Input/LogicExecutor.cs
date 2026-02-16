// Ubicación del archivo: Assets/Scripts/ClickSystem/Logic/LogicExecutor.cs

using UnityEngine;
using ClickSystem.Data;

namespace ClickSystem.Logic
{
    /// <summary>
    /// Componente responsable de ejecutar la lógica del juego basada en los datos recibidos.
    /// Actúa como el consumidor del sistema de clicks.
    /// </summary>
    public class LogicExecutor : MonoBehaviour
    {
        /// <summary>
        /// Método público encargado de procesar el payload.
        /// </summary>
        /// <param name="data">El paquete de datos proveniente del inspector de clicks.</param>
        public void Execute(InspectionPayload data)
        {
            // Validación: Si no hay datos, salimos inmediatamente.
            if (data == null) return;

            // --- Lógica de Ejemplo (Aquí pondrías tu código real del juego) ---

            // 1. Log básico: Muestra el nombre del objeto clickeado.
            Debug.Log($"<color=cyan>[ClickSystem]</color> Objeto detectado: <b>{data.ObjectName}</b>");

            // 2. Verificación de propiedad extraída.
            if (data.ExtractedProperty != null)
            {
                // Si encontramos la propiedad, mostramos su tipo.
                Debug.Log($"<color=green>Propiedad Encontrada:</color> {data.ExtractedProperty.GetType().Name}");

                // Ejemplo de cómo usarlo: Castear el objeto a su tipo real si es necesario.
                // if (data.ExtractedProperty is SpriteRenderer renderer) { renderer.color = Color.red; }
            }
            else
            {
                // Log si no se encontró el componente específico.
                Debug.LogWarning($"El objeto {data.ObjectName} no tenía el componente solicitado.");
            }
        }
    }
}