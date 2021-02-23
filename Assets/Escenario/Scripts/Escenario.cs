using Juego;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Escenario : MonoBehaviour
{
    [Header("Debug")]
    public bool Colores;
    public bool RecortarBordes;
    public bool PonerLlano;

    [Header("Scripts")]
    public Arranque arranque;

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

        bool aleatorio = false;

        if (aleatorio == true)
        {
            GUIUtility.systemCopyBuffer = null;
          
            int montañasGenerar = (int)arranque.tamañoEscenarioX / 100 * (int)arranque.tamañoEscenarioZ / 100;
            int intentosGeneracion = montañasGenerar * 2;
         
            int i = 1;
            while (i <= montañasGenerar)
            {
                float alturaCasilla = (int)Random.Range(3, alturaMaxima);
             
                int posicionX = (int)Random.Range(0 + alturaCasilla, (int)arranque.tamañoEscenarioX - alturaCasilla);
                int posicionZ = (int)Random.Range(0 + alturaCasilla, (int)arranque.tamañoEscenarioZ - alturaCasilla);

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
                    GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + "new Vector3(" + posicionX.ToString() + ", " + alturaCasilla.ToString() + ", " + posicionZ.ToString() + ")," + Environment.NewLine;

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
                                    if (alturaCasilla == 1f)
                                    {                                                                             
                                        for (int origenX = posicionX + x - 2; origenX < posicionX + x + 3; origenX++)
                                        {
                                            for (int origenZ = posicionZ + z - 2; origenZ < posicionZ + z + 3; origenZ++)
                                            {
                                                if (terrenos[origenX, origenZ] == null)
                                                {
                                                    if (ComprobarLimiteX(origenX, 2) == true && ComprobarLimiteZ(origenZ, 2) == true)
                                                    {
                                                        listadoCasillasInicial.Add(new Vector3(origenX, alturaCasilla, origenZ));
                                                        GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + "new Vector3(" + origenX.ToString() + ", " + alturaCasilla.ToString() + ", " + origenZ.ToString() + ")," + Environment.NewLine;
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
                                            GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + "new Vector3(" + (posicionX + x).ToString() + ", " + alturaCasilla.ToString() + ", " + (posicionZ + z).ToString() + ")," + Environment.NewLine;
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
            listadoCasillasInicial = new List<Vector3>
                {
new Vector3(68, 7, 367),
new Vector3(67, 6.5f, 371),
new Vector3(71, 6.5f, 370),
new Vector3(62, 6, 367),
new Vector3(66, 6, 373),
new Vector3(67, 6, 361),
new Vector3(74, 6, 368),
new Vector3(63, 6, 372),
new Vector3(61, 5.5f, 360),
new Vector3(60, 5.5f, 365),
new Vector3(76, 5.5f, 366),
new Vector3(76, 5.5f, 368),
new Vector3(59, 5, 376),
new Vector3(64, 4.5f, 379),
new Vector3(80, 4.5f, 366),
new Vector3(64, 4.5f, 355),
new Vector3(80, 4.5f, 366),
new Vector3(64, 4.5f, 379),
new Vector3(79, 4.5f, 378),
new Vector3(56, 4.5f, 362),
new Vector3(79, 4.5f, 356),
new Vector3(62, 4, 381),
new Vector3(55, 4, 380),
new Vector3(81, 4, 380),
new Vector3(55, 4, 380),
new Vector3(81, 4, 354),
new Vector3(82, 4, 366),
new Vector3(54, 4, 371),
new Vector3(72, 4, 353),
new Vector3(52, 3.5f, 360),
new Vector3(83, 3.5f, 382),
new Vector3(50, 3, 366),
new Vector3(50, 3, 362),
new Vector3(51, 3, 384),
new Vector3(71, 2.5f, 387),
new Vector3(49, 2.5f, 348),
new Vector3(64, 2.5f, 347),
new Vector3(87, 2.5f, 348),
new Vector3(87, 2.5f, 348),
new Vector3(70, 2.5f, 347),
new Vector3(64, 2.5f, 387),
new Vector3(88, 2.5f, 358),
new Vector3(88, 2.5f, 363),
new Vector3(76, 2.5f, 387),
new Vector3(46, 2, 363),
new Vector3(44, 1.5f, 361),
new Vector3(58, 1.5f, 343),
new Vector3(71, 1.5f, 343),
new Vector3(91, 1.5f, 344),
new Vector3(92, 1.5f, 376),
new Vector3(41, 1, 340),
new Vector3(41, 1, 341),
new Vector3(41, 1, 342),
new Vector3(41, 1, 343),
new Vector3(41, 1, 344),
new Vector3(42, 1, 340),
new Vector3(42, 1, 341),
new Vector3(42, 1, 342),
new Vector3(42, 1, 343),
new Vector3(42, 1, 344),
new Vector3(43, 1, 340),
new Vector3(43, 1, 341),
new Vector3(43, 1, 342),
new Vector3(43, 1, 343),
new Vector3(43, 1, 344),
new Vector3(44, 1, 340),
new Vector3(44, 1, 341),
new Vector3(44, 1, 342),
new Vector3(44, 1, 343),
new Vector3(44, 1, 344),
new Vector3(45, 1, 340),
new Vector3(45, 1, 341),
new Vector3(45, 1, 342),
new Vector3(45, 1, 343),
new Vector3(45, 1, 344),
new Vector3(41, 1, 390),
new Vector3(41, 1, 391),
new Vector3(41, 1, 392),
new Vector3(41, 1, 393),
new Vector3(41, 1, 394),
new Vector3(42, 1, 390),
new Vector3(42, 1, 391),
new Vector3(42, 1, 392),
new Vector3(42, 1, 393),
new Vector3(42, 1, 394),
new Vector3(43, 1, 390),
new Vector3(43, 1, 391),
new Vector3(43, 1, 392),
new Vector3(43, 1, 393),
new Vector3(43, 1, 394),
new Vector3(44, 1, 390),
new Vector3(44, 1, 391),
new Vector3(44, 1, 392),
new Vector3(44, 1, 393),
new Vector3(44, 1, 394),
new Vector3(45, 1, 390),
new Vector3(45, 1, 391),
new Vector3(45, 1, 392),
new Vector3(45, 1, 393),
new Vector3(45, 1, 394),
new Vector3(66, 1, 391),
new Vector3(66, 1, 392),
new Vector3(66, 1, 393),
new Vector3(66, 1, 394),
new Vector3(66, 1, 395),
new Vector3(67, 1, 391),
new Vector3(67, 1, 392),
new Vector3(67, 1, 393),
new Vector3(67, 1, 394),
new Vector3(67, 1, 395),
new Vector3(68, 1, 391),
new Vector3(68, 1, 392),
new Vector3(68, 1, 393),
new Vector3(68, 1, 394),
new Vector3(68, 1, 395),
new Vector3(69, 1, 391),
new Vector3(69, 1, 392),
new Vector3(69, 1, 393),
new Vector3(69, 1, 394),
new Vector3(69, 1, 395),
new Vector3(70, 1, 391),
new Vector3(70, 1, 392),
new Vector3(70, 1, 393),
new Vector3(70, 1, 394),
new Vector3(70, 1, 395),
new Vector3(40, 1, 357),
new Vector3(40, 1, 358),
new Vector3(40, 1, 359),
new Vector3(40, 1, 360),
new Vector3(40, 1, 361),
new Vector3(41, 1, 357),
new Vector3(41, 1, 358),
new Vector3(41, 1, 359),
new Vector3(41, 1, 360),
new Vector3(41, 1, 361),
new Vector3(42, 1, 357),
new Vector3(42, 1, 358),
new Vector3(42, 1, 359),
new Vector3(42, 1, 360),
new Vector3(42, 1, 361),
new Vector3(43, 1, 357),
new Vector3(43, 1, 358),
new Vector3(43, 1, 359),
new Vector3(43, 1, 360),
new Vector3(43, 1, 361),
new Vector3(44, 1, 357),
new Vector3(44, 1, 358),
new Vector3(44, 1, 359),
new Vector3(44, 1, 360),
new Vector3(44, 1, 361),
new Vector3(121, 6, 127),
new Vector3(120, 5.5f, 123),
new Vector3(118, 5.5f, 124),
new Vector3(120, 5.5f, 131),
new Vector3(124, 5.5f, 130),
new Vector3(116, 5, 122),
new Vector3(116, 5, 122),
new Vector3(126, 5, 122),
new Vector3(127, 5, 127),
new Vector3(119, 5, 121),
new Vector3(113, 4.5f, 125),
new Vector3(118, 4.5f, 135),
new Vector3(129, 4.5f, 126),
new Vector3(114, 4.5f, 134),
new Vector3(114, 4.5f, 120),
new Vector3(113, 4.5f, 125),
new Vector3(111, 4, 126),
new Vector3(112, 4, 136),
new Vector3(132, 3.5f, 116),
new Vector3(110, 3.5f, 138),
new Vector3(110, 3.5f, 116),
new Vector3(116, 3.5f, 139),
new Vector3(109, 3.5f, 127),
new Vector3(108, 3, 114),
new Vector3(107, 3, 129),
new Vector3(107, 3, 126),
new Vector3(107, 3, 129),
new Vector3(134, 3, 114),
new Vector3(124, 3, 141),
new Vector3(135, 3, 127),
new Vector3(107, 3, 125),
new Vector3(136, 2.5f, 112),
new Vector3(106, 2.5f, 142),
new Vector3(123, 2.5f, 143),
new Vector3(105, 2.5f, 122),
new Vector3(137, 2.5f, 128),
new Vector3(125, 2.5f, 143),
new Vector3(137, 2.5f, 132),
new Vector3(137, 2.5f, 131),
new Vector3(137, 2.5f, 122),
new Vector3(137, 2.5f, 124),
new Vector3(139, 2, 124),
new Vector3(139, 2, 121),
new Vector3(103, 2, 122),
new Vector3(114, 2, 109),
new Vector3(120, 1.5f, 147),
new Vector3(141, 1.5f, 119),
new Vector3(101, 1.5f, 131),
new Vector3(140, 1.5f, 108),
new Vector3(129, 1.5f, 147),
new Vector3(102, 1.5f, 108),
new Vector3(141, 1.5f, 128),
new Vector3(141, 1.5f, 126),
new Vector3(102, 1.5f, 146),
new Vector3(117, 1.5f, 147),
new Vector3(141, 1, 119),
new Vector3(141, 1, 120),
new Vector3(141, 1, 121),
new Vector3(141, 1, 122),
new Vector3(141, 1, 123),
new Vector3(142, 1, 119),
new Vector3(142, 1, 120),
new Vector3(142, 1, 121),
new Vector3(142, 1, 122),
new Vector3(142, 1, 123),
new Vector3(143, 1, 119),
new Vector3(143, 1, 120),
new Vector3(143, 1, 121),
new Vector3(143, 1, 122),
new Vector3(143, 1, 123),
new Vector3(144, 1, 119),
new Vector3(144, 1, 120),
new Vector3(144, 1, 121),
new Vector3(144, 1, 122),
new Vector3(144, 1, 123),
new Vector3(145, 1, 119),
new Vector3(145, 1, 120),
new Vector3(145, 1, 121),
new Vector3(145, 1, 122),
new Vector3(145, 1, 123),
new Vector3(97, 1, 117),
new Vector3(97, 1, 118),
new Vector3(97, 1, 119),
new Vector3(97, 1, 120),
new Vector3(97, 1, 121),
new Vector3(98, 1, 117),
new Vector3(98, 1, 118),
new Vector3(98, 1, 119),
new Vector3(98, 1, 120),
new Vector3(98, 1, 121),
new Vector3(99, 1, 117),
new Vector3(99, 1, 118),
new Vector3(99, 1, 119),
new Vector3(99, 1, 120),
new Vector3(99, 1, 121),
new Vector3(100, 1, 117),
new Vector3(100, 1, 118),
new Vector3(100, 1, 119),
new Vector3(100, 1, 120),
new Vector3(100, 1, 121),
new Vector3(101, 1, 117),
new Vector3(101, 1, 118),
new Vector3(101, 1, 119),
new Vector3(101, 1, 120),
new Vector3(101, 1, 121),
new Vector3(202, 7, 120),
new Vector3(202, 6.5f, 124),
new Vector3(205, 6.5f, 123),
new Vector3(206, 6.5f, 120),
new Vector3(201, 6.5f, 124),
new Vector3(207, 6, 125),
new Vector3(201, 6, 126),
new Vector3(208, 6, 119),
new Vector3(196, 6, 119),
new Vector3(208, 6, 120),
new Vector3(201, 5.5f, 128),
new Vector3(201, 5.5f, 128),
new Vector3(194, 5.5f, 119),
new Vector3(210, 5.5f, 117),
new Vector3(193, 5, 129),
new Vector3(193, 5, 111),
new Vector3(211, 5, 111),
new Vector3(200, 4.5f, 108),
new Vector3(191, 4.5f, 109),
new Vector3(215, 4, 107),
new Vector3(188, 4, 125),
new Vector3(199, 3.5f, 136),
new Vector3(187, 3.5f, 105),
new Vector3(200, 3.5f, 136),
new Vector3(203, 3.5f, 104),
new Vector3(186, 3.5f, 116),
new Vector3(186, 3.5f, 116),
new Vector3(217, 3.5f, 105),
new Vector3(186, 3.5f, 119),
new Vector3(217, 3.5f, 105),
new Vector3(218, 3.5f, 115),
new Vector3(217, 3.5f, 105),
new Vector3(185, 3, 103),
new Vector3(207, 2, 142),
new Vector3(203, 2, 98),
new Vector3(224, 2, 116),
new Vector3(210, 2, 142),
new Vector3(180, 2, 121),
new Vector3(180, 2, 126),
new Vector3(200, 2, 98),
new Vector3(202, 2, 142),
new Vector3(195, 2, 98),
new Vector3(224, 2, 113),
new Vector3(224, 2, 110),
new Vector3(181, 2, 99),
new Vector3(225, 1.5f, 97),
new Vector3(225, 1.5f, 143),
new Vector3(225, 1.5f, 97),
new Vector3(179, 1.5f, 143),
new Vector3(179, 1.5f, 97),
new Vector3(205, 1.5f, 96),
new Vector3(204, 1.5f, 144),
new Vector3(226, 1.5f, 120),
new Vector3(179, 1.5f, 143),
new Vector3(225, 1.5f, 143),
new Vector3(226, 1.5f, 124),
new Vector3(225, 1.5f, 143),
new Vector3(174, 1, 125),
new Vector3(174, 1, 126),
new Vector3(174, 1, 127),
new Vector3(174, 1, 128),
new Vector3(174, 1, 129),
new Vector3(175, 1, 125),
new Vector3(175, 1, 126),
new Vector3(175, 1, 127),
new Vector3(175, 1, 128),
new Vector3(175, 1, 129),
new Vector3(176, 1, 125),
new Vector3(176, 1, 126),
new Vector3(176, 1, 127),
new Vector3(176, 1, 128),
new Vector3(176, 1, 129),
new Vector3(177, 1, 125),
new Vector3(177, 1, 126),
new Vector3(177, 1, 127),
new Vector3(177, 1, 128),
new Vector3(177, 1, 129),
new Vector3(178, 1, 125),
new Vector3(178, 1, 126),
new Vector3(178, 1, 127),
new Vector3(178, 1, 128),
new Vector3(178, 1, 129),
new Vector3(226, 1, 121),
new Vector3(226, 1, 122),
new Vector3(226, 1, 123),
new Vector3(226, 1, 124),
new Vector3(226, 1, 125),
new Vector3(227, 1, 121),
new Vector3(227, 1, 122),
new Vector3(227, 1, 123),
new Vector3(227, 1, 124),
new Vector3(227, 1, 125),
new Vector3(228, 1, 121),
new Vector3(228, 1, 122),
new Vector3(228, 1, 123),
new Vector3(228, 1, 124),
new Vector3(228, 1, 125),
new Vector3(229, 1, 121),
new Vector3(229, 1, 122),
new Vector3(229, 1, 123),
new Vector3(229, 1, 124),
new Vector3(229, 1, 125),
new Vector3(230, 1, 121),
new Vector3(230, 1, 122),
new Vector3(230, 1, 123),
new Vector3(230, 1, 124),
new Vector3(230, 1, 125),
new Vector3(175, 1, 143),
new Vector3(175, 1, 144),
new Vector3(175, 1, 145),
new Vector3(175, 1, 146),
new Vector3(175, 1, 147),
new Vector3(176, 1, 143),
new Vector3(176, 1, 144),
new Vector3(176, 1, 145),
new Vector3(176, 1, 146),
new Vector3(176, 1, 147),
new Vector3(177, 1, 143),
new Vector3(177, 1, 144),
new Vector3(177, 1, 145),
new Vector3(177, 1, 146),
new Vector3(177, 1, 147),
new Vector3(178, 1, 143),
new Vector3(178, 1, 144),
new Vector3(178, 1, 145),
new Vector3(178, 1, 146),
new Vector3(178, 1, 147),
new Vector3(179, 1, 143),
new Vector3(179, 1, 144),
new Vector3(179, 1, 145),
new Vector3(179, 1, 146),
new Vector3(179, 1, 147),
new Vector3(175, 1, 143),
new Vector3(175, 1, 144),
new Vector3(175, 1, 145),
new Vector3(175, 1, 146),
new Vector3(175, 1, 147),
new Vector3(176, 1, 143),
new Vector3(176, 1, 144),
new Vector3(176, 1, 145),
new Vector3(176, 1, 146),
new Vector3(176, 1, 147),
new Vector3(177, 1, 143),
new Vector3(177, 1, 144),
new Vector3(177, 1, 145),
new Vector3(177, 1, 146),
new Vector3(177, 1, 147),
new Vector3(178, 1, 143),
new Vector3(178, 1, 144),
new Vector3(178, 1, 145),
new Vector3(178, 1, 146),
new Vector3(178, 1, 147),
new Vector3(179, 1, 143),
new Vector3(179, 1, 144),
new Vector3(179, 1, 145),
new Vector3(179, 1, 146),
new Vector3(179, 1, 147),
new Vector3(196, 1, 92),
new Vector3(196, 1, 93),
new Vector3(196, 1, 94),
new Vector3(196, 1, 95),
new Vector3(196, 1, 96),
new Vector3(197, 1, 92),
new Vector3(197, 1, 93),
new Vector3(197, 1, 94),
new Vector3(197, 1, 95),
new Vector3(197, 1, 96),
new Vector3(198, 1, 92),
new Vector3(198, 1, 93),
new Vector3(198, 1, 94),
new Vector3(198, 1, 95),
new Vector3(198, 1, 96),
new Vector3(199, 1, 92),
new Vector3(199, 1, 93),
new Vector3(199, 1, 94),
new Vector3(199, 1, 95),
new Vector3(199, 1, 96),
new Vector3(200, 1, 92),
new Vector3(200, 1, 93),
new Vector3(200, 1, 94),
new Vector3(200, 1, 95),
new Vector3(200, 1, 96),
new Vector3(174, 1, 124),
new Vector3(174, 1, 125),
new Vector3(174, 1, 126),
new Vector3(174, 1, 127),
new Vector3(174, 1, 128),
new Vector3(175, 1, 124),
new Vector3(175, 1, 125),
new Vector3(175, 1, 126),
new Vector3(175, 1, 127),
new Vector3(175, 1, 128),
new Vector3(176, 1, 124),
new Vector3(176, 1, 125),
new Vector3(176, 1, 126),
new Vector3(176, 1, 127),
new Vector3(176, 1, 128),
new Vector3(177, 1, 124),
new Vector3(177, 1, 125),
new Vector3(177, 1, 126),
new Vector3(177, 1, 127),
new Vector3(177, 1, 128),
new Vector3(178, 1, 124),
new Vector3(178, 1, 125),
new Vector3(178, 1, 126),
new Vector3(178, 1, 127),
new Vector3(178, 1, 128),
new Vector3(226, 1, 123),
new Vector3(226, 1, 124),
new Vector3(226, 1, 125),
new Vector3(226, 1, 126),
new Vector3(226, 1, 127),
new Vector3(227, 1, 123),
new Vector3(227, 1, 124),
new Vector3(227, 1, 125),
new Vector3(227, 1, 126),
new Vector3(227, 1, 127),
new Vector3(228, 1, 123),
new Vector3(228, 1, 124),
new Vector3(228, 1, 125),
new Vector3(228, 1, 126),
new Vector3(228, 1, 127),
new Vector3(229, 1, 123),
new Vector3(229, 1, 124),
new Vector3(229, 1, 125),
new Vector3(229, 1, 126),
new Vector3(229, 1, 127),
new Vector3(230, 1, 123),
new Vector3(230, 1, 124),
new Vector3(230, 1, 125),
new Vector3(230, 1, 126),
new Vector3(230, 1, 127),
new Vector3(175, 1, 143),
new Vector3(175, 1, 144),
new Vector3(175, 1, 145),
new Vector3(175, 1, 146),
new Vector3(175, 1, 147),
new Vector3(176, 1, 143),
new Vector3(176, 1, 144),
new Vector3(176, 1, 145),
new Vector3(176, 1, 146),
new Vector3(176, 1, 147),
new Vector3(177, 1, 143),
new Vector3(177, 1, 144),
new Vector3(177, 1, 145),
new Vector3(177, 1, 146),
new Vector3(177, 1, 147),
new Vector3(178, 1, 143),
new Vector3(178, 1, 144),
new Vector3(178, 1, 145),
new Vector3(178, 1, 146),
new Vector3(178, 1, 147),
new Vector3(179, 1, 143),
new Vector3(179, 1, 144),
new Vector3(179, 1, 145),
new Vector3(179, 1, 146),
new Vector3(179, 1, 147),
new Vector3(175, 1, 93),
new Vector3(175, 1, 94),
new Vector3(175, 1, 95),
new Vector3(175, 1, 96),
new Vector3(175, 1, 97),
new Vector3(176, 1, 93),
new Vector3(176, 1, 94),
new Vector3(176, 1, 95),
new Vector3(176, 1, 96),
new Vector3(176, 1, 97),
new Vector3(177, 1, 93),
new Vector3(177, 1, 94),
new Vector3(177, 1, 95),
new Vector3(177, 1, 96),
new Vector3(177, 1, 97),
new Vector3(178, 1, 93),
new Vector3(178, 1, 94),
new Vector3(178, 1, 95),
new Vector3(178, 1, 96),
new Vector3(178, 1, 97),
new Vector3(179, 1, 93),
new Vector3(179, 1, 94),
new Vector3(179, 1, 95),
new Vector3(179, 1, 96),
new Vector3(179, 1, 97),
new Vector3(210, 1, 144),
new Vector3(210, 1, 145),
new Vector3(210, 1, 146),
new Vector3(210, 1, 147),
new Vector3(210, 1, 148),
new Vector3(211, 1, 144),
new Vector3(211, 1, 145),
new Vector3(211, 1, 146),
new Vector3(211, 1, 147),
new Vector3(211, 1, 148),
new Vector3(212, 1, 144),
new Vector3(212, 1, 145),
new Vector3(212, 1, 146),
new Vector3(212, 1, 147),
new Vector3(212, 1, 148),
new Vector3(213, 1, 144),
new Vector3(213, 1, 145),
new Vector3(213, 1, 146),
new Vector3(213, 1, 147),
new Vector3(213, 1, 148),
new Vector3(214, 1, 144),
new Vector3(214, 1, 145),
new Vector3(214, 1, 146),
new Vector3(214, 1, 147),
new Vector3(214, 1, 148),
new Vector3(174, 1, 124),
new Vector3(174, 1, 125),
new Vector3(174, 1, 126),
new Vector3(174, 1, 127),
new Vector3(174, 1, 128),
new Vector3(175, 1, 124),
new Vector3(175, 1, 125),
new Vector3(175, 1, 126),
new Vector3(175, 1, 127),
new Vector3(175, 1, 128),
new Vector3(176, 1, 124),
new Vector3(176, 1, 125),
new Vector3(176, 1, 126),
new Vector3(176, 1, 127),
new Vector3(176, 1, 128),
new Vector3(177, 1, 124),
new Vector3(177, 1, 125),
new Vector3(177, 1, 126),
new Vector3(177, 1, 127),
new Vector3(177, 1, 128),
new Vector3(178, 1, 124),
new Vector3(178, 1, 125),
new Vector3(178, 1, 126),
new Vector3(178, 1, 127),
new Vector3(178, 1, 128),
new Vector3(36, 6, 228),
new Vector3(33, 5.5f, 225),
new Vector3(39, 5.5f, 225),
new Vector3(30, 5, 229),
new Vector3(41, 5, 223),
new Vector3(36, 5, 234),
new Vector3(36, 5, 234),
new Vector3(41, 5, 223),
new Vector3(37, 4, 238),
new Vector3(26, 4, 224),
new Vector3(26, 4, 230),
new Vector3(45, 4, 219),
new Vector3(26, 4, 225),
new Vector3(34, 4, 218),
new Vector3(26, 4, 228),
new Vector3(48, 3.5f, 229),
new Vector3(48, 3.5f, 226),
new Vector3(48, 3.5f, 231),
new Vector3(39, 3.5f, 216),
new Vector3(24, 3.5f, 224),
new Vector3(24, 3.5f, 225),
new Vector3(24, 3.5f, 228),
new Vector3(47, 3.5f, 239),
new Vector3(50, 3, 233),
new Vector3(50, 3, 231),
new Vector3(50, 3, 226),
new Vector3(23, 3, 241),
new Vector3(32, 3, 214),
new Vector3(23, 3, 215),
new Vector3(30, 3, 214),
new Vector3(22, 3, 229),
new Vector3(50, 3, 223),
new Vector3(52, 2.5f, 224),
new Vector3(52, 2.5f, 233),
new Vector3(54, 2, 221),
new Vector3(36, 2, 210),
new Vector3(19, 2, 211),
new Vector3(18, 2, 232),
new Vector3(53, 2, 245),
new Vector3(35, 2, 210),
new Vector3(53, 2, 211),
new Vector3(17, 1.5f, 247),
new Vector3(17, 1.5f, 209),
new Vector3(56, 1.5f, 229),
new Vector3(55, 1.5f, 247),
new Vector3(55, 1.5f, 209),
new Vector3(16, 1.5f, 236),
new Vector3(56, 1.5f, 224),
new Vector3(17, 1.5f, 247),
new Vector3(12, 1, 231),
new Vector3(12, 1, 232),
new Vector3(12, 1, 233),
new Vector3(12, 1, 234),
new Vector3(12, 1, 235),
new Vector3(13, 1, 231),
new Vector3(13, 1, 232),
new Vector3(13, 1, 233),
new Vector3(13, 1, 234),
new Vector3(13, 1, 235),
new Vector3(14, 1, 231),
new Vector3(14, 1, 232),
new Vector3(14, 1, 233),
new Vector3(14, 1, 234),
new Vector3(14, 1, 235),
new Vector3(15, 1, 231),
new Vector3(15, 1, 232),
new Vector3(15, 1, 233),
new Vector3(15, 1, 234),
new Vector3(15, 1, 235),
new Vector3(16, 1, 231),
new Vector3(16, 1, 232),
new Vector3(16, 1, 233),
new Vector3(16, 1, 234),
new Vector3(16, 1, 235),
new Vector3(55, 1, 247),
new Vector3(55, 1, 248),
new Vector3(55, 1, 249),
new Vector3(55, 1, 250),
new Vector3(55, 1, 251),
new Vector3(56, 1, 247),
new Vector3(56, 1, 248),
new Vector3(56, 1, 249),
new Vector3(56, 1, 250),
new Vector3(56, 1, 251),
new Vector3(57, 1, 247),
new Vector3(57, 1, 248),
new Vector3(57, 1, 249),
new Vector3(57, 1, 250),
new Vector3(57, 1, 251),
new Vector3(58, 1, 247),
new Vector3(58, 1, 248),
new Vector3(58, 1, 249),
new Vector3(58, 1, 250),
new Vector3(58, 1, 251),
new Vector3(59, 1, 247),
new Vector3(59, 1, 248),
new Vector3(59, 1, 249),
new Vector3(59, 1, 250),
new Vector3(59, 1, 251),
new Vector3(55, 1, 247),
new Vector3(55, 1, 248),
new Vector3(55, 1, 249),
new Vector3(55, 1, 250),
new Vector3(55, 1, 251),
new Vector3(56, 1, 247),
new Vector3(56, 1, 248),
new Vector3(56, 1, 249),
new Vector3(56, 1, 250),
new Vector3(56, 1, 251),
new Vector3(57, 1, 247),
new Vector3(57, 1, 248),
new Vector3(57, 1, 249),
new Vector3(57, 1, 250),
new Vector3(57, 1, 251),
new Vector3(58, 1, 247),
new Vector3(58, 1, 248),
new Vector3(58, 1, 249),
new Vector3(58, 1, 250),
new Vector3(58, 1, 251),
new Vector3(59, 1, 247),
new Vector3(59, 1, 248),
new Vector3(59, 1, 249),
new Vector3(59, 1, 250),
new Vector3(59, 1, 251),
new Vector3(25, 1, 204),
new Vector3(25, 1, 205),
new Vector3(25, 1, 206),
new Vector3(25, 1, 207),
new Vector3(25, 1, 208),
new Vector3(26, 1, 204),
new Vector3(26, 1, 205),
new Vector3(26, 1, 206),
new Vector3(26, 1, 207),
new Vector3(26, 1, 208),
new Vector3(27, 1, 204),
new Vector3(27, 1, 205),
new Vector3(27, 1, 206),
new Vector3(27, 1, 207),
new Vector3(27, 1, 208),
new Vector3(28, 1, 204),
new Vector3(28, 1, 205),
new Vector3(28, 1, 206),
new Vector3(28, 1, 207),
new Vector3(28, 1, 208),
new Vector3(29, 1, 204),
new Vector3(29, 1, 205),
new Vector3(29, 1, 206),
new Vector3(29, 1, 207),
new Vector3(29, 1, 208),
new Vector3(13, 1, 205),
new Vector3(13, 1, 206),
new Vector3(13, 1, 207),
new Vector3(13, 1, 208),
new Vector3(13, 1, 209),
new Vector3(14, 1, 205),
new Vector3(14, 1, 206),
new Vector3(14, 1, 207),
new Vector3(14, 1, 208),
new Vector3(14, 1, 209),
new Vector3(15, 1, 205),
new Vector3(15, 1, 206),
new Vector3(15, 1, 207),
new Vector3(15, 1, 208),
new Vector3(15, 1, 209),
new Vector3(16, 1, 205),
new Vector3(16, 1, 206),
new Vector3(16, 1, 207),
new Vector3(16, 1, 208),
new Vector3(16, 1, 209),
new Vector3(17, 1, 205),
new Vector3(17, 1, 206),
new Vector3(17, 1, 207),
new Vector3(17, 1, 208),
new Vector3(17, 1, 209),
new Vector3(55, 1, 205),
new Vector3(55, 1, 206),
new Vector3(55, 1, 207),
new Vector3(55, 1, 208),
new Vector3(55, 1, 209),
new Vector3(56, 1, 205),
new Vector3(56, 1, 206),
new Vector3(56, 1, 207),
new Vector3(56, 1, 208),
new Vector3(56, 1, 209),
new Vector3(57, 1, 205),
new Vector3(57, 1, 206),
new Vector3(57, 1, 207),
new Vector3(57, 1, 208),
new Vector3(57, 1, 209),
new Vector3(58, 1, 205),
new Vector3(58, 1, 206),
new Vector3(58, 1, 207),
new Vector3(58, 1, 208),
new Vector3(58, 1, 209),
new Vector3(59, 1, 205),
new Vector3(59, 1, 206),
new Vector3(59, 1, 207),
new Vector3(59, 1, 208),
new Vector3(59, 1, 209),
new Vector3(12, 1, 225),
new Vector3(12, 1, 226),
new Vector3(12, 1, 227),
new Vector3(12, 1, 228),
new Vector3(12, 1, 229),
new Vector3(13, 1, 225),
new Vector3(13, 1, 226),
new Vector3(13, 1, 227),
new Vector3(13, 1, 228),
new Vector3(13, 1, 229),
new Vector3(14, 1, 225),
new Vector3(14, 1, 226),
new Vector3(14, 1, 227),
new Vector3(14, 1, 228),
new Vector3(14, 1, 229),
new Vector3(15, 1, 225),
new Vector3(15, 1, 226),
new Vector3(15, 1, 227),
new Vector3(15, 1, 228),
new Vector3(15, 1, 229),
new Vector3(16, 1, 225),
new Vector3(16, 1, 226),
new Vector3(16, 1, 227),
new Vector3(16, 1, 228),
new Vector3(16, 1, 229),
new Vector3(55, 1, 205),
new Vector3(55, 1, 206),
new Vector3(55, 1, 207),
new Vector3(55, 1, 208),
new Vector3(55, 1, 209),
new Vector3(56, 1, 205),
new Vector3(56, 1, 206),
new Vector3(56, 1, 207),
new Vector3(56, 1, 208),
new Vector3(56, 1, 209),
new Vector3(57, 1, 205),
new Vector3(57, 1, 206),
new Vector3(57, 1, 207),
new Vector3(57, 1, 208),
new Vector3(57, 1, 209),
new Vector3(58, 1, 205),
new Vector3(58, 1, 206),
new Vector3(58, 1, 207),
new Vector3(58, 1, 208),
new Vector3(58, 1, 209),
new Vector3(59, 1, 205),
new Vector3(59, 1, 206),
new Vector3(59, 1, 207),
new Vector3(59, 1, 208),
new Vector3(59, 1, 209),
new Vector3(55, 1, 247),
new Vector3(55, 1, 248),
new Vector3(55, 1, 249),
new Vector3(55, 1, 250),
new Vector3(55, 1, 251),
new Vector3(56, 1, 247),
new Vector3(56, 1, 248),
new Vector3(56, 1, 249),
new Vector3(56, 1, 250),
new Vector3(56, 1, 251),
new Vector3(57, 1, 247),
new Vector3(57, 1, 248),
new Vector3(57, 1, 249),
new Vector3(57, 1, 250),
new Vector3(57, 1, 251),
new Vector3(58, 1, 247),
new Vector3(58, 1, 248),
new Vector3(58, 1, 249),
new Vector3(58, 1, 250),
new Vector3(58, 1, 251),
new Vector3(59, 1, 247),
new Vector3(59, 1, 248),
new Vector3(59, 1, 249),
new Vector3(59, 1, 250),
new Vector3(59, 1, 251),
new Vector3(56, 1, 225),
new Vector3(56, 1, 226),
new Vector3(56, 1, 227),
new Vector3(56, 1, 228),
new Vector3(56, 1, 229),
new Vector3(57, 1, 225),
new Vector3(57, 1, 226),
new Vector3(57, 1, 227),
new Vector3(57, 1, 228),
new Vector3(57, 1, 229),
new Vector3(58, 1, 225),
new Vector3(58, 1, 226),
new Vector3(58, 1, 227),
new Vector3(58, 1, 228),
new Vector3(58, 1, 229),
new Vector3(59, 1, 225),
new Vector3(59, 1, 226),
new Vector3(59, 1, 227),
new Vector3(59, 1, 228),
new Vector3(59, 1, 229),
new Vector3(60, 1, 225),
new Vector3(60, 1, 226),
new Vector3(60, 1, 227),
new Vector3(60, 1, 228),
new Vector3(60, 1, 229),
new Vector3(231, 4, 137),
new Vector3(235, 3.5f, 136),
new Vector3(230, 3.5f, 141),
new Vector3(227, 3.5f, 136),
new Vector3(226, 3, 142),
new Vector3(239, 2.5f, 135),
new Vector3(240, 2, 128),
new Vector3(220, 1.5f, 148),
new Vector3(219, 1.5f, 135),
new Vector3(233, 1.5f, 149),
new Vector3(219, 1.5f, 138),
new Vector3(242, 1.5f, 148),
new Vector3(243, 1.5f, 134),
new Vector3(224, 1, 121),
new Vector3(224, 1, 122),
new Vector3(224, 1, 123),
new Vector3(224, 1, 124),
new Vector3(224, 1, 125),
new Vector3(225, 1, 121),
new Vector3(225, 1, 122),
new Vector3(225, 1, 123),
new Vector3(225, 1, 124),
new Vector3(225, 1, 125),
new Vector3(226, 1, 121),
new Vector3(226, 1, 122),
new Vector3(226, 1, 123),
new Vector3(226, 1, 124),
new Vector3(226, 1, 125),
new Vector3(227, 1, 121),
new Vector3(227, 1, 122),
new Vector3(227, 1, 123),
new Vector3(227, 1, 124),
new Vector3(227, 1, 125),
new Vector3(228, 1, 121),
new Vector3(228, 1, 122),
new Vector3(228, 1, 123),
new Vector3(228, 1, 124),
new Vector3(228, 1, 125),
new Vector3(205, 3, 284),
new Vector3(201, 2.5f, 284),
new Vector3(208, 2.5f, 287),
new Vector3(208, 2.5f, 281),
new Vector3(201, 2.5f, 283),
new Vector3(204, 2.5f, 288),
new Vector3(210, 2, 289),
new Vector3(211, 2, 284),
new Vector3(200, 2, 289),
new Vector3(199, 2, 282),
new Vector3(211, 2, 282),
new Vector3(204, 2, 290),
new Vector3(213, 1.5f, 282),
new Vector3(212, 1.5f, 277),
new Vector3(206, 1.5f, 292),
new Vector3(207, 1.5f, 292),
new Vector3(206, 1.5f, 292),
new Vector3(197, 1.5f, 281),
new Vector3(212, 1, 291),
new Vector3(212, 1, 292),
new Vector3(212, 1, 293),
new Vector3(212, 1, 294),
new Vector3(212, 1, 295),
new Vector3(213, 1, 291),
new Vector3(213, 1, 292),
new Vector3(213, 1, 293),
new Vector3(213, 1, 294),
new Vector3(213, 1, 295),
new Vector3(214, 1, 291),
new Vector3(214, 1, 292),
new Vector3(214, 1, 293),
new Vector3(214, 1, 294),
new Vector3(214, 1, 295),
new Vector3(215, 1, 291),
new Vector3(215, 1, 292),
new Vector3(215, 1, 293),
new Vector3(215, 1, 294),
new Vector3(215, 1, 295),
new Vector3(216, 1, 291),
new Vector3(216, 1, 292),
new Vector3(216, 1, 293),
new Vector3(216, 1, 294),
new Vector3(216, 1, 295),
new Vector3(201, 1, 292),
new Vector3(201, 1, 293),
new Vector3(201, 1, 294),
new Vector3(201, 1, 295),
new Vector3(201, 1, 296),
new Vector3(202, 1, 292),
new Vector3(202, 1, 293),
new Vector3(202, 1, 294),
new Vector3(202, 1, 295),
new Vector3(202, 1, 296),
new Vector3(203, 1, 292),
new Vector3(203, 1, 293),
new Vector3(203, 1, 294),
new Vector3(203, 1, 295),
new Vector3(203, 1, 296),
new Vector3(204, 1, 292),
new Vector3(204, 1, 293),
new Vector3(204, 1, 294),
new Vector3(204, 1, 295),
new Vector3(204, 1, 296),
new Vector3(205, 1, 292),
new Vector3(205, 1, 293),
new Vector3(205, 1, 294),
new Vector3(205, 1, 295),
new Vector3(205, 1, 296),
new Vector3(221, 4, 17),
new Vector3(219, 3, 23),
new Vector3(216, 3, 22),
new Vector3(226, 3, 12),
new Vector3(220, 3, 11),
new Vector3(220, 2.5f, 25),
new Vector3(222, 2.5f, 25),
new Vector3(220, 2.5f, 25),
new Vector3(228, 2.5f, 24),
new Vector3(230, 2, 26),
new Vector3(233, 1.5f, 16),
new Vector3(209, 1.5f, 14),
new Vector3(210, 1.5f, 28),
new Vector3(221, 1.5f, 29),
new Vector3(232, 1.5f, 28),
new Vector3(233, 1.5f, 21),
new Vector3(220, 1.5f, 5),
new Vector3(206, 1, 2),
new Vector3(206, 1, 3),
new Vector3(206, 1, 4),
new Vector3(206, 1, 5),
new Vector3(206, 1, 6),
new Vector3(207, 1, 2),
new Vector3(207, 1, 3),
new Vector3(207, 1, 4),
new Vector3(207, 1, 5),
new Vector3(207, 1, 6),
new Vector3(208, 1, 2),
new Vector3(208, 1, 3),
new Vector3(208, 1, 4),
new Vector3(208, 1, 5),
new Vector3(208, 1, 6),
new Vector3(209, 1, 2),
new Vector3(209, 1, 3),
new Vector3(209, 1, 4),
new Vector3(209, 1, 5),
new Vector3(209, 1, 6),
new Vector3(210, 1, 2),
new Vector3(210, 1, 3),
new Vector3(210, 1, 4),
new Vector3(210, 1, 5),
new Vector3(210, 1, 6),
new Vector3(233, 1, 13),
new Vector3(233, 1, 14),
new Vector3(233, 1, 15),
new Vector3(233, 1, 16),
new Vector3(233, 1, 17),
new Vector3(234, 1, 13),
new Vector3(234, 1, 14),
new Vector3(234, 1, 15),
new Vector3(234, 1, 16),
new Vector3(234, 1, 17),
new Vector3(235, 1, 13),
new Vector3(235, 1, 14),
new Vector3(235, 1, 15),
new Vector3(235, 1, 16),
new Vector3(235, 1, 17),
new Vector3(236, 1, 13),
new Vector3(236, 1, 14),
new Vector3(236, 1, 15),
new Vector3(236, 1, 16),
new Vector3(236, 1, 17),
new Vector3(237, 1, 13),
new Vector3(237, 1, 14),
new Vector3(237, 1, 15),
new Vector3(237, 1, 16),
new Vector3(237, 1, 17),
new Vector3(218, 1, 29),
new Vector3(218, 1, 30),
new Vector3(218, 1, 31),
new Vector3(218, 1, 32),
new Vector3(218, 1, 33),
new Vector3(219, 1, 29),
new Vector3(219, 1, 30),
new Vector3(219, 1, 31),
new Vector3(219, 1, 32),
new Vector3(219, 1, 33),
new Vector3(220, 1, 29),
new Vector3(220, 1, 30),
new Vector3(220, 1, 31),
new Vector3(220, 1, 32),
new Vector3(220, 1, 33),
new Vector3(221, 1, 29),
new Vector3(221, 1, 30),
new Vector3(221, 1, 31),
new Vector3(221, 1, 32),
new Vector3(221, 1, 33),
new Vector3(222, 1, 29),
new Vector3(222, 1, 30),
new Vector3(222, 1, 31),
new Vector3(222, 1, 32),
new Vector3(222, 1, 33),
new Vector3(215, 1, 2),
new Vector3(215, 1, 3),
new Vector3(215, 1, 4),
new Vector3(215, 1, 5),
new Vector3(216, 1, 2),
new Vector3(216, 1, 3),
new Vector3(216, 1, 4),
new Vector3(216, 1, 5),
new Vector3(217, 1, 2),
new Vector3(217, 1, 3),
new Vector3(217, 1, 4),
new Vector3(217, 1, 5),
new Vector3(218, 1, 2),
new Vector3(218, 1, 3),
new Vector3(218, 1, 4),
new Vector3(218, 1, 5),
new Vector3(219, 1, 2),
new Vector3(219, 1, 3),
new Vector3(219, 1, 4),
new Vector3(219, 1, 5),
new Vector3(233, 1, 15),
new Vector3(233, 1, 16),
new Vector3(233, 1, 17),
new Vector3(233, 1, 18),
new Vector3(233, 1, 19),
new Vector3(234, 1, 15),
new Vector3(234, 1, 16),
new Vector3(234, 1, 17),
new Vector3(234, 1, 18),
new Vector3(234, 1, 19),
new Vector3(235, 1, 15),
new Vector3(235, 1, 16),
new Vector3(235, 1, 17),
new Vector3(235, 1, 18),
new Vector3(235, 1, 19),
new Vector3(236, 1, 15),
new Vector3(236, 1, 16),
new Vector3(236, 1, 17),
new Vector3(236, 1, 18),
new Vector3(236, 1, 19),
new Vector3(237, 1, 15),
new Vector3(237, 1, 16),
new Vector3(237, 1, 17),
new Vector3(237, 1, 18),
new Vector3(237, 1, 19),
new Vector3(220, 1, 29),
new Vector3(220, 1, 30),
new Vector3(220, 1, 31),
new Vector3(220, 1, 32),
new Vector3(220, 1, 33),
new Vector3(221, 1, 29),
new Vector3(221, 1, 30),
new Vector3(221, 1, 31),
new Vector3(221, 1, 32),
new Vector3(221, 1, 33),
new Vector3(222, 1, 29),
new Vector3(222, 1, 30),
new Vector3(222, 1, 31),
new Vector3(222, 1, 32),
new Vector3(222, 1, 33),
new Vector3(223, 1, 29),
new Vector3(223, 1, 30),
new Vector3(223, 1, 31),
new Vector3(223, 1, 32),
new Vector3(223, 1, 33),
new Vector3(224, 1, 29),
new Vector3(224, 1, 30),
new Vector3(224, 1, 31),
new Vector3(224, 1, 32),
new Vector3(224, 1, 33),
new Vector3(205, 1, 18),
new Vector3(205, 1, 19),
new Vector3(205, 1, 20),
new Vector3(205, 1, 21),
new Vector3(205, 1, 22),
new Vector3(206, 1, 18),
new Vector3(206, 1, 19),
new Vector3(206, 1, 20),
new Vector3(206, 1, 21),
new Vector3(206, 1, 22),
new Vector3(207, 1, 18),
new Vector3(207, 1, 19),
new Vector3(207, 1, 20),
new Vector3(207, 1, 21),
new Vector3(207, 1, 22),
new Vector3(208, 1, 18),
new Vector3(208, 1, 19),
new Vector3(208, 1, 20),
new Vector3(208, 1, 21),
new Vector3(208, 1, 22),
new Vector3(209, 1, 18),
new Vector3(209, 1, 19),
new Vector3(209, 1, 20),
new Vector3(209, 1, 21),
new Vector3(209, 1, 22),
new Vector3(120, 7, 180),
new Vector3(123, 6.5f, 183),
new Vector3(114, 6, 181),
new Vector3(120, 6, 174),
new Vector3(126, 6, 179),
new Vector3(126, 6, 180),
new Vector3(127, 5.5f, 173),
new Vector3(112, 5.5f, 182),
new Vector3(127, 5.5f, 173),
new Vector3(128, 5.5f, 179),
new Vector3(112, 5.5f, 178),
new Vector3(110, 5, 180),
new Vector3(110, 5, 176),
new Vector3(129, 5, 189),
new Vector3(124, 4.5f, 168),
new Vector3(108, 4.5f, 177),
new Vector3(109, 4.5f, 169),
new Vector3(134, 4, 181),
new Vector3(133, 4, 193),
new Vector3(134, 4, 182),
new Vector3(125, 3.5f, 164),
new Vector3(124, 3.5f, 196),
new Vector3(105, 3.5f, 195),
new Vector3(116, 3.5f, 196),
new Vector3(115, 3.5f, 196),
new Vector3(135, 3.5f, 195),
new Vector3(136, 3.5f, 183),
new Vector3(120, 3.5f, 196),
new Vector3(136, 3.5f, 183),
new Vector3(139, 2.5f, 199),
new Vector3(139, 2.5f, 199),
new Vector3(100, 2.5f, 184),
new Vector3(139, 2.5f, 199),
new Vector3(121, 2.5f, 200),
new Vector3(140, 2.5f, 181),
new Vector3(140, 2.5f, 172),
new Vector3(123, 2.5f, 200),
new Vector3(101, 2.5f, 161),
new Vector3(125, 2.5f, 200),
new Vector3(101, 2.5f, 161),
new Vector3(98, 2, 176),
new Vector3(141, 2, 201),
new Vector3(124, 2, 202),
new Vector3(112, 2, 158),
new Vector3(112, 2, 158),
new Vector3(141, 2, 159),
new Vector3(141, 2, 159),
new Vector3(98, 2, 174),
new Vector3(99, 2, 201),
new Vector3(142, 2, 175),
new Vector3(142, 2, 179),
new Vector3(141, 2, 201),
new Vector3(141, 2, 201),
new Vector3(96, 1.5f, 178),
new Vector3(144, 1, 169),
new Vector3(144, 1, 170),
new Vector3(144, 1, 171),
new Vector3(144, 1, 172),
new Vector3(144, 1, 173),
new Vector3(145, 1, 169),
new Vector3(145, 1, 170),
new Vector3(145, 1, 171),
new Vector3(145, 1, 172),
new Vector3(145, 1, 173),
new Vector3(146, 1, 169),
new Vector3(146, 1, 170),
new Vector3(146, 1, 171),
new Vector3(146, 1, 172),
new Vector3(146, 1, 173),
new Vector3(147, 1, 169),
new Vector3(147, 1, 170),
new Vector3(147, 1, 171),
new Vector3(147, 1, 172),
new Vector3(147, 1, 173),
new Vector3(148, 1, 169),
new Vector3(148, 1, 170),
new Vector3(148, 1, 171),
new Vector3(148, 1, 172),
new Vector3(148, 1, 173),
new Vector3(144, 1, 177),
new Vector3(144, 1, 178),
new Vector3(144, 1, 179),
new Vector3(144, 1, 180),
new Vector3(144, 1, 181),
new Vector3(145, 1, 177),
new Vector3(145, 1, 178),
new Vector3(145, 1, 179),
new Vector3(145, 1, 180),
new Vector3(145, 1, 181),
new Vector3(146, 1, 177),
new Vector3(146, 1, 178),
new Vector3(146, 1, 179),
new Vector3(146, 1, 180),
new Vector3(146, 1, 181),
new Vector3(147, 1, 177),
new Vector3(147, 1, 178),
new Vector3(147, 1, 179),
new Vector3(147, 1, 180),
new Vector3(147, 1, 181),
new Vector3(148, 1, 177),
new Vector3(148, 1, 178),
new Vector3(148, 1, 179),
new Vector3(148, 1, 180),
new Vector3(148, 1, 181),
new Vector3(93, 1, 203),
new Vector3(93, 1, 204),
new Vector3(93, 1, 205),
new Vector3(93, 1, 206),
new Vector3(93, 1, 207),
new Vector3(94, 1, 203),
new Vector3(94, 1, 204),
new Vector3(94, 1, 205),
new Vector3(94, 1, 206),
new Vector3(94, 1, 207),
new Vector3(95, 1, 203),
new Vector3(95, 1, 204),
new Vector3(95, 1, 205),
new Vector3(95, 1, 206),
new Vector3(95, 1, 207),
new Vector3(96, 1, 203),
new Vector3(96, 1, 204),
new Vector3(96, 1, 205),
new Vector3(96, 1, 206),
new Vector3(96, 1, 207),
new Vector3(97, 1, 203),
new Vector3(97, 1, 204),
new Vector3(97, 1, 205),
new Vector3(97, 1, 206),
new Vector3(97, 1, 207),
new Vector3(144, 1, 180),
new Vector3(144, 1, 181),
new Vector3(144, 1, 182),
new Vector3(144, 1, 183),
new Vector3(144, 1, 184),
new Vector3(145, 1, 180),
new Vector3(145, 1, 181),
new Vector3(145, 1, 182),
new Vector3(145, 1, 183),
new Vector3(145, 1, 184),
new Vector3(146, 1, 180),
new Vector3(146, 1, 181),
new Vector3(146, 1, 182),
new Vector3(146, 1, 183),
new Vector3(146, 1, 184),
new Vector3(147, 1, 180),
new Vector3(147, 1, 181),
new Vector3(147, 1, 182),
new Vector3(147, 1, 183),
new Vector3(147, 1, 184),
new Vector3(148, 1, 180),
new Vector3(148, 1, 181),
new Vector3(148, 1, 182),
new Vector3(148, 1, 183),
new Vector3(148, 1, 184),
new Vector3(143, 1, 203),
new Vector3(143, 1, 204),
new Vector3(143, 1, 205),
new Vector3(143, 1, 206),
new Vector3(143, 1, 207),
new Vector3(144, 1, 203),
new Vector3(144, 1, 204),
new Vector3(144, 1, 205),
new Vector3(144, 1, 206),
new Vector3(144, 1, 207),
new Vector3(145, 1, 203),
new Vector3(145, 1, 204),
new Vector3(145, 1, 205),
new Vector3(145, 1, 206),
new Vector3(145, 1, 207),
new Vector3(146, 1, 203),
new Vector3(146, 1, 204),
new Vector3(146, 1, 205),
new Vector3(146, 1, 206),
new Vector3(146, 1, 207),
new Vector3(147, 1, 203),
new Vector3(147, 1, 204),
new Vector3(147, 1, 205),
new Vector3(147, 1, 206),
new Vector3(147, 1, 207),
new Vector3(93, 1, 203),
new Vector3(93, 1, 204),
new Vector3(93, 1, 205),
new Vector3(93, 1, 206),
new Vector3(93, 1, 207),
new Vector3(94, 1, 203),
new Vector3(94, 1, 204),
new Vector3(94, 1, 205),
new Vector3(94, 1, 206),
new Vector3(94, 1, 207),
new Vector3(95, 1, 203),
new Vector3(95, 1, 204),
new Vector3(95, 1, 205),
new Vector3(95, 1, 206),
new Vector3(95, 1, 207),
new Vector3(96, 1, 203),
new Vector3(96, 1, 204),
new Vector3(96, 1, 205),
new Vector3(96, 1, 206),
new Vector3(96, 1, 207),
new Vector3(97, 1, 203),
new Vector3(97, 1, 204),
new Vector3(97, 1, 205),
new Vector3(97, 1, 206),
new Vector3(97, 1, 207),
new Vector3(143, 1, 153),
new Vector3(143, 1, 154),
new Vector3(143, 1, 155),
new Vector3(143, 1, 156),
new Vector3(143, 1, 157),
new Vector3(144, 1, 153),
new Vector3(144, 1, 154),
new Vector3(144, 1, 155),
new Vector3(144, 1, 156),
new Vector3(144, 1, 157),
new Vector3(145, 1, 153),
new Vector3(145, 1, 154),
new Vector3(145, 1, 155),
new Vector3(145, 1, 156),
new Vector3(145, 1, 157),
new Vector3(146, 1, 153),
new Vector3(146, 1, 154),
new Vector3(146, 1, 155),
new Vector3(146, 1, 156),
new Vector3(146, 1, 157),
new Vector3(147, 1, 153),
new Vector3(147, 1, 154),
new Vector3(147, 1, 155),
new Vector3(147, 1, 156),
new Vector3(147, 1, 157),
new Vector3(143, 1, 203),
new Vector3(143, 1, 204),
new Vector3(143, 1, 205),
new Vector3(143, 1, 206),
new Vector3(143, 1, 207),
new Vector3(144, 1, 203),
new Vector3(144, 1, 204),
new Vector3(144, 1, 205),
new Vector3(144, 1, 206),
new Vector3(144, 1, 207),
new Vector3(145, 1, 203),
new Vector3(145, 1, 204),
new Vector3(145, 1, 205),
new Vector3(145, 1, 206),
new Vector3(145, 1, 207),
new Vector3(146, 1, 203),
new Vector3(146, 1, 204),
new Vector3(146, 1, 205),
new Vector3(146, 1, 206),
new Vector3(146, 1, 207),
new Vector3(147, 1, 203),
new Vector3(147, 1, 204),
new Vector3(147, 1, 205),
new Vector3(147, 1, 206),
new Vector3(147, 1, 207),
new Vector3(92, 1, 168),
new Vector3(92, 1, 169),
new Vector3(92, 1, 170),
new Vector3(92, 1, 171),
new Vector3(92, 1, 172),
new Vector3(93, 1, 168),
new Vector3(93, 1, 169),
new Vector3(93, 1, 170),
new Vector3(93, 1, 171),
new Vector3(93, 1, 172),
new Vector3(94, 1, 168),
new Vector3(94, 1, 169),
new Vector3(94, 1, 170),
new Vector3(94, 1, 171),
new Vector3(94, 1, 172),
new Vector3(95, 1, 168),
new Vector3(95, 1, 169),
new Vector3(95, 1, 170),
new Vector3(95, 1, 171),
new Vector3(95, 1, 172),
new Vector3(96, 1, 168),
new Vector3(96, 1, 169),
new Vector3(96, 1, 170),
new Vector3(96, 1, 171),
new Vector3(96, 1, 172),
new Vector3(117, 1, 204),
new Vector3(117, 1, 205),
new Vector3(117, 1, 206),
new Vector3(117, 1, 207),
new Vector3(117, 1, 208),
new Vector3(118, 1, 204),
new Vector3(118, 1, 205),
new Vector3(118, 1, 206),
new Vector3(118, 1, 207),
new Vector3(118, 1, 208),
new Vector3(119, 1, 204),
new Vector3(119, 1, 205),
new Vector3(119, 1, 206),
new Vector3(119, 1, 207),
new Vector3(119, 1, 208),
new Vector3(120, 1, 204),
new Vector3(120, 1, 205),
new Vector3(120, 1, 206),
new Vector3(120, 1, 207),
new Vector3(120, 1, 208),
new Vector3(121, 1, 204),
new Vector3(121, 1, 205),
new Vector3(121, 1, 206),
new Vector3(121, 1, 207),
new Vector3(121, 1, 208),
new Vector3(144, 1, 169),
new Vector3(144, 1, 170),
new Vector3(144, 1, 171),
new Vector3(144, 1, 172),
new Vector3(144, 1, 173),
new Vector3(145, 1, 169),
new Vector3(145, 1, 170),
new Vector3(145, 1, 171),
new Vector3(145, 1, 172),
new Vector3(145, 1, 173),
new Vector3(146, 1, 169),
new Vector3(146, 1, 170),
new Vector3(146, 1, 171),
new Vector3(146, 1, 172),
new Vector3(146, 1, 173),
new Vector3(147, 1, 169),
new Vector3(147, 1, 170),
new Vector3(147, 1, 171),
new Vector3(147, 1, 172),
new Vector3(147, 1, 173),
new Vector3(148, 1, 169),
new Vector3(148, 1, 170),
new Vector3(148, 1, 171),
new Vector3(148, 1, 172),
new Vector3(148, 1, 173),
new Vector3(26, 7, 159),
new Vector3(30, 6.5f, 158),
new Vector3(31, 6, 154),
new Vector3(20, 6, 157),
new Vector3(32, 6, 158),
new Vector3(19, 5.5f, 152),
new Vector3(19, 5.5f, 166),
new Vector3(19, 5.5f, 166),
new Vector3(18, 5.5f, 160),
new Vector3(36, 5, 157),
new Vector3(35, 5, 150),
new Vector3(38, 4.5f, 157),
new Vector3(14, 4.5f, 155),
new Vector3(15, 4.5f, 170),
new Vector3(23, 4.5f, 171),
new Vector3(40, 4, 162),
new Vector3(12, 4, 156),
new Vector3(39, 4, 146),
new Vector3(13, 4, 172),
new Vector3(12, 4, 164),
new Vector3(42, 3.5f, 154),
new Vector3(42, 3.5f, 155),
new Vector3(41, 3.5f, 174),
new Vector3(31, 3.5f, 143),
new Vector3(19, 3.5f, 143),
new Vector3(41, 3.5f, 144),
new Vector3(9, 3, 176),
new Vector3(26, 3, 177),
new Vector3(8, 3, 166),
new Vector3(43, 3, 176),
new Vector3(44, 3, 151),
new Vector3(32, 3, 141),
new Vector3(9, 3, 176),
new Vector3(7, 2.5f, 178),
new Vector3(46, 2.5f, 161),
new Vector3(25, 2.5f, 139),
new Vector3(6, 2.5f, 155),
new Vector3(7, 2.5f, 178),
new Vector3(6, 2.5f, 151),
new Vector3(45, 2.5f, 140),
new Vector3(6, 2.5f, 167),
new Vector3(18, 2.5f, 179),
new Vector3(4, 2, 151),
new Vector3(48, 2, 162),
new Vector3(32, 2, 181),
new Vector3(5, 2, 180),
new Vector3(48, 2, 150),
new Vector3(34, 2, 181),
new Vector3(32, 2, 137),
new Vector3(50, 1.5f, 162),
new Vector3(49, 1.5f, 182),
new Vector3(50, 1.5f, 157),
new Vector3(3, 1.5f, 136),
new Vector3(14, 1, 131),
new Vector3(14, 1, 132),
new Vector3(14, 1, 133),
new Vector3(14, 1, 134),
new Vector3(14, 1, 135),
new Vector3(15, 1, 131),
new Vector3(15, 1, 132),
new Vector3(15, 1, 133),
new Vector3(15, 1, 134),
new Vector3(15, 1, 135),
new Vector3(16, 1, 131),
new Vector3(16, 1, 132),
new Vector3(16, 1, 133),
new Vector3(16, 1, 134),
new Vector3(16, 1, 135),
new Vector3(17, 1, 131),
new Vector3(17, 1, 132),
new Vector3(17, 1, 133),
new Vector3(17, 1, 134),
new Vector3(17, 1, 135),
new Vector3(18, 1, 131),
new Vector3(18, 1, 132),
new Vector3(18, 1, 133),
new Vector3(18, 1, 134),
new Vector3(18, 1, 135),
new Vector3(50, 1, 160),
new Vector3(50, 1, 161),
new Vector3(50, 1, 162),
new Vector3(50, 1, 163),
new Vector3(50, 1, 164),
new Vector3(51, 1, 160),
new Vector3(51, 1, 161),
new Vector3(51, 1, 162),
new Vector3(51, 1, 163),
new Vector3(51, 1, 164),
new Vector3(52, 1, 160),
new Vector3(52, 1, 161),
new Vector3(52, 1, 162),
new Vector3(52, 1, 163),
new Vector3(52, 1, 164),
new Vector3(53, 1, 160),
new Vector3(53, 1, 161),
new Vector3(53, 1, 162),
new Vector3(53, 1, 163),
new Vector3(53, 1, 164),
new Vector3(54, 1, 160),
new Vector3(54, 1, 161),
new Vector3(54, 1, 162),
new Vector3(54, 1, 163),
new Vector3(54, 1, 164),
new Vector3(49, 1, 132),
new Vector3(49, 1, 133),
new Vector3(49, 1, 134),
new Vector3(49, 1, 135),
new Vector3(49, 1, 136),
new Vector3(50, 1, 132),
new Vector3(50, 1, 133),
new Vector3(50, 1, 134),
new Vector3(50, 1, 135),
new Vector3(50, 1, 136),
new Vector3(51, 1, 132),
new Vector3(51, 1, 133),
new Vector3(51, 1, 134),
new Vector3(51, 1, 135),
new Vector3(51, 1, 136),
new Vector3(52, 1, 132),
new Vector3(52, 1, 133),
new Vector3(52, 1, 134),
new Vector3(52, 1, 135),
new Vector3(52, 1, 136),
new Vector3(53, 1, 132),
new Vector3(53, 1, 133),
new Vector3(53, 1, 134),
new Vector3(53, 1, 135),
new Vector3(53, 1, 136),
new Vector3(50, 1, 167),
new Vector3(50, 1, 168),
new Vector3(50, 1, 169),
new Vector3(50, 1, 170),
new Vector3(50, 1, 171),
new Vector3(51, 1, 167),
new Vector3(51, 1, 168),
new Vector3(51, 1, 169),
new Vector3(51, 1, 170),
new Vector3(51, 1, 171),
new Vector3(52, 1, 167),
new Vector3(52, 1, 168),
new Vector3(52, 1, 169),
new Vector3(52, 1, 170),
new Vector3(52, 1, 171),
new Vector3(53, 1, 167),
new Vector3(53, 1, 168),
new Vector3(53, 1, 169),
new Vector3(53, 1, 170),
new Vector3(53, 1, 171),
new Vector3(54, 1, 167),
new Vector3(54, 1, 168),
new Vector3(54, 1, 169),
new Vector3(54, 1, 170),
new Vector3(54, 1, 171),
new Vector3(50, 1, 149),
new Vector3(50, 1, 150),
new Vector3(50, 1, 151),
new Vector3(50, 1, 152),
new Vector3(50, 1, 153),
new Vector3(51, 1, 149),
new Vector3(51, 1, 150),
new Vector3(51, 1, 151),
new Vector3(51, 1, 152),
new Vector3(51, 1, 153),
new Vector3(52, 1, 149),
new Vector3(52, 1, 150),
new Vector3(52, 1, 151),
new Vector3(52, 1, 152),
new Vector3(52, 1, 153),
new Vector3(53, 1, 149),
new Vector3(53, 1, 150),
new Vector3(53, 1, 151),
new Vector3(53, 1, 152),
new Vector3(53, 1, 153),
new Vector3(54, 1, 149),
new Vector3(54, 1, 150),
new Vector3(54, 1, 151),
new Vector3(54, 1, 152),
new Vector3(54, 1, 153),
new Vector3(276, 4, 105),
new Vector3(279, 3.5f, 108),
new Vector3(273, 3.5f, 108),
new Vector3(280, 3.5f, 104),
new Vector3(280, 3.5f, 105),
new Vector3(273, 3.5f, 108),
new Vector3(275, 3, 111),
new Vector3(284, 2.5f, 102),
new Vector3(266, 2, 101),
new Vector3(285, 2, 96),
new Vector3(286, 2, 107),
new Vector3(286, 2, 102),
new Vector3(272, 1.5f, 93),
new Vector3(271, 1.5f, 93),
new Vector3(265, 1.5f, 116),
new Vector3(279, 1.5f, 117),
new Vector3(274, 1.5f, 117),
new Vector3(265, 1.5f, 94),
new Vector3(265, 1.5f, 116),
new Vector3(275, 1.5f, 117),
new Vector3(260, 1, 108),
new Vector3(260, 1, 109),
new Vector3(260, 1, 110),
new Vector3(260, 1, 111),
new Vector3(260, 1, 112),
new Vector3(261, 1, 108),
new Vector3(261, 1, 109),
new Vector3(261, 1, 110),
new Vector3(261, 1, 111),
new Vector3(261, 1, 112),
new Vector3(262, 1, 108),
new Vector3(262, 1, 109),
new Vector3(262, 1, 110),
new Vector3(262, 1, 111),
new Vector3(262, 1, 112),
new Vector3(263, 1, 108),
new Vector3(263, 1, 109),
new Vector3(263, 1, 110),
new Vector3(263, 1, 111),
new Vector3(263, 1, 112),
new Vector3(264, 1, 108),
new Vector3(264, 1, 109),
new Vector3(264, 1, 110),
new Vector3(264, 1, 111),
new Vector3(264, 1, 112),
new Vector3(278, 1, 117),
new Vector3(278, 1, 118),
new Vector3(278, 1, 119),
new Vector3(278, 1, 120),
new Vector3(278, 1, 121),
new Vector3(279, 1, 117),
new Vector3(279, 1, 118),
new Vector3(279, 1, 119),
new Vector3(279, 1, 120),
new Vector3(279, 1, 121),
new Vector3(280, 1, 117),
new Vector3(280, 1, 118),
new Vector3(280, 1, 119),
new Vector3(280, 1, 120),
new Vector3(280, 1, 121),
new Vector3(281, 1, 117),
new Vector3(281, 1, 118),
new Vector3(281, 1, 119),
new Vector3(281, 1, 120),
new Vector3(281, 1, 121),
new Vector3(282, 1, 117),
new Vector3(282, 1, 118),
new Vector3(282, 1, 119),
new Vector3(282, 1, 120),
new Vector3(282, 1, 121),
new Vector3(261, 1, 90),
new Vector3(261, 1, 91),
new Vector3(261, 1, 92),
new Vector3(261, 1, 93),
new Vector3(261, 1, 94),
new Vector3(262, 1, 90),
new Vector3(262, 1, 91),
new Vector3(262, 1, 92),
new Vector3(262, 1, 93),
new Vector3(262, 1, 94),
new Vector3(263, 1, 90),
new Vector3(263, 1, 91),
new Vector3(263, 1, 92),
new Vector3(263, 1, 93),
new Vector3(263, 1, 94),
new Vector3(264, 1, 90),
new Vector3(264, 1, 91),
new Vector3(264, 1, 92),
new Vector3(264, 1, 93),
new Vector3(264, 1, 94),
new Vector3(265, 1, 90),
new Vector3(265, 1, 91),
new Vector3(265, 1, 92),
new Vector3(265, 1, 93),
new Vector3(265, 1, 94),
new Vector3(261, 1, 90),
new Vector3(261, 1, 91),
new Vector3(261, 1, 92),
new Vector3(261, 1, 93),
new Vector3(261, 1, 94),
new Vector3(262, 1, 90),
new Vector3(262, 1, 91),
new Vector3(262, 1, 92),
new Vector3(262, 1, 93),
new Vector3(262, 1, 94),
new Vector3(263, 1, 90),
new Vector3(263, 1, 91),
new Vector3(263, 1, 92),
new Vector3(263, 1, 93),
new Vector3(263, 1, 94),
new Vector3(264, 1, 90),
new Vector3(264, 1, 91),
new Vector3(264, 1, 92),
new Vector3(264, 1, 93),
new Vector3(264, 1, 94),
new Vector3(265, 1, 90),
new Vector3(265, 1, 91),
new Vector3(265, 1, 92),
new Vector3(265, 1, 93),
new Vector3(265, 1, 94),
new Vector3(271, 1, 89),
new Vector3(271, 1, 90),
new Vector3(271, 1, 91),
new Vector3(271, 1, 92),
new Vector3(271, 1, 93),
new Vector3(272, 1, 89),
new Vector3(272, 1, 90),
new Vector3(272, 1, 91),
new Vector3(272, 1, 92),
new Vector3(272, 1, 93),
new Vector3(273, 1, 89),
new Vector3(273, 1, 90),
new Vector3(273, 1, 91),
new Vector3(273, 1, 92),
new Vector3(273, 1, 93),
new Vector3(274, 1, 89),
new Vector3(274, 1, 90),
new Vector3(274, 1, 91),
new Vector3(274, 1, 92),
new Vector3(274, 1, 93),
new Vector3(275, 1, 89),
new Vector3(275, 1, 90),
new Vector3(275, 1, 91),
new Vector3(275, 1, 92),
new Vector3(275, 1, 93),
new Vector3(288, 1, 97),
new Vector3(288, 1, 98),
new Vector3(288, 1, 99),
new Vector3(288, 1, 100),
new Vector3(288, 1, 101),
new Vector3(289, 1, 97),
new Vector3(289, 1, 98),
new Vector3(289, 1, 99),
new Vector3(289, 1, 100),
new Vector3(289, 1, 101),
new Vector3(290, 1, 97),
new Vector3(290, 1, 98),
new Vector3(290, 1, 99),
new Vector3(290, 1, 100),
new Vector3(290, 1, 101),
new Vector3(291, 1, 97),
new Vector3(291, 1, 98),
new Vector3(291, 1, 99),
new Vector3(291, 1, 100),
new Vector3(291, 1, 101),
new Vector3(292, 1, 97),
new Vector3(292, 1, 98),
new Vector3(292, 1, 99),
new Vector3(292, 1, 100),
new Vector3(292, 1, 101),
new Vector3(261, 1, 90),
new Vector3(261, 1, 91),
new Vector3(261, 1, 92),
new Vector3(261, 1, 93),
new Vector3(261, 1, 94),
new Vector3(262, 1, 90),
new Vector3(262, 1, 91),
new Vector3(262, 1, 92),
new Vector3(262, 1, 93),
new Vector3(262, 1, 94),
new Vector3(263, 1, 90),
new Vector3(263, 1, 91),
new Vector3(263, 1, 92),
new Vector3(263, 1, 93),
new Vector3(263, 1, 94),
new Vector3(264, 1, 90),
new Vector3(264, 1, 91),
new Vector3(264, 1, 92),
new Vector3(264, 1, 93),
new Vector3(264, 1, 94),
new Vector3(265, 1, 90),
new Vector3(265, 1, 91),
new Vector3(265, 1, 92),
new Vector3(265, 1, 93),
new Vector3(265, 1, 94),
new Vector3(287, 1, 116),
new Vector3(287, 1, 117),
new Vector3(287, 1, 118),
new Vector3(287, 1, 119),
new Vector3(287, 1, 120),
new Vector3(288, 1, 116),
new Vector3(288, 1, 117),
new Vector3(288, 1, 118),
new Vector3(288, 1, 119),
new Vector3(288, 1, 120),
new Vector3(289, 1, 116),
new Vector3(289, 1, 117),
new Vector3(289, 1, 118),
new Vector3(289, 1, 119),
new Vector3(289, 1, 120),
new Vector3(290, 1, 116),
new Vector3(290, 1, 117),
new Vector3(290, 1, 118),
new Vector3(290, 1, 119),
new Vector3(290, 1, 120),
new Vector3(291, 1, 116),
new Vector3(291, 1, 117),
new Vector3(291, 1, 118),
new Vector3(291, 1, 119),
new Vector3(291, 1, 120),
new Vector3(287, 1, 90),
new Vector3(287, 1, 91),
new Vector3(287, 1, 92),
new Vector3(287, 1, 93),
new Vector3(287, 1, 94),
new Vector3(288, 1, 90),
new Vector3(288, 1, 91),
new Vector3(288, 1, 92),
new Vector3(288, 1, 93),
new Vector3(288, 1, 94),
new Vector3(289, 1, 90),
new Vector3(289, 1, 91),
new Vector3(289, 1, 92),
new Vector3(289, 1, 93),
new Vector3(289, 1, 94),
new Vector3(290, 1, 90),
new Vector3(290, 1, 91),
new Vector3(290, 1, 92),
new Vector3(290, 1, 93),
new Vector3(290, 1, 94),
new Vector3(291, 1, 90),
new Vector3(291, 1, 91),
new Vector3(291, 1, 92),
new Vector3(291, 1, 93),
new Vector3(291, 1, 94),
new Vector3(106, 4, 108),
new Vector3(105, 3.5f, 112),
new Vector3(102, 3.5f, 108),
new Vector3(109, 3.5f, 105),
new Vector3(103, 3.5f, 111),
new Vector3(101, 3, 113),
new Vector3(101, 3, 113),
new Vector3(112, 3, 108),
new Vector3(107, 3, 102),
new Vector3(114, 2.5f, 105),
new Vector3(98, 2.5f, 107),
new Vector3(106, 2, 118),
new Vector3(97, 2, 117),
new Vector3(97, 2, 99),
new Vector3(106, 1.5f, 120),
new Vector3(94, 1.5f, 106),
new Vector3(117, 1.5f, 97),
new Vector3(98, 1, 92),
new Vector3(98, 1, 93),
new Vector3(98, 1, 94),
new Vector3(98, 1, 95),
new Vector3(98, 1, 96),
new Vector3(99, 1, 92),
new Vector3(99, 1, 93),
new Vector3(99, 1, 94),
new Vector3(99, 1, 95),
new Vector3(99, 1, 96),
new Vector3(100, 1, 92),
new Vector3(100, 1, 93),
new Vector3(100, 1, 94),
new Vector3(100, 1, 95),
new Vector3(100, 1, 96),
new Vector3(101, 1, 92),
new Vector3(101, 1, 93),
new Vector3(101, 1, 94),
new Vector3(101, 1, 95),
new Vector3(101, 1, 96),
new Vector3(102, 1, 92),
new Vector3(102, 1, 93),
new Vector3(102, 1, 94),
new Vector3(102, 1, 95),
new Vector3(102, 1, 96),
new Vector3(117, 1, 93),
new Vector3(117, 1, 94),
new Vector3(117, 1, 95),
new Vector3(117, 1, 96),
new Vector3(117, 1, 97),
new Vector3(118, 1, 93),
new Vector3(118, 1, 94),
new Vector3(118, 1, 95),
new Vector3(118, 1, 96),
new Vector3(118, 1, 97),
new Vector3(119, 1, 93),
new Vector3(119, 1, 94),
new Vector3(119, 1, 95),
new Vector3(119, 1, 96),
new Vector3(119, 1, 97),
new Vector3(120, 1, 93),
new Vector3(120, 1, 94),
new Vector3(120, 1, 95),
new Vector3(120, 1, 96),
new Vector3(120, 1, 97),
new Vector3(121, 1, 93),
new Vector3(121, 1, 94),
new Vector3(121, 1, 95),
new Vector3(121, 1, 96),
new Vector3(121, 1, 97),
new Vector3(103, 1, 92),
new Vector3(103, 1, 93),
new Vector3(103, 1, 94),
new Vector3(103, 1, 95),
new Vector3(103, 1, 96),
new Vector3(104, 1, 92),
new Vector3(104, 1, 93),
new Vector3(104, 1, 94),
new Vector3(104, 1, 95),
new Vector3(104, 1, 96),
new Vector3(105, 1, 92),
new Vector3(105, 1, 93),
new Vector3(105, 1, 94),
new Vector3(105, 1, 95),
new Vector3(105, 1, 96),
new Vector3(106, 1, 92),
new Vector3(106, 1, 93),
new Vector3(106, 1, 94),
new Vector3(106, 1, 95),
new Vector3(106, 1, 96),
new Vector3(107, 1, 92),
new Vector3(107, 1, 93),
new Vector3(107, 1, 94),
new Vector3(107, 1, 95),
new Vector3(107, 1, 96),
new Vector3(80, 4, 258),
new Vector3(79, 3.5f, 262),
new Vector3(79, 3.5f, 262),
new Vector3(79, 3.5f, 262),
new Vector3(85, 3, 263),
new Vector3(74, 3, 256),
new Vector3(75, 3, 263),
new Vector3(85, 3, 253),
new Vector3(86, 3, 259),
new Vector3(82, 2.5f, 250),
new Vector3(78, 2.5f, 266),
new Vector3(87, 2.5f, 265),
new Vector3(88, 2.5f, 259),
new Vector3(87, 2.5f, 251),
new Vector3(88, 2.5f, 258),
new Vector3(80, 2.5f, 266),
new Vector3(90, 2, 260),
new Vector3(75, 1.5f, 270),
new Vector3(69, 1.5f, 269),
new Vector3(64, 1, 258),
new Vector3(64, 1, 259),
new Vector3(64, 1, 260),
new Vector3(64, 1, 261),
new Vector3(64, 1, 262),
new Vector3(65, 1, 258),
new Vector3(65, 1, 259),
new Vector3(65, 1, 260),
new Vector3(65, 1, 261),
new Vector3(65, 1, 262),
new Vector3(66, 1, 258),
new Vector3(66, 1, 259),
new Vector3(66, 1, 260),
new Vector3(66, 1, 261),
new Vector3(66, 1, 262),
new Vector3(67, 1, 258),
new Vector3(67, 1, 259),
new Vector3(67, 1, 260),
new Vector3(67, 1, 261),
new Vector3(67, 1, 262),
new Vector3(68, 1, 258),
new Vector3(68, 1, 259),
new Vector3(68, 1, 260),
new Vector3(68, 1, 261),
new Vector3(68, 1, 262),
new Vector3(75, 1, 270),
new Vector3(75, 1, 271),
new Vector3(75, 1, 272),
new Vector3(75, 1, 273),
new Vector3(75, 1, 274),
new Vector3(76, 1, 270),
new Vector3(76, 1, 271),
new Vector3(76, 1, 272),
new Vector3(76, 1, 273),
new Vector3(76, 1, 274),
new Vector3(77, 1, 270),
new Vector3(77, 1, 271),
new Vector3(77, 1, 272),
new Vector3(77, 1, 273),
new Vector3(77, 1, 274),
new Vector3(78, 1, 270),
new Vector3(78, 1, 271),
new Vector3(78, 1, 272),
new Vector3(78, 1, 273),
new Vector3(78, 1, 274),
new Vector3(79, 1, 270),
new Vector3(79, 1, 271),
new Vector3(79, 1, 272),
new Vector3(79, 1, 273),
new Vector3(79, 1, 274),
new Vector3(92, 1, 252),
new Vector3(92, 1, 253),
new Vector3(92, 1, 254),
new Vector3(92, 1, 255),
new Vector3(92, 1, 256),
new Vector3(93, 1, 252),
new Vector3(93, 1, 253),
new Vector3(93, 1, 254),
new Vector3(93, 1, 255),
new Vector3(93, 1, 256),
new Vector3(94, 1, 252),
new Vector3(94, 1, 253),
new Vector3(94, 1, 254),
new Vector3(94, 1, 255),
new Vector3(94, 1, 256),
new Vector3(95, 1, 252),
new Vector3(95, 1, 253),
new Vector3(95, 1, 254),
new Vector3(95, 1, 255),
new Vector3(95, 1, 256),
new Vector3(96, 1, 252),
new Vector3(96, 1, 253),
new Vector3(96, 1, 254),
new Vector3(96, 1, 255),
new Vector3(96, 1, 256),
new Vector3(91, 1, 243),
new Vector3(91, 1, 244),
new Vector3(91, 1, 245),
new Vector3(91, 1, 246),
new Vector3(91, 1, 247),
new Vector3(92, 1, 243),
new Vector3(92, 1, 244),
new Vector3(92, 1, 245),
new Vector3(92, 1, 246),
new Vector3(92, 1, 247),
new Vector3(93, 1, 243),
new Vector3(93, 1, 244),
new Vector3(93, 1, 245),
new Vector3(93, 1, 246),
new Vector3(93, 1, 247),
new Vector3(94, 1, 243),
new Vector3(94, 1, 244),
new Vector3(94, 1, 245),
new Vector3(94, 1, 246),
new Vector3(94, 1, 247),
new Vector3(95, 1, 243),
new Vector3(95, 1, 244),
new Vector3(95, 1, 245),
new Vector3(95, 1, 246),
new Vector3(95, 1, 247),
new Vector3(64, 1, 255),
new Vector3(64, 1, 256),
new Vector3(64, 1, 257),
new Vector3(64, 1, 258),
new Vector3(64, 1, 259),
new Vector3(65, 1, 255),
new Vector3(65, 1, 256),
new Vector3(65, 1, 257),
new Vector3(65, 1, 258),
new Vector3(65, 1, 259),
new Vector3(66, 1, 255),
new Vector3(66, 1, 256),
new Vector3(66, 1, 257),
new Vector3(66, 1, 258),
new Vector3(66, 1, 259),
new Vector3(67, 1, 255),
new Vector3(67, 1, 256),
new Vector3(67, 1, 257),
new Vector3(67, 1, 258),
new Vector3(67, 1, 259),
new Vector3(68, 1, 255),
new Vector3(68, 1, 256),
new Vector3(68, 1, 257),
new Vector3(68, 1, 258),
new Vector3(68, 1, 259),
new Vector3(64, 1, 254),
new Vector3(64, 1, 255),
new Vector3(64, 1, 256),
new Vector3(64, 1, 257),
new Vector3(64, 1, 258),
new Vector3(65, 1, 254),
new Vector3(65, 1, 255),
new Vector3(65, 1, 256),
new Vector3(65, 1, 257),
new Vector3(65, 1, 258),
new Vector3(66, 1, 254),
new Vector3(66, 1, 255),
new Vector3(66, 1, 256),
new Vector3(66, 1, 257),
new Vector3(66, 1, 258),
new Vector3(67, 1, 254),
new Vector3(67, 1, 255),
new Vector3(67, 1, 256),
new Vector3(67, 1, 257),
new Vector3(67, 1, 258),
new Vector3(68, 1, 254),
new Vector3(68, 1, 255),
new Vector3(68, 1, 256),
new Vector3(68, 1, 257),
new Vector3(68, 1, 258),
new Vector3(77, 1, 242),
new Vector3(77, 1, 243),
new Vector3(77, 1, 244),
new Vector3(77, 1, 245),
new Vector3(77, 1, 246),
new Vector3(78, 1, 242),
new Vector3(78, 1, 243),
new Vector3(78, 1, 244),
new Vector3(78, 1, 245),
new Vector3(78, 1, 246),
new Vector3(79, 1, 242),
new Vector3(79, 1, 243),
new Vector3(79, 1, 244),
new Vector3(79, 1, 245),
new Vector3(79, 1, 246),
new Vector3(80, 1, 242),
new Vector3(80, 1, 243),
new Vector3(80, 1, 244),
new Vector3(80, 1, 245),
new Vector3(80, 1, 246),
new Vector3(81, 1, 242),
new Vector3(81, 1, 243),
new Vector3(81, 1, 244),
new Vector3(81, 1, 245),
new Vector3(81, 1, 246),
new Vector3(91, 1, 243),
new Vector3(91, 1, 244),
new Vector3(91, 1, 245),
new Vector3(91, 1, 246),
new Vector3(91, 1, 247),
new Vector3(92, 1, 243),
new Vector3(92, 1, 244),
new Vector3(92, 1, 245),
new Vector3(92, 1, 246),
new Vector3(92, 1, 247),
new Vector3(93, 1, 243),
new Vector3(93, 1, 244),
new Vector3(93, 1, 245),
new Vector3(93, 1, 246),
new Vector3(93, 1, 247),
new Vector3(94, 1, 243),
new Vector3(94, 1, 244),
new Vector3(94, 1, 245),
new Vector3(94, 1, 246),
new Vector3(94, 1, 247),
new Vector3(95, 1, 243),
new Vector3(95, 1, 244),
new Vector3(95, 1, 245),
new Vector3(95, 1, 246),
new Vector3(95, 1, 247),
new Vector3(144, 6, 59),
new Vector3(143, 5.5f, 63),
new Vector3(147, 5.5f, 56),
new Vector3(140, 5.5f, 58),
new Vector3(149, 5, 64),
new Vector3(138, 5, 58),
new Vector3(149, 5, 64),
new Vector3(138, 5, 59),
new Vector3(139, 5, 54),
new Vector3(144, 4.5f, 51),
new Vector3(137, 4.5f, 52),
new Vector3(152, 4.5f, 58),
new Vector3(143, 4.5f, 51),
new Vector3(154, 4, 61),
new Vector3(156, 3.5f, 60),
new Vector3(133, 3.5f, 70),
new Vector3(155, 3.5f, 70),
new Vector3(133, 3.5f, 48),
new Vector3(130, 3, 54),
new Vector3(158, 3, 54),
new Vector3(131, 3, 72),
new Vector3(158, 3, 58),
new Vector3(131, 3, 72),
new Vector3(157, 3, 46),
new Vector3(145, 2.5f, 43),
new Vector3(160, 2.5f, 65),
new Vector3(159, 2.5f, 44),
new Vector3(145, 2.5f, 75),
new Vector3(160, 2.5f, 59),
new Vector3(141, 2.5f, 75),
new Vector3(149, 2.5f, 75),
new Vector3(160, 2.5f, 57),
new Vector3(162, 2, 64),
new Vector3(125, 1.5f, 78),
new Vector3(164, 1.5f, 54),
new Vector3(139, 1.5f, 79),
new Vector3(164, 1.5f, 64),
new Vector3(139, 1.5f, 79),
new Vector3(163, 1.5f, 78),
new Vector3(163, 1.5f, 40),
new Vector3(125, 1.5f, 78),
new Vector3(125, 1.5f, 40),
new Vector3(125, 1.5f, 40),
new Vector3(163, 1.5f, 40),
new Vector3(145, 1.5f, 79),
new Vector3(125, 1.5f, 78),
new Vector3(121, 1, 78),
new Vector3(121, 1, 79),
new Vector3(121, 1, 80),
new Vector3(121, 1, 81),
new Vector3(121, 1, 82),
new Vector3(122, 1, 78),
new Vector3(122, 1, 79),
new Vector3(122, 1, 80),
new Vector3(122, 1, 81),
new Vector3(122, 1, 82),
new Vector3(123, 1, 78),
new Vector3(123, 1, 79),
new Vector3(123, 1, 80),
new Vector3(123, 1, 81),
new Vector3(123, 1, 82),
new Vector3(124, 1, 78),
new Vector3(124, 1, 79),
new Vector3(124, 1, 80),
new Vector3(124, 1, 81),
new Vector3(124, 1, 82),
new Vector3(125, 1, 78),
new Vector3(125, 1, 79),
new Vector3(125, 1, 80),
new Vector3(125, 1, 81),
new Vector3(125, 1, 82),
new Vector3(163, 1, 78),
new Vector3(163, 1, 79),
new Vector3(163, 1, 80),
new Vector3(163, 1, 81),
new Vector3(163, 1, 82),
new Vector3(164, 1, 78),
new Vector3(164, 1, 79),
new Vector3(164, 1, 80),
new Vector3(164, 1, 81),
new Vector3(164, 1, 82),
new Vector3(165, 1, 78),
new Vector3(165, 1, 79),
new Vector3(165, 1, 80),
new Vector3(165, 1, 81),
new Vector3(165, 1, 82),
new Vector3(166, 1, 78),
new Vector3(166, 1, 79),
new Vector3(166, 1, 80),
new Vector3(166, 1, 81),
new Vector3(166, 1, 82),
new Vector3(167, 1, 78),
new Vector3(167, 1, 79),
new Vector3(167, 1, 80),
new Vector3(167, 1, 81),
new Vector3(167, 1, 82),
new Vector3(121, 1, 36),
new Vector3(121, 1, 37),
new Vector3(121, 1, 38),
new Vector3(121, 1, 39),
new Vector3(121, 1, 40),
new Vector3(122, 1, 36),
new Vector3(122, 1, 37),
new Vector3(122, 1, 38),
new Vector3(122, 1, 39),
new Vector3(122, 1, 40),
new Vector3(123, 1, 36),
new Vector3(123, 1, 37),
new Vector3(123, 1, 38),
new Vector3(123, 1, 39),
new Vector3(123, 1, 40),
new Vector3(124, 1, 36),
new Vector3(124, 1, 37),
new Vector3(124, 1, 38),
new Vector3(124, 1, 39),
new Vector3(124, 1, 40),
new Vector3(125, 1, 36),
new Vector3(125, 1, 37),
new Vector3(125, 1, 38),
new Vector3(125, 1, 39),
new Vector3(125, 1, 40),
new Vector3(164, 1, 55),
new Vector3(164, 1, 56),
new Vector3(164, 1, 57),
new Vector3(164, 1, 58),
new Vector3(164, 1, 59),
new Vector3(165, 1, 55),
new Vector3(165, 1, 56),
new Vector3(165, 1, 57),
new Vector3(165, 1, 58),
new Vector3(165, 1, 59),
new Vector3(166, 1, 55),
new Vector3(166, 1, 56),
new Vector3(166, 1, 57),
new Vector3(166, 1, 58),
new Vector3(166, 1, 59),
new Vector3(167, 1, 55),
new Vector3(167, 1, 56),
new Vector3(167, 1, 57),
new Vector3(167, 1, 58),
new Vector3(167, 1, 59),
new Vector3(168, 1, 55),
new Vector3(168, 1, 56),
new Vector3(168, 1, 57),
new Vector3(168, 1, 58),
new Vector3(168, 1, 59),
new Vector3(163, 1, 36),
new Vector3(163, 1, 37),
new Vector3(163, 1, 38),
new Vector3(163, 1, 39),
new Vector3(163, 1, 40),
new Vector3(164, 1, 36),
new Vector3(164, 1, 37),
new Vector3(164, 1, 38),
new Vector3(164, 1, 39),
new Vector3(164, 1, 40),
new Vector3(165, 1, 36),
new Vector3(165, 1, 37),
new Vector3(165, 1, 38),
new Vector3(165, 1, 39),
new Vector3(165, 1, 40),
new Vector3(166, 1, 36),
new Vector3(166, 1, 37),
new Vector3(166, 1, 38),
new Vector3(166, 1, 39),
new Vector3(166, 1, 40),
new Vector3(167, 1, 36),
new Vector3(167, 1, 37),
new Vector3(167, 1, 38),
new Vector3(167, 1, 39),
new Vector3(167, 1, 40),
new Vector3(279, 4, 92),
new Vector3(279, 3.5f, 88),
new Vector3(275, 3.5f, 91),
new Vector3(285, 3, 93),
new Vector3(278, 3, 86),
new Vector3(273, 3, 90),
new Vector3(273, 3, 90),
new Vector3(279, 2.5f, 100),
new Vector3(286, 2.5f, 85),
new Vector3(287, 2.5f, 90),
new Vector3(271, 2.5f, 93),
new Vector3(271, 2.5f, 93),
new Vector3(281, 2.5f, 100),
new Vector3(270, 2, 83),
new Vector3(288, 2, 83),
new Vector3(270, 2, 83),
new Vector3(278, 2, 82),
new Vector3(281, 2, 102),
new Vector3(267, 1.5f, 90),
new Vector3(267, 1.5f, 89),
new Vector3(267, 1.5f, 96),
new Vector3(268, 1.5f, 103),
new Vector3(290, 1, 103),
new Vector3(290, 1, 104),
new Vector3(290, 1, 105),
new Vector3(290, 1, 106),
new Vector3(290, 1, 107),
new Vector3(291, 1, 103),
new Vector3(291, 1, 104),
new Vector3(291, 1, 105),
new Vector3(291, 1, 106),
new Vector3(291, 1, 107),
new Vector3(292, 1, 103),
new Vector3(292, 1, 104),
new Vector3(292, 1, 105),
new Vector3(292, 1, 106),
new Vector3(292, 1, 107),
new Vector3(293, 1, 103),
new Vector3(293, 1, 104),
new Vector3(293, 1, 105),
new Vector3(293, 1, 106),
new Vector3(293, 1, 107),
new Vector3(294, 1, 103),
new Vector3(294, 1, 104),
new Vector3(294, 1, 105),
new Vector3(294, 1, 106),
new Vector3(294, 1, 107),
new Vector3(282, 1, 104),
new Vector3(282, 1, 105),
new Vector3(282, 1, 106),
new Vector3(282, 1, 107),
new Vector3(282, 1, 108),
new Vector3(283, 1, 104),
new Vector3(283, 1, 105),
new Vector3(283, 1, 106),
new Vector3(283, 1, 107),
new Vector3(283, 1, 108),
new Vector3(284, 1, 104),
new Vector3(284, 1, 105),
new Vector3(284, 1, 106),
new Vector3(284, 1, 107),
new Vector3(284, 1, 108),
new Vector3(285, 1, 104),
new Vector3(285, 1, 105),
new Vector3(285, 1, 106),
new Vector3(285, 1, 107),
new Vector3(285, 1, 108),
new Vector3(286, 1, 104),
new Vector3(286, 1, 105),
new Vector3(286, 1, 106),
new Vector3(286, 1, 107),
new Vector3(286, 1, 108),
new Vector3(278, 1, 104),
new Vector3(278, 1, 105),
new Vector3(278, 1, 106),
new Vector3(278, 1, 107),
new Vector3(278, 1, 108),
new Vector3(279, 1, 104),
new Vector3(279, 1, 105),
new Vector3(279, 1, 106),
new Vector3(279, 1, 107),
new Vector3(279, 1, 108),
new Vector3(280, 1, 104),
new Vector3(280, 1, 105),
new Vector3(280, 1, 106),
new Vector3(280, 1, 107),
new Vector3(280, 1, 108),
new Vector3(281, 1, 104),
new Vector3(281, 1, 105),
new Vector3(281, 1, 106),
new Vector3(281, 1, 107),
new Vector3(281, 1, 108),
new Vector3(282, 1, 104),
new Vector3(282, 1, 105),
new Vector3(282, 1, 106),
new Vector3(282, 1, 107),
new Vector3(282, 1, 108),
new Vector3(275, 1, 104),
new Vector3(275, 1, 105),
new Vector3(275, 1, 106),
new Vector3(275, 1, 107),
new Vector3(275, 1, 108),
new Vector3(276, 1, 104),
new Vector3(276, 1, 105),
new Vector3(276, 1, 106),
new Vector3(276, 1, 107),
new Vector3(276, 1, 108),
new Vector3(277, 1, 104),
new Vector3(277, 1, 105),
new Vector3(277, 1, 106),
new Vector3(277, 1, 107),
new Vector3(277, 1, 108),
new Vector3(278, 1, 104),
new Vector3(278, 1, 105),
new Vector3(278, 1, 106),
new Vector3(278, 1, 107),
new Vector3(278, 1, 108),
new Vector3(279, 1, 104),
new Vector3(279, 1, 105),
new Vector3(279, 1, 106),
new Vector3(279, 1, 107),
new Vector3(279, 1, 108),
new Vector3(276, 1, 76),
new Vector3(276, 1, 77),
new Vector3(276, 1, 78),
new Vector3(276, 1, 79),
new Vector3(276, 1, 80),
new Vector3(277, 1, 76),
new Vector3(277, 1, 77),
new Vector3(277, 1, 78),
new Vector3(277, 1, 79),
new Vector3(277, 1, 80),
new Vector3(278, 1, 76),
new Vector3(278, 1, 77),
new Vector3(278, 1, 78),
new Vector3(278, 1, 79),
new Vector3(278, 1, 80),
new Vector3(279, 1, 76),
new Vector3(279, 1, 77),
new Vector3(279, 1, 78),
new Vector3(279, 1, 79),
new Vector3(279, 1, 80),
new Vector3(280, 1, 76),
new Vector3(280, 1, 77),
new Vector3(280, 1, 78),
new Vector3(280, 1, 79),
new Vector3(280, 1, 80),
new Vector3(291, 1, 86),
new Vector3(291, 1, 87),
new Vector3(291, 1, 88),
new Vector3(291, 1, 89),
new Vector3(291, 1, 90),
new Vector3(292, 1, 86),
new Vector3(292, 1, 87),
new Vector3(292, 1, 88),
new Vector3(292, 1, 89),
new Vector3(292, 1, 90),
new Vector3(293, 1, 86),
new Vector3(293, 1, 87),
new Vector3(293, 1, 88),
new Vector3(293, 1, 89),
new Vector3(293, 1, 90),
new Vector3(294, 1, 86),
new Vector3(294, 1, 87),
new Vector3(294, 1, 88),
new Vector3(294, 1, 89),
new Vector3(294, 1, 90),
new Vector3(295, 1, 86),
new Vector3(295, 1, 87),
new Vector3(295, 1, 88),
new Vector3(295, 1, 89),
new Vector3(295, 1, 90),
new Vector3(311, 3, 44),
new Vector3(308, 2.5f, 41),
new Vector3(317, 2, 45),
new Vector3(305, 2, 43),
new Vector3(317, 2, 45),
new Vector3(317, 2, 43),
new Vector3(317, 2, 43),
new Vector3(317, 2, 42),
new Vector3(304, 1.5f, 51),
new Vector3(313, 1.5f, 36),
new Vector3(303, 1.5f, 41),
new Vector3(318, 1.5f, 37),
new Vector3(304, 1.5f, 51),
new Vector3(304, 1.5f, 37),
new Vector3(310, 1, 52),
new Vector3(310, 1, 53),
new Vector3(310, 1, 54),
new Vector3(310, 1, 55),
new Vector3(310, 1, 56),
new Vector3(311, 1, 52),
new Vector3(311, 1, 53),
new Vector3(311, 1, 54),
new Vector3(311, 1, 55),
new Vector3(311, 1, 56),
new Vector3(312, 1, 52),
new Vector3(312, 1, 53),
new Vector3(312, 1, 54),
new Vector3(312, 1, 55),
new Vector3(312, 1, 56),
new Vector3(313, 1, 52),
new Vector3(313, 1, 53),
new Vector3(313, 1, 54),
new Vector3(313, 1, 55),
new Vector3(313, 1, 56),
new Vector3(314, 1, 52),
new Vector3(314, 1, 53),
new Vector3(314, 1, 54),
new Vector3(314, 1, 55),
new Vector3(314, 1, 56),
new Vector3(318, 1, 33),
new Vector3(318, 1, 34),
new Vector3(318, 1, 35),
new Vector3(318, 1, 36),
new Vector3(318, 1, 37),
new Vector3(319, 1, 33),
new Vector3(319, 1, 34),
new Vector3(319, 1, 35),
new Vector3(319, 1, 36),
new Vector3(319, 1, 37),
new Vector3(320, 1, 33),
new Vector3(320, 1, 34),
new Vector3(320, 1, 35),
new Vector3(320, 1, 36),
new Vector3(320, 1, 37),
new Vector3(321, 1, 33),
new Vector3(321, 1, 34),
new Vector3(321, 1, 35),
new Vector3(321, 1, 36),
new Vector3(321, 1, 37),
new Vector3(322, 1, 33),
new Vector3(322, 1, 34),
new Vector3(322, 1, 35),
new Vector3(322, 1, 36),
new Vector3(322, 1, 37),
new Vector3(309, 1, 52),
new Vector3(309, 1, 53),
new Vector3(309, 1, 54),
new Vector3(309, 1, 55),
new Vector3(309, 1, 56),
new Vector3(310, 1, 52),
new Vector3(310, 1, 53),
new Vector3(310, 1, 54),
new Vector3(310, 1, 55),
new Vector3(310, 1, 56),
new Vector3(311, 1, 52),
new Vector3(311, 1, 53),
new Vector3(311, 1, 54),
new Vector3(311, 1, 55),
new Vector3(311, 1, 56),
new Vector3(312, 1, 52),
new Vector3(312, 1, 53),
new Vector3(312, 1, 54),
new Vector3(312, 1, 55),
new Vector3(312, 1, 56),
new Vector3(313, 1, 52),
new Vector3(313, 1, 53),
new Vector3(313, 1, 54),
new Vector3(313, 1, 55),
new Vector3(313, 1, 56),
new Vector3(299, 1, 45),
new Vector3(299, 1, 46),
new Vector3(299, 1, 47),
new Vector3(299, 1, 48),
new Vector3(299, 1, 49),
new Vector3(300, 1, 45),
new Vector3(300, 1, 46),
new Vector3(300, 1, 47),
new Vector3(300, 1, 48),
new Vector3(300, 1, 49),
new Vector3(301, 1, 45),
new Vector3(301, 1, 46),
new Vector3(301, 1, 47),
new Vector3(301, 1, 48),
new Vector3(301, 1, 49),
new Vector3(302, 1, 45),
new Vector3(302, 1, 46),
new Vector3(302, 1, 47),
new Vector3(302, 1, 48),
new Vector3(302, 1, 49),
new Vector3(303, 1, 45),
new Vector3(303, 1, 46),
new Vector3(303, 1, 47),
new Vector3(303, 1, 48),
new Vector3(303, 1, 49),
new Vector3(319, 1, 44),
new Vector3(319, 1, 45),
new Vector3(319, 1, 46),
new Vector3(319, 1, 47),
new Vector3(319, 1, 48),
new Vector3(320, 1, 44),
new Vector3(320, 1, 45),
new Vector3(320, 1, 46),
new Vector3(320, 1, 47),
new Vector3(320, 1, 48),
new Vector3(321, 1, 44),
new Vector3(321, 1, 45),
new Vector3(321, 1, 46),
new Vector3(321, 1, 47),
new Vector3(321, 1, 48),
new Vector3(322, 1, 44),
new Vector3(322, 1, 45),
new Vector3(322, 1, 46),
new Vector3(322, 1, 47),
new Vector3(322, 1, 48),
new Vector3(323, 1, 44),
new Vector3(323, 1, 45),
new Vector3(323, 1, 46),
new Vector3(323, 1, 47),
new Vector3(323, 1, 48),
new Vector3(319, 1, 42),
new Vector3(319, 1, 43),
new Vector3(319, 1, 44),
new Vector3(319, 1, 45),
new Vector3(319, 1, 46),
new Vector3(320, 1, 42),
new Vector3(320, 1, 43),
new Vector3(320, 1, 44),
new Vector3(320, 1, 45),
new Vector3(320, 1, 46),
new Vector3(321, 1, 42),
new Vector3(321, 1, 43),
new Vector3(321, 1, 44),
new Vector3(321, 1, 45),
new Vector3(321, 1, 46),
new Vector3(322, 1, 42),
new Vector3(322, 1, 43),
new Vector3(322, 1, 44),
new Vector3(322, 1, 45),
new Vector3(322, 1, 46),
new Vector3(323, 1, 42),
new Vector3(323, 1, 43),
new Vector3(323, 1, 44),
new Vector3(323, 1, 45),
new Vector3(323, 1, 46),
new Vector3(307, 1, 52),
new Vector3(307, 1, 53),
new Vector3(307, 1, 54),
new Vector3(307, 1, 55),
new Vector3(307, 1, 56),
new Vector3(308, 1, 52),
new Vector3(308, 1, 53),
new Vector3(308, 1, 54),
new Vector3(308, 1, 55),
new Vector3(308, 1, 56),
new Vector3(309, 1, 52),
new Vector3(309, 1, 53),
new Vector3(309, 1, 54),
new Vector3(309, 1, 55),
new Vector3(309, 1, 56),
new Vector3(310, 1, 52),
new Vector3(310, 1, 53),
new Vector3(310, 1, 54),
new Vector3(310, 1, 55),
new Vector3(310, 1, 56),
new Vector3(311, 1, 52),
new Vector3(311, 1, 53),
new Vector3(311, 1, 54),
new Vector3(311, 1, 55),
new Vector3(311, 1, 56),
new Vector3(94, 6, 141),
new Vector3(90, 5.5f, 141),
new Vector3(93, 5.5f, 145),
new Vector3(93, 5.5f, 137),
new Vector3(93, 5.5f, 145),
new Vector3(88, 5, 140),
new Vector3(99, 5, 136),
new Vector3(95, 5, 147),
new Vector3(89, 5, 146),
new Vector3(101, 4.5f, 148),
new Vector3(86, 4.5f, 140),
new Vector3(86, 4.5f, 142),
new Vector3(87, 4.5f, 148),
new Vector3(104, 4, 144),
new Vector3(92, 4, 151),
new Vector3(104, 4, 142),
new Vector3(91, 4, 151),
new Vector3(103, 4, 132),
new Vector3(105, 3.5f, 152),
new Vector3(82, 3.5f, 138),
new Vector3(97, 3.5f, 153),
new Vector3(106, 3.5f, 138),
new Vector3(83, 3.5f, 152),
new Vector3(105, 3.5f, 152),
new Vector3(105, 3.5f, 130),
new Vector3(96, 3, 155),
new Vector3(93, 3, 155),
new Vector3(107, 3, 128),
new Vector3(80, 3, 137),
new Vector3(107, 3, 128),
new Vector3(78, 2.5f, 142),
new Vector3(109, 2.5f, 126),
new Vector3(78, 2.5f, 144),
new Vector3(109, 2.5f, 156),
new Vector3(110, 2.5f, 141),
new Vector3(78, 2.5f, 138),
new Vector3(110, 2.5f, 136),
new Vector3(112, 2, 134),
new Vector3(77, 2, 124),
new Vector3(76, 2, 146),
new Vector3(74, 1.5f, 141),
new Vector3(75, 1.5f, 160),
new Vector3(114, 1.5f, 149),
new Vector3(74, 1.5f, 135),
new Vector3(87, 1.5f, 161),
new Vector3(82, 1, 161),
new Vector3(82, 1, 162),
new Vector3(82, 1, 163),
new Vector3(82, 1, 164),
new Vector3(82, 1, 165),
new Vector3(83, 1, 161),
new Vector3(83, 1, 162),
new Vector3(83, 1, 163),
new Vector3(83, 1, 164),
new Vector3(83, 1, 165),
new Vector3(84, 1, 161),
new Vector3(84, 1, 162),
new Vector3(84, 1, 163),
new Vector3(84, 1, 164),
new Vector3(84, 1, 165),
new Vector3(85, 1, 161),
new Vector3(85, 1, 162),
new Vector3(85, 1, 163),
new Vector3(85, 1, 164),
new Vector3(85, 1, 165),
new Vector3(86, 1, 161),
new Vector3(86, 1, 162),
new Vector3(86, 1, 163),
new Vector3(86, 1, 164),
new Vector3(86, 1, 165),
new Vector3(88, 1, 161),
new Vector3(88, 1, 162),
new Vector3(88, 1, 163),
new Vector3(88, 1, 164),
new Vector3(88, 1, 165),
new Vector3(89, 1, 161),
new Vector3(89, 1, 162),
new Vector3(89, 1, 163),
new Vector3(89, 1, 164),
new Vector3(89, 1, 165),
new Vector3(90, 1, 161),
new Vector3(90, 1, 162),
new Vector3(90, 1, 163),
new Vector3(90, 1, 164),
new Vector3(90, 1, 165),
new Vector3(91, 1, 161),
new Vector3(91, 1, 162),
new Vector3(91, 1, 163),
new Vector3(91, 1, 164),
new Vector3(91, 1, 165),
new Vector3(92, 1, 161),
new Vector3(92, 1, 162),
new Vector3(92, 1, 163),
new Vector3(92, 1, 164),
new Vector3(92, 1, 165),
new Vector3(113, 1, 118),
new Vector3(113, 1, 119),
new Vector3(113, 1, 120),
new Vector3(113, 1, 121),
new Vector3(113, 1, 122),
new Vector3(114, 1, 118),
new Vector3(114, 1, 119),
new Vector3(114, 1, 120),
new Vector3(114, 1, 121),
new Vector3(114, 1, 122),
new Vector3(115, 1, 118),
new Vector3(115, 1, 119),
new Vector3(115, 1, 120),
new Vector3(115, 1, 121),
new Vector3(115, 1, 122),
new Vector3(116, 1, 118),
new Vector3(116, 1, 119),
new Vector3(116, 1, 120),
new Vector3(116, 1, 121),
new Vector3(116, 1, 122),
new Vector3(117, 1, 118),
new Vector3(117, 1, 119),
new Vector3(117, 1, 120),
new Vector3(117, 1, 121),
new Vector3(117, 1, 122),
new Vector3(113, 1, 160),
new Vector3(113, 1, 161),
new Vector3(113, 1, 162),
new Vector3(113, 1, 163),
new Vector3(113, 1, 164),
new Vector3(114, 1, 160),
new Vector3(114, 1, 161),
new Vector3(114, 1, 162),
new Vector3(114, 1, 163),
new Vector3(114, 1, 164),
new Vector3(115, 1, 160),
new Vector3(115, 1, 161),
new Vector3(115, 1, 162),
new Vector3(115, 1, 163),
new Vector3(115, 1, 164),
new Vector3(116, 1, 160),
new Vector3(116, 1, 161),
new Vector3(116, 1, 162),
new Vector3(116, 1, 163),
new Vector3(116, 1, 164),
new Vector3(117, 1, 160),
new Vector3(117, 1, 161),
new Vector3(117, 1, 162),
new Vector3(117, 1, 163),
new Vector3(117, 1, 164),
new Vector3(70, 1, 141),
new Vector3(70, 1, 142),
new Vector3(70, 1, 143),
new Vector3(70, 1, 144),
new Vector3(70, 1, 145),
new Vector3(71, 1, 141),
new Vector3(71, 1, 142),
new Vector3(71, 1, 143),
new Vector3(71, 1, 144),
new Vector3(71, 1, 145),
new Vector3(72, 1, 141),
new Vector3(72, 1, 142),
new Vector3(72, 1, 143),
new Vector3(72, 1, 144),
new Vector3(72, 1, 145),
new Vector3(73, 1, 141),
new Vector3(73, 1, 142),
new Vector3(73, 1, 143),
new Vector3(73, 1, 144),
new Vector3(73, 1, 145),
new Vector3(74, 1, 141),
new Vector3(74, 1, 142),
new Vector3(74, 1, 143),
new Vector3(74, 1, 144),
new Vector3(74, 1, 145),
new Vector3(88, 1, 161),
new Vector3(88, 1, 162),
new Vector3(88, 1, 163),
new Vector3(88, 1, 164),
new Vector3(88, 1, 165),
new Vector3(89, 1, 161),
new Vector3(89, 1, 162),
new Vector3(89, 1, 163),
new Vector3(89, 1, 164),
new Vector3(89, 1, 165),
new Vector3(90, 1, 161),
new Vector3(90, 1, 162),
new Vector3(90, 1, 163),
new Vector3(90, 1, 164),
new Vector3(90, 1, 165),
new Vector3(91, 1, 161),
new Vector3(91, 1, 162),
new Vector3(91, 1, 163),
new Vector3(91, 1, 164),
new Vector3(91, 1, 165),
new Vector3(92, 1, 161),
new Vector3(92, 1, 162),
new Vector3(92, 1, 163),
new Vector3(92, 1, 164),
new Vector3(92, 1, 165),
new Vector3(113, 1, 160),
new Vector3(113, 1, 161),
new Vector3(113, 1, 162),
new Vector3(113, 1, 163),
new Vector3(113, 1, 164),
new Vector3(114, 1, 160),
new Vector3(114, 1, 161),
new Vector3(114, 1, 162),
new Vector3(114, 1, 163),
new Vector3(114, 1, 164),
new Vector3(115, 1, 160),
new Vector3(115, 1, 161),
new Vector3(115, 1, 162),
new Vector3(115, 1, 163),
new Vector3(115, 1, 164),
new Vector3(116, 1, 160),
new Vector3(116, 1, 161),
new Vector3(116, 1, 162),
new Vector3(116, 1, 163),
new Vector3(116, 1, 164),
new Vector3(117, 1, 160),
new Vector3(117, 1, 161),
new Vector3(117, 1, 162),
new Vector3(117, 1, 163),
new Vector3(117, 1, 164),
new Vector3(86, 1, 117),
new Vector3(86, 1, 118),
new Vector3(86, 1, 119),
new Vector3(86, 1, 120),
new Vector3(86, 1, 121),
new Vector3(87, 1, 117),
new Vector3(87, 1, 118),
new Vector3(87, 1, 119),
new Vector3(87, 1, 120),
new Vector3(87, 1, 121),
new Vector3(88, 1, 117),
new Vector3(88, 1, 118),
new Vector3(88, 1, 119),
new Vector3(88, 1, 120),
new Vector3(88, 1, 121),
new Vector3(89, 1, 117),
new Vector3(89, 1, 118),
new Vector3(89, 1, 119),
new Vector3(89, 1, 120),
new Vector3(89, 1, 121),
new Vector3(90, 1, 117),
new Vector3(90, 1, 118),
new Vector3(90, 1, 119),
new Vector3(90, 1, 120),
new Vector3(90, 1, 121)
            };
        }
  
        int k = 0;
        int tope = (int)alturaMaxima * 2;
        while (k < tope)
        {
            if (alturaMaxima == 0.5f)
            {
                if (RecortarBordes == true)
                {
                    RecortarBordes2();                  
                }
                
                if (PonerLlano == true)
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

            GenerarNivel(alturaMaxima, listadoCasillasInicial);
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
                if (terrenos[(int)casillaInicial.x, (int)casillaInicial.z] == null)
                {
                    PonerTerreno(new Terreno(0, 0, casillaInicial));
                    listadoCasillasInicial.Remove(casillaInicial);
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

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarTerreno2(terrenos[x + 2, z], y - 0.5f, 180) == true && ComprobarVacio(terrenos[x, z - 2]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 0) == true)
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
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z - 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 270) == true && ComprobarVacio(terrenos[x + 1, z]) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x, z - 2]) == false)
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

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarRampas(x, z, 2, -2) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarRampas(x, z, 2, -2) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarRampas(x, z, 2, -2) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno3(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z + 2], y - 0.5f, 0) == true)
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
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno2(terrenos[x, z + 2], y - 0.5f, 90) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x + 1, z]) == false)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarVacio(terrenos[x, z + 2]) == false)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == true)
        {
            PonerTerreno(esquina3rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
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

        //---------------------------------------

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarRampas(x, z, 2, 2) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarRampas(x, z, 2, 2) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarRampas(x, z, 2, 2) == true)
        {
            PonerTerreno(rampas4rotacion90);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarRampas(x, z, 2, 2) == true)
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

        if (Colores == false)
        {
            id = CalcularID(id);
        }

        int x = (int)terreno.posicion.x;
        int z = (int)terreno.posicion.z;

        if (terrenos[x, z] == null)
        {
            Terreno terreno2 = Instantiate(casillas[id], terreno.posicion, Quaternion.identity);
            terreno2.gameObject.transform.Rotate(Vector3.up, terreno.rotacion, Space.World);
            terreno2.rotacion = terreno.rotacion;
            terreno2.posicion = terreno.posicion;
            
            terrenos[x, z] = terreno2;
        }       
    }

    private int CalcularID(int id)
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

    private bool ComprobarRampas(int x, int z, int xUbicacion, int zUbicacion)
    {
        if (ComprobarVacio(terrenos[x + (xUbicacion / 2), z]) == true && ComprobarVacio(terrenos[x + xUbicacion, z]) == true && ComprobarVacio(terrenos[x + xUbicacion, z + (zUbicacion / 2)]) == true && ComprobarVacio(terrenos[x + (xUbicacion / 2), z + (zUbicacion / 2)]) == true)
        {
            if (ComprobarVacio(terrenos[x, z + (zUbicacion / 2)]) == true && ComprobarVacio(terrenos[x, z + zUbicacion]) == true && ComprobarVacio(terrenos[x + (xUbicacion / 2), z + zUbicacion]) == true && ComprobarVacio(terrenos[x + (xUbicacion / 2), z + (zUbicacion / 2)]) == true)
            {
                return true;
            }
        }

        return false;
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

    private void RecortarBordes2()
    {
        foreach (Terreno casilla in terrenos)
        {
            if (casilla != null)
            {
                if (casilla.posicion.x < limitesMapa || casilla.posicion.z < limitesMapa || casilla.posicion.x > arranque.tamañoEscenarioX - limitesMapa || casilla.posicion.z > arranque.tamañoEscenarioZ - limitesMapa)
                {
                    terrenos[(int)casilla.posicion.x, (int)casilla.posicion.z] = null;
                    Destroy(casilla.gameObject);
                }
            }
        }
    }
}
