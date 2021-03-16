using UnityEngine;

namespace Juego 
{
    public class Estaciones : MonoBehaviour
    {
        [Header("Scripts")]
        public Escenario escenario;
        public Arranque arranque;

        [Header("Teclas")]
        public KeyCode teclaInvierno;
        public KeyCode teclaPrimavera;
        public KeyCode teclaVerano;
        public KeyCode teclaOtoño;

        public void Start()
        {

        }

        public void Update()
        {
            if (Input.GetKey(teclaInvierno) == true)
            {
                Cambiar(0);
            }
            else if (Input.GetKey(teclaPrimavera) == true)
            {
                Cambiar(1);
            }
            else if (Input.GetKey(teclaVerano) == true)
            {
                Cambiar(2);
            }
            else if (Input.GetKey(teclaOtoño) == true)
            {
                Cambiar(3);
            }
        }

        public void Cambiar(int nuevaEstacion)
        {
            arranque.estacion = nuevaEstacion;

            foreach (Terreno casilla in escenario.terrenos)
            {
                if (casilla != null)
                {
                    Terreno nuevaCasilla = new Terreno(casilla.id, casilla.rotacion, casilla.posicion);
                    nuevaCasilla.idDebug = casilla.idDebug;
                    escenario.terrenos[(int)casilla.posicion.x, (int)casilla.posicion.z] = null;
                    Destroy(casilla.gameObject);

                    escenario.PonerTerreno(nuevaCasilla);
                }
            }
        }
    }
}