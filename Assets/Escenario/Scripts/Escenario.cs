﻿using Juego;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Escenario : MonoBehaviour
{
    [Header("Debug")]
    public bool aleatorio;
    public bool coloresDebug;
    public bool coloresAltura;
    public bool ponerLlano;

    [Header("Scripts")]
    public Arranque arranque;
    public Portapapeles portapapeles;

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

        List<Vector3> listadoCasillasInicial = new List<Vector3>();

        if (aleatorio == true)
        {
            portapapeles.LimpiarPortapapeles();

            int montañasGenerar = (int)arranque.tamañoEscenarioX / 100 * (int)arranque.tamañoEscenarioZ / 100;
            int intentosGeneracion = montañasGenerar * 2;
         
            int i = 1;
            while (i <= intentosGeneracion)
            {
                float alturaCasilla = (int)Random.Range(3, alturaMaxima);
             
                int posicionX = (int)Random.Range(0 + limitesMapa, (int)arranque.tamañoEscenarioX - limitesMapa);
                int posicionZ = (int)Random.Range(0 + limitesMapa, (int)arranque.tamañoEscenarioZ - limitesMapa);

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
        
                if (ComprobarLimiteX(posicionX, 2) == false || ComprobarLimiteZ(posicionZ, 2) == false)
                {
                    añadir = false;
                }
              
                if (añadir == true)
                {
                    listadoCasillasInicial.Add(new Vector3(posicionX, alturaCasilla, posicionZ));
                    portapapeles.CopiarPortapapeles(new Vector3(posicionX, alturaCasilla, posicionZ));
     
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
                                                if (ComprobarLimiteX(origenX, 2) == true && ComprobarLimiteZ(origenZ, 2) == true)
                                                {
                                                    if (terrenos[origenX, origenZ] == null)
                                                    {
                                                        listadoCasillasInicial.Add(new Vector3(origenX, alturaCasilla, origenZ));
                                                        portapapeles.CopiarPortapapeles(new Vector3(origenX, alturaCasilla, origenZ));
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
                                                if (ComprobarLimiteX(origenX, 2) == true && ComprobarLimiteZ(origenZ, 2) == true)
                                                {
                                                    if (terrenos[origenX, origenZ] == null)
                                                    {
                                                        listadoCasillasInicial.Add(new Vector3(origenX, alturaCasilla, origenZ));
                                                        portapapeles.CopiarPortapapeles(new Vector3(origenX, alturaCasilla, origenZ));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ComprobarLimiteX(posicionX + x, 2) == true && ComprobarLimiteZ(posicionZ + z, 2) == true)
                                        {
                                            listadoCasillasInicial.Add(new Vector3(posicionX + x, alturaCasilla, posicionZ + z));
                                            portapapeles.CopiarPortapapeles(new Vector3(posicionX + x, alturaCasilla, posicionZ + z));
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
        }
        else
        {
            listadoCasillasInicial = new List<Vector3> {new Vector3(36, 4, 62),
new Vector3(33, 3.5f, 59),
new Vector3(35, 3.5f, 66),
new Vector3(32, 3.5f, 61),
new Vector3(37, 3, 56),
new Vector3(31, 3, 57),
new Vector3(37, 2.5f, 70),
new Vector3(29, 2.5f, 69),
new Vector3(45, 2, 58),
new Vector3(45, 2, 59),
new Vector3(45, 2, 60),
new Vector3(46, 2, 58),
new Vector3(46, 2, 59),
new Vector3(46, 2, 60),
new Vector3(47, 2, 58),
new Vector3(47, 2, 59),
new Vector3(47, 2, 60),
new Vector3(32, 1.5f, 73),
new Vector3(32, 1.5f, 74),
new Vector3(32, 1.5f, 75),
new Vector3(33, 1.5f, 73),
new Vector3(33, 1.5f, 74),
new Vector3(33, 1.5f, 75),
new Vector3(34, 1.5f, 73),
new Vector3(34, 1.5f, 74),
new Vector3(34, 1.5f, 75),
new Vector3(23, 1.5f, 65),
new Vector3(23, 1.5f, 66),
new Vector3(23, 1.5f, 67),
new Vector3(24, 1.5f, 65),
new Vector3(24, 1.5f, 66),
new Vector3(24, 1.5f, 67),
new Vector3(25, 1.5f, 65),
new Vector3(25, 1.5f, 66),
new Vector3(25, 1.5f, 67),
new Vector3(33, 1.5f, 49),
new Vector3(33, 1.5f, 50),
new Vector3(33, 1.5f, 51),
new Vector3(34, 1.5f, 49),
new Vector3(34, 1.5f, 50),
new Vector3(34, 1.5f, 51),
new Vector3(35, 1.5f, 49),
new Vector3(35, 1.5f, 50),
new Vector3(35, 1.5f, 51),
new Vector3(32, 1.5f, 73),
new Vector3(32, 1.5f, 74),
new Vector3(32, 1.5f, 75),
new Vector3(33, 1.5f, 73),
new Vector3(33, 1.5f, 74),
new Vector3(33, 1.5f, 75),
new Vector3(34, 1.5f, 73),
new Vector3(34, 1.5f, 74),
new Vector3(34, 1.5f, 75),
new Vector3(47, 1, 73),
new Vector3(47, 1, 74),
new Vector3(47, 1, 75),
new Vector3(47, 1, 76),
new Vector3(47, 1, 77),
new Vector3(48, 1, 73),
new Vector3(48, 1, 74),
new Vector3(48, 1, 75),
new Vector3(48, 1, 76),
new Vector3(48, 1, 77),
new Vector3(49, 1, 73),
new Vector3(49, 1, 74),
new Vector3(49, 1, 75),
new Vector3(49, 1, 76),
new Vector3(49, 1, 77),
new Vector3(50, 1, 73),
new Vector3(50, 1, 74),
new Vector3(50, 1, 75),
new Vector3(50, 1, 76),
new Vector3(50, 1, 77),
new Vector3(51, 1, 73),
new Vector3(51, 1, 74),
new Vector3(51, 1, 75),
new Vector3(51, 1, 76),
new Vector3(51, 1, 77),
new Vector3(20, 1, 62),
new Vector3(20, 1, 63),
new Vector3(20, 1, 64),
new Vector3(20, 1, 65),
new Vector3(20, 1, 66),
new Vector3(21, 1, 62),
new Vector3(21, 1, 63),
new Vector3(21, 1, 64),
new Vector3(21, 1, 65),
new Vector3(21, 1, 66),
new Vector3(22, 1, 62),
new Vector3(22, 1, 63),
new Vector3(22, 1, 64),
new Vector3(22, 1, 65),
new Vector3(22, 1, 66),
new Vector3(23, 1, 62),
new Vector3(23, 1, 63),
new Vector3(23, 1, 64),
new Vector3(23, 1, 65),
new Vector3(23, 1, 66),
new Vector3(24, 1, 62),
new Vector3(24, 1, 63),
new Vector3(24, 1, 64),
new Vector3(24, 1, 65),
new Vector3(24, 1, 66),
new Vector3(47, 1, 73),
new Vector3(47, 1, 74),
new Vector3(47, 1, 75),
new Vector3(47, 1, 76),
new Vector3(47, 1, 77),
new Vector3(48, 1, 73),
new Vector3(48, 1, 74),
new Vector3(48, 1, 75),
new Vector3(48, 1, 76),
new Vector3(48, 1, 77),
new Vector3(49, 1, 73),
new Vector3(49, 1, 74),
new Vector3(49, 1, 75),
new Vector3(49, 1, 76),
new Vector3(49, 1, 77),
new Vector3(50, 1, 73),
new Vector3(50, 1, 74),
new Vector3(50, 1, 75),
new Vector3(50, 1, 76),
new Vector3(50, 1, 77),
new Vector3(51, 1, 73),
new Vector3(51, 1, 74),
new Vector3(51, 1, 75),
new Vector3(51, 1, 76),
new Vector3(51, 1, 77),
new Vector3(48, 1, 62),
new Vector3(48, 1, 63),
new Vector3(48, 1, 64),
new Vector3(48, 1, 65),
new Vector3(48, 1, 66),
new Vector3(49, 1, 62),
new Vector3(49, 1, 63),
new Vector3(49, 1, 64),
new Vector3(49, 1, 65),
new Vector3(49, 1, 66),
new Vector3(50, 1, 62),
new Vector3(50, 1, 63),
new Vector3(50, 1, 64),
new Vector3(50, 1, 65),
new Vector3(50, 1, 66),
new Vector3(51, 1, 62),
new Vector3(51, 1, 63),
new Vector3(51, 1, 64),
new Vector3(51, 1, 65),
new Vector3(51, 1, 66),
new Vector3(52, 1, 62),
new Vector3(52, 1, 63),
new Vector3(52, 1, 64),
new Vector3(52, 1, 65),
new Vector3(52, 1, 66),
new Vector3(21, 1, 47),
new Vector3(21, 1, 48),
new Vector3(21, 1, 49),
new Vector3(21, 1, 50),
new Vector3(21, 1, 51),
new Vector3(22, 1, 47),
new Vector3(22, 1, 48),
new Vector3(22, 1, 49),
new Vector3(22, 1, 50),
new Vector3(22, 1, 51),
new Vector3(23, 1, 47),
new Vector3(23, 1, 48),
new Vector3(23, 1, 49),
new Vector3(23, 1, 50),
new Vector3(23, 1, 51),
new Vector3(24, 1, 47),
new Vector3(24, 1, 48),
new Vector3(24, 1, 49),
new Vector3(24, 1, 50),
new Vector3(24, 1, 51),
new Vector3(25, 1, 47),
new Vector3(25, 1, 48),
new Vector3(25, 1, 49),
new Vector3(25, 1, 50),
new Vector3(25, 1, 51),
new Vector3(48, 1, 64),
new Vector3(48, 1, 65),
new Vector3(48, 1, 66),
new Vector3(48, 1, 67),
new Vector3(48, 1, 68),
new Vector3(49, 1, 64),
new Vector3(49, 1, 65),
new Vector3(49, 1, 66),
new Vector3(49, 1, 67),
new Vector3(49, 1, 68),
new Vector3(50, 1, 64),
new Vector3(50, 1, 65),
new Vector3(50, 1, 66),
new Vector3(50, 1, 67),
new Vector3(50, 1, 68),
new Vector3(51, 1, 64),
new Vector3(51, 1, 65),
new Vector3(51, 1, 66),
new Vector3(51, 1, 67),
new Vector3(51, 1, 68),
new Vector3(52, 1, 64),
new Vector3(52, 1, 65),
new Vector3(52, 1, 66),
new Vector3(52, 1, 67),
new Vector3(52, 1, 68),
new Vector3(29, 1, 74),
new Vector3(29, 1, 75),
new Vector3(29, 1, 76),
new Vector3(29, 1, 77),
new Vector3(29, 1, 78),
new Vector3(30, 1, 74),
new Vector3(30, 1, 75),
new Vector3(30, 1, 76),
new Vector3(30, 1, 77),
new Vector3(30, 1, 78),
new Vector3(31, 1, 74),
new Vector3(31, 1, 75),
new Vector3(31, 1, 76),
new Vector3(31, 1, 77),
new Vector3(31, 1, 78),
new Vector3(32, 1, 74),
new Vector3(32, 1, 75),
new Vector3(32, 1, 76),
new Vector3(32, 1, 77),
new Vector3(32, 1, 78),
new Vector3(33, 1, 74),
new Vector3(33, 1, 75),
new Vector3(33, 1, 76),
new Vector3(33, 1, 77),
new Vector3(33, 1, 78),
new Vector3(8, 6, 30),
new Vector3(4, 5.5f, 29),
new Vector3(4, 5.5f, 29),
new Vector3(12, 5.5f, 30),
new Vector3(5, 5.5f, 33),
new Vector3(4, 5.5f, 30),
new Vector3(3, 5, 35),
new Vector3(9, 5, 36),
new Vector3(13, 5, 35),
new Vector3(2, 5, 31),
new Vector3(16, 4.5f, 31),
new Vector3(15, 4.5f, 37),
new Vector3(18, 4, 32),
new Vector3(8, 3.5f, 42),
new Vector3(19, 3.5f, 41),
new Vector3(9, 3, 16),
new Vector3(2, 3, 44),
new Vector3(21, 3, 17),
new Vector3(6, 3, 44),
new Vector3(22, 3, 33),
new Vector3(22, 3, 25),
new Vector3(2, 3, 16),
new Vector3(22, 3, 25),
new Vector3(8, 3, 44),
new Vector3(24, 2.5f, 28),
new Vector3(10, 2.5f, 46),
new Vector3(23, 2.5f, 45),
new Vector3(12, 2.5f, 46),
new Vector3(24, 2.5f, 30),
new Vector3(5, 2.5f, 46),
new Vector3(27, 1.5f, 25),
new Vector3(27, 1.5f, 26),
new Vector3(27, 1.5f, 27),
new Vector3(28, 1.5f, 25),
new Vector3(28, 1.5f, 26),
new Vector3(28, 1.5f, 27),
new Vector3(29, 1.5f, 25),
new Vector3(29, 1.5f, 26),
new Vector3(29, 1.5f, 27),
new Vector3(27, 1.5f, 32),
new Vector3(27, 1.5f, 33),
new Vector3(27, 1.5f, 34),
new Vector3(28, 1.5f, 32),
new Vector3(28, 1.5f, 33),
new Vector3(28, 1.5f, 34),
new Vector3(29, 1.5f, 32),
new Vector3(29, 1.5f, 33),
new Vector3(29, 1.5f, 34),
new Vector3(10, 1.5f, 49),
new Vector3(10, 1.5f, 50),
new Vector3(10, 1.5f, 51),
new Vector3(11, 1.5f, 49),
new Vector3(11, 1.5f, 50),
new Vector3(11, 1.5f, 51),
new Vector3(12, 1.5f, 49),
new Vector3(12, 1.5f, 50),
new Vector3(12, 1.5f, 51),
new Vector3(27, 1, 49),
new Vector3(27, 1, 50),
new Vector3(27, 1, 51),
new Vector3(27, 1, 52),
new Vector3(27, 1, 53),
new Vector3(28, 1, 49),
new Vector3(28, 1, 50),
new Vector3(28, 1, 51),
new Vector3(28, 1, 52),
new Vector3(28, 1, 53),
new Vector3(29, 1, 49),
new Vector3(29, 1, 50),
new Vector3(29, 1, 51),
new Vector3(29, 1, 52),
new Vector3(29, 1, 53),
new Vector3(30, 1, 49),
new Vector3(30, 1, 50),
new Vector3(30, 1, 51),
new Vector3(30, 1, 52),
new Vector3(30, 1, 53),
new Vector3(31, 1, 49),
new Vector3(31, 1, 50),
new Vector3(31, 1, 51),
new Vector3(31, 1, 52),
new Vector3(31, 1, 53),
new Vector3(28, 1, 20),
new Vector3(28, 1, 21),
new Vector3(28, 1, 22),
new Vector3(28, 1, 23),
new Vector3(28, 1, 24),
new Vector3(29, 1, 20),
new Vector3(29, 1, 21),
new Vector3(29, 1, 22),
new Vector3(29, 1, 23),
new Vector3(29, 1, 24),
new Vector3(30, 1, 20),
new Vector3(30, 1, 21),
new Vector3(30, 1, 22),
new Vector3(30, 1, 23),
new Vector3(30, 1, 24),
new Vector3(31, 1, 20),
new Vector3(31, 1, 21),
new Vector3(31, 1, 22),
new Vector3(31, 1, 23),
new Vector3(31, 1, 24),
new Vector3(32, 1, 20),
new Vector3(32, 1, 21),
new Vector3(32, 1, 22),
new Vector3(32, 1, 23),
new Vector3(32, 1, 24),
new Vector3(2, 1, 6),
new Vector3(2, 1, 7),
new Vector3(2, 1, 8),
new Vector3(2, 1, 9),
new Vector3(2, 1, 10),
new Vector3(3, 1, 6),
new Vector3(3, 1, 7),
new Vector3(3, 1, 8),
new Vector3(3, 1, 9),
new Vector3(3, 1, 10),
new Vector3(4, 1, 6),
new Vector3(4, 1, 7),
new Vector3(4, 1, 8),
new Vector3(4, 1, 9),
new Vector3(4, 1, 10),
new Vector3(5, 1, 6),
new Vector3(5, 1, 7),
new Vector3(5, 1, 8),
new Vector3(5, 1, 9),
new Vector3(5, 1, 10),
new Vector3(12, 1, 6),
new Vector3(12, 1, 7),
new Vector3(12, 1, 8),
new Vector3(12, 1, 9),
new Vector3(12, 1, 10),
new Vector3(13, 1, 6),
new Vector3(13, 1, 7),
new Vector3(13, 1, 8),
new Vector3(13, 1, 9),
new Vector3(13, 1, 10),
new Vector3(14, 1, 6),
new Vector3(14, 1, 7),
new Vector3(14, 1, 8),
new Vector3(14, 1, 9),
new Vector3(14, 1, 10),
new Vector3(15, 1, 6),
new Vector3(15, 1, 7),
new Vector3(15, 1, 8),
new Vector3(15, 1, 9),
new Vector3(15, 1, 10),
new Vector3(16, 1, 6),
new Vector3(16, 1, 7),
new Vector3(16, 1, 8),
new Vector3(16, 1, 9),
new Vector3(16, 1, 10) };
        }
  
        int k = 0;
        int tope = (int)alturaMaxima * 2;
        while (k < tope)
        {
            if (alturaMaxima == 0.5f)
            {               
                if (ponerLlano == true)
                {
                    PonerLlano2(alturaMaxima);
                }

                break;
            }

            alturaMaxima -= 0.5f;

            if (alturaMaxima < 0.5f)
            {
                alturaMaxima = 0.5f;
            }

            try
            {
                GenerarNivel(alturaMaxima, listadoCasillasInicial);                
            }
            catch (Exception fallo)
            {
                Debug.Log(fallo);
                k -= 1;
            }

            k += 1;
        }
    }

    public void Update()
    {

    }

    private void GenerarNivel(float altura, List<Vector3> listadoCasillasInicial)
    {
        foreach (Vector3 casillaInicial in listadoCasillasInicial.ToList<Vector3>())
        {
            if (altura == casillaInicial.y)
            {
                if (ComprobarLimiteX((int)casillaInicial.x, 3) == true && ComprobarLimiteZ((int)casillaInicial.z, 3) == true)
                {
                    if (terrenos[(int)casillaInicial.x, (int)casillaInicial.z] == null)
                    {
                        PonerTerreno(new Terreno(0, 0, casillaInicial));
                        listadoCasillasInicial.Remove(casillaInicial);
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 2, z + 1]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
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

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(28, 90, new Vector3(x + 1, y, z + 1));

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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x, z + 2]) == false)
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

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(28, 270, new Vector3(x + 1, y, z + 1));

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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
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

        if (ComprobarLimiteX(x, 4) == true && ComprobarLimiteZ(z, 3) == true)
        {
            if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 3, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z], y, 0) == true)
            {
                PonerTerreno(esquina3rotacion270);
            }
            else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 3, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 3, z], y, 0) == true)
            {
                PonerTerreno(esquina3rotacion270);
            }
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
