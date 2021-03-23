using Juego;
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
                                if (arbol != null)
                                {
                                    bool ocultar = false;

                                    int cachoX = (arranque.tamañoEscenarioX - (escenario.limitesMapa * 2)) / 6;
                                    int cachoZ = (arranque.tamañoEscenarioZ - (escenario.limitesMapa * 2)) / 6;

                                    if ((int)casilla.posicion.x > cachoX * 2 && (int)casilla.posicion.x < cachoX * 4)
                                    {
                                        if ((int)casilla.posicion.z > cachoZ * 2 && (int)casilla.posicion.z < cachoZ * 4)
                                        {
                                            ocultar = true;
                                        }
                                    }

                                    if (ocultar == true)
                                    {
                                        arbol.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        int azar = (int)Random.Range(0, 100);

                                        if (azar < (85 + (int)casilla.posicion.y * 10))
                                        {
                                            arbol.visibilidad = false;
                                            arbol.gameObject.SetActive(false);
                                        }
                                    }
                                }                                                             
                            }
                        }
                    }                    
                }             
            }
        }
    }
}