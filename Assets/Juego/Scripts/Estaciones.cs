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

                    if (casilla.arbol != null)
                    {
                        if (nuevaCasilla.arbol != null)
                        {
                            nuevaCasilla.arbol.visibilidad = casilla.arbol.visibilidad;
                            nuevaCasilla.arbol.gameObject.SetActive(casilla.arbol.visibilidad);
                        }
                    }

                    escenario.terrenos[(int)casilla.posicion.x, (int)casilla.posicion.z] = null;                                                      
                    Destroy(casilla.gameObject);

                    Terreno[] casillasFinal;

                    if (arranque.estacion == 0)
                    {
                        casillasFinal = escenario.casillasInvierno;
                    }
                    else if (arranque.estacion == 1)
                    {
                        casillasFinal = escenario.casillasPrimavera;
                    }
                    else if (arranque.estacion == 2)
                    {
                        casillasFinal = escenario.casillasVerano;
                    }
                    else
                    {
                        casillasFinal = escenario.casillasOtoño;
                    }

                    Terreno terreno2 = Instantiate(casillasFinal[nuevaCasilla.id], nuevaCasilla.posicion, Quaternion.identity);
                    terreno2.gameObject.transform.Rotate(Vector3.up, nuevaCasilla.rotacion, Space.World);
                    terreno2.rotacion = nuevaCasilla.rotacion;
                    terreno2.posicion = nuevaCasilla.posicion;
                    terreno2.idDebug = nuevaCasilla.idDebug;

                    if (nuevaCasilla.arbol != null)
                    {
                        terreno2.arbol.visibilidad = nuevaCasilla.arbol.visibilidad;
                        terreno2.arbol.gameObject.SetActive(nuevaCasilla.arbol.visibilidad);
                        Debug.Log(nuevaCasilla.arbol.visibilidad);
                    }
                        
                    escenario.terrenos[(int)nuevaCasilla.posicion.x, (int)nuevaCasilla.posicion.z] = terreno2;
                }
            }
        }
    }
}