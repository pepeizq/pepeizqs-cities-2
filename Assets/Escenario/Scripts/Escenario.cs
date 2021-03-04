using Juego;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    [Header("Debug")]
    public bool aleatorio;
    public bool coloresDebug;
    public bool agua;
    public bool coloresAltura;
    public bool ponerLlano;

    [Header("Scripts")]
    public Arranque arranque;
    public Vectores vectores;

    [Header("Prefabs")]
    public Terreno[] casillas;

    [HideInInspector]
    public Terreno[,] terrenos = new Terreno[1, 1];

    [Header("Opciones")]
    public float alturaMaxima = 8;

    private int limitesMapa = 3;

    public void Start()
    {
        terrenos = new Terreno[arranque.tamañoEscenarioX, arranque.tamañoEscenarioZ];

        List<Vector3> listadoTerrenoInicial = new List<Vector3>();
        List<Vector3> listadoAguaInicial = new List<Vector3>();

        if (aleatorio == true)
        {
            listadoTerrenoInicial = vectores.GenerarTerreno(terrenos, (int)arranque.tamañoEscenarioX, (int)arranque.tamañoEscenarioZ, alturaMaxima, limitesMapa);
            listadoAguaInicial = vectores.GenerarAgua(terrenos, (int)arranque.tamañoEscenarioX, (int)arranque.tamañoEscenarioZ, alturaMaxima, limitesMapa);
        }
        else
        {
            listadoTerrenoInicial = new List<Vector3> {
new Vector3(66, 4, 17),
new Vector3(70, 3.5f, 17),
new Vector3(65, 3.5f, 13),
new Vector3(63, 3.5f, 20),
new Vector3(69, 3.5f, 20),
new Vector3(66, 3.5f, 13),
new Vector3(71, 3, 22),
new Vector3(60, 3, 16),
new Vector3(60, 3, 18),
new Vector3(61, 3, 12),
new Vector3(72, 3, 15),
new Vector3(68, 2.5f, 25),
new Vector3(73, 2.5f, 10),
new Vector3(74, 2.5f, 16),
new Vector3(74, 2.5f, 19),
new Vector3(59, 2.5f, 10),
new Vector3(75, 2, 18),
new Vector3(75, 2, 19),
new Vector3(75, 2, 20),
new Vector3(76, 2, 18),
new Vector3(76, 2, 19),
new Vector3(76, 2, 20),
new Vector3(77, 2, 18),
new Vector3(77, 2, 19),
new Vector3(77, 2, 20),
new Vector3(74, 2, 25),
new Vector3(74, 2, 26),
new Vector3(74, 2, 27),
new Vector3(75, 2, 25),
new Vector3(75, 2, 26),
new Vector3(75, 2, 27),
new Vector3(76, 2, 25),
new Vector3(76, 2, 26),
new Vector3(76, 2, 27),
new Vector3(56, 2, 25),
new Vector3(56, 2, 26),
new Vector3(56, 2, 27),
new Vector3(57, 2, 25),
new Vector3(57, 2, 26),
new Vector3(57, 2, 27),
new Vector3(58, 2, 25),
new Vector3(58, 2, 26),
new Vector3(58, 2, 27),
new Vector3(68, 2, 26),
new Vector3(68, 2, 27),
new Vector3(68, 2, 28),
new Vector3(69, 2, 26),
new Vector3(69, 2, 27),
new Vector3(69, 2, 28),
new Vector3(70, 2, 26),
new Vector3(70, 2, 27),
new Vector3(70, 2, 28),
new Vector3(75, 2, 17),
new Vector3(75, 2, 18),
new Vector3(75, 2, 19),
new Vector3(76, 2, 17),
new Vector3(76, 2, 18),
new Vector3(76, 2, 19),
new Vector3(77, 2, 17),
new Vector3(77, 2, 18),
new Vector3(77, 2, 19),
new Vector3(53, 1.5f, 11),
new Vector3(53, 1.5f, 12),
new Vector3(53, 1.5f, 13),
new Vector3(54, 1.5f, 11),
new Vector3(54, 1.5f, 12),
new Vector3(54, 1.5f, 13),
new Vector3(55, 1.5f, 11),
new Vector3(55, 1.5f, 12),
new Vector3(55, 1.5f, 13),
new Vector3(54, 1.5f, 27),
new Vector3(54, 1.5f, 28),
new Vector3(54, 1.5f, 29),
new Vector3(55, 1.5f, 27),
new Vector3(55, 1.5f, 28),
new Vector3(55, 1.5f, 29),
new Vector3(56, 1.5f, 27),
new Vector3(56, 1.5f, 28),
new Vector3(56, 1.5f, 29),
new Vector3(77, 1, 28),
new Vector3(77, 1, 29),
new Vector3(77, 1, 30),
new Vector3(77, 1, 31),
new Vector3(77, 1, 32),
new Vector3(78, 1, 28),
new Vector3(78, 1, 29),
new Vector3(78, 1, 30),
new Vector3(78, 1, 31),
new Vector3(78, 1, 32),
new Vector3(79, 1, 28),
new Vector3(79, 1, 29),
new Vector3(79, 1, 30),
new Vector3(79, 1, 31),
new Vector3(79, 1, 32),
new Vector3(80, 1, 28),
new Vector3(80, 1, 29),
new Vector3(80, 1, 30),
new Vector3(80, 1, 31),
new Vector3(80, 1, 32),
new Vector3(81, 1, 28),
new Vector3(81, 1, 29),
new Vector3(81, 1, 30),
new Vector3(81, 1, 31),
new Vector3(81, 1, 32),
new Vector3(50, 1, 16),
new Vector3(50, 1, 17),
new Vector3(50, 1, 18),
new Vector3(50, 1, 19),
new Vector3(50, 1, 20),
new Vector3(51, 1, 16),
new Vector3(51, 1, 17),
new Vector3(51, 1, 18),
new Vector3(51, 1, 19),
new Vector3(51, 1, 20),
new Vector3(52, 1, 16),
new Vector3(52, 1, 17),
new Vector3(52, 1, 18),
new Vector3(52, 1, 19),
new Vector3(52, 1, 20),
new Vector3(53, 1, 16),
new Vector3(53, 1, 17),
new Vector3(53, 1, 18),
new Vector3(53, 1, 19),
new Vector3(53, 1, 20),
new Vector3(54, 1, 16),
new Vector3(54, 1, 17),
new Vector3(54, 1, 18),
new Vector3(54, 1, 19),
new Vector3(54, 1, 20),
new Vector3(78, 1, 9),
new Vector3(78, 1, 10),
new Vector3(78, 1, 11),
new Vector3(78, 1, 12),
new Vector3(78, 1, 13),
new Vector3(79, 1, 9),
new Vector3(79, 1, 10),
new Vector3(79, 1, 11),
new Vector3(79, 1, 12),
new Vector3(79, 1, 13),
new Vector3(80, 1, 9),
new Vector3(80, 1, 10),
new Vector3(80, 1, 11),
new Vector3(80, 1, 12),
new Vector3(80, 1, 13),
new Vector3(81, 1, 9),
new Vector3(81, 1, 10),
new Vector3(81, 1, 11),
new Vector3(81, 1, 12),
new Vector3(81, 1, 13),
new Vector3(82, 1, 9),
new Vector3(82, 1, 10),
new Vector3(82, 1, 11),
new Vector3(82, 1, 12),
new Vector3(82, 1, 13),
new Vector3(66, 1, 2),
new Vector3(66, 1, 3),
new Vector3(66, 1, 4),
new Vector3(66, 1, 5),
new Vector3(67, 1, 2),
new Vector3(67, 1, 3),
new Vector3(67, 1, 4),
new Vector3(67, 1, 5),
new Vector3(68, 1, 2),
new Vector3(68, 1, 3),
new Vector3(68, 1, 4),
new Vector3(68, 1, 5),
new Vector3(69, 1, 2),
new Vector3(69, 1, 3),
new Vector3(69, 1, 4),
new Vector3(69, 1, 5),
new Vector3(70, 1, 2),
new Vector3(70, 1, 3),
new Vector3(70, 1, 4),
new Vector3(70, 1, 5),
new Vector3(51, 1, 2),
new Vector3(51, 1, 3),
new Vector3(51, 1, 4),
new Vector3(51, 1, 5),
new Vector3(51, 1, 6),
new Vector3(52, 1, 2),
new Vector3(52, 1, 3),
new Vector3(52, 1, 4),
new Vector3(52, 1, 5),
new Vector3(52, 1, 6),
new Vector3(53, 1, 2),
new Vector3(53, 1, 3),
new Vector3(53, 1, 4),
new Vector3(53, 1, 5),
new Vector3(53, 1, 6),
new Vector3(54, 1, 2),
new Vector3(54, 1, 3),
new Vector3(54, 1, 4),
new Vector3(54, 1, 5),
new Vector3(54, 1, 6),
new Vector3(55, 1, 2),
new Vector3(55, 1, 3),
new Vector3(55, 1, 4),
new Vector3(55, 1, 5),
new Vector3(55, 1, 6),
new Vector3(51, 1, 2),
new Vector3(51, 1, 3),
new Vector3(51, 1, 4),
new Vector3(51, 1, 5),
new Vector3(51, 1, 6),
new Vector3(52, 1, 2),
new Vector3(52, 1, 3),
new Vector3(52, 1, 4),
new Vector3(52, 1, 5),
new Vector3(52, 1, 6),
new Vector3(53, 1, 2),
new Vector3(53, 1, 3),
new Vector3(53, 1, 4),
new Vector3(53, 1, 5),
new Vector3(53, 1, 6),
new Vector3(54, 1, 2),
new Vector3(54, 1, 3),
new Vector3(54, 1, 4),
new Vector3(54, 1, 5),
new Vector3(54, 1, 6),
new Vector3(55, 1, 2),
new Vector3(55, 1, 3),
new Vector3(55, 1, 4),
new Vector3(55, 1, 5),
new Vector3(55, 1, 6),
new Vector3(90, 4, 77),
new Vector3(86, 3.5f, 76),
new Vector3(90, 3, 83),
new Vector3(95, 3, 82),
new Vector3(85, 3, 82),
new Vector3(95, 3, 72),
new Vector3(84, 3, 76),
new Vector3(91, 2.5f, 85),
new Vector3(97, 2.5f, 84),
new Vector3(80, 2, 85),
new Vector3(80, 2, 86),
new Vector3(80, 2, 87),
new Vector3(81, 2, 85),
new Vector3(81, 2, 86),
new Vector3(81, 2, 87),
new Vector3(82, 2, 85),
new Vector3(82, 2, 86),
new Vector3(82, 2, 87),
new Vector3(98, 2, 67),
new Vector3(98, 2, 68),
new Vector3(98, 2, 69),
new Vector3(80, 2, 85),
new Vector3(80, 2, 86),
new Vector3(80, 2, 87),
new Vector3(81, 2, 85),
new Vector3(81, 2, 86),
new Vector3(81, 2, 87),
new Vector3(82, 2, 85),
new Vector3(82, 2, 86),
new Vector3(82, 2, 87),
new Vector3(91, 2, 66),
new Vector3(91, 2, 67),
new Vector3(91, 2, 68),
new Vector3(92, 2, 66),
new Vector3(92, 2, 67),
new Vector3(92, 2, 68),
new Vector3(93, 2, 66),
new Vector3(93, 2, 67),
new Vector3(93, 2, 68),
new Vector3(80, 2, 85),
new Vector3(80, 2, 86),
new Vector3(80, 2, 87),
new Vector3(81, 2, 85),
new Vector3(81, 2, 86),
new Vector3(81, 2, 87),
new Vector3(82, 2, 85),
new Vector3(82, 2, 86),
new Vector3(82, 2, 87),
new Vector3(74, 1, 73),
new Vector3(74, 1, 74),
new Vector3(74, 1, 75),
new Vector3(74, 1, 76),
new Vector3(74, 1, 77),
new Vector3(75, 1, 73),
new Vector3(75, 1, 74),
new Vector3(75, 1, 75),
new Vector3(75, 1, 76),
new Vector3(75, 1, 77),
new Vector3(76, 1, 73),
new Vector3(76, 1, 74),
new Vector3(76, 1, 75),
new Vector3(76, 1, 76),
new Vector3(76, 1, 77),
new Vector3(77, 1, 73),
new Vector3(77, 1, 74),
new Vector3(77, 1, 75),
new Vector3(77, 1, 76),
new Vector3(77, 1, 77),
new Vector3(78, 1, 73),
new Vector3(78, 1, 74),
new Vector3(78, 1, 75),
new Vector3(78, 1, 76),
new Vector3(78, 1, 77),
new Vector3(74, 1, 75),
new Vector3(74, 1, 76),
new Vector3(74, 1, 77),
new Vector3(74, 1, 78),
new Vector3(74, 1, 79),
new Vector3(75, 1, 75),
new Vector3(75, 1, 76),
new Vector3(75, 1, 77),
new Vector3(75, 1, 78),
new Vector3(75, 1, 79),
new Vector3(76, 1, 75),
new Vector3(76, 1, 76),
new Vector3(76, 1, 77),
new Vector3(76, 1, 78),
new Vector3(76, 1, 79),
new Vector3(77, 1, 75),
new Vector3(77, 1, 76),
new Vector3(77, 1, 77),
new Vector3(77, 1, 78),
new Vector3(77, 1, 79),
new Vector3(78, 1, 75),
new Vector3(78, 1, 76),
new Vector3(78, 1, 77),
new Vector3(78, 1, 78),
new Vector3(78, 1, 79),
new Vector3(86, 1, 89),
new Vector3(86, 1, 90),
new Vector3(86, 1, 91),
new Vector3(86, 1, 92),
new Vector3(86, 1, 93),
new Vector3(87, 1, 89),
new Vector3(87, 1, 90),
new Vector3(87, 1, 91),
new Vector3(87, 1, 92),
new Vector3(87, 1, 93),
new Vector3(88, 1, 89),
new Vector3(88, 1, 90),
new Vector3(88, 1, 91),
new Vector3(88, 1, 92),
new Vector3(88, 1, 93),
new Vector3(89, 1, 89),
new Vector3(89, 1, 90),
new Vector3(89, 1, 91),
new Vector3(89, 1, 92),
new Vector3(89, 1, 93),
new Vector3(90, 1, 89),
new Vector3(90, 1, 90),
new Vector3(90, 1, 91),
new Vector3(90, 1, 92),
new Vector3(90, 1, 93),
new Vector3(75, 1, 88),
new Vector3(75, 1, 89),
new Vector3(75, 1, 90),
new Vector3(75, 1, 91),
new Vector3(75, 1, 92),
new Vector3(76, 1, 88),
new Vector3(76, 1, 89),
new Vector3(76, 1, 90),
new Vector3(76, 1, 91),
new Vector3(76, 1, 92),
new Vector3(77, 1, 88),
new Vector3(77, 1, 89),
new Vector3(77, 1, 90),
new Vector3(77, 1, 91),
new Vector3(77, 1, 92),
new Vector3(78, 1, 88),
new Vector3(78, 1, 89),
new Vector3(78, 1, 90),
new Vector3(78, 1, 91),
new Vector3(78, 1, 92),
new Vector3(79, 1, 88),
new Vector3(79, 1, 89),
new Vector3(79, 1, 90),
new Vector3(79, 1, 91),
new Vector3(79, 1, 92)
};

            listadoAguaInicial = new List<Vector3> {
new Vector3(4, 0, 0)};

        }

        int k = 0;
        int tope = (int)alturaMaxima * 2;
        while (k < tope)
        {
            if (alturaMaxima == 0.5f)
            {               
                break;
            }

            alturaMaxima -= 0.5f;

            if (alturaMaxima < 0.5f)
            {
                alturaMaxima = 0.5f;
            }

            try
            {
                GenerarNivel(alturaMaxima, listadoTerrenoInicial);                
            }
            catch (Exception fallo)
            {
                Debug.Log(fallo);
                k -= 1;
            }

            k += 1;
        }

        GenerarAgua(listadoAguaInicial);

        if (ponerLlano == true)
        {
            PonerLlano2(alturaMaxima);
        }
    }

    public void Update()
    {

    }

    //------------------------------------------------------------------------------------------------------------------------------------

    private void GenerarNivel(float altura, List<Vector3> listadoTerrenoInicial)
    {
        foreach (Vector3 casillaInicial in listadoTerrenoInicial.ToList<Vector3>())
        {
            if (altura == casillaInicial.y)
            {
                if (Limites.Comprobar((int)casillaInicial.x, 3, (int)arranque.tamañoEscenarioX) == true && Limites.Comprobar((int)casillaInicial.z, 3, (int)arranque.tamañoEscenarioZ) == true)
                {
                    if (terrenos[(int)casillaInicial.x, (int)casillaInicial.z] == null)
                    {
                        PonerTerreno(new Terreno(0, 0, casillaInicial));
                        listadoTerrenoInicial.Remove(casillaInicial);
                    }
                }            
            }
        }

        foreach (Terreno subcasilla in terrenos)
        {
            if (subcasilla != null)
            {
                int x = (int)subcasilla.posicion.x;
                int z = (int)subcasilla.posicion.z;

                float y = subcasilla.posicion.y;
                y = y - 0.5f;

                if (y < 0.0f)
                {
                    y = 0.0f;
                }

                if ((y > 0) && (altura == subcasilla.posicion.y) && ComprobarLimiteX(x, 2) == true && ComprobarLimiteZ(z, 2) == true)
                {
                    if (terrenos[x - 1, z - 1] == null)
                    {
                        CalcularTerreno_Xmenos1_Zmenos1(x, y, z);
                    }

                    if (terrenos[x - 1, z + 1] == null)
                    {
                        CalcularTerreno_Xmenos1_Zmas1(x, y, z);
                    }

                    if (terrenos[x + 1, z - 1] == null)
                    {
                        CalcularTerreno_Xmas1_Zmenos1(x, y, z);
                    }

                    if (terrenos[x + 1, z + 1] == null)
                    {
                        CalcularTerreno_Xmas1_Zmas1(x, y, z);
                    }

                    if (terrenos[x, z - 1] == null)
                    {
                        CalcularTerreno_X0_Zmenos1(x, y, z);
                    }

                    if (terrenos[x - 1, z] == null)
                    {
                        CalcularTerreno_Xmenos1_Z0(x, y, z);
                    }

                    if (terrenos[x, z + 1] == null)
                    {
                        CalcularTerreno_X0_Zmas1(x, y, z);
                    }

                    if (terrenos[x + 1, z] == null)
                    {
                        CalcularTerreno_Xmas1_Z0(x, y, z);
                    }
                }
            }            
        }
    }

    //Verde - esquina2rotacion180
    private void CalcularTerreno_Xmenos1_Zmenos1(int x, float y, int z)
    {
        Terreno rampas4rotacion90 = new Terreno(4, 90, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarVacio(terrenos[x, z - 2]) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarVacio(terrenos[x, z - 2]) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 180) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarVacio(terrenos[x, z - 2]) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }

        //---------------------------------------

        Terreno plano = new Terreno(0, 0, new Vector3(x - 1, y + 0.5f, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(3, 90, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 2], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(3, 270, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(3, 180, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true && ComprobarTerreno0(terrenos[x, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }

        //---------------------------------------

        Terreno rampa1rotacion90 = new Terreno(1, 90, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }

        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(1, 180, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 1], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 1], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x, z - 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }

        //---------------------------------------

        Terreno esquina2rotacion180 = new Terreno(2, 180, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(esquina2rotacion180);
        }
    }

    //Gris - esquina2rotacion270
    private void CalcularTerreno_Xmenos1_Zmas1(int x, float y, int z)
    {
        Terreno rampas4rotacion0 = new Terreno(39, 0, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 2], y, 90) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarVacio(terrenos[x, z + 2]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 2], y, 90) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 180) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 2], y, 90) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarVacio(terrenos[x, z + 2]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarVacio(terrenos[x, z + 2]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 180) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x - 2, z]) == true && ComprobarTerreno3(terrenos[x, z + 2], y - 0.5f, 180) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }

        //---------------------------------------

        Terreno plano = new Terreno(35, 0, new Vector3(x - 1, y + 0.5f, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 2, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(38, 180, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(38, 0, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(38, 270, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------
      
        Terreno rampa1rotacion270 = new Terreno(36, 270, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }

        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(36, 180, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }

        //---------------------------------------

        Terreno esquina2rotacion270 = new Terreno(37, 270, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(esquina2rotacion270);
        }
    }

    //Marron Claro - esquina2rotacion90 
    private void CalcularTerreno_Xmas1_Zmenos1(int x, float y, int z)
    {
        Terreno rampas4rotacion0 = new Terreno(34, 0, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z], y - 0.5f, 180) == true && ComprobarVacio(terrenos[x, z - 2]) == true && ComprobarVacio(terrenos[x + 1, z]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z - 1]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 270) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z - 1]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z - 1]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 270) == true && ComprobarVacio(terrenos[x + 1, z]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno3(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno3(terrenos[x, z - 2], y - 0.5f, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z - 1]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 270) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }

        //---------------------------------------

        Terreno plano = new Terreno(30, 0, new Vector3(x + 1, y + 0.5f, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(33, 180, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 1, z - 2]) == true && ComprobarVacio(terrenos[x + 2, z]) == false)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(33, 0, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(33, 90, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }       

        //---------------------------------------

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }

        //---------------------------------------

        Terreno rampa1rotacion0 = new Terreno(31, 0, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }

        //---------------------------------------

        Terreno rampa1rotacion90 = new Terreno(31, 90, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }

        //---------------------------------------

        Terreno esquina2rotacion90 = new Terreno(32, 90, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(esquina2rotacion90);
        }
    }

    //Morado - esquina2rotacion0
    private void CalcularTerreno_Xmas1_Zmas1(int x, float y, int z)
    {
        Terreno rampas4rotacion90 = new Terreno(29, 90, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y - 0.5f, 270) == true && ComprobarVacio(terrenos[x, z + 2]) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y - 0.5f, 180) == true && ComprobarVacio(terrenos[x, z + 2]) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno3(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno0(terrenos[x + 1, z], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }

        //---------------------------------------

        Terreno plano = new Terreno(25, 0, new Vector3(x + 1, y + 0.5f, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(28, 0, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarVacio(terrenos[x + 1, z]) == false)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(28, 90, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x, z + 2]) == false)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z + 2]) == true && ComprobarVacio(terrenos[x + 2, z]) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarVacio(terrenos[x, z + 1]) == false)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(28, 270, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarVacio(terrenos[x + 1, z + 2]) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarVacio(terrenos[x + 1, z + 2]) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno3(terrenos[x + 2, z + 2], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }

        //---------------------------------------

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }

        //---------------------------------------

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }

        //---------------------------------------

        Terreno rampa1rotacion270 = new Terreno(26, 270, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }

        //---------------------------------------

        Terreno rampa1rotacion0 = new Terreno(26, 0, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }

        //---------------------------------------

        Terreno esquina2rotacion0 = new Terreno(27, 0, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion0);
        }
    }

    //Rojo - rampa1rotacion90
    private void CalcularTerreno_X0_Zmenos1(int x, float y, int z)
    {
        Terreno plano = new Terreno(20, 0, new Vector3(x, y + 0.5f, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(23, 90, new Vector3(x, y, z - 1));

        if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(23, 180, new Vector3(x, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }

        //---------------------------------------

        Terreno rampa1rotacion90 = new Terreno(21, 90, new Vector3(x, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90);
        }
    }

    //Marron Oscuro - rampa1rotacion180
    private void CalcularTerreno_Xmenos1_Z0(int x, float y, int z)
    {
        Terreno plano = new Terreno(5, 0, new Vector3(x - 1, y + 0.5f, z));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano); 
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(8, 270, new Vector3(x - 1, y, z));

        if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(8, 180, new Vector3(x - 1, y, z));

        if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion180);
        }

        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(6, 180, new Vector3(x - 1, y, z));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180);
        }
    }

    //Blanco - rampa1rotacion270
    private void CalcularTerreno_X0_Zmas1(int x, float y, int z)
    {
        Terreno plano = new Terreno(10, 0, new Vector3(x, y + 0.5f, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true) 
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(13, 0, new Vector3(x, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true) 
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(13, 270, new Vector3(x, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }

        //---------------------------------------

        Terreno rampa1rotacion270 = new Terreno(11, 270, new Vector3(x, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270);
        }
    }

    //Amarillo - rampa1rotacion0
    private void CalcularTerreno_Xmas1_Z0(int x, float y, int z)
    {
        Terreno plano = new Terreno(15, 0, new Vector3(x + 1, y + 0.5f, z));

        if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
        {
            PonerTerreno(plano);
        }

        if (ComprobarLimiteX(x, 4) == true && ComprobarLimiteZ(z, 3) == true)
        {
            if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 3, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
            {
                PonerTerreno(plano);
            }
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(18, 0, new Vector3(x + 1, y, z));

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(18, 90, new Vector3(x + 1, y, z));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }

        //---------------------------------------

        Terreno rampa1rotacion0 = new Terreno(16, 0, new Vector3(x + 1, y, z));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------

    private void GenerarAgua(List<Vector3> listadoAguaInicial)
    {
        foreach (Vector3 casillaInicial in listadoAguaInicial.ToList<Vector3>())
        {
            if (Limites.Comprobar((int)casillaInicial.x, 3, (int)arranque.tamañoEscenarioX) == true && Limites.Comprobar((int)casillaInicial.z, 3, (int)arranque.tamañoEscenarioZ) == true)
            {
                if (terrenos[(int)casillaInicial.x, (int)casillaInicial.z] == null)
                {
                    PonerTerreno(new Terreno(40, 0, casillaInicial));
                    listadoAguaInicial.Remove(casillaInicial);
                }
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------

    private void PonerTerreno(Terreno terreno)
    {
        int id = terreno.id;
        int idDebug = id;

        if (coloresDebug == false)
        {
            id = CalcularID(id, terreno.posicion.y);
        }

        int x = (int)terreno.posicion.x;
        int z = (int)terreno.posicion.z;

        if (ComprobarLimiteX(x, 3) == true && ComprobarLimiteZ(z, 3) == true)
        {
            if (terrenos[x, z] == null)
            {
                Terreno terreno2 = Instantiate(casillas[id], terreno.posicion, Quaternion.identity);
                terreno2.gameObject.transform.Rotate(Vector3.up, terreno.rotacion, Space.World);
                terreno2.rotacion = terreno.rotacion;
                terreno2.posicion = terreno.posicion;
                terreno2.idDebug = idDebug;

                terrenos[x, z] = terreno2;
            }
        }  
    }

    private int CalcularID(int id, float altura)
    {
        if (id >= 5 && id <= 9)
        {
            id = id - 5;
        }
        else if (id >= 10 && id <= 14)
        {
            id = id - 10;
        }
        else if (id >= 15 && id <= 19)
        {
            id = id - 15;
        }
        else if (id >= 20 && id <= 24)
        {
            id = id - 20;
        }
        else if (id >= 25 && id <= 29)
        {
            id = id - 25;
        }
        else if (id >= 30 && id <= 34)
        {
            id = id - 30;
        }
        else if (id >= 34 && id <= 39)
        {
            id = id - 35;
        }

        if (coloresAltura == true)
        {
            if (altura >= 1f && altura <= 5f)
            {
                id = id + 30;
            }
            else if (altura >= 5.5f)
            {
                id = id + 10;
            }
        }

        return id;
    }

    private bool ComprobarTerreno0(Terreno terreno, float altura, int rotacion)
    {        
        if (terreno != null)
        {
            if (ComprobarLimiteX((int)terreno.posicion.x, 3) == true && ComprobarLimiteZ((int)terreno.posicion.z, 3) == true)
            {
                if (terreno.posicion.y == (altura + 0.5f))
                {
                    if (terreno.rotacion == rotacion)
                    {
                        if (terreno.id == 0)
                        {
                            return true;
                        }
                    }
                }
            }               
        }

        return false;
    }

    private bool ComprobarTerreno1(Terreno terreno, float altura, int rotacion)
    {      
        if (terreno != null)
        {
            if (ComprobarLimiteX((int)terreno.posicion.x, 3) == true && ComprobarLimiteZ((int)terreno.posicion.z, 3) == true)
            {
                if (terreno.posicion.y == (altura + 0.5f))
                {
                    if (terreno.rotacion == rotacion)
                    {
                        if (terreno.id == 1)
                        {
                            return true;
                        }
                    }
                }
            }               
        }

        return false;
    }

    private bool ComprobarTerreno2(Terreno terreno, float altura, int rotacion)
    {
        if (terreno != null)
        {
            if (ComprobarLimiteX((int)terreno.posicion.x, 3) == true && ComprobarLimiteZ((int)terreno.posicion.z, 3) == true)
            {
                if (terreno.posicion.y == (altura + 0.5f))
                {
                    if (terreno.rotacion == rotacion)
                    {
                        if (terreno.id == 2)
                        {
                            return true;
                        }
                    }
                }
            }              
        }

        return false;
    }

    private bool ComprobarTerreno3(Terreno terreno, float altura, int rotacion)
    {
        if (terreno != null)
        {
            if (ComprobarLimiteX((int)terreno.posicion.x, 3) == true && ComprobarLimiteZ((int)terreno.posicion.z, 3) == true)
            {
                if (terreno.posicion.y == (altura + 0.5f))
                {
                    if (terreno.rotacion == rotacion)
                    {
                        if (terreno.id == 3)
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private bool ComprobarVacio(Terreno terreno)
    {
        if (terreno != null)
        {
            if (ComprobarLimiteX((int)terreno.posicion.x, 3) == true && ComprobarLimiteZ((int)terreno.posicion.z, 3) == true)
            {
                if (terrenos[(int)terreno.posicion.x, (int)terreno.posicion.z] != null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool ComprobarLimiteX(int x, int ajuste)
    {
        if ((x - ajuste >= 0) && (x + ajuste <= arranque.tamañoEscenarioX))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ComprobarLimiteZ(int z, int ajuste)
    {
        if ((z - ajuste >= 0) && (z + ajuste <= arranque.tamañoEscenarioZ))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void PonerLlano2(float altura)
    {
        for (int x = 0; x < terrenos.GetLength(0); x++)
        {
            for (int z = 0; z < terrenos.GetLength(1); z++)
            {
                if (terrenos[x, z] == null)
                {
                    if (x >= limitesMapa && z >= limitesMapa && x <= arranque.tamañoEscenarioX - limitesMapa && z <= arranque.tamañoEscenarioZ - limitesMapa)
                    {
                        Terreno plano = new Terreno(0, 0, new Vector3(x, altura, z));
                        PonerTerreno(plano);
                    }
                }
            }
        }
    }
}
