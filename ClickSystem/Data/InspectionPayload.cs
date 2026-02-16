// Ubicación del archivo: Assets/Scripts/ClickSystem/Data/InspectionPayload.cs

using UnityEngine;

namespace ClickSystem.Data
{
    /// <summary>
    /// Clase de transferencia de datos (DTO).
    /// Contiene toda la información extraída de un objeto tras hacer click sobre él.
    /// </summary>
    [System.Serializable]
    public class InspectionPayload
    {
        /// <summary>
        /// El nombre del GameObject que fue seleccionado en la escena.
        /// </summary>
        public string ObjectName;

        /// <summary>
        /// La posición en el mundo (x, y) donde se encuentra el objeto.
        /// </summary>
        public Vector2 WorldPosition;

        /// <summary>
        /// Referencia directa al GameObject seleccionado, por si se requiere manipulación física (destruir, mover).
        /// </summary>
        public GameObject SourceObject;

        /// <summary>
        /// Propiedad genérica que almacena un componente o dato específico extraído dinámicamente.
        /// Se almacena como 'object' para permitir cualquier tipo de dato (Componente, ScriptableObject, int, etc.).
        /// </summary>
        public object ExtractedProperty;

        /// <summary>
        /// Constructor de la clase. Inicializa los valores por defecto para evitar errores de nulidad.
        /// </summary>
        public InspectionPayload()
        {
            // Inicializamos el nombre como cadena vacía.
            ObjectName = string.Empty;
            // Inicializamos la propiedad extraída como nula explícitamente.
            ExtractedProperty = null;
        }
    }
}
