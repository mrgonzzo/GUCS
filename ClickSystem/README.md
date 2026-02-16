================================================================================
                            CLICK INSPECTOR SYSTEM
                           Versión 1.0 | Unity 6
================================================================================

1. DESCRIPCIÓN
--------------------------------------------------------------------------------
Este sistema permite detectar clicks en objetos 2D, extraer información de ellos 
(nombre, posición, componentes específicos) y enviarla a un ejecutor de lógica.

Estructura de Carpetas:
- /Data:  Contiene los modelos de datos (Payloads).
- /Logic: Contiene el extractor (Miner) y el ejecutor de acciones.
- /Input: Contiene el detector de clicks y raycasts.

2. REQUISITOS
--------------------------------------------------------------------------------
- Unity 2021.3 o superior (Probado en Unity 6000.3).
- Paquete "Input System" instalado desde el Package Manager.

3. CÓMO USARLO EN UN NUEVO PROYECTO
--------------------------------------------------------------------------------
PASO A: Configuración de Escena
   1. Crea un GameObject vacío llamado "System_Click".
   2. Añade el componente 'LogicExecutor'.
   3. Añade el componente 'ClickInputHandler'.
   4. En 'ClickInputHandler', arrastra el componente 'LogicExecutor' al campo "Executor".
   5. Asegúrate de que 'Target Layers' incluya las capas de tus objetos.

PASO B: Configuración de Objetos
   1. Tus objetos deben tener un Collider2D (BoxCollider2D, CircleCollider2D, etc).

PASO C: Personalización (Avanzado)
   - Para extraer un componente diferente (ej. EnemyHealth):
     Abre 'ClickInputHandler.cs', busca la línea 'PropertyMiner.MineProperties'
     y cambia <SpriteRenderer> por <EnemyHealth>.

4. SOLUCIÓN DE PROBLEMAS
--------------------------------------------------------------------------------
- ¿No detecta clicks? 
  Revisa que el objeto tenga Collider2D y que no haya UI (Canvas) bloqueando el rayo.
  
- ¿Error de 'Mouse.current'? 
  Asegúrate de haber habilitado el New Input System en Project Settings > Player.

================================================================================
