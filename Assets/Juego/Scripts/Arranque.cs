using Interfaz;
using UnityEngine;

namespace Juego
{
    public class Arranque : MonoBehaviour
    {
        [Header("Opciones")]
        public int tamañoEscenarioX;
        public int tamañoEscenarioZ;

        [Header("Canvas")]
        public Canvas canvas;

        [Header("Scripts")]
        public Partidas partidas;
        public Escenario escenario;
        public Panel panelDatos;

        private void Start()
        {
            Objetos.Mostrar(canvas.gameObject);
            //escenario.GenerarAleatorio(10);

            //List<Partida> partidasGuardadas = new List<Partida>();
            //partidasGuardadas = partidas.ListadoPartidas();

            //if (partidasGuardadas.Count > 0)
            //{

            //}
            //else 
            //{
                
            //}
        }

        private void Update()
        {
            //Vector3 posicion = Input.mousePosition;

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out RaycastHit hit))
            //{
            //    if (!EventSystem.current.IsPointerOverGameObject())
            //    {
            //        //panelDatos.gameObject.GetComponent<Text>().text = ((int)hit.point.x).ToString();

            //        int x = 0;
            //        while (x < tamañoEscenarioX)
            //        {
            //            int z = 0;
            //            while (z < tamañoEscenarioZ)
            //            {
            //                if ((int)posicion.x == (int)hit.point.x && (int)posicion.z == (int)hit.point.z)
            //                {
            //                    if (escenario.terrenos[x, z] != null)
            //                    {
            //                        panelDatos.gameObject.GetComponent<Text>().text = "probando";
            //                    }
            //                }

            //                z += 1;
            //            }
            //            x += 1;
            //        }
            //    }
            //}

            

            

            //posicion.x = posicion.x + 10;
            //posicion.y = posicion.y - 35;

            //panelDatos.gameObject.transform.position = posicion;          
        }

        public void Reiniciar()
        {
            Interfaz.Reiniciar.Escena();
        }
    }
}
