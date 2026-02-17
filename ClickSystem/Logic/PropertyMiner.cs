// Ubicación del archivo: Assets/Scripts/ClickSystem/Logic/PropertyMiner.cs

using UnityEngine;
using ClickSystem.Data;

namespace ClickSystem.Logic
{
    /// <summary>
    /// Clase utilitaria estática encargada de inspeccionar GameObjects.
    /// Contiene el "Método Plantilla" para extraer componentes específicos de forma genérica.
    /// </summary>
    public static class PropertyMiner
    {
        /// <summary>
        /// Método Plantilla Principal.
        /// Extrae información básica del objeto y busca un componente específico definido por <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">El tipo de Componente que deseamos extraer (ej. Rigidbody2D, SpriteRenderer, ScriptPropio).</typeparam>
        /// <param name="target">El GameObject sobre el cual se hizo click.</param>
        /// <returns>Un objeto <see cref="InspectionPayload"/> con los datos recolectados, o null si el target es inválido.</returns>
        public static InspectionPayload MineProperties<T>(GameObject target) where T : Component
        {
            // Paso 1: Validación de seguridad. Si el objeto no existe, retornamos nulo.
            if (target == null)
            {
                return null;
            }

            // Paso 2: Creación del contenedor de datos (Payload).
            InspectionPayload payload = new InspectionPayload();

            // Paso 3: Extracción de datos básicos comunes a todos los objetos.
            // Asignamos el nombre.
            payload.ObjectName = target.name;
            // Asignamos la posición.
            payload.WorldPosition = target.transform.position;
            // Guardamos la referencia original.
            payload.SourceObject = target;

            // Paso 4: Extracción del componente específico (El Método Plantilla).
            // Usamos TryGetComponent que es la forma más optimizada en Unity para buscar componentes sin generar basura (GC).
            if (target.TryGetComponent<T>(out T foundComponent))
            {
                // Si se encuentra, lo guardamos en la propiedad genérica.
                payload.ExtractedProperty = foundComponent;
            }
            else
            {
                // Si no se encuentra, dejamos la propiedad como null.
                // Esto permite al Ejecutor saber que el objeto no tenía la propiedad deseada.
                payload.ExtractedProperty = null;
            }

            // Paso 5: Retornamos el paquete listo.
            return payload;
        }
    }
}
