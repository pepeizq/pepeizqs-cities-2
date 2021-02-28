using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Interfaz
{
    public class Carga : MonoBehaviour
    {
        [Header("Canvas")]
        public Canvas canvasCarga;

        [HideInInspector]
        public Canvas canvasOrigen;

        [Header("Progreso")]
        public Slider progreso;

        [HideInInspector]
        public AsyncOperation cargando;

        private void Start()
        {

        }

        public void Iniciar(Canvas canvasOrigen_)
        {
            canvasOrigen = canvasOrigen_;
            Objetos.Ocultar(canvasOrigen.gameObject);
            Objetos.Mostrar(canvasCarga.gameObject);
            cargando = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            progreso.value = 0;
        }

        private void Update()
        {
            if (cargando != null)
            {
                progreso.value = Mathf.Clamp01(cargando.progress / 0.9f);

                if (cargando.isDone == true)
                {
                    Objetos.Ocultar(canvasCarga.gameObject);
                    Objetos.Mostrar(canvasOrigen.gameObject);
                }
            }
        }
    }
}
