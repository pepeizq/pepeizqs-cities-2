using Juego;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Escenario : MonoBehaviour
{
    public Arranque arranque;

    public Terreno[] casillas;

    [HideInInspector]
    public Terreno[,] terrenos = new Terreno[1, 1];

    public KeyCode teclaGenerarNivel;

    private float alturaNivel = 8;
    private List<Terreno> listadoCasillas;
    private List<Terreno> listadoCasillasTemporal;

    public void Start()
    {
        terrenos = new Terreno[arranque.tamañoEscenarioX, arranque.tamañoEscenarioZ];

        bool aleatorio = false;

        if (aleatorio == true)
        {
            GUIUtility.systemCopyBuffer = null;

            listadoCasillas = new List<Terreno>();

            int montañasGenerar = (int)arranque.tamañoEscenarioX / 100 * (int)arranque.tamañoEscenarioZ / 100;
            int intentosGeneracion = montañasGenerar * 2;

            int i = 1;
            while (i <= montañasGenerar)
            {
                float alturaCasilla = (int)Random.Range(3, alturaNivel);
             
                int posicionX = (int)Random.Range(0 + alturaCasilla, (int)arranque.tamañoEscenarioX - alturaCasilla);
                int posicionZ = (int)Random.Range(0 + alturaCasilla, (int)arranque.tamañoEscenarioZ - alturaCasilla);

                bool añadir = true;

                foreach (Terreno casilla in listadoCasillas)
                {
                    if(Enumerable.Range((int)(casilla.posicion.x - alturaCasilla), (int)(casilla.posicion.x + alturaCasilla)).Contains(posicionX))
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

                if (añadir == true)
                {
                    //Debug.Log(string.Format("{0}", posicionX));
                    listadoCasillas.Add(new Terreno(0, 0, new Vector3(posicionX, alturaCasilla, posicionZ)));
                    GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + "new Terreno(0, 0, new Vector3(" + (posicionX).ToString() + ", " + alturaCasilla.ToString() + ", " + (posicionZ).ToString() + "))," + Environment.NewLine;

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
                                    if (ComprobarLimiteX(posicionX + x, 2) == true && ComprobarLimiteZ(posicionZ + z, 2) == true)
                                    {
                                        listadoCasillas.Add(new Terreno(0, 0, new Vector3(posicionX + x, alturaCasilla, posicionZ + z)));
                                        GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + "new Terreno(0, 0, new Vector3(" + (posicionX + x).ToString() + ", " + alturaCasilla.ToString() + ", " + (posicionZ + z).ToString() + "))," + Environment.NewLine;
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
            listadoCasillas = new List<Terreno>
                {
new Terreno(0, 0, new Vector3(89, 7, 108)),
new Terreno(0, 0, new Vector3(92, 6.5f, 105)),
new Terreno(0, 0, new Vector3(93, 6.5f, 108)),
new Terreno(0, 0, new Vector3(85, 6.5f, 108)),
new Terreno(0, 0, new Vector3(86, 6.5f, 111)),
new Terreno(0, 0, new Vector3(88, 6, 102)),
new Terreno(0, 0, new Vector3(84, 6, 113)),
new Terreno(0, 0, new Vector3(97, 5.5f, 106)),
new Terreno(0, 0, new Vector3(80, 5, 117)),
new Terreno(0, 0, new Vector3(85, 5, 118)),
new Terreno(0, 0, new Vector3(98, 5, 99)),
new Terreno(0, 0, new Vector3(99, 5, 109)),
new Terreno(0, 0, new Vector3(99, 5, 104)),
new Terreno(0, 0, new Vector3(79, 5, 111)),
new Terreno(0, 0, new Vector3(77, 4.5f, 105)),
new Terreno(0, 0, new Vector3(85, 4.5f, 120)),
new Terreno(0, 0, new Vector3(78, 4.5f, 97)),
new Terreno(0, 0, new Vector3(78, 4.5f, 119)),
new Terreno(0, 0, new Vector3(77, 4.5f, 105)),
new Terreno(0, 0, new Vector3(100, 4.5f, 119)),
new Terreno(0, 0, new Vector3(77, 4.5f, 106)),
new Terreno(0, 0, new Vector3(84, 4.5f, 96)),
new Terreno(0, 0, new Vector3(89, 4.5f, 96)),
new Terreno(0, 0, new Vector3(103, 4, 103)),
new Terreno(0, 0, new Vector3(103, 4, 109)),
new Terreno(0, 0, new Vector3(103, 4, 103)),
new Terreno(0, 0, new Vector3(91, 4, 122)),
new Terreno(0, 0, new Vector3(73, 3.5f, 101)),
new Terreno(0, 0, new Vector3(92, 3.5f, 92)),
new Terreno(0, 0, new Vector3(74, 3.5f, 93)),
new Terreno(0, 0, new Vector3(104, 3.5f, 93)),
new Terreno(0, 0, new Vector3(72, 3, 125)),
new Terreno(0, 0, new Vector3(71, 3, 114)),
new Terreno(0, 0, new Vector3(71, 3, 110)),
new Terreno(0, 0, new Vector3(72, 3, 125)),
new Terreno(0, 0, new Vector3(71, 3, 110)),
new Terreno(0, 0, new Vector3(72, 3, 125)),
new Terreno(0, 0, new Vector3(72, 3, 125)),
new Terreno(0, 0, new Vector3(96, 3, 126)),
new Terreno(0, 0, new Vector3(106, 3, 125)),
new Terreno(0, 0, new Vector3(106, 3, 91)),
new Terreno(0, 0, new Vector3(109, 2.5f, 100)),
new Terreno(0, 0, new Vector3(69, 2.5f, 106)),
new Terreno(0, 0, new Vector3(87, 2.5f, 88)),
new Terreno(0, 0, new Vector3(110, 2, 87)),
new Terreno(0, 0, new Vector3(94, 2, 86)),
new Terreno(0, 0, new Vector3(67, 2, 109)),
new Terreno(0, 0, new Vector3(110, 2, 129)),
new Terreno(0, 0, new Vector3(68, 2, 87)),
new Terreno(0, 0, new Vector3(68, 2, 129)),
new Terreno(0, 0, new Vector3(110, 2, 87)),
new Terreno(0, 0, new Vector3(67, 2, 105)),
new Terreno(0, 0, new Vector3(110, 2, 87)),
new Terreno(0, 0, new Vector3(81, 2, 130)),
new Terreno(0, 0, new Vector3(67, 2, 110)),
new Terreno(0, 0, new Vector3(67, 2, 105)),
new Terreno(0, 0, new Vector3(88, 2, 130)),
new Terreno(0, 0, new Vector3(112, 1.5f, 131)),
new Terreno(0, 0, new Vector3(89, 1.5f, 132)),
new Terreno(0, 0, new Vector3(92, 1.5f, 132)),
new Terreno(0, 0, new Vector3(66, 1.5f, 85)),
new Terreno(0, 0, new Vector3(112, 1.5f, 131)),
new Terreno(0, 0, new Vector3(113, 1.5f, 97)),
new Terreno(0, 0, new Vector3(65, 1.5f, 115)),
new Terreno(0, 0, new Vector3(65, 1.5f, 111)),
new Terreno(0, 0, new Vector3(115, 1, 114)),
new Terreno(0, 0, new Vector3(114, 1, 83)),
new Terreno(0, 0, new Vector3(88, 1, 82)),
new Terreno(0, 0, new Vector3(64, 1, 83)),
new Terreno(0, 0, new Vector3(97, 1, 134)),
new Terreno(0, 0, new Vector3(115, 1, 105)),
new Terreno(0, 0, new Vector3(115, 1, 115)),
new Terreno(0, 0, new Vector3(114, 1, 83)),
new Terreno(0, 0, new Vector3(291, 4, 83)),
new Terreno(0, 0, new Vector3(294, 3.5f, 80)),
new Terreno(0, 0, new Vector3(287, 3.5f, 82)),
new Terreno(0, 0, new Vector3(295, 3.5f, 83)),
new Terreno(0, 0, new Vector3(290, 3.5f, 87)),
new Terreno(0, 0, new Vector3(295, 3.5f, 82)),
new Terreno(0, 0, new Vector3(286, 3, 78)),
new Terreno(0, 0, new Vector3(296, 3, 88)),
new Terreno(0, 0, new Vector3(283, 2.5f, 81)),
new Terreno(0, 0, new Vector3(299, 2.5f, 82)),
new Terreno(0, 0, new Vector3(283, 2.5f, 82)),
new Terreno(0, 0, new Vector3(293, 2.5f, 91)),
new Terreno(0, 0, new Vector3(301, 2, 85)),
new Terreno(0, 0, new Vector3(288, 2, 93)),
new Terreno(0, 0, new Vector3(292, 2, 73)),
new Terreno(0, 0, new Vector3(301, 2, 80)),
new Terreno(0, 0, new Vector3(282, 2, 74)),
new Terreno(0, 0, new Vector3(288, 2, 93)),
new Terreno(0, 0, new Vector3(280, 1.5f, 72)),
new Terreno(0, 0, new Vector3(292, 1.5f, 95)),
new Terreno(0, 0, new Vector3(303, 1.5f, 78)),
new Terreno(0, 0, new Vector3(293, 1, 69)),
new Terreno(0, 0, new Vector3(293, 1, 97)),
new Terreno(0, 0, new Vector3(278, 1, 96)),
new Terreno(0, 0, new Vector3(278, 1, 96)),
new Terreno(0, 0, new Vector3(296, 1, 97)),
new Terreno(0, 0, new Vector3(344, 6, 42)),
new Terreno(0, 0, new Vector3(341, 5.5f, 39)),
new Terreno(0, 0, new Vector3(344, 5.5f, 38)),
new Terreno(0, 0, new Vector3(341, 5.5f, 39)),
new Terreno(0, 0, new Vector3(350, 5, 40)),
new Terreno(0, 0, new Vector3(351, 4.5f, 49)),
new Terreno(0, 0, new Vector3(351, 4.5f, 35)),
new Terreno(0, 0, new Vector3(336, 4.5f, 43)),
new Terreno(0, 0, new Vector3(336, 4.5f, 40)),
new Terreno(0, 0, new Vector3(351, 4.5f, 35)),
new Terreno(0, 0, new Vector3(352, 4.5f, 43)),
new Terreno(0, 0, new Vector3(354, 4, 44)),
new Terreno(0, 0, new Vector3(332, 3.5f, 43)),
new Terreno(0, 0, new Vector3(333, 3.5f, 31)),
new Terreno(0, 0, new Vector3(355, 3.5f, 31)),
new Terreno(0, 0, new Vector3(345, 3.5f, 30)),
new Terreno(0, 0, new Vector3(355, 3.5f, 53)),
new Terreno(0, 0, new Vector3(355, 3.5f, 31)),
new Terreno(0, 0, new Vector3(355, 3.5f, 31)),
new Terreno(0, 0, new Vector3(356, 3.5f, 41)),
new Terreno(0, 0, new Vector3(357, 3, 29)),
new Terreno(0, 0, new Vector3(357, 3, 55)),
new Terreno(0, 0, new Vector3(330, 3, 38)),
new Terreno(0, 0, new Vector3(343, 3, 56)),
new Terreno(0, 0, new Vector3(357, 3, 29)),
new Terreno(0, 0, new Vector3(339, 3, 28)),
new Terreno(0, 0, new Vector3(339, 3, 56)),
new Terreno(0, 0, new Vector3(330, 3, 40)),
new Terreno(0, 0, new Vector3(342, 3, 56)),
new Terreno(0, 0, new Vector3(358, 3, 36)),
new Terreno(0, 0, new Vector3(329, 2.5f, 57)),
new Terreno(0, 0, new Vector3(360, 2.5f, 48)),
new Terreno(0, 0, new Vector3(329, 2.5f, 57)),
new Terreno(0, 0, new Vector3(360, 2.5f, 41)),
new Terreno(0, 0, new Vector3(328, 2.5f, 40)),
new Terreno(0, 0, new Vector3(360, 2.5f, 44)),
new Terreno(0, 0, new Vector3(328, 2.5f, 44)),
new Terreno(0, 0, new Vector3(326, 2, 35)),
new Terreno(0, 0, new Vector3(361, 2, 59)),
new Terreno(0, 0, new Vector3(327, 2, 25)),
new Terreno(0, 0, new Vector3(325, 1.5f, 61)),
new Terreno(0, 0, new Vector3(324, 1.5f, 43)),
new Terreno(0, 0, new Vector3(336, 1.5f, 62)),
new Terreno(0, 0, new Vector3(325, 1.5f, 61)),
new Terreno(0, 0, new Vector3(363, 1.5f, 61)),
new Terreno(0, 0, new Vector3(324, 1.5f, 48)),
new Terreno(0, 0, new Vector3(337, 1.5f, 62)),
new Terreno(0, 0, new Vector3(363, 1.5f, 61)),
new Terreno(0, 0, new Vector3(364, 1.5f, 41)),
new Terreno(0, 0, new Vector3(325, 1.5f, 23)),
new Terreno(0, 0, new Vector3(325, 1.5f, 23)),
new Terreno(0, 0, new Vector3(365, 1, 21)),
new Terreno(0, 0, new Vector3(347, 1, 20)),
new Terreno(0, 0, new Vector3(353, 1, 64)),
new Terreno(0, 0, new Vector3(322, 1, 34)),
new Terreno(0, 0, new Vector3(342, 1, 20)),
new Terreno(0, 0, new Vector3(365, 1, 21)),
new Terreno(0, 0, new Vector3(323, 1, 63)),
new Terreno(0, 0, new Vector3(322, 1, 33)),
new Terreno(0, 0, new Vector3(365, 1, 63)),
new Terreno(0, 0, new Vector3(188, 7, 55)),
new Terreno(0, 0, new Vector3(191, 6.5f, 58)),
new Terreno(0, 0, new Vector3(185, 6.5f, 52)),
new Terreno(0, 0, new Vector3(192, 6.5f, 54)),
new Terreno(0, 0, new Vector3(183, 6, 50)),
new Terreno(0, 0, new Vector3(193, 6, 50)),
new Terreno(0, 0, new Vector3(193, 6, 50)),
new Terreno(0, 0, new Vector3(193, 6, 60)),
new Terreno(0, 0, new Vector3(193, 6, 50)),
new Terreno(0, 0, new Vector3(193, 6, 60)),
new Terreno(0, 0, new Vector3(189, 5.5f, 63)),
new Terreno(0, 0, new Vector3(195, 5.5f, 62)),
new Terreno(0, 0, new Vector3(196, 5.5f, 52)),
new Terreno(0, 0, new Vector3(180, 5.5f, 52)),
new Terreno(0, 0, new Vector3(187, 5.5f, 47)),
new Terreno(0, 0, new Vector3(181, 5.5f, 62)),
new Terreno(0, 0, new Vector3(179, 5, 46)),
new Terreno(0, 0, new Vector3(198, 5, 57)),
new Terreno(0, 0, new Vector3(198, 5, 54)),
new Terreno(0, 0, new Vector3(197, 5, 46)),
new Terreno(0, 0, new Vector3(198, 5, 53)),
new Terreno(0, 0, new Vector3(198, 5, 54)),
new Terreno(0, 0, new Vector3(199, 4.5f, 66)),
new Terreno(0, 0, new Vector3(187, 4.5f, 67)),
new Terreno(0, 0, new Vector3(199, 4.5f, 66)),
new Terreno(0, 0, new Vector3(176, 4.5f, 53)),
new Terreno(0, 0, new Vector3(201, 4, 42)),
new Terreno(0, 0, new Vector3(202, 4, 50)),
new Terreno(0, 0, new Vector3(174, 4, 60)),
new Terreno(0, 0, new Vector3(189, 4, 41)),
new Terreno(0, 0, new Vector3(202, 4, 59)),
new Terreno(0, 0, new Vector3(172, 3.5f, 56)),
new Terreno(0, 0, new Vector3(170, 3, 52)),
new Terreno(0, 0, new Vector3(206, 3, 48)),
new Terreno(0, 0, new Vector3(188, 3, 73)),
new Terreno(0, 0, new Vector3(205, 3, 38)),
new Terreno(0, 0, new Vector3(207, 2.5f, 36)),
new Terreno(0, 0, new Vector3(208, 2.5f, 53)),
new Terreno(0, 0, new Vector3(194, 2.5f, 75)),
new Terreno(0, 0, new Vector3(207, 2.5f, 36)),
new Terreno(0, 0, new Vector3(207, 2.5f, 36)),
new Terreno(0, 0, new Vector3(169, 2.5f, 74)),
new Terreno(0, 0, new Vector3(168, 2.5f, 56)),
new Terreno(0, 0, new Vector3(207, 2.5f, 74)),
new Terreno(0, 0, new Vector3(168, 2.5f, 54)),
new Terreno(0, 0, new Vector3(169, 2.5f, 36)),
new Terreno(0, 0, new Vector3(208, 2.5f, 56)),
new Terreno(0, 0, new Vector3(193, 2.5f, 75)),
new Terreno(0, 0, new Vector3(193, 2, 33)),
new Terreno(0, 0, new Vector3(187, 2, 33)),
new Terreno(0, 0, new Vector3(185, 2, 77)),
new Terreno(0, 0, new Vector3(210, 2, 57)),
new Terreno(0, 0, new Vector3(166, 2, 53)),
new Terreno(0, 0, new Vector3(196, 2, 33)),
new Terreno(0, 0, new Vector3(184, 1.5f, 79)),
new Terreno(0, 0, new Vector3(164, 1.5f, 56)),
new Terreno(0, 0, new Vector3(163, 1, 30)),
new Terreno(0, 0, new Vector3(213, 1, 30)),
new Terreno(0, 0, new Vector3(214, 1, 55)),
new Terreno(0, 0, new Vector3(84, 4, 31)),
new Terreno(0, 0, new Vector3(87, 3.5f, 34)),
new Terreno(0, 0, new Vector3(81, 3.5f, 28)),
new Terreno(0, 0, new Vector3(83, 3, 25)),
new Terreno(0, 0, new Vector3(89, 3, 26)),
new Terreno(0, 0, new Vector3(89, 3, 26)),
new Terreno(0, 0, new Vector3(79, 3, 36)),
new Terreno(0, 0, new Vector3(83, 3, 37)),
new Terreno(0, 0, new Vector3(82, 2.5f, 23)),
new Terreno(0, 0, new Vector3(83, 2, 41)),
new Terreno(0, 0, new Vector3(94, 2, 34)),
new Terreno(0, 0, new Vector3(82, 2, 41)),
new Terreno(0, 0, new Vector3(75, 2, 40)),
new Terreno(0, 0, new Vector3(95, 1.5f, 20)),
new Terreno(0, 0, new Vector3(95, 1.5f, 42)),
new Terreno(0, 0, new Vector3(72, 1.5f, 31)),
new Terreno(0, 0, new Vector3(73, 1.5f, 42)),
new Terreno(0, 0, new Vector3(73, 1.5f, 20)),
new Terreno(0, 0, new Vector3(82, 1.5f, 43)),
new Terreno(0, 0, new Vector3(72, 1.5f, 30)),
new Terreno(0, 0, new Vector3(71, 1, 44)),
new Terreno(0, 0, new Vector3(71, 1, 44)),
new Terreno(0, 0, new Vector3(70, 1, 31)),
new Terreno(0, 0, new Vector3(11, 3, 63)),
new Terreno(0, 0, new Vector3(8, 2.5f, 60)),
new Terreno(0, 0, new Vector3(11, 2.5f, 67)),
new Terreno(0, 0, new Vector3(15, 2.5f, 63)),
new Terreno(0, 0, new Vector3(6, 2, 58)),
new Terreno(0, 0, new Vector3(5, 2, 61)),
new Terreno(0, 0, new Vector3(17, 2, 64)),
new Terreno(0, 0, new Vector3(19, 1.5f, 65)),
new Terreno(0, 0, new Vector3(2, 1, 54)),
new Terreno(0, 0, new Vector3(13, 1, 73)),
new Terreno(0, 0, new Vector3(20, 1, 72)),
new Terreno(0, 0, new Vector3(13, 1, 73)),
new Terreno(0, 0, new Vector3(20, 1, 54)),
new Terreno(0, 0, new Vector3(347, 6, 13)),
new Terreno(0, 0, new Vector3(351, 5.5f, 13)),
new Terreno(0, 0, new Vector3(350, 5.5f, 10)),
new Terreno(0, 0, new Vector3(353, 5, 13)),
new Terreno(0, 0, new Vector3(352, 5, 18)),
new Terreno(0, 0, new Vector3(352, 5, 18)),
new Terreno(0, 0, new Vector3(342, 5, 18)),
new Terreno(0, 0, new Vector3(342, 5, 18)),
new Terreno(0, 0, new Vector3(354, 4.5f, 20)),
new Terreno(0, 0, new Vector3(338, 4, 22)),
new Terreno(0, 0, new Vector3(347, 4, 23)),
new Terreno(0, 0, new Vector3(335, 3.5f, 10)),
new Terreno(0, 0, new Vector3(335, 3.5f, 12)),
new Terreno(0, 0, new Vector3(347, 3, 27)),
new Terreno(0, 0, new Vector3(360, 3, 26)),
new Terreno(0, 0, new Vector3(343, 3, 27)),
new Terreno(0, 0, new Vector3(363, 2.5f, 10)),
new Terreno(0, 0, new Vector3(345, 2.5f, 29)),
new Terreno(0, 0, new Vector3(351, 2.5f, 29)),
new Terreno(0, 0, new Vector3(363, 2.5f, 8)),
new Terreno(0, 0, new Vector3(365, 2, 7)),
new Terreno(0, 0, new Vector3(330, 2, 30)),
new Terreno(0, 0, new Vector3(365, 2, 7)),
new Terreno(0, 0, new Vector3(364, 2, 30)),
new Terreno(0, 0, new Vector3(329, 2, 8)),
new Terreno(0, 0, new Vector3(368, 1, 34)),
new Terreno(0, 0, new Vector3(341, 1, 35)),
new Terreno(0, 0, new Vector3(368, 1, 34)),
new Terreno(0, 0, new Vector3(8, 3, 52)),
new Terreno(0, 0, new Vector3(12, 2.5f, 51)),
new Terreno(0, 0, new Vector3(4, 2.5f, 52)),
new Terreno(0, 0, new Vector3(13, 2, 57)),
new Terreno(0, 0, new Vector3(9, 2, 58)),
new Terreno(0, 0, new Vector3(16, 1.5f, 53)),
new Terreno(0, 0, new Vector3(9, 1.5f, 60)),
new Terreno(0, 0, new Vector3(17, 1, 61)),
new Terreno(0, 0, new Vector3(18, 1, 55)),
new Terreno(0, 0, new Vector3(4, 1, 62)),
new Terreno(0, 0, new Vector3(5, 1, 62)),
new Terreno(0, 0, new Vector3(18, 1, 53)),
new Terreno(0, 0, new Vector3(48, 4, 99)),
new Terreno(0, 0, new Vector3(53, 3, 104)),
new Terreno(0, 0, new Vector3(46, 3, 93)),
new Terreno(0, 0, new Vector3(53, 3, 104)),
new Terreno(0, 0, new Vector3(43, 3, 104)),
new Terreno(0, 0, new Vector3(48, 2.5f, 91)),
new Terreno(0, 0, new Vector3(48, 2.5f, 107)),
new Terreno(0, 0, new Vector3(40, 2.5f, 96)),
new Terreno(0, 0, new Vector3(40, 2.5f, 99)),
new Terreno(0, 0, new Vector3(46, 2.5f, 107)),
new Terreno(0, 0, new Vector3(55, 2.5f, 106)),
new Terreno(0, 0, new Vector3(41, 2.5f, 92)),
new Terreno(0, 0, new Vector3(38, 2, 98)),
new Terreno(0, 0, new Vector3(49, 2, 89)),
new Terreno(0, 0, new Vector3(60, 1.5f, 102)),
new Terreno(0, 0, new Vector3(52, 1.5f, 111)),
new Terreno(0, 0, new Vector3(49, 1, 113)),
new Terreno(0, 0, new Vector3(35, 1, 86)),
new Terreno(0, 0, new Vector3(34, 1, 102)),
new Terreno(0, 0, new Vector3(62, 1, 99)),
new Terreno(0, 0, new Vector3(48, 1, 85)),
new Terreno(0, 0, new Vector3(35, 1, 112)),
new Terreno(0, 0, new Vector3(61, 1, 112)),
new Terreno(0, 0, new Vector3(62, 1, 99)),
new Terreno(0, 0, new Vector3(35, 1, 112))
            };
        }

        foreach (Terreno subcasilla in listadoCasillas)
        {
            PonerTerreno(subcasilla, null, false);
        }

        //StartCoroutine(GenerarEscenario());

        int k = 0;
        while (k < arranque.tamañoEscenarioX)
        {
            alturaNivel -= 0.5f;

            if (alturaNivel < 0.5f)
            {
                alturaNivel = 0.5f;
            }

            GenerarNivel(alturaNivel, listadoCasillas);
            k += 1;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(teclaGenerarNivel))
        {
            alturaNivel -= 0.5f;

            if (alturaNivel < 0.5f)
            {
                alturaNivel = 0.5f;
            }

            GenerarNivel(alturaNivel, listadoCasillas);
            //Debug.Log(alturaNivel);
        }
    }

    IEnumerator GenerarEscenario()
    {
        int i = 0;
        while (i < arranque.tamañoEscenarioX)
        {
            yield return new WaitForSeconds(1f);

            alturaNivel -= 0.5f;

            if (alturaNivel < 0.5f)
            {
                alturaNivel = 0.5f;
            }

            GenerarNivel(alturaNivel, listadoCasillas);
            i += 1;
        }
    }

    private void GenerarNivel(float altura, List<Terreno> listadoCasillas)
    {
        listadoCasillasTemporal = new List<Terreno>();

        foreach (Terreno subcasilla in listadoCasillas)
        {
            listadoCasillasTemporal.Add(subcasilla);
        }

        foreach (Terreno subcasilla in listadoCasillasTemporal)
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
                    CalcularTerreno_Xmenos1_Zmenos1(x, y, z, listadoCasillas);
                }

                if (terrenos[x - 1, z + 1] == null)
                {
                    CalcularTerreno_Xmenos1_Zmas1(x, y, z, listadoCasillas);
                }

                if (terrenos[x + 1, z - 1] == null)
                {
                    CalcularTerreno_Xmas1_Zmenos1(x, y, z, listadoCasillas);
                }

                if (terrenos[x + 1, z + 1] == null)
                {
                    CalcularTerreno_Xmas1_Zmas1(x, y, z, listadoCasillas);
                }

                if (terrenos[x, z - 1] == null)
                {
                    CalcularTerreno_X0_Zmenos1(x, y, z, listadoCasillas);
                }

                if (terrenos[x - 1, z] == null)
                {
                    CalcularTerreno_Xmenos1_Z0(x, y, z, listadoCasillas);
                }

                if (terrenos[x, z + 1] == null)
                {
                    CalcularTerreno_X0_Zmas1(x, y, z, listadoCasillas);
                }

                if (terrenos[x + 1, z] == null)
                {
                    CalcularTerreno_Xmas1_Z0(x, y, z, listadoCasillas);
                }
            }
        }
    }

    //Verde - esquina2rotacion180
    private void CalcularTerreno_Xmenos1_Zmenos1(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno esquina3rotacion90 = new Terreno(3, 90, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(3, 270, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion90 = new Terreno(1, 90, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(1, 180, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 1], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina2rotacion180 = new Terreno(2, 180, new Vector3(x - 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(esquina2rotacion180, listadoCasillas, true);
        }
    }

    //Gris - esquina2rotacion270
    private void CalcularTerreno_Xmenos1_Zmas1(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno esquina3rotacion180 = new Terreno(38, 180, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(36, 180, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina2rotacion270 = new Terreno(37, 270, new Vector3(x - 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(esquina2rotacion270, listadoCasillas, true);
        }
    }

    //Marron Claro - esquina2rotacion90 
    private void CalcularTerreno_Xmas1_Zmenos1(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno plano = new Terreno(30, 0, new Vector3(x + 1, y + 0.5f, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(33, 180, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion90 = new Terreno(31, 90, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina2rotacion90 = new Terreno(32, 90, new Vector3(x + 1, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(esquina2rotacion90, listadoCasillas, true);
        }
    }

    //Morado - esquina2rotacion0
    private void CalcularTerreno_Xmas1_Zmas1(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno rampas4rotacion90 = new Terreno(29, 90, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && terrenos[x + 2, z] == null && terrenos[x, z + 2] == null)
        {
            PonerTerreno(rampas4rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && terrenos[x + 2, z] == null && terrenos[x, z + 2] == null)
        {
            PonerTerreno(rampas4rotacion90, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno plano = new Terreno(25, 0, new Vector3(x + 1, y + 0.5f, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 2], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(28, 270, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion270 = new Terreno(26, 270, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion0 = new Terreno(26, 0, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina2rotacion0 = new Terreno(27, 0, new Vector3(x + 1, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(esquina2rotacion0, listadoCasillas, true);
        }
    }

    //Rojo - rampa1rotacion90
    private void CalcularTerreno_X0_Zmenos1(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno plano = new Terreno(20, 0, new Vector3(x, y + 0.5f, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x, z - 2], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x, z - 2], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(23, 90, new Vector3(x, y, z - 1));

        if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 2], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(23, 180, new Vector3(x, y, z - 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 2], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion90 = new Terreno(21, 90, new Vector3(x, y, z - 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion90, listadoCasillas, true);
        }
    }

    //Marron Oscuro - rampa1rotacion180
    private void CalcularTerreno_Xmenos1_Z0(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno plano = new Terreno(5, 0, new Vector3(x - 1, y + 0.5f, z));

        if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 2, z], y, 0) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(8, 270, new Vector3(x - 1, y, z));

        if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion180 = new Terreno(8, 180, new Vector3(x - 1, y, z));

        if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 2, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion180, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(6, 180, new Vector3(x - 1, y, z));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 180) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion180, listadoCasillas, true);
        }
    }

    //Blanco - rampa1rotacion270
    private void CalcularTerreno_X0_Zmas1(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno plano = new Terreno(10, 0, new Vector3(x, y + 0.5f, z + 1));

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x, z + 2], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(13, 0, new Vector3(x, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x - 1, z + 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x - 1, z + 2], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion270 = new Terreno(13, 270, new Vector3(x, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion270, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion270 = new Terreno(11, 270, new Vector3(x, y, z + 1));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 270) == true)
        {
            PonerTerreno(rampa1rotacion270, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion270, listadoCasillas, true);
        }
    }

    //Amarillo - rampa1rotacion0
    private void CalcularTerreno_Xmas1_Z0(int x, float y, int z, List<Terreno> listadoCasillas)
    {
        Terreno plano = new Terreno(15, 0, new Vector3(x + 1, y + 0.5f, z));

        if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 2, z], y, 180) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true)
        {
            PonerTerreno(plano, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion0 = new Terreno(18, 0, new Vector3(x + 1, y, z));

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z - 1], y, 270) == true)
        {
            PonerTerreno(esquina3rotacion0, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno esquina3rotacion90 = new Terreno(18, 90, new Vector3(x + 1, y, z));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno1(terrenos[x + 1, z + 1], y, 90) == true)
        {
            PonerTerreno(esquina3rotacion90, listadoCasillas, true);
        }

        //---------------------------------------

        Terreno rampa1rotacion0 = new Terreno(16, 0, new Vector3(x + 1, y, z));

        if (ComprobarTerreno0(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno1(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true)
        {
            PonerTerreno(rampa1rotacion0, listadoCasillas, true);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------

    private void PonerTerreno(Terreno terreno, List<Terreno> listadoCasillas, bool ponerListado)
    {
        int x = (int)terreno.posicion.x;
        int z = (int)terreno.posicion.z;

        Terreno terrenoGenerar = casillas[terreno.id];

        if (terrenos[x, z] == null)
        {
            Terreno terreno2 = Instantiate(terrenoGenerar, terreno.posicion, Quaternion.identity);
            terreno2.gameObject.transform.Rotate(Vector3.up, terreno.rotacion, Space.World);
            terreno2.rotacion = terreno.rotacion;
            terreno2.posicion = terreno.posicion;
            terrenos[x, z] = terreno2;
        }

        if (listadoCasillas != null)
        {
            if (ponerListado == true)
            {
                listadoCasillas.Add(terreno);
            }
        }
    }

    private void BorrarTerreno(Terreno terreno)
    {
        GameObject.Destroy(terrenos[(int)terreno.posicion.x, (int)terreno.posicion.z]);
        terrenos[(int)terreno.posicion.x, (int)terreno.posicion.z] = null;
        listadoCasillas.Remove(terreno);
        listadoCasillasTemporal.Remove(terreno);
    }

    private bool ComprobarTerreno0(Terreno terreno, float altura, int rotacion)
    {
        if (terreno != null)
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
            else
            {
                if (altura - terreno.posicion.y >= 0.5f)
                {
                    BorrarTerreno(terreno);
                    return false;
                }
            }
        }

        return false;
    }

    private bool ComprobarTerreno1(Terreno terreno, float altura, int rotacion)
    {
        if (terreno != null)
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
            else
            {
                if (altura - terreno.posicion.y >= 0.5f || altura - terreno.posicion.y <= -0.5f)
                {
                    BorrarTerreno(terreno);
                    return false;
                }
            }
        }

        return false;
    }

    private bool ComprobarTerreno2(Terreno terreno, float altura, int rotacion)
    {
        if (terreno != null)
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
            else
            {
                if (altura - terreno.posicion.y >= 0.5f)
                {
                    BorrarTerreno(terreno);
                    return false;
                }
            }
        }

        return false;
    }

    private bool ComprobarLimiteX(int x, int ajuste)
    {
        if ((x - ajuste >= 0) && (x + ajuste - 1 < arranque.tamañoEscenarioX))
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
        if ((z - ajuste >= 0) && (z + ajuste - 1 < arranque.tamañoEscenarioZ))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
