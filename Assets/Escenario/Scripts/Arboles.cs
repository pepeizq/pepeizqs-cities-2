using Juego;
using System.Collections.Generic;
using UnityEngine;

public class Arboles : MonoBehaviour
{
    [Header("Scripts")]
    public Arranque arranque;
    public Escenario escenario;

    public void Start()
    {

    }

    public void Update()
    {

    }

    public void Generar()
    {
        foreach (Terreno casilla in escenario.terrenos)
        {
            if (casilla != null)
            {
                if (Limites.Comprobar((int)casilla.posicion.x, escenario.limitesMapa, arranque.tamañoEscenarioX) == true && Limites.Comprobar((int)casilla.posicion.z, escenario.limitesMapa, arranque.tamañoEscenarioZ) == true)
                {
                    if (casilla.arboles != null)
                    {
                        if (casilla.arboles.Count > 0)
                        {
                            foreach (Arbol arbol in casilla.arboles)
                            {
                                int azar = (int)Random.Range(0, (int)casilla.posicion.y * 50);
                          
                                if (azar > 25)
                                {
                                    arbol.gameObject.SetActive(false);
                                }                               
                            }
                        }
                    }

                    //if (casilla.arbolesUbicaciones != null)
                    //{
                    //    if (casilla.arbolesUbicaciones.Count > 0)
                    //    {
                    //        foreach (Vector3 ubicacion in casilla.arbolesUbicaciones)
                    //        {
                    //            int azar = (int)Random.Range(0, 100 - (int)casilla.posicion.y * 10);

                    //            if (azar > 50)
                    //            {
                    //                int estacion = arranque.estacion;
                    //                Arbol[] arboles;

                    //                if (estacion == 0)
                    //                {
                    //                    arboles = escenario.arbolesInvierno;
                    //                }
                    //                else if (estacion == 1)
                    //                {
                    //                    arboles = escenario.arbolesPrimavera;
                    //                }
                    //                else if (estacion == 2)
                    //                {
                    //                    arboles = escenario.arbolesVerano;
                    //                }
                    //                else
                    //                {
                    //                    arboles = escenario.arbolesOtoño;
                    //                }
                    //                Debug.Log(ubicacion.x);
                    //                int idArbol = (int)Random.Range(0, arboles.Length - 1);
                    //                Vector3 ubicacion2 = new Vector3();
                    //                ubicacion2.x = casilla.posicion.x + ubicacion.x + 0.5f;
                    //                ubicacion2.y = casilla.posicion.y + ubicacion.y - 0.1f;
                    //                ubicacion2.z = casilla.posicion.z + ubicacion.z + 0.5f;
                    //                Arbol arbol2 = Instantiate(arboles[idArbol], ubicacion2, Quaternion.identity);

                    //                if (casilla.arboles == null)
                    //                {
                    //                    List<Arbol> arboles2 = new List<Arbol>();
                    //                    arboles2.Add(arbol2);
                    //                }
                    //                else
                    //                {
                    //                    casilla.arboles.Add(arbol2);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }             
            }
        }
    }
}