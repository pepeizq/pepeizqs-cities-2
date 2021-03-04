using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Vectores : MonoBehaviour
{
    [Header("Scripts")]
    public Portapapeles portapapeles;

    public List<Vector3> GenerarTerreno(Terreno[,] terrenos, int tamañoEscenarioX, int tamañoEscenarioZ, float alturaMaxima, int limitesMapa)
    {
        List<Vector3> listado = new List<Vector3>();
        portapapeles.Limpiar();
        portapapeles.Texto("listadoTerrenoInicial = new List<Vector3> {");

        int montañasGenerar = tamañoEscenarioX / 100 * tamañoEscenarioZ / 100;
        int intentosGeneracion = montañasGenerar * 2;

        int i = 1;
        while (i <= intentosGeneracion)
        {
            float alturaCasilla = (int)Random.Range(3, alturaMaxima);

            int posicionX = (int)Random.Range(0 + limitesMapa, tamañoEscenarioX - limitesMapa);
            int posicionZ = (int)Random.Range(0 + limitesMapa, tamañoEscenarioZ - limitesMapa);

            bool añadir = true;

            foreach (Terreno casilla in terrenos)
            {
                if (casilla != null)
                {
                    if (Enumerable.Range((int)(casilla.posicion.x - alturaCasilla), (int)(casilla.posicion.x + alturaCasilla)).Contains(posicionX))
                    {
                        if (Enumerable.Range((int)(casilla.posicion.z - alturaCasilla), (int)(casilla.posicion.z + alturaCasilla)).Contains(posicionZ))
                        {
                            añadir = false;

                            if (intentosGeneracion >= 0)
                            {
                                intentosGeneracion -= 1;
                                i -= 1;
                            }
                        }
                    }
                }
            }

            if (Limites.Comprobar(posicionX, 2, tamañoEscenarioX) == false || Limites.Comprobar(posicionZ, 2, tamañoEscenarioZ) == false)
            {
                añadir = false;
            }

            if (añadir == true)
            {
                listado.Add(new Vector3(posicionX, alturaCasilla, posicionZ));
                portapapeles.Vector3(new Vector3(posicionX, alturaCasilla, posicionZ));

                int desplazamiento = 0;
                while (alturaCasilla >= 1)
                {
                    int planos = (int)Random.Range(0, 4 + desplazamiento);

                    if (desplazamiento > 0)
                    {
                        int j = 0;
                        while (j <= planos)
                        {
                            int x = 0;
                            int z = 0;

                            int azar = (int)Random.Range(0, 12);

                            if (azar == 1)
                            {
                                x = 1 + (int)(desplazamiento * 2);
                                z = 1 + (int)(desplazamiento * 2);
                            }
                            else if (azar == 2)
                            {
                                x = 1 + (int)(desplazamiento * 2);
                                z = -1 - (int)(desplazamiento * 2);
                            }
                            else if (azar == 3)
                            {
                                x = -1 - (int)(desplazamiento * 2);
                                z = 1 + (int)(desplazamiento * 2);
                            }
                            else if (azar == 4)
                            {
                                x = -1 - (int)(desplazamiento * 2);
                                z = -1 - (int)(desplazamiento * 2);
                            }
                            else if (azar == 5 || azar == 6)
                            {
                                x = 2 + (int)(desplazamiento * 2);
                                z = Random.Range(-desplazamiento, desplazamiento);
                            }
                            else if (azar == 7 || azar == 8)
                            {
                                x = -2 - (int)(desplazamiento * 2);
                                z = Random.Range(-desplazamiento, desplazamiento);
                            }
                            else if (azar == 9 || azar == 10)
                            {
                                x = Random.Range(-desplazamiento, desplazamiento);
                                z = 2 + (int)(desplazamiento * 2);
                            }
                            else if (azar == 11 || azar == 12)
                            {
                                x = Random.Range(-desplazamiento, desplazamiento);
                                z = -2 - (int)(desplazamiento * 2);
                            }

                            if (azar > 0)
                            {
                                if (alturaCasilla == 1.5f || alturaCasilla == 2f)
                                {
                                    for (int origenX = posicionX + x - 1; origenX < posicionX + x + 2; origenX++)
                                    {
                                        for (int origenZ = posicionZ + z - 1; origenZ < posicionZ + z + 2; origenZ++)
                                        {
                                            if (Limites.Comprobar(origenX, 2, tamañoEscenarioX) == true && Limites.Comprobar(origenZ, 2, tamañoEscenarioZ) == true)
                                            {
                                                if (terrenos[origenX, origenZ] == null)
                                                {
                                                    listado.Add(new Vector3(origenX, alturaCasilla, origenZ));
                                                    portapapeles.Vector3(new Vector3(origenX, alturaCasilla, origenZ));
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (alturaCasilla == 1f)
                                {
                                    for (int origenX = posicionX + x - 2; origenX < posicionX + x + 3; origenX++)
                                    {
                                        for (int origenZ = posicionZ + z - 2; origenZ < posicionZ + z + 3; origenZ++)
                                        {
                                            if (Limites.Comprobar(origenX, 2, tamañoEscenarioX) == true && Limites.Comprobar(origenZ, 2, tamañoEscenarioZ) == true)
                                            {
                                                if (terrenos[origenX, origenZ] == null)
                                                {
                                                    listado.Add(new Vector3(origenX, alturaCasilla, origenZ));
                                                    portapapeles.Vector3(new Vector3(origenX, alturaCasilla, origenZ));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Limites.Comprobar(posicionX + x, 2, tamañoEscenarioX) == true && Limites.Comprobar(posicionZ + z, 2, tamañoEscenarioZ) == true)
                                    {
                                        listado.Add(new Vector3(posicionX + x, alturaCasilla, posicionZ + z));
                                        portapapeles.Vector3(new Vector3(posicionX + x, alturaCasilla, posicionZ + z));
                                    }
                                }
                            }

                            j += 1;
                        }
                    }

                    alturaCasilla -= 0.5f;
                    desplazamiento += 1;
                }
            }

            i += 1;
        }

        portapapeles.Texto("};");

        return listado;
    }

    public List<Vector3> GenerarAgua(Terreno[,] terrenos, int tamañoEscenarioX, int tamañoEscenarioZ, float alturaMaxima, int limitesMapa)
    {
        List<Vector3> listado = new List<Vector3>();
        portapapeles.Texto("listadoAguaInicial = new List<Vector3> {");

        int intentosInicio = tamañoEscenarioX / 100 * tamañoEscenarioZ / 100;

        int i = 0;
        while (i < intentosInicio)
        {
            int posicionX = (int)Random.Range(0 + limitesMapa, tamañoEscenarioX - limitesMapa);

            bool añadir = true;

            foreach (Terreno casilla in terrenos)
            {
                if (casilla != null)
                {
                    if (Enumerable.Range((int)(casilla.posicion.x - alturaMaxima - limitesMapa), (int)(casilla.posicion.x + alturaMaxima + limitesMapa)).Contains(posicionX))
                    {
                        añadir = false;                       
                    }
                }
            }

            if (Limites.Comprobar(posicionX, 4, tamañoEscenarioX) == false)
            {
                añadir = false;
            }

            if (añadir == false)
            {
                if (intentosInicio >= 0)
                {
                    intentosInicio -= 1;
                    i -= 1;
                }
            }

            if (añadir == true)
            {
                listado.Add(new Vector3(posicionX, 0, limitesMapa));
                portapapeles.Vector3(new Vector3(posicionX, 0, limitesMapa));

                listado.Add(new Vector3(posicionX - 1, 0, limitesMapa));
                portapapeles.Vector3(new Vector3(posicionX - 1, 0, limitesMapa));

                listado.Add(new Vector3(posicionX + 1, 0, limitesMapa));
                portapapeles.Vector3(new Vector3(posicionX + 1, 0, limitesMapa));

                for (int origenZ = limitesMapa; origenZ < tamañoEscenarioZ - limitesMapa; origenZ++)
                {
                    if (Limites.Comprobar(posicionX, 2, tamañoEscenarioX) == true && Limites.Comprobar(origenZ, 2, tamañoEscenarioZ) == true)
                    {
                        if (terrenos[posicionX, origenZ] == null)
                        {
                            listado.Add(new Vector3(posicionX, 0, origenZ));
                            portapapeles.Vector3(new Vector3(posicionX, 0, origenZ));
                        }
                    }
                }
            }

            i += 1;
        }

        portapapeles.Texto("};");

        return listado;
    }
}
