using Juego;
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

        bool aleatorio = false;

        if (aleatorio == true)
        {
            portapapeles.LimpiarPortapapeles();

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
            listadoCasillasInicial = new List<Vector3> { new Vector3(199, 6, 222),
new Vector3(195, 5.5f, 221),
new Vector3(193, 5, 221),
new Vector3(193, 5, 223),
new Vector3(199, 5, 216),
new Vector3(194, 5, 227),
new Vector3(200, 5, 228),
new Vector3(193, 5, 221),
new Vector3(206, 4.5f, 215),
new Vector3(200, 4.5f, 230),
new Vector3(192, 4.5f, 215),
new Vector3(207, 4.5f, 224),
new Vector3(196, 4.5f, 230),
new Vector3(192, 4.5f, 215),
new Vector3(207, 4.5f, 219),
new Vector3(209, 4, 221),
new Vector3(199, 3.5f, 234),
new Vector3(211, 3.5f, 223),
new Vector3(196, 3.5f, 210),
new Vector3(187, 3.5f, 220),
new Vector3(199, 3.5f, 234),
new Vector3(187, 3.5f, 225),
new Vector3(194, 3, 236),
new Vector3(185, 3, 220),
new Vector3(214, 2.5f, 237),
new Vector3(203, 2.5f, 206),
new Vector3(183, 2.5f, 228),
new Vector3(214, 2.5f, 237),
new Vector3(215, 2.5f, 215),
new Vector3(214, 2.5f, 207),
new Vector3(181, 2, 238),
new Vector3(181, 2, 239),
new Vector3(181, 2, 240),
new Vector3(182, 2, 238),
new Vector3(182, 2, 239),
new Vector3(182, 2, 240),
new Vector3(183, 2, 238),
new Vector3(183, 2, 239),
new Vector3(183, 2, 240),
new Vector3(216, 2, 214),
new Vector3(216, 2, 215),
new Vector3(216, 2, 216),
new Vector3(217, 2, 214),
new Vector3(217, 2, 215),
new Vector3(217, 2, 216),
new Vector3(218, 2, 214),
new Vector3(218, 2, 215),
new Vector3(218, 2, 216),
new Vector3(203, 2, 203),
new Vector3(203, 2, 204),
new Vector3(203, 2, 205),
new Vector3(204, 2, 203),
new Vector3(204, 2, 204),
new Vector3(204, 2, 205),
new Vector3(205, 2, 203),
new Vector3(205, 2, 204),
new Vector3(205, 2, 205),
new Vector3(178, 1.5f, 217),
new Vector3(178, 1.5f, 218),
new Vector3(178, 1.5f, 219),
new Vector3(179, 1.5f, 217),
new Vector3(179, 1.5f, 218),
new Vector3(179, 1.5f, 219),
new Vector3(180, 1.5f, 217),
new Vector3(180, 1.5f, 218),
new Vector3(180, 1.5f, 219),
new Vector3(187, 1, 198),
new Vector3(187, 1, 199),
new Vector3(187, 1, 200),
new Vector3(187, 1, 201),
new Vector3(187, 1, 202),
new Vector3(188, 1, 198),
new Vector3(188, 1, 199),
new Vector3(188, 1, 200),
new Vector3(188, 1, 201),
new Vector3(188, 1, 202),
new Vector3(189, 1, 198),
new Vector3(189, 1, 199),
new Vector3(189, 1, 200),
new Vector3(189, 1, 201),
new Vector3(189, 1, 202),
new Vector3(190, 1, 198),
new Vector3(190, 1, 199),
new Vector3(190, 1, 200),
new Vector3(190, 1, 201),
new Vector3(190, 1, 202),
new Vector3(191, 1, 198),
new Vector3(191, 1, 199),
new Vector3(191, 1, 200),
new Vector3(191, 1, 201),
new Vector3(191, 1, 202),
new Vector3(175, 1, 212),
new Vector3(175, 1, 213),
new Vector3(175, 1, 214),
new Vector3(175, 1, 215),
new Vector3(175, 1, 216),
new Vector3(176, 1, 212),
new Vector3(176, 1, 213),
new Vector3(176, 1, 214),
new Vector3(176, 1, 215),
new Vector3(176, 1, 216),
new Vector3(177, 1, 212),
new Vector3(177, 1, 213),
new Vector3(177, 1, 214),
new Vector3(177, 1, 215),
new Vector3(177, 1, 216),
new Vector3(178, 1, 212),
new Vector3(178, 1, 213),
new Vector3(178, 1, 214),
new Vector3(178, 1, 215),
new Vector3(178, 1, 216),
new Vector3(179, 1, 212),
new Vector3(179, 1, 213),
new Vector3(179, 1, 214),
new Vector3(179, 1, 215),
new Vector3(179, 1, 216),
new Vector3(262, 3, 310),
new Vector3(266, 2.5f, 310),
new Vector3(259, 2.5f, 307),
new Vector3(261, 2.5f, 314),
new Vector3(259, 2.5f, 313),
new Vector3(255, 2, 310),
new Vector3(255, 2, 311),
new Vector3(255, 2, 312),
new Vector3(256, 2, 310),
new Vector3(256, 2, 311),
new Vector3(256, 2, 312),
new Vector3(257, 2, 310),
new Vector3(257, 2, 311),
new Vector3(257, 2, 312),
new Vector3(255, 2, 308),
new Vector3(255, 2, 309),
new Vector3(255, 2, 310),
new Vector3(256, 2, 308),
new Vector3(256, 2, 309),
new Vector3(256, 2, 310),
new Vector3(257, 2, 308),
new Vector3(257, 2, 309),
new Vector3(257, 2, 310),
new Vector3(268, 1.5f, 316),
new Vector3(268, 1.5f, 317),
new Vector3(268, 1.5f, 318),
new Vector3(269, 1.5f, 316),
new Vector3(269, 1.5f, 317),
new Vector3(269, 1.5f, 318),
new Vector3(270, 1.5f, 316),
new Vector3(270, 1.5f, 317),
new Vector3(270, 1.5f, 318),
new Vector3(262, 1.5f, 301),
new Vector3(262, 1.5f, 302),
new Vector3(262, 1.5f, 303),
new Vector3(263, 1.5f, 301),
new Vector3(263, 1.5f, 302),
new Vector3(263, 1.5f, 303),
new Vector3(264, 1.5f, 301),
new Vector3(264, 1.5f, 302),
new Vector3(264, 1.5f, 303),
new Vector3(269, 1.5f, 309),
new Vector3(269, 1.5f, 310),
new Vector3(269, 1.5f, 311),
new Vector3(270, 1.5f, 309),
new Vector3(270, 1.5f, 310),
new Vector3(270, 1.5f, 311),
new Vector3(271, 1.5f, 309),
new Vector3(271, 1.5f, 310),
new Vector3(271, 1.5f, 311),
new Vector3(270, 1, 309),
new Vector3(270, 1, 310),
new Vector3(270, 1, 311),
new Vector3(270, 1, 312),
new Vector3(270, 1, 313),
new Vector3(271, 1, 309),
new Vector3(271, 1, 310),
new Vector3(271, 1, 311),
new Vector3(271, 1, 312),
new Vector3(271, 1, 313),
new Vector3(272, 1, 309),
new Vector3(272, 1, 310),
new Vector3(272, 1, 311),
new Vector3(272, 1, 312),
new Vector3(272, 1, 313),
new Vector3(273, 1, 309),
new Vector3(273, 1, 310),
new Vector3(273, 1, 311),
new Vector3(273, 1, 312),
new Vector3(273, 1, 313),
new Vector3(274, 1, 309),
new Vector3(274, 1, 310),
new Vector3(274, 1, 311),
new Vector3(274, 1, 312),
new Vector3(274, 1, 313),
new Vector3(256, 1, 298),
new Vector3(256, 1, 299),
new Vector3(256, 1, 300),
new Vector3(256, 1, 301),
new Vector3(256, 1, 302),
new Vector3(257, 1, 298),
new Vector3(257, 1, 299),
new Vector3(257, 1, 300),
new Vector3(257, 1, 301),
new Vector3(257, 1, 302),
new Vector3(258, 1, 298),
new Vector3(258, 1, 299),
new Vector3(258, 1, 300),
new Vector3(258, 1, 301),
new Vector3(258, 1, 302),
new Vector3(259, 1, 298),
new Vector3(259, 1, 299),
new Vector3(259, 1, 300),
new Vector3(259, 1, 301),
new Vector3(259, 1, 302),
new Vector3(260, 1, 298),
new Vector3(260, 1, 299),
new Vector3(260, 1, 300),
new Vector3(260, 1, 301),
new Vector3(260, 1, 302),
new Vector3(256, 1, 318),
new Vector3(256, 1, 319),
new Vector3(256, 1, 320),
new Vector3(256, 1, 321),
new Vector3(256, 1, 322),
new Vector3(257, 1, 318),
new Vector3(257, 1, 319),
new Vector3(257, 1, 320),
new Vector3(257, 1, 321),
new Vector3(257, 1, 322),
new Vector3(258, 1, 318),
new Vector3(258, 1, 319),
new Vector3(258, 1, 320),
new Vector3(258, 1, 321),
new Vector3(258, 1, 322),
new Vector3(259, 1, 318),
new Vector3(259, 1, 319),
new Vector3(259, 1, 320),
new Vector3(259, 1, 321),
new Vector3(259, 1, 322),
new Vector3(260, 1, 318),
new Vector3(260, 1, 319),
new Vector3(260, 1, 320),
new Vector3(260, 1, 321),
new Vector3(260, 1, 322),
new Vector3(251, 1, 299),
new Vector3(251, 1, 300),
new Vector3(251, 1, 301),
new Vector3(251, 1, 302),
new Vector3(251, 1, 303),
new Vector3(252, 1, 299),
new Vector3(252, 1, 300),
new Vector3(252, 1, 301),
new Vector3(252, 1, 302),
new Vector3(252, 1, 303),
new Vector3(253, 1, 299),
new Vector3(253, 1, 300),
new Vector3(253, 1, 301),
new Vector3(253, 1, 302),
new Vector3(253, 1, 303),
new Vector3(254, 1, 299),
new Vector3(254, 1, 300),
new Vector3(254, 1, 301),
new Vector3(254, 1, 302),
new Vector3(254, 1, 303),
new Vector3(255, 1, 299),
new Vector3(255, 1, 300),
new Vector3(255, 1, 301),
new Vector3(255, 1, 302),
new Vector3(255, 1, 303),
new Vector3(251, 1, 299),
new Vector3(251, 1, 300),
new Vector3(251, 1, 301),
new Vector3(251, 1, 302),
new Vector3(251, 1, 303),
new Vector3(252, 1, 299),
new Vector3(252, 1, 300),
new Vector3(252, 1, 301),
new Vector3(252, 1, 302),
new Vector3(252, 1, 303),
new Vector3(253, 1, 299),
new Vector3(253, 1, 300),
new Vector3(253, 1, 301),
new Vector3(253, 1, 302),
new Vector3(253, 1, 303),
new Vector3(254, 1, 299),
new Vector3(254, 1, 300),
new Vector3(254, 1, 301),
new Vector3(254, 1, 302),
new Vector3(254, 1, 303),
new Vector3(255, 1, 299),
new Vector3(255, 1, 300),
new Vector3(255, 1, 301),
new Vector3(255, 1, 302),
new Vector3(255, 1, 303),
new Vector3(259, 1, 298),
new Vector3(259, 1, 299),
new Vector3(259, 1, 300),
new Vector3(259, 1, 301),
new Vector3(259, 1, 302),
new Vector3(260, 1, 298),
new Vector3(260, 1, 299),
new Vector3(260, 1, 300),
new Vector3(260, 1, 301),
new Vector3(260, 1, 302),
new Vector3(261, 1, 298),
new Vector3(261, 1, 299),
new Vector3(261, 1, 300),
new Vector3(261, 1, 301),
new Vector3(261, 1, 302),
new Vector3(262, 1, 298),
new Vector3(262, 1, 299),
new Vector3(262, 1, 300),
new Vector3(262, 1, 301),
new Vector3(262, 1, 302),
new Vector3(263, 1, 298),
new Vector3(263, 1, 299),
new Vector3(263, 1, 300),
new Vector3(263, 1, 301),
new Vector3(263, 1, 302),
new Vector3(221, 4, 176),
new Vector3(218, 3.5f, 179),
new Vector3(225, 3.5f, 176),
new Vector3(225, 3.5f, 176),
new Vector3(225, 3.5f, 175),
new Vector3(226, 3, 181),
new Vector3(215, 3, 176),
new Vector3(222, 3, 170),
new Vector3(220, 3, 170),
new Vector3(219, 3, 182),
new Vector3(214, 2.5f, 183),
new Vector3(229, 2.5f, 176),
new Vector3(214, 2.5f, 169),
new Vector3(229, 2.5f, 173),
new Vector3(229, 2.5f, 173),
new Vector3(229, 2, 184),
new Vector3(229, 2, 185),
new Vector3(229, 2, 186),
new Vector3(230, 2, 184),
new Vector3(230, 2, 185),
new Vector3(230, 2, 186),
new Vector3(231, 2, 184),
new Vector3(231, 2, 185),
new Vector3(231, 2, 186),
new Vector3(219, 2, 185),
new Vector3(219, 2, 186),
new Vector3(219, 2, 187),
new Vector3(220, 2, 185),
new Vector3(220, 2, 186),
new Vector3(220, 2, 187),
new Vector3(221, 2, 185),
new Vector3(221, 2, 186),
new Vector3(221, 2, 187),
new Vector3(209, 1.5f, 186),
new Vector3(209, 1.5f, 187),
new Vector3(209, 1.5f, 188),
new Vector3(210, 1.5f, 186),
new Vector3(210, 1.5f, 187),
new Vector3(210, 1.5f, 188),
new Vector3(211, 1.5f, 186),
new Vector3(211, 1.5f, 187),
new Vector3(211, 1.5f, 188),
new Vector3(218, 1.5f, 187),
new Vector3(218, 1.5f, 188),
new Vector3(218, 1.5f, 189),
new Vector3(219, 1.5f, 187),
new Vector3(219, 1.5f, 188),
new Vector3(219, 1.5f, 189),
new Vector3(220, 1.5f, 187),
new Vector3(220, 1.5f, 188),
new Vector3(220, 1.5f, 189),
new Vector3(232, 1.5f, 175),
new Vector3(232, 1.5f, 176),
new Vector3(232, 1.5f, 177),
new Vector3(233, 1.5f, 175),
new Vector3(233, 1.5f, 176),
new Vector3(233, 1.5f, 177),
new Vector3(234, 1.5f, 175),
new Vector3(234, 1.5f, 176),
new Vector3(234, 1.5f, 177),
new Vector3(232, 1, 161),
new Vector3(232, 1, 162),
new Vector3(232, 1, 163),
new Vector3(232, 1, 164),
new Vector3(232, 1, 165),
new Vector3(233, 1, 161),
new Vector3(233, 1, 162),
new Vector3(233, 1, 163),
new Vector3(233, 1, 164),
new Vector3(233, 1, 165),
new Vector3(234, 1, 161),
new Vector3(234, 1, 162),
new Vector3(234, 1, 163),
new Vector3(234, 1, 164),
new Vector3(234, 1, 165),
new Vector3(235, 1, 161),
new Vector3(235, 1, 162),
new Vector3(235, 1, 163),
new Vector3(235, 1, 164),
new Vector3(235, 1, 165),
new Vector3(236, 1, 161),
new Vector3(236, 1, 162),
new Vector3(236, 1, 163),
new Vector3(236, 1, 164),
new Vector3(236, 1, 165),
new Vector3(51, 6, 56),
new Vector3(48, 5.5f, 53),
new Vector3(52, 5, 50),
new Vector3(45, 5, 55),
new Vector3(46, 5, 61),
new Vector3(52, 5, 50),
new Vector3(50, 5, 62),
new Vector3(43, 4.5f, 58),
new Vector3(43, 4.5f, 53),
new Vector3(52, 4, 46),
new Vector3(60, 4, 65),
new Vector3(54, 4, 66),
new Vector3(41, 4, 55),
new Vector3(41, 4, 56),
new Vector3(42, 4, 65),
new Vector3(55, 3.5f, 68),
new Vector3(40, 3.5f, 45),
new Vector3(54, 3.5f, 68),
new Vector3(48, 3.5f, 68),
new Vector3(40, 3.5f, 67),
new Vector3(62, 3.5f, 67),
new Vector3(64, 3, 43),
new Vector3(64, 3, 69),
new Vector3(37, 3, 54),
new Vector3(37, 3, 55),
new Vector3(67, 2.5f, 55),
new Vector3(67, 2.5f, 62),
new Vector3(36, 2.5f, 41),
new Vector3(67, 2, 38),
new Vector3(67, 2, 39),
new Vector3(67, 2, 40),
new Vector3(68, 2, 38),
new Vector3(68, 2, 39),
new Vector3(68, 2, 40),
new Vector3(69, 2, 38),
new Vector3(69, 2, 39),
new Vector3(69, 2, 40),
new Vector3(49, 2, 37),
new Vector3(49, 2, 38),
new Vector3(49, 2, 39),
new Vector3(50, 2, 37),
new Vector3(50, 2, 38),
new Vector3(50, 2, 39),
new Vector3(51, 2, 37),
new Vector3(51, 2, 38),
new Vector3(51, 2, 39),
new Vector3(68, 2, 59),
new Vector3(68, 2, 60),
new Vector3(68, 2, 61),
new Vector3(69, 2, 59),
new Vector3(69, 2, 60),
new Vector3(69, 2, 61),
new Vector3(70, 2, 59),
new Vector3(70, 2, 60),
new Vector3(70, 2, 61),
new Vector3(67, 2, 72),
new Vector3(67, 2, 73),
new Vector3(67, 2, 74),
new Vector3(68, 2, 72),
new Vector3(68, 2, 73),
new Vector3(68, 2, 74),
new Vector3(69, 2, 72),
new Vector3(69, 2, 73),
new Vector3(69, 2, 74),
new Vector3(33, 2, 72),
new Vector3(33, 2, 73),
new Vector3(33, 2, 74),
new Vector3(34, 2, 72),
new Vector3(34, 2, 73),
new Vector3(34, 2, 74),
new Vector3(35, 2, 72),
new Vector3(35, 2, 73),
new Vector3(35, 2, 74),
new Vector3(68, 2, 62),
new Vector3(68, 2, 63),
new Vector3(68, 2, 64),
new Vector3(69, 2, 62),
new Vector3(69, 2, 63),
new Vector3(69, 2, 64),
new Vector3(70, 2, 62),
new Vector3(70, 2, 63),
new Vector3(70, 2, 64),
new Vector3(67, 2, 38),
new Vector3(67, 2, 39),
new Vector3(67, 2, 40),
new Vector3(68, 2, 38),
new Vector3(68, 2, 39),
new Vector3(68, 2, 40),
new Vector3(69, 2, 38),
new Vector3(69, 2, 39),
new Vector3(69, 2, 40),
new Vector3(49, 2, 37),
new Vector3(49, 2, 38),
new Vector3(49, 2, 39),
new Vector3(50, 2, 37),
new Vector3(50, 2, 38),
new Vector3(50, 2, 39),
new Vector3(51, 2, 37),
new Vector3(51, 2, 38),
new Vector3(51, 2, 39),
new Vector3(30, 1.5f, 61),
new Vector3(30, 1.5f, 62),
new Vector3(30, 1.5f, 63),
new Vector3(31, 1.5f, 61),
new Vector3(31, 1.5f, 62),
new Vector3(31, 1.5f, 63),
new Vector3(32, 1.5f, 61),
new Vector3(32, 1.5f, 62),
new Vector3(32, 1.5f, 63),
new Vector3(69, 1.5f, 36),
new Vector3(69, 1.5f, 37),
new Vector3(69, 1.5f, 38),
new Vector3(70, 1.5f, 36),
new Vector3(70, 1.5f, 37),
new Vector3(70, 1.5f, 38),
new Vector3(71, 1.5f, 36),
new Vector3(71, 1.5f, 37),
new Vector3(71, 1.5f, 38),
new Vector3(30, 1.5f, 49),
new Vector3(30, 1.5f, 50),
new Vector3(30, 1.5f, 51),
new Vector3(31, 1.5f, 49),
new Vector3(31, 1.5f, 50),
new Vector3(31, 1.5f, 51),
new Vector3(32, 1.5f, 49),
new Vector3(32, 1.5f, 50),
new Vector3(32, 1.5f, 51),
new Vector3(69, 1.5f, 74),
new Vector3(69, 1.5f, 75),
new Vector3(69, 1.5f, 76),
new Vector3(70, 1.5f, 74),
new Vector3(70, 1.5f, 75),
new Vector3(70, 1.5f, 76),
new Vector3(71, 1.5f, 74),
new Vector3(71, 1.5f, 75),
new Vector3(71, 1.5f, 76),
new Vector3(69, 1.5f, 74),
new Vector3(69, 1.5f, 75),
new Vector3(69, 1.5f, 76),
new Vector3(70, 1.5f, 74),
new Vector3(70, 1.5f, 75),
new Vector3(70, 1.5f, 76),
new Vector3(71, 1.5f, 74),
new Vector3(71, 1.5f, 75),
new Vector3(71, 1.5f, 76),
new Vector3(46, 1.5f, 75),
new Vector3(46, 1.5f, 76),
new Vector3(46, 1.5f, 77),
new Vector3(47, 1.5f, 75),
new Vector3(47, 1.5f, 76),
new Vector3(47, 1.5f, 77),
new Vector3(48, 1.5f, 75),
new Vector3(48, 1.5f, 76),
new Vector3(48, 1.5f, 77),
new Vector3(31, 1.5f, 36),
new Vector3(31, 1.5f, 37),
new Vector3(31, 1.5f, 38),
new Vector3(32, 1.5f, 36),
new Vector3(32, 1.5f, 37),
new Vector3(32, 1.5f, 38),
new Vector3(33, 1.5f, 36),
new Vector3(33, 1.5f, 37),
new Vector3(33, 1.5f, 38),
new Vector3(52, 1.5f, 75),
new Vector3(52, 1.5f, 76),
new Vector3(52, 1.5f, 77),
new Vector3(53, 1.5f, 75),
new Vector3(53, 1.5f, 76),
new Vector3(53, 1.5f, 77),
new Vector3(54, 1.5f, 75),
new Vector3(54, 1.5f, 76),
new Vector3(54, 1.5f, 77),
new Vector3(28, 1, 33),
new Vector3(28, 1, 34),
new Vector3(28, 1, 35),
new Vector3(28, 1, 36),
new Vector3(28, 1, 37),
new Vector3(29, 1, 33),
new Vector3(29, 1, 34),
new Vector3(29, 1, 35),
new Vector3(29, 1, 36),
new Vector3(29, 1, 37),
new Vector3(30, 1, 33),
new Vector3(30, 1, 34),
new Vector3(30, 1, 35),
new Vector3(30, 1, 36),
new Vector3(30, 1, 37),
new Vector3(31, 1, 33),
new Vector3(31, 1, 34),
new Vector3(31, 1, 35),
new Vector3(31, 1, 36),
new Vector3(31, 1, 37),
new Vector3(32, 1, 33),
new Vector3(32, 1, 34),
new Vector3(32, 1, 35),
new Vector3(32, 1, 36),
new Vector3(32, 1, 37),
new Vector3(44, 1, 76),
new Vector3(44, 1, 77),
new Vector3(44, 1, 78),
new Vector3(44, 1, 79),
new Vector3(44, 1, 80),
new Vector3(45, 1, 76),
new Vector3(45, 1, 77),
new Vector3(45, 1, 78),
new Vector3(45, 1, 79),
new Vector3(45, 1, 80),
new Vector3(46, 1, 76),
new Vector3(46, 1, 77),
new Vector3(46, 1, 78),
new Vector3(46, 1, 79),
new Vector3(46, 1, 80),
new Vector3(47, 1, 76),
new Vector3(47, 1, 77),
new Vector3(47, 1, 78),
new Vector3(47, 1, 79),
new Vector3(47, 1, 80),
new Vector3(48, 1, 76),
new Vector3(48, 1, 77),
new Vector3(48, 1, 78),
new Vector3(48, 1, 79),
new Vector3(48, 1, 80),
new Vector3(27, 1, 44),
new Vector3(27, 1, 45),
new Vector3(27, 1, 46),
new Vector3(27, 1, 47),
new Vector3(27, 1, 48),
new Vector3(28, 1, 44),
new Vector3(28, 1, 45),
new Vector3(28, 1, 46),
new Vector3(28, 1, 47),
new Vector3(28, 1, 48),
new Vector3(29, 1, 44),
new Vector3(29, 1, 45),
new Vector3(29, 1, 46),
new Vector3(29, 1, 47),
new Vector3(29, 1, 48),
new Vector3(30, 1, 44),
new Vector3(30, 1, 45),
new Vector3(30, 1, 46),
new Vector3(30, 1, 47),
new Vector3(30, 1, 48),
new Vector3(31, 1, 44),
new Vector3(31, 1, 45),
new Vector3(31, 1, 46),
new Vector3(31, 1, 47),
new Vector3(31, 1, 48),
new Vector3(28, 1, 33),
new Vector3(28, 1, 34),
new Vector3(28, 1, 35),
new Vector3(28, 1, 36),
new Vector3(28, 1, 37),
new Vector3(29, 1, 33),
new Vector3(29, 1, 34),
new Vector3(29, 1, 35),
new Vector3(29, 1, 36),
new Vector3(29, 1, 37),
new Vector3(30, 1, 33),
new Vector3(30, 1, 34),
new Vector3(30, 1, 35),
new Vector3(30, 1, 36),
new Vector3(30, 1, 37),
new Vector3(31, 1, 33),
new Vector3(31, 1, 34),
new Vector3(31, 1, 35),
new Vector3(31, 1, 36),
new Vector3(31, 1, 37),
new Vector3(32, 1, 33),
new Vector3(32, 1, 34),
new Vector3(32, 1, 35),
new Vector3(32, 1, 36),
new Vector3(32, 1, 37),
new Vector3(44, 1, 32),
new Vector3(44, 1, 33),
new Vector3(44, 1, 34),
new Vector3(44, 1, 35),
new Vector3(44, 1, 36),
new Vector3(45, 1, 32),
new Vector3(45, 1, 33),
new Vector3(45, 1, 34),
new Vector3(45, 1, 35),
new Vector3(45, 1, 36),
new Vector3(46, 1, 32),
new Vector3(46, 1, 33),
new Vector3(46, 1, 34),
new Vector3(46, 1, 35),
new Vector3(46, 1, 36),
new Vector3(47, 1, 32),
new Vector3(47, 1, 33),
new Vector3(47, 1, 34),
new Vector3(47, 1, 35),
new Vector3(47, 1, 36),
new Vector3(48, 1, 32),
new Vector3(48, 1, 33),
new Vector3(48, 1, 34),
new Vector3(48, 1, 35),
new Vector3(48, 1, 36),
new Vector3(56, 1, 32),
new Vector3(56, 1, 33),
new Vector3(56, 1, 34),
new Vector3(56, 1, 35),
new Vector3(56, 1, 36),
new Vector3(57, 1, 32),
new Vector3(57, 1, 33),
new Vector3(57, 1, 34),
new Vector3(57, 1, 35),
new Vector3(57, 1, 36),
new Vector3(58, 1, 32),
new Vector3(58, 1, 33),
new Vector3(58, 1, 34),
new Vector3(58, 1, 35),
new Vector3(58, 1, 36),
new Vector3(59, 1, 32),
new Vector3(59, 1, 33),
new Vector3(59, 1, 34),
new Vector3(59, 1, 35),
new Vector3(59, 1, 36),
new Vector3(60, 1, 32),
new Vector3(60, 1, 33),
new Vector3(60, 1, 34),
new Vector3(60, 1, 35),
new Vector3(60, 1, 36),
new Vector3(27, 1, 52),
new Vector3(27, 1, 53),
new Vector3(27, 1, 54),
new Vector3(27, 1, 55),
new Vector3(27, 1, 56),
new Vector3(28, 1, 52),
new Vector3(28, 1, 53),
new Vector3(28, 1, 54),
new Vector3(28, 1, 55),
new Vector3(28, 1, 56),
new Vector3(29, 1, 52),
new Vector3(29, 1, 53),
new Vector3(29, 1, 54),
new Vector3(29, 1, 55),
new Vector3(29, 1, 56),
new Vector3(30, 1, 52),
new Vector3(30, 1, 53),
new Vector3(30, 1, 54),
new Vector3(30, 1, 55),
new Vector3(30, 1, 56),
new Vector3(31, 1, 52),
new Vector3(31, 1, 53),
new Vector3(31, 1, 54),
new Vector3(31, 1, 55),
new Vector3(31, 1, 56),
new Vector3(46, 1, 32),
new Vector3(46, 1, 33),
new Vector3(46, 1, 34),
new Vector3(46, 1, 35),
new Vector3(46, 1, 36),
new Vector3(47, 1, 32),
new Vector3(47, 1, 33),
new Vector3(47, 1, 34),
new Vector3(47, 1, 35),
new Vector3(47, 1, 36),
new Vector3(48, 1, 32),
new Vector3(48, 1, 33),
new Vector3(48, 1, 34),
new Vector3(48, 1, 35),
new Vector3(48, 1, 36),
new Vector3(49, 1, 32),
new Vector3(49, 1, 33),
new Vector3(49, 1, 34),
new Vector3(49, 1, 35),
new Vector3(49, 1, 36),
new Vector3(50, 1, 32),
new Vector3(50, 1, 33),
new Vector3(50, 1, 34),
new Vector3(50, 1, 35),
new Vector3(50, 1, 36),
new Vector3(249, 3, 209),
new Vector3(249, 2.5f, 213),
new Vector3(242, 2, 207),
new Vector3(242, 2, 208),
new Vector3(242, 2, 209),
new Vector3(243, 2, 207),
new Vector3(243, 2, 208),
new Vector3(243, 2, 209),
new Vector3(244, 2, 207),
new Vector3(244, 2, 208),
new Vector3(244, 2, 209),
new Vector3(254, 2, 208),
new Vector3(254, 2, 209),
new Vector3(254, 2, 210),
new Vector3(255, 2, 208),
new Vector3(255, 2, 209),
new Vector3(255, 2, 210),
new Vector3(256, 2, 208),
new Vector3(256, 2, 209),
new Vector3(256, 2, 210),
new Vector3(248, 2, 214),
new Vector3(248, 2, 215),
new Vector3(248, 2, 216),
new Vector3(249, 2, 214),
new Vector3(249, 2, 215),
new Vector3(249, 2, 216),
new Vector3(250, 2, 214),
new Vector3(250, 2, 215),
new Vector3(250, 2, 216),
new Vector3(247, 1.5f, 216),
new Vector3(247, 1.5f, 217),
new Vector3(247, 1.5f, 218),
new Vector3(248, 1.5f, 216),
new Vector3(248, 1.5f, 217),
new Vector3(248, 1.5f, 218),
new Vector3(249, 1.5f, 216),
new Vector3(249, 1.5f, 217),
new Vector3(249, 1.5f, 218),
new Vector3(237, 1, 207),
new Vector3(237, 1, 208),
new Vector3(237, 1, 209),
new Vector3(237, 1, 210),
new Vector3(237, 1, 211),
new Vector3(238, 1, 207),
new Vector3(238, 1, 208),
new Vector3(238, 1, 209),
new Vector3(238, 1, 210),
new Vector3(238, 1, 211),
new Vector3(239, 1, 207),
new Vector3(239, 1, 208),
new Vector3(239, 1, 209),
new Vector3(239, 1, 210),
new Vector3(239, 1, 211),
new Vector3(240, 1, 207),
new Vector3(240, 1, 208),
new Vector3(240, 1, 209),
new Vector3(240, 1, 210),
new Vector3(240, 1, 211),
new Vector3(241, 1, 207),
new Vector3(241, 1, 208),
new Vector3(241, 1, 209),
new Vector3(241, 1, 210),
new Vector3(241, 1, 211),
new Vector3(244, 1, 197),
new Vector3(244, 1, 198),
new Vector3(244, 1, 199),
new Vector3(244, 1, 200),
new Vector3(244, 1, 201),
new Vector3(245, 1, 197),
new Vector3(245, 1, 198),
new Vector3(245, 1, 199),
new Vector3(245, 1, 200),
new Vector3(245, 1, 201),
new Vector3(246, 1, 197),
new Vector3(246, 1, 198),
new Vector3(246, 1, 199),
new Vector3(246, 1, 200),
new Vector3(246, 1, 201),
new Vector3(247, 1, 197),
new Vector3(247, 1, 198),
new Vector3(247, 1, 199),
new Vector3(247, 1, 200),
new Vector3(247, 1, 201),
new Vector3(248, 1, 197),
new Vector3(248, 1, 198),
new Vector3(248, 1, 199),
new Vector3(248, 1, 200),
new Vector3(248, 1, 201),
new Vector3(243, 1, 197),
new Vector3(243, 1, 198),
new Vector3(243, 1, 199),
new Vector3(243, 1, 200),
new Vector3(243, 1, 201),
new Vector3(244, 1, 197),
new Vector3(244, 1, 198),
new Vector3(244, 1, 199),
new Vector3(244, 1, 200),
new Vector3(244, 1, 201),
new Vector3(245, 1, 197),
new Vector3(245, 1, 198),
new Vector3(245, 1, 199),
new Vector3(245, 1, 200),
new Vector3(245, 1, 201),
new Vector3(246, 1, 197),
new Vector3(246, 1, 198),
new Vector3(246, 1, 199),
new Vector3(246, 1, 200),
new Vector3(246, 1, 201),
new Vector3(247, 1, 197),
new Vector3(247, 1, 198),
new Vector3(247, 1, 199),
new Vector3(247, 1, 200),
new Vector3(247, 1, 201),
new Vector3(243, 1, 197),
new Vector3(243, 1, 198),
new Vector3(243, 1, 199),
new Vector3(243, 1, 200),
new Vector3(243, 1, 201),
new Vector3(244, 1, 197),
new Vector3(244, 1, 198),
new Vector3(244, 1, 199),
new Vector3(244, 1, 200),
new Vector3(244, 1, 201),
new Vector3(245, 1, 197),
new Vector3(245, 1, 198),
new Vector3(245, 1, 199),
new Vector3(245, 1, 200),
new Vector3(245, 1, 201),
new Vector3(246, 1, 197),
new Vector3(246, 1, 198),
new Vector3(246, 1, 199),
new Vector3(246, 1, 200),
new Vector3(246, 1, 201),
new Vector3(247, 1, 197),
new Vector3(247, 1, 198),
new Vector3(247, 1, 199),
new Vector3(247, 1, 200),
new Vector3(247, 1, 201),
new Vector3(237, 1, 205),
new Vector3(237, 1, 206),
new Vector3(237, 1, 207),
new Vector3(237, 1, 208),
new Vector3(237, 1, 209),
new Vector3(238, 1, 205),
new Vector3(238, 1, 206),
new Vector3(238, 1, 207),
new Vector3(238, 1, 208),
new Vector3(238, 1, 209),
new Vector3(239, 1, 205),
new Vector3(239, 1, 206),
new Vector3(239, 1, 207),
new Vector3(239, 1, 208),
new Vector3(239, 1, 209),
new Vector3(240, 1, 205),
new Vector3(240, 1, 206),
new Vector3(240, 1, 207),
new Vector3(240, 1, 208),
new Vector3(240, 1, 209),
new Vector3(241, 1, 205),
new Vector3(241, 1, 206),
new Vector3(241, 1, 207),
new Vector3(241, 1, 208),
new Vector3(241, 1, 209),
new Vector3(24, 6, 277),
new Vector3(24, 5.5f, 281),
new Vector3(23, 5.5f, 281),
new Vector3(28, 5.5f, 277),
new Vector3(27, 5.5f, 280),
new Vector3(18, 5, 275),
new Vector3(23, 5, 283),
new Vector3(16, 4.5f, 274),
new Vector3(17, 4.5f, 270),
new Vector3(34, 4, 279),
new Vector3(15, 4, 286),
new Vector3(15, 4, 286),
new Vector3(33, 4, 268),
new Vector3(14, 4, 280),
new Vector3(14, 4, 277),
new Vector3(35, 3.5f, 266),
new Vector3(20, 3.5f, 289),
new Vector3(35, 3.5f, 288),
new Vector3(26, 3.5f, 265),
new Vector3(36, 3.5f, 274),
new Vector3(13, 3.5f, 288),
new Vector3(29, 3, 263),
new Vector3(38, 3, 282),
new Vector3(37, 3, 264),
new Vector3(38, 3, 278),
new Vector3(10, 3, 277),
new Vector3(37, 3, 264),
new Vector3(11, 3, 290),
new Vector3(25, 2.5f, 293),
new Vector3(8, 2.5f, 281),
new Vector3(8, 2.5f, 281),
new Vector3(5, 2, 283),
new Vector3(5, 2, 284),
new Vector3(5, 2, 285),
new Vector3(6, 2, 283),
new Vector3(6, 2, 284),
new Vector3(6, 2, 285),
new Vector3(7, 2, 283),
new Vector3(7, 2, 284),
new Vector3(7, 2, 285),
new Vector3(15, 2, 258),
new Vector3(15, 2, 259),
new Vector3(15, 2, 260),
new Vector3(16, 2, 258),
new Vector3(16, 2, 259),
new Vector3(16, 2, 260),
new Vector3(17, 2, 258),
new Vector3(17, 2, 259),
new Vector3(17, 2, 260),
new Vector3(40, 2, 259),
new Vector3(40, 2, 260),
new Vector3(40, 2, 261),
new Vector3(41, 2, 259),
new Vector3(41, 2, 260),
new Vector3(41, 2, 261),
new Vector3(42, 2, 259),
new Vector3(42, 2, 260),
new Vector3(42, 2, 261),
new Vector3(28, 2, 294),
new Vector3(28, 2, 295),
new Vector3(28, 2, 296),
new Vector3(29, 2, 294),
new Vector3(29, 2, 295),
new Vector3(29, 2, 296),
new Vector3(30, 2, 294),
new Vector3(30, 2, 295),
new Vector3(30, 2, 296),
new Vector3(4, 1.5f, 295),
new Vector3(4, 1.5f, 296),
new Vector3(4, 1.5f, 297),
new Vector3(5, 1.5f, 295),
new Vector3(5, 1.5f, 296),
new Vector3(5, 1.5f, 297),
new Vector3(6, 1.5f, 295),
new Vector3(6, 1.5f, 296),
new Vector3(6, 1.5f, 297),
new Vector3(26, 1.5f, 256),
new Vector3(26, 1.5f, 257),
new Vector3(26, 1.5f, 258),
new Vector3(27, 1.5f, 256),
new Vector3(27, 1.5f, 257),
new Vector3(27, 1.5f, 258),
new Vector3(28, 1.5f, 256),
new Vector3(28, 1.5f, 257),
new Vector3(28, 1.5f, 258),
new Vector3(43, 1.5f, 274),
new Vector3(43, 1.5f, 275),
new Vector3(43, 1.5f, 276),
new Vector3(44, 1.5f, 274),
new Vector3(44, 1.5f, 275),
new Vector3(44, 1.5f, 276),
new Vector3(45, 1.5f, 274),
new Vector3(45, 1.5f, 275),
new Vector3(45, 1.5f, 276),
new Vector3(42, 1.5f, 257),
new Vector3(42, 1.5f, 258),
new Vector3(42, 1.5f, 259),
new Vector3(43, 1.5f, 257),
new Vector3(43, 1.5f, 258),
new Vector3(43, 1.5f, 259),
new Vector3(44, 1.5f, 257),
new Vector3(44, 1.5f, 258),
new Vector3(44, 1.5f, 259),
new Vector3(43, 1.5f, 280),
new Vector3(43, 1.5f, 281),
new Vector3(43, 1.5f, 282),
new Vector3(44, 1.5f, 280),
new Vector3(44, 1.5f, 281),
new Vector3(44, 1.5f, 282),
new Vector3(45, 1.5f, 280),
new Vector3(45, 1.5f, 281),
new Vector3(45, 1.5f, 282),
new Vector3(43, 1.5f, 280),
new Vector3(43, 1.5f, 281),
new Vector3(43, 1.5f, 282),
new Vector3(44, 1.5f, 280),
new Vector3(44, 1.5f, 281),
new Vector3(44, 1.5f, 282),
new Vector3(45, 1.5f, 280),
new Vector3(45, 1.5f, 281),
new Vector3(45, 1.5f, 282),
new Vector3(3, 1.5f, 277),
new Vector3(3, 1.5f, 278),
new Vector3(3, 1.5f, 279),
new Vector3(4, 1.5f, 277),
new Vector3(4, 1.5f, 278),
new Vector3(4, 1.5f, 279),
new Vector3(5, 1.5f, 277),
new Vector3(5, 1.5f, 278),
new Vector3(5, 1.5f, 279),
new Vector3(42, 1.5f, 257),
new Vector3(42, 1.5f, 258),
new Vector3(42, 1.5f, 259),
new Vector3(43, 1.5f, 257),
new Vector3(43, 1.5f, 258),
new Vector3(43, 1.5f, 259),
new Vector3(44, 1.5f, 257),
new Vector3(44, 1.5f, 258),
new Vector3(44, 1.5f, 259),
new Vector3(43, 1.5f, 280),
new Vector3(43, 1.5f, 281),
new Vector3(43, 1.5f, 282),
new Vector3(44, 1.5f, 280),
new Vector3(44, 1.5f, 281),
new Vector3(44, 1.5f, 282),
new Vector3(45, 1.5f, 280),
new Vector3(45, 1.5f, 281),
new Vector3(45, 1.5f, 282),
new Vector3(43, 1, 254),
new Vector3(43, 1, 255),
new Vector3(43, 1, 256),
new Vector3(43, 1, 257),
new Vector3(43, 1, 258),
new Vector3(44, 1, 254),
new Vector3(44, 1, 255),
new Vector3(44, 1, 256),
new Vector3(44, 1, 257),
new Vector3(44, 1, 258),
new Vector3(45, 1, 254),
new Vector3(45, 1, 255),
new Vector3(45, 1, 256),
new Vector3(45, 1, 257),
new Vector3(45, 1, 258),
new Vector3(46, 1, 254),
new Vector3(46, 1, 255),
new Vector3(46, 1, 256),
new Vector3(46, 1, 257),
new Vector3(46, 1, 258),
new Vector3(47, 1, 254),
new Vector3(47, 1, 255),
new Vector3(47, 1, 256),
new Vector3(47, 1, 257),
new Vector3(47, 1, 258),
new Vector3(44, 1, 275),
new Vector3(44, 1, 276),
new Vector3(44, 1, 277),
new Vector3(44, 1, 278),
new Vector3(44, 1, 279),
new Vector3(45, 1, 275),
new Vector3(45, 1, 276),
new Vector3(45, 1, 277),
new Vector3(45, 1, 278),
new Vector3(45, 1, 279),
new Vector3(46, 1, 275),
new Vector3(46, 1, 276),
new Vector3(46, 1, 277),
new Vector3(46, 1, 278),
new Vector3(46, 1, 279),
new Vector3(47, 1, 275),
new Vector3(47, 1, 276),
new Vector3(47, 1, 277),
new Vector3(47, 1, 278),
new Vector3(47, 1, 279),
new Vector3(48, 1, 275),
new Vector3(48, 1, 276),
new Vector3(48, 1, 277),
new Vector3(48, 1, 278),
new Vector3(48, 1, 279),
new Vector3(44, 1, 276),
new Vector3(44, 1, 277),
new Vector3(44, 1, 278),
new Vector3(44, 1, 279),
new Vector3(44, 1, 280),
new Vector3(45, 1, 276),
new Vector3(45, 1, 277),
new Vector3(45, 1, 278),
new Vector3(45, 1, 279),
new Vector3(45, 1, 280),
new Vector3(46, 1, 276),
new Vector3(46, 1, 277),
new Vector3(46, 1, 278),
new Vector3(46, 1, 279),
new Vector3(46, 1, 280),
new Vector3(47, 1, 276),
new Vector3(47, 1, 277),
new Vector3(47, 1, 278),
new Vector3(47, 1, 279),
new Vector3(47, 1, 280),
new Vector3(48, 1, 276),
new Vector3(48, 1, 277),
new Vector3(48, 1, 278),
new Vector3(48, 1, 279),
new Vector3(48, 1, 280),
new Vector3(26, 1, 253),
new Vector3(26, 1, 254),
new Vector3(26, 1, 255),
new Vector3(26, 1, 256),
new Vector3(26, 1, 257),
new Vector3(27, 1, 253),
new Vector3(27, 1, 254),
new Vector3(27, 1, 255),
new Vector3(27, 1, 256),
new Vector3(27, 1, 257),
new Vector3(28, 1, 253),
new Vector3(28, 1, 254),
new Vector3(28, 1, 255),
new Vector3(28, 1, 256),
new Vector3(28, 1, 257),
new Vector3(29, 1, 253),
new Vector3(29, 1, 254),
new Vector3(29, 1, 255),
new Vector3(29, 1, 256),
new Vector3(29, 1, 257),
new Vector3(30, 1, 253),
new Vector3(30, 1, 254),
new Vector3(30, 1, 255),
new Vector3(30, 1, 256),
new Vector3(30, 1, 257),
new Vector3(43, 1, 254),
new Vector3(43, 1, 255),
new Vector3(43, 1, 256),
new Vector3(43, 1, 257),
new Vector3(43, 1, 258),
new Vector3(44, 1, 254),
new Vector3(44, 1, 255),
new Vector3(44, 1, 256),
new Vector3(44, 1, 257),
new Vector3(44, 1, 258),
new Vector3(45, 1, 254),
new Vector3(45, 1, 255),
new Vector3(45, 1, 256),
new Vector3(45, 1, 257),
new Vector3(45, 1, 258),
new Vector3(46, 1, 254),
new Vector3(46, 1, 255),
new Vector3(46, 1, 256),
new Vector3(46, 1, 257),
new Vector3(46, 1, 258),
new Vector3(47, 1, 254),
new Vector3(47, 1, 255),
new Vector3(47, 1, 256),
new Vector3(47, 1, 257),
new Vector3(47, 1, 258),
new Vector3(43, 1, 254),
new Vector3(43, 1, 255),
new Vector3(43, 1, 256),
new Vector3(43, 1, 257),
new Vector3(43, 1, 258),
new Vector3(44, 1, 254),
new Vector3(44, 1, 255),
new Vector3(44, 1, 256),
new Vector3(44, 1, 257),
new Vector3(44, 1, 258),
new Vector3(45, 1, 254),
new Vector3(45, 1, 255),
new Vector3(45, 1, 256),
new Vector3(45, 1, 257),
new Vector3(45, 1, 258),
new Vector3(46, 1, 254),
new Vector3(46, 1, 255),
new Vector3(46, 1, 256),
new Vector3(46, 1, 257),
new Vector3(46, 1, 258),
new Vector3(47, 1, 254),
new Vector3(47, 1, 255),
new Vector3(47, 1, 256),
new Vector3(47, 1, 257),
new Vector3(47, 1, 258),
new Vector3(236, 7, 124),
new Vector3(240, 6.5f, 124),
new Vector3(239, 6.5f, 121),
new Vector3(239, 6.5f, 127),
new Vector3(236, 6.5f, 128),
new Vector3(231, 6, 129),
new Vector3(236, 5.5f, 116),
new Vector3(248, 4.5f, 127),
new Vector3(239, 4.5f, 136),
new Vector3(222, 4, 126),
new Vector3(250, 4, 122),
new Vector3(231, 4, 138),
new Vector3(249, 4, 137),
new Vector3(250, 4, 122),
new Vector3(237, 4, 110),
new Vector3(252, 3.5f, 123),
new Vector3(251, 3.5f, 109),
new Vector3(252, 3.5f, 124),
new Vector3(220, 3.5f, 118),
new Vector3(251, 3.5f, 139),
new Vector3(236, 3.5f, 140),
new Vector3(251, 3.5f, 109),
new Vector3(218, 3, 128),
new Vector3(253, 3, 107),
new Vector3(253, 3, 141),
new Vector3(253, 3, 141),
new Vector3(256, 2.5f, 126),
new Vector3(214, 2, 102),
new Vector3(214, 2, 103),
new Vector3(214, 2, 104),
new Vector3(215, 2, 102),
new Vector3(215, 2, 103),
new Vector3(215, 2, 104),
new Vector3(216, 2, 102),
new Vector3(216, 2, 103),
new Vector3(216, 2, 104),
new Vector3(214, 2, 144),
new Vector3(214, 2, 145),
new Vector3(214, 2, 146),
new Vector3(215, 2, 144),
new Vector3(215, 2, 145),
new Vector3(215, 2, 146),
new Vector3(216, 2, 144),
new Vector3(216, 2, 145),
new Vector3(216, 2, 146),
new Vector3(256, 2, 144),
new Vector3(256, 2, 145),
new Vector3(256, 2, 146),
new Vector3(257, 2, 144),
new Vector3(257, 2, 145),
new Vector3(257, 2, 146),
new Vector3(258, 2, 144),
new Vector3(258, 2, 145),
new Vector3(258, 2, 146),
new Vector3(244, 2, 145),
new Vector3(244, 2, 146),
new Vector3(244, 2, 147),
new Vector3(245, 2, 145),
new Vector3(245, 2, 146),
new Vector3(245, 2, 147),
new Vector3(246, 2, 145),
new Vector3(246, 2, 146),
new Vector3(246, 2, 147),
new Vector3(226, 2, 145),
new Vector3(226, 2, 146),
new Vector3(226, 2, 147),
new Vector3(227, 2, 145),
new Vector3(227, 2, 146),
new Vector3(227, 2, 147),
new Vector3(228, 2, 145),
new Vector3(228, 2, 146),
new Vector3(228, 2, 147),
new Vector3(214, 2, 102),
new Vector3(214, 2, 103),
new Vector3(214, 2, 104),
new Vector3(215, 2, 102),
new Vector3(215, 2, 103),
new Vector3(215, 2, 104),
new Vector3(216, 2, 102),
new Vector3(216, 2, 103),
new Vector3(216, 2, 104),
new Vector3(214, 2, 144),
new Vector3(214, 2, 145),
new Vector3(214, 2, 146),
new Vector3(215, 2, 144),
new Vector3(215, 2, 145),
new Vector3(215, 2, 146),
new Vector3(216, 2, 144),
new Vector3(216, 2, 145),
new Vector3(216, 2, 146),
new Vector3(256, 2, 102),
new Vector3(256, 2, 103),
new Vector3(256, 2, 104),
new Vector3(257, 2, 102),
new Vector3(257, 2, 103),
new Vector3(257, 2, 104),
new Vector3(258, 2, 102),
new Vector3(258, 2, 103),
new Vector3(258, 2, 104),
new Vector3(258, 1.5f, 146),
new Vector3(258, 1.5f, 147),
new Vector3(258, 1.5f, 148),
new Vector3(259, 1.5f, 146),
new Vector3(259, 1.5f, 147),
new Vector3(259, 1.5f, 148),
new Vector3(260, 1.5f, 146),
new Vector3(260, 1.5f, 147),
new Vector3(260, 1.5f, 148),
new Vector3(212, 1.5f, 146),
new Vector3(212, 1.5f, 147),
new Vector3(212, 1.5f, 148),
new Vector3(213, 1.5f, 146),
new Vector3(213, 1.5f, 147),
new Vector3(213, 1.5f, 148),
new Vector3(214, 1.5f, 146),
new Vector3(214, 1.5f, 147),
new Vector3(214, 1.5f, 148),
new Vector3(212, 1.5f, 100),
new Vector3(212, 1.5f, 101),
new Vector3(212, 1.5f, 102),
new Vector3(213, 1.5f, 100),
new Vector3(213, 1.5f, 101),
new Vector3(213, 1.5f, 102),
new Vector3(214, 1.5f, 100),
new Vector3(214, 1.5f, 101),
new Vector3(214, 1.5f, 102),
new Vector3(259, 1.5f, 128),
new Vector3(259, 1.5f, 129),
new Vector3(259, 1.5f, 130),
new Vector3(260, 1.5f, 128),
new Vector3(260, 1.5f, 129),
new Vector3(260, 1.5f, 130),
new Vector3(261, 1.5f, 128),
new Vector3(261, 1.5f, 129),
new Vector3(261, 1.5f, 130),
new Vector3(211, 1.5f, 123),
new Vector3(211, 1.5f, 124),
new Vector3(211, 1.5f, 125),
new Vector3(212, 1.5f, 123),
new Vector3(212, 1.5f, 124),
new Vector3(212, 1.5f, 125),
new Vector3(213, 1.5f, 123),
new Vector3(213, 1.5f, 124),
new Vector3(213, 1.5f, 125),
new Vector3(258, 1.5f, 146),
new Vector3(258, 1.5f, 147),
new Vector3(258, 1.5f, 148),
new Vector3(259, 1.5f, 146),
new Vector3(259, 1.5f, 147),
new Vector3(259, 1.5f, 148),
new Vector3(260, 1.5f, 146),
new Vector3(260, 1.5f, 147),
new Vector3(260, 1.5f, 148),
new Vector3(231, 1.5f, 147),
new Vector3(231, 1.5f, 148),
new Vector3(231, 1.5f, 149),
new Vector3(232, 1.5f, 147),
new Vector3(232, 1.5f, 148),
new Vector3(232, 1.5f, 149),
new Vector3(233, 1.5f, 147),
new Vector3(233, 1.5f, 148),
new Vector3(233, 1.5f, 149),
new Vector3(212, 1.5f, 100),
new Vector3(212, 1.5f, 101),
new Vector3(212, 1.5f, 102),
new Vector3(213, 1.5f, 100),
new Vector3(213, 1.5f, 101),
new Vector3(213, 1.5f, 102),
new Vector3(214, 1.5f, 100),
new Vector3(214, 1.5f, 101),
new Vector3(214, 1.5f, 102),
new Vector3(211, 1.5f, 129),
new Vector3(211, 1.5f, 130),
new Vector3(211, 1.5f, 131),
new Vector3(212, 1.5f, 129),
new Vector3(212, 1.5f, 130),
new Vector3(212, 1.5f, 131),
new Vector3(213, 1.5f, 129),
new Vector3(213, 1.5f, 130),
new Vector3(213, 1.5f, 131),
new Vector3(212, 1.5f, 146),
new Vector3(212, 1.5f, 147),
new Vector3(212, 1.5f, 148),
new Vector3(213, 1.5f, 146),
new Vector3(213, 1.5f, 147),
new Vector3(213, 1.5f, 148),
new Vector3(214, 1.5f, 146),
new Vector3(214, 1.5f, 147),
new Vector3(214, 1.5f, 148),
new Vector3(227, 1.5f, 147),
new Vector3(227, 1.5f, 148),
new Vector3(227, 1.5f, 149),
new Vector3(228, 1.5f, 147),
new Vector3(228, 1.5f, 148),
new Vector3(228, 1.5f, 149),
new Vector3(229, 1.5f, 147),
new Vector3(229, 1.5f, 148),
new Vector3(229, 1.5f, 149),
new Vector3(245, 1.5f, 147),
new Vector3(245, 1.5f, 148),
new Vector3(245, 1.5f, 149),
new Vector3(246, 1.5f, 147),
new Vector3(246, 1.5f, 148),
new Vector3(246, 1.5f, 149),
new Vector3(247, 1.5f, 147),
new Vector3(247, 1.5f, 148),
new Vector3(247, 1.5f, 149),
new Vector3(258, 1.5f, 146),
new Vector3(258, 1.5f, 147),
new Vector3(258, 1.5f, 148),
new Vector3(259, 1.5f, 146),
new Vector3(259, 1.5f, 147),
new Vector3(259, 1.5f, 148),
new Vector3(260, 1.5f, 146),
new Vector3(260, 1.5f, 147),
new Vector3(260, 1.5f, 148),
new Vector3(211, 1.5f, 114),
new Vector3(211, 1.5f, 115),
new Vector3(211, 1.5f, 116),
new Vector3(212, 1.5f, 114),
new Vector3(212, 1.5f, 115),
new Vector3(212, 1.5f, 116),
new Vector3(213, 1.5f, 114),
new Vector3(213, 1.5f, 115),
new Vector3(213, 1.5f, 116),
new Vector3(260, 1, 127),
new Vector3(260, 1, 128),
new Vector3(260, 1, 129),
new Vector3(260, 1, 130),
new Vector3(260, 1, 131),
new Vector3(261, 1, 127),
new Vector3(261, 1, 128),
new Vector3(261, 1, 129),
new Vector3(261, 1, 130),
new Vector3(261, 1, 131),
new Vector3(262, 1, 127),
new Vector3(262, 1, 128),
new Vector3(262, 1, 129),
new Vector3(262, 1, 130),
new Vector3(262, 1, 131),
new Vector3(263, 1, 127),
new Vector3(263, 1, 128),
new Vector3(263, 1, 129),
new Vector3(263, 1, 130),
new Vector3(263, 1, 131),
new Vector3(264, 1, 127),
new Vector3(264, 1, 128),
new Vector3(264, 1, 129),
new Vector3(264, 1, 130),
new Vector3(264, 1, 131),
new Vector3(259, 1, 147),
new Vector3(259, 1, 148),
new Vector3(259, 1, 149),
new Vector3(259, 1, 150),
new Vector3(259, 1, 151),
new Vector3(260, 1, 147),
new Vector3(260, 1, 148),
new Vector3(260, 1, 149),
new Vector3(260, 1, 150),
new Vector3(260, 1, 151),
new Vector3(261, 1, 147),
new Vector3(261, 1, 148),
new Vector3(261, 1, 149),
new Vector3(261, 1, 150),
new Vector3(261, 1, 151),
new Vector3(262, 1, 147),
new Vector3(262, 1, 148),
new Vector3(262, 1, 149),
new Vector3(262, 1, 150),
new Vector3(262, 1, 151),
new Vector3(263, 1, 147),
new Vector3(263, 1, 148),
new Vector3(263, 1, 149),
new Vector3(263, 1, 150),
new Vector3(263, 1, 151),
new Vector3(239, 1, 148),
new Vector3(239, 1, 149),
new Vector3(239, 1, 150),
new Vector3(239, 1, 151),
new Vector3(239, 1, 152),
new Vector3(240, 1, 148),
new Vector3(240, 1, 149),
new Vector3(240, 1, 150),
new Vector3(240, 1, 151),
new Vector3(240, 1, 152),
new Vector3(241, 1, 148),
new Vector3(241, 1, 149),
new Vector3(241, 1, 150),
new Vector3(241, 1, 151),
new Vector3(241, 1, 152),
new Vector3(242, 1, 148),
new Vector3(242, 1, 149),
new Vector3(242, 1, 150),
new Vector3(242, 1, 151),
new Vector3(242, 1, 152),
new Vector3(243, 1, 148),
new Vector3(243, 1, 149),
new Vector3(243, 1, 150),
new Vector3(243, 1, 151),
new Vector3(243, 1, 152),
new Vector3(259, 1, 147),
new Vector3(259, 1, 148),
new Vector3(259, 1, 149),
new Vector3(259, 1, 150),
new Vector3(259, 1, 151),
new Vector3(260, 1, 147),
new Vector3(260, 1, 148),
new Vector3(260, 1, 149),
new Vector3(260, 1, 150),
new Vector3(260, 1, 151),
new Vector3(261, 1, 147),
new Vector3(261, 1, 148),
new Vector3(261, 1, 149),
new Vector3(261, 1, 150),
new Vector3(261, 1, 151),
new Vector3(262, 1, 147),
new Vector3(262, 1, 148),
new Vector3(262, 1, 149),
new Vector3(262, 1, 150),
new Vector3(262, 1, 151),
new Vector3(263, 1, 147),
new Vector3(263, 1, 148),
new Vector3(263, 1, 149),
new Vector3(263, 1, 150),
new Vector3(263, 1, 151),
new Vector3(259, 1, 97),
new Vector3(259, 1, 98),
new Vector3(259, 1, 99),
new Vector3(259, 1, 100),
new Vector3(259, 1, 101),
new Vector3(260, 1, 97),
new Vector3(260, 1, 98),
new Vector3(260, 1, 99),
new Vector3(260, 1, 100),
new Vector3(260, 1, 101),
new Vector3(261, 1, 97),
new Vector3(261, 1, 98),
new Vector3(261, 1, 99),
new Vector3(261, 1, 100),
new Vector3(261, 1, 101),
new Vector3(262, 1, 97),
new Vector3(262, 1, 98),
new Vector3(262, 1, 99),
new Vector3(262, 1, 100),
new Vector3(262, 1, 101),
new Vector3(263, 1, 97),
new Vector3(263, 1, 98),
new Vector3(263, 1, 99),
new Vector3(263, 1, 100),
new Vector3(263, 1, 101),
new Vector3(208, 1, 122),
new Vector3(208, 1, 123),
new Vector3(208, 1, 124),
new Vector3(208, 1, 125),
new Vector3(208, 1, 126),
new Vector3(209, 1, 122),
new Vector3(209, 1, 123),
new Vector3(209, 1, 124),
new Vector3(209, 1, 125),
new Vector3(209, 1, 126),
new Vector3(210, 1, 122),
new Vector3(210, 1, 123),
new Vector3(210, 1, 124),
new Vector3(210, 1, 125),
new Vector3(210, 1, 126),
new Vector3(211, 1, 122),
new Vector3(211, 1, 123),
new Vector3(211, 1, 124),
new Vector3(211, 1, 125),
new Vector3(211, 1, 126),
new Vector3(212, 1, 122),
new Vector3(212, 1, 123),
new Vector3(212, 1, 124),
new Vector3(212, 1, 125),
new Vector3(212, 1, 126),
new Vector3(260, 1, 118),
new Vector3(260, 1, 119),
new Vector3(260, 1, 120),
new Vector3(260, 1, 121),
new Vector3(260, 1, 122),
new Vector3(261, 1, 118),
new Vector3(261, 1, 119),
new Vector3(261, 1, 120),
new Vector3(261, 1, 121),
new Vector3(261, 1, 122),
new Vector3(262, 1, 118),
new Vector3(262, 1, 119),
new Vector3(262, 1, 120),
new Vector3(262, 1, 121),
new Vector3(262, 1, 122),
new Vector3(263, 1, 118),
new Vector3(263, 1, 119),
new Vector3(263, 1, 120),
new Vector3(263, 1, 121),
new Vector3(263, 1, 122),
new Vector3(264, 1, 118),
new Vector3(264, 1, 119),
new Vector3(264, 1, 120),
new Vector3(264, 1, 121),
new Vector3(264, 1, 122),
new Vector3(259, 1, 147),
new Vector3(259, 1, 148),
new Vector3(259, 1, 149),
new Vector3(259, 1, 150),
new Vector3(259, 1, 151),
new Vector3(260, 1, 147),
new Vector3(260, 1, 148),
new Vector3(260, 1, 149),
new Vector3(260, 1, 150),
new Vector3(260, 1, 151),
new Vector3(261, 1, 147),
new Vector3(261, 1, 148),
new Vector3(261, 1, 149),
new Vector3(261, 1, 150),
new Vector3(261, 1, 151),
new Vector3(262, 1, 147),
new Vector3(262, 1, 148),
new Vector3(262, 1, 149),
new Vector3(262, 1, 150),
new Vector3(262, 1, 151),
new Vector3(263, 1, 147),
new Vector3(263, 1, 148),
new Vector3(263, 1, 149),
new Vector3(263, 1, 150),
new Vector3(263, 1, 151),
new Vector3(259, 1, 147),
new Vector3(259, 1, 148),
new Vector3(259, 1, 149),
new Vector3(259, 1, 150),
new Vector3(259, 1, 151),
new Vector3(260, 1, 147),
new Vector3(260, 1, 148),
new Vector3(260, 1, 149),
new Vector3(260, 1, 150),
new Vector3(260, 1, 151),
new Vector3(261, 1, 147),
new Vector3(261, 1, 148),
new Vector3(261, 1, 149),
new Vector3(261, 1, 150),
new Vector3(261, 1, 151),
new Vector3(262, 1, 147),
new Vector3(262, 1, 148),
new Vector3(262, 1, 149),
new Vector3(262, 1, 150),
new Vector3(262, 1, 151),
new Vector3(263, 1, 147),
new Vector3(263, 1, 148),
new Vector3(263, 1, 149),
new Vector3(263, 1, 150),
new Vector3(263, 1, 151),
new Vector3(238, 7, 158),
new Vector3(238, 6.5f, 154),
new Vector3(234, 6.5f, 157),
new Vector3(241, 6.5f, 155),
new Vector3(241, 6.5f, 161),
new Vector3(234, 6.5f, 157),
new Vector3(244, 6, 156),
new Vector3(233, 6, 153),
new Vector3(238, 5.5f, 166),
new Vector3(245, 5.5f, 151),
new Vector3(238, 5.5f, 166),
new Vector3(235, 5.5f, 166),
new Vector3(246, 5.5f, 157),
new Vector3(245, 5.5f, 165),
new Vector3(228, 5, 155),
new Vector3(227, 4.5f, 147),
new Vector3(226, 4.5f, 156),
new Vector3(226, 4.5f, 153),
new Vector3(227, 4.5f, 169),
new Vector3(249, 4.5f, 147),
new Vector3(225, 4, 171),
new Vector3(224, 4, 153),
new Vector3(252, 4, 156),
new Vector3(251, 4, 171),
new Vector3(252, 4, 163),
new Vector3(252, 4, 159),
new Vector3(224, 4, 154),
new Vector3(251, 4, 171),
new Vector3(251, 4, 145),
new Vector3(234, 4, 172),
new Vector3(243, 3.5f, 174),
new Vector3(253, 3.5f, 173),
new Vector3(233, 3.5f, 174),
new Vector3(223, 3.5f, 173),
new Vector3(222, 3.5f, 151),
new Vector3(254, 3.5f, 163),
new Vector3(223, 3.5f, 173),
new Vector3(223, 3.5f, 143),
new Vector3(242, 3.5f, 174),
new Vector3(220, 3, 155),
new Vector3(256, 3, 155),
new Vector3(220, 3, 151),
new Vector3(256, 3, 151),
new Vector3(255, 3, 141),
new Vector3(221, 3, 175),
new Vector3(218, 2.5f, 164),
new Vector3(232, 2.5f, 178),
new Vector3(258, 2.5f, 153),
new Vector3(258, 2.5f, 155),
new Vector3(257, 2.5f, 139),
new Vector3(258, 2.5f, 157),
new Vector3(259, 2, 151),
new Vector3(259, 2, 152),
new Vector3(259, 2, 153),
new Vector3(260, 2, 151),
new Vector3(260, 2, 152),
new Vector3(260, 2, 153),
new Vector3(261, 2, 151),
new Vector3(261, 2, 152),
new Vector3(261, 2, 153),
new Vector3(227, 1.5f, 181),
new Vector3(227, 1.5f, 182),
new Vector3(227, 1.5f, 183),
new Vector3(228, 1.5f, 181),
new Vector3(228, 1.5f, 182),
new Vector3(228, 1.5f, 183),
new Vector3(229, 1.5f, 181),
new Vector3(229, 1.5f, 182),
new Vector3(229, 1.5f, 183),
new Vector3(261, 1.5f, 148),
new Vector3(261, 1.5f, 149),
new Vector3(261, 1.5f, 150),
new Vector3(262, 1.5f, 148),
new Vector3(263, 1.5f, 149),
new Vector3(263, 1.5f, 150),
new Vector3(214, 1.5f, 180),
new Vector3(214, 1.5f, 181),
new Vector3(214, 1.5f, 182),
new Vector3(215, 1.5f, 180),
new Vector3(215, 1.5f, 181),
new Vector3(215, 1.5f, 182),
new Vector3(216, 1.5f, 180),
new Vector3(216, 1.5f, 181),
new Vector3(216, 1.5f, 182),
new Vector3(261, 1.5f, 155),
new Vector3(261, 1.5f, 156),
new Vector3(261, 1.5f, 157),
new Vector3(262, 1.5f, 155),
new Vector3(262, 1.5f, 156),
new Vector3(262, 1.5f, 157),
new Vector3(263, 1.5f, 155),
new Vector3(263, 1.5f, 156),
new Vector3(263, 1.5f, 157),
new Vector3(262, 1, 160),
new Vector3(262, 1, 161),
new Vector3(262, 1, 162),
new Vector3(262, 1, 163),
new Vector3(262, 1, 164),
new Vector3(263, 1, 160),
new Vector3(263, 1, 161),
new Vector3(263, 1, 162),
new Vector3(263, 1, 163),
new Vector3(263, 1, 164),
new Vector3(264, 1, 160),
new Vector3(264, 1, 161),
new Vector3(264, 1, 162),
new Vector3(264, 1, 163),
new Vector3(264, 1, 164),
new Vector3(265, 1, 160),
new Vector3(265, 1, 161),
new Vector3(265, 1, 162),
new Vector3(265, 1, 163),
new Vector3(265, 1, 164),
new Vector3(266, 1, 160),
new Vector3(266, 1, 161),
new Vector3(266, 1, 162),
new Vector3(266, 1, 163),
new Vector3(266, 1, 164),
new Vector3(261, 1, 131),
new Vector3(261, 1, 132),
new Vector3(261, 1, 133),
new Vector3(261, 1, 134),
new Vector3(261, 1, 135),
new Vector3(262, 1, 131),
new Vector3(262, 1, 132),
new Vector3(262, 1, 133),
new Vector3(262, 1, 134),
new Vector3(262, 1, 135),
new Vector3(263, 1, 131),
new Vector3(263, 1, 132),
new Vector3(263, 1, 133),
new Vector3(263, 1, 134),
new Vector3(263, 1, 135),
new Vector3(264, 1, 131),
new Vector3(264, 1, 132),
new Vector3(264, 1, 133),
new Vector3(264, 1, 134),
new Vector3(264, 1, 135),
new Vector3(265, 1, 131),
new Vector3(265, 1, 132),
new Vector3(265, 1, 133),
new Vector3(265, 1, 134),
new Vector3(265, 1, 135),
new Vector3(210, 1, 163),
new Vector3(210, 1, 164),
new Vector3(210, 1, 165),
new Vector3(210, 1, 166),
new Vector3(210, 1, 167),
new Vector3(211, 1, 163),
new Vector3(211, 1, 164),
new Vector3(211, 1, 165),
new Vector3(211, 1, 166),
new Vector3(211, 1, 167),
new Vector3(212, 1, 163),
new Vector3(212, 1, 164),
new Vector3(212, 1, 165),
new Vector3(212, 1, 166),
new Vector3(212, 1, 167),
new Vector3(213, 1, 163),
new Vector3(213, 1, 164),
new Vector3(213, 1, 165),
new Vector3(213, 1, 166),
new Vector3(213, 1, 167),
new Vector3(214, 1, 163),
new Vector3(214, 1, 164),
new Vector3(214, 1, 165),
new Vector3(214, 1, 166),
new Vector3(214, 1, 167),
new Vector3(261, 1, 181),
new Vector3(261, 1, 182),
new Vector3(261, 1, 183),
new Vector3(261, 1, 184),
new Vector3(261, 1, 185),
new Vector3(262, 1, 181),
new Vector3(262, 1, 182),
new Vector3(262, 1, 183),
new Vector3(262, 1, 184),
new Vector3(262, 1, 185),
new Vector3(263, 1, 181),
new Vector3(263, 1, 182),
new Vector3(263, 1, 183),
new Vector3(263, 1, 184),
new Vector3(263, 1, 185),
new Vector3(264, 1, 181),
new Vector3(264, 1, 182),
new Vector3(264, 1, 183),
new Vector3(264, 1, 184),
new Vector3(264, 1, 185),
new Vector3(265, 1, 181),
new Vector3(265, 1, 182),
new Vector3(265, 1, 183),
new Vector3(265, 1, 184),
new Vector3(265, 1, 185),
new Vector3(210, 1, 165),
new Vector3(210, 1, 166),
new Vector3(210, 1, 167),
new Vector3(210, 1, 168),
new Vector3(210, 1, 169),
new Vector3(211, 1, 165),
new Vector3(211, 1, 166),
new Vector3(211, 1, 167),
new Vector3(211, 1, 168),
new Vector3(211, 1, 169),
new Vector3(212, 1, 165),
new Vector3(212, 1, 166),
new Vector3(212, 1, 167),
new Vector3(212, 1, 168),
new Vector3(212, 1, 169),
new Vector3(213, 1, 165),
new Vector3(213, 1, 166),
new Vector3(213, 1, 167),
new Vector3(213, 1, 168),
new Vector3(213, 1, 169),
new Vector3(214, 1, 165),
new Vector3(214, 1, 166),
new Vector3(214, 1, 167),
new Vector3(214, 1, 168),
new Vector3(214, 1, 169),
new Vector3(210, 1, 153),
new Vector3(210, 1, 154),
new Vector3(210, 1, 155),
new Vector3(210, 1, 156),
new Vector3(210, 1, 157),
new Vector3(211, 1, 153),
new Vector3(211, 1, 154),
new Vector3(211, 1, 155),
new Vector3(211, 1, 156),
new Vector3(211, 1, 157),
new Vector3(212, 1, 153),
new Vector3(212, 1, 154),
new Vector3(212, 1, 155),
new Vector3(212, 1, 156),
new Vector3(212, 1, 157),
new Vector3(213, 1, 153),
new Vector3(213, 1, 154),
new Vector3(213, 1, 155),
new Vector3(213, 1, 156),
new Vector3(213, 1, 157),
new Vector3(214, 1, 153),
new Vector3(214, 1, 154),
new Vector3(214, 1, 155),
new Vector3(214, 1, 156),
new Vector3(214, 1, 157),
new Vector3(261, 1, 181),
new Vector3(261, 1, 182),
new Vector3(261, 1, 183),
new Vector3(261, 1, 184),
new Vector3(261, 1, 185),
new Vector3(262, 1, 181),
new Vector3(262, 1, 182),
new Vector3(262, 1, 183),
new Vector3(262, 1, 184),
new Vector3(262, 1, 185),
new Vector3(263, 1, 181),
new Vector3(263, 1, 182),
new Vector3(263, 1, 183),
new Vector3(263, 1, 184),
new Vector3(263, 1, 185),
new Vector3(264, 1, 181),
new Vector3(264, 1, 182),
new Vector3(264, 1, 183),
new Vector3(264, 1, 184),
new Vector3(264, 1, 185),
new Vector3(265, 1, 181),
new Vector3(265, 1, 182),
new Vector3(265, 1, 183),
new Vector3(265, 1, 184),
new Vector3(265, 1, 185),
new Vector3(227, 1, 130),
new Vector3(227, 1, 131),
new Vector3(227, 1, 132),
new Vector3(227, 1, 133),
new Vector3(227, 1, 134),
new Vector3(228, 1, 130),
new Vector3(228, 1, 131),
new Vector3(228, 1, 132),
new Vector3(228, 1, 133),
new Vector3(228, 1, 134),
new Vector3(229, 1, 130),
new Vector3(229, 1, 131),
new Vector3(229, 1, 132),
new Vector3(229, 1, 133),
new Vector3(229, 1, 134),
new Vector3(230, 1, 130),
new Vector3(230, 1, 131),
new Vector3(230, 1, 132),
new Vector3(230, 1, 133),
new Vector3(230, 1, 134),
new Vector3(231, 1, 130),
new Vector3(231, 1, 131),
new Vector3(231, 1, 132),
new Vector3(231, 1, 133),
new Vector3(231, 1, 134),
new Vector3(211, 1, 181),
new Vector3(211, 1, 182),
new Vector3(211, 1, 183),
new Vector3(211, 1, 184),
new Vector3(211, 1, 185),
new Vector3(212, 1, 181),
new Vector3(212, 1, 182),
new Vector3(212, 1, 183),
new Vector3(212, 1, 184),
new Vector3(212, 1, 185),
new Vector3(213, 1, 181),
new Vector3(213, 1, 182),
new Vector3(213, 1, 183),
new Vector3(213, 1, 184),
new Vector3(213, 1, 185),
new Vector3(214, 1, 181),
new Vector3(214, 1, 182),
new Vector3(214, 1, 183),
new Vector3(214, 1, 184),
new Vector3(214, 1, 185),
new Vector3(215, 1, 181),
new Vector3(215, 1, 182),
new Vector3(215, 1, 183),
new Vector3(215, 1, 184),
new Vector3(215, 1, 185),
new Vector3(262, 1, 154),
new Vector3(262, 1, 155),
new Vector3(262, 1, 156),
new Vector3(262, 1, 157),
new Vector3(262, 1, 158),
new Vector3(263, 1, 154),
new Vector3(263, 1, 155),
new Vector3(263, 1, 156),
new Vector3(263, 1, 157),
new Vector3(263, 1, 158),
new Vector3(264, 1, 154),
new Vector3(264, 1, 155),
new Vector3(264, 1, 156),
new Vector3(264, 1, 157),
new Vector3(264, 1, 158),
new Vector3(265, 1, 154),
new Vector3(265, 1, 155),
new Vector3(265, 1, 156),
new Vector3(265, 1, 157),
new Vector3(265, 1, 158),
new Vector3(266, 1, 154),
new Vector3(266, 1, 155),
new Vector3(266, 1, 156),
new Vector3(266, 1, 157),
new Vector3(266, 1, 158),
new Vector3(262, 1, 149),
new Vector3(262, 1, 150),
new Vector3(262, 1, 151),
new Vector3(262, 1, 152),
new Vector3(262, 1, 153),
new Vector3(263, 1, 149),
new Vector3(263, 1, 150),
new Vector3(263, 1, 151),
new Vector3(263, 1, 152),
new Vector3(263, 1, 153),
new Vector3(264, 1, 149),
new Vector3(264, 1, 150),
new Vector3(264, 1, 151),
new Vector3(264, 1, 152),
new Vector3(264, 1, 153),
new Vector3(265, 1, 149),
new Vector3(265, 1, 150),
new Vector3(265, 1, 151),
new Vector3(265, 1, 152),
new Vector3(265, 1, 153),
new Vector3(266, 1, 149),
new Vector3(266, 1, 150),
new Vector3(266, 1, 151),
new Vector3(266, 1, 152),
new Vector3(266, 1, 153),
new Vector3(236, 1, 182),
new Vector3(236, 1, 183),
new Vector3(236, 1, 184),
new Vector3(236, 1, 185),
new Vector3(236, 1, 186),
new Vector3(237, 1, 182),
new Vector3(237, 1, 183),
new Vector3(237, 1, 184),
new Vector3(237, 1, 185),
new Vector3(237, 1, 186),
new Vector3(238, 1, 182),
new Vector3(238, 1, 183),
new Vector3(238, 1, 184),
new Vector3(238, 1, 185),
new Vector3(238, 1, 186),
new Vector3(239, 1, 182),
new Vector3(239, 1, 183),
new Vector3(239, 1, 184),
new Vector3(239, 1, 185),
new Vector3(239, 1, 186),
new Vector3(240, 1, 182),
new Vector3(240, 1, 183),
new Vector3(240, 1, 184),
new Vector3(240, 1, 185),
new Vector3(240, 1, 186),
new Vector3(222, 4, 270),
new Vector3(227, 3, 265),
new Vector3(220, 3, 276),
new Vector3(228, 3, 270),
new Vector3(222, 3, 276),
new Vector3(221, 2.5f, 262),
new Vector3(214, 2.5f, 271),
new Vector3(230, 2.5f, 271),
new Vector3(230, 2.5f, 268),
new Vector3(224, 2.5f, 278),
new Vector3(219, 2, 279),
new Vector3(219, 2, 280),
new Vector3(219, 2, 281),
new Vector3(220, 2, 279),
new Vector3(220, 2, 280),
new Vector3(220, 2, 281),
new Vector3(221, 2, 279),
new Vector3(221, 2, 280),
new Vector3(221, 2, 281),
new Vector3(230, 2, 278),
new Vector3(230, 2, 279),
new Vector3(230, 2, 280),
new Vector3(231, 2, 278),
new Vector3(231, 2, 279),
new Vector3(231, 2, 280),
new Vector3(232, 2, 278),
new Vector3(232, 2, 279),
new Vector3(232, 2, 280),
new Vector3(211, 2, 270),
new Vector3(211, 2, 271),
new Vector3(211, 2, 272),
new Vector3(212, 2, 270),
new Vector3(212, 2, 271),
new Vector3(212, 2, 272),
new Vector3(213, 2, 270),
new Vector3(213, 2, 271),
new Vector3(213, 2, 272),
new Vector3(223, 2, 279),
new Vector3(223, 2, 280),
new Vector3(223, 2, 281),
new Vector3(224, 2, 279),
new Vector3(224, 2, 280),
new Vector3(224, 2, 281),
new Vector3(225, 2, 279),
new Vector3(225, 2, 280),
new Vector3(225, 2, 281),
new Vector3(212, 2, 278),
new Vector3(212, 2, 279),
new Vector3(212, 2, 280),
new Vector3(213, 2, 278),
new Vector3(213, 2, 279),
new Vector3(213, 2, 280),
new Vector3(214, 2, 278),
new Vector3(214, 2, 279),
new Vector3(214, 2, 280),
new Vector3(223, 2, 259),
new Vector3(223, 2, 260),
new Vector3(223, 2, 261),
new Vector3(224, 2, 259),
new Vector3(224, 2, 260),
new Vector3(224, 2, 261),
new Vector3(225, 2, 259),
new Vector3(225, 2, 260),
new Vector3(225, 2, 261),
new Vector3(218, 2, 259),
new Vector3(218, 2, 260),
new Vector3(218, 2, 261),
new Vector3(219, 2, 259),
new Vector3(219, 2, 260),
new Vector3(219, 2, 261),
new Vector3(220, 2, 259),
new Vector3(220, 2, 260),
new Vector3(220, 2, 261),
new Vector3(209, 1.5f, 267),
new Vector3(209, 1.5f, 268),
new Vector3(209, 1.5f, 269),
new Vector3(210, 1.5f, 267),
new Vector3(210, 1.5f, 268),
new Vector3(210, 1.5f, 269),
new Vector3(211, 1.5f, 267),
new Vector3(211, 1.5f, 268),
new Vector3(211, 1.5f, 269),
new Vector3(224, 1.5f, 281),
new Vector3(224, 1.5f, 282),
new Vector3(224, 1.5f, 283),
new Vector3(225, 1.5f, 281),
new Vector3(225, 1.5f, 282),
new Vector3(225, 1.5f, 283),
new Vector3(226, 1.5f, 281),
new Vector3(226, 1.5f, 282),
new Vector3(226, 1.5f, 283),
new Vector3(233, 1.5f, 269),
new Vector3(233, 1.5f, 270),
new Vector3(233, 1.5f, 271),
new Vector3(234, 1.5f, 269),
new Vector3(234, 1.5f, 270),
new Vector3(234, 1.5f, 271),
new Vector3(235, 1.5f, 269),
new Vector3(235, 1.5f, 270),
new Vector3(235, 1.5f, 271),
new Vector3(233, 1.5f, 267),
new Vector3(233, 1.5f, 268),
new Vector3(233, 1.5f, 269),
new Vector3(234, 1.5f, 267),
new Vector3(234, 1.5f, 268),
new Vector3(234, 1.5f, 269),
new Vector3(235, 1.5f, 267),
new Vector3(235, 1.5f, 268),
new Vector3(235, 1.5f, 269),
new Vector3(210, 1.5f, 280),
new Vector3(210, 1.5f, 281),
new Vector3(210, 1.5f, 282),
new Vector3(211, 1.5f, 280),
new Vector3(211, 1.5f, 281),
new Vector3(211, 1.5f, 282),
new Vector3(212, 1.5f, 280),
new Vector3(212, 1.5f, 281),
new Vector3(212, 1.5f, 282),
new Vector3(206, 1, 268),
new Vector3(206, 1, 269),
new Vector3(206, 1, 270),
new Vector3(206, 1, 271),
new Vector3(206, 1, 272),
new Vector3(207, 1, 268),
new Vector3(207, 1, 269),
new Vector3(207, 1, 270),
new Vector3(207, 1, 271),
new Vector3(207, 1, 272),
new Vector3(208, 1, 268),
new Vector3(208, 1, 269),
new Vector3(208, 1, 270),
new Vector3(208, 1, 271),
new Vector3(208, 1, 272),
new Vector3(209, 1, 268),
new Vector3(209, 1, 269),
new Vector3(209, 1, 270),
new Vector3(209, 1, 271),
new Vector3(209, 1, 272),
new Vector3(210, 1, 268),
new Vector3(210, 1, 269),
new Vector3(210, 1, 270),
new Vector3(210, 1, 271),
new Vector3(210, 1, 272),
new Vector3(207, 1, 255),
new Vector3(207, 1, 256),
new Vector3(207, 1, 257),
new Vector3(207, 1, 258),
new Vector3(207, 1, 259),
new Vector3(208, 1, 255),
new Vector3(208, 1, 256),
new Vector3(208, 1, 257),
new Vector3(208, 1, 258),
new Vector3(208, 1, 259),
new Vector3(209, 1, 255),
new Vector3(209, 1, 256),
new Vector3(209, 1, 257),
new Vector3(209, 1, 258),
new Vector3(209, 1, 259),
new Vector3(210, 1, 255),
new Vector3(210, 1, 256),
new Vector3(210, 1, 257),
new Vector3(210, 1, 258),
new Vector3(210, 1, 259),
new Vector3(211, 1, 255),
new Vector3(211, 1, 256),
new Vector3(211, 1, 257),
new Vector3(211, 1, 258),
new Vector3(211, 1, 259),
new Vector3(220, 1, 282),
new Vector3(220, 1, 283),
new Vector3(220, 1, 284),
new Vector3(220, 1, 285),
new Vector3(220, 1, 286),
new Vector3(221, 1, 282),
new Vector3(221, 1, 283),
new Vector3(221, 1, 284),
new Vector3(221, 1, 285),
new Vector3(221, 1, 286),
new Vector3(222, 1, 282),
new Vector3(222, 1, 283),
new Vector3(222, 1, 284),
new Vector3(222, 1, 285),
new Vector3(222, 1, 286),
new Vector3(223, 1, 282),
new Vector3(223, 1, 283),
new Vector3(223, 1, 284),
new Vector3(223, 1, 285),
new Vector3(223, 1, 286),
new Vector3(224, 1, 282),
new Vector3(224, 1, 283),
new Vector3(224, 1, 284),
new Vector3(224, 1, 285),
new Vector3(224, 1, 286),
new Vector3(233, 1, 255),
new Vector3(233, 1, 256),
new Vector3(233, 1, 257),
new Vector3(233, 1, 258),
new Vector3(233, 1, 259),
new Vector3(234, 1, 255),
new Vector3(234, 1, 256),
new Vector3(234, 1, 257),
new Vector3(234, 1, 258),
new Vector3(234, 1, 259),
new Vector3(235, 1, 255),
new Vector3(235, 1, 256),
new Vector3(235, 1, 257),
new Vector3(235, 1, 258),
new Vector3(235, 1, 259),
new Vector3(236, 1, 255),
new Vector3(236, 1, 256),
new Vector3(236, 1, 257),
new Vector3(236, 1, 258),
new Vector3(236, 1, 259),
new Vector3(237, 1, 255),
new Vector3(237, 1, 256),
new Vector3(237, 1, 257),
new Vector3(237, 1, 258),
new Vector3(237, 1, 259),
new Vector3(234, 1, 273),
new Vector3(234, 1, 274),
new Vector3(234, 1, 275),
new Vector3(234, 1, 276),
new Vector3(234, 1, 277),
new Vector3(235, 1, 273),
new Vector3(235, 1, 274),
new Vector3(235, 1, 275),
new Vector3(235, 1, 276),
new Vector3(235, 1, 277),
new Vector3(236, 1, 273),
new Vector3(236, 1, 274),
new Vector3(236, 1, 275),
new Vector3(236, 1, 276),
new Vector3(236, 1, 277),
new Vector3(237, 1, 273),
new Vector3(237, 1, 274),
new Vector3(237, 1, 275),
new Vector3(237, 1, 276),
new Vector3(237, 1, 277),
new Vector3(238, 1, 273),
new Vector3(238, 1, 274),
new Vector3(238, 1, 275),
new Vector3(238, 1, 276),
new Vector3(238, 1, 277),
new Vector3(206, 1, 269),
new Vector3(206, 1, 270),
new Vector3(206, 1, 271),
new Vector3(206, 1, 272),
new Vector3(206, 1, 273),
new Vector3(207, 1, 269),
new Vector3(207, 1, 270),
new Vector3(207, 1, 271),
new Vector3(207, 1, 272),
new Vector3(207, 1, 273),
new Vector3(208, 1, 269),
new Vector3(208, 1, 270),
new Vector3(208, 1, 271),
new Vector3(208, 1, 272),
new Vector3(208, 1, 273),
new Vector3(209, 1, 269),
new Vector3(209, 1, 270),
new Vector3(209, 1, 271),
new Vector3(209, 1, 272),
new Vector3(209, 1, 273),
new Vector3(210, 1, 269),
new Vector3(210, 1, 270),
new Vector3(210, 1, 271),
new Vector3(210, 1, 272),
new Vector3(210, 1, 273),
new Vector3(214, 1, 282),
new Vector3(214, 1, 283),
new Vector3(214, 1, 284),
new Vector3(214, 1, 285),
new Vector3(214, 1, 286),
new Vector3(215, 1, 282),
new Vector3(215, 1, 283),
new Vector3(215, 1, 284),
new Vector3(215, 1, 285),
new Vector3(215, 1, 286),
new Vector3(216, 1, 282),
new Vector3(216, 1, 283),
new Vector3(216, 1, 284),
new Vector3(216, 1, 285),
new Vector3(216, 1, 286),
new Vector3(217, 1, 282),
new Vector3(217, 1, 283),
new Vector3(217, 1, 284),
new Vector3(217, 1, 285),
new Vector3(217, 1, 286),
new Vector3(218, 1, 282),
new Vector3(218, 1, 283),
new Vector3(218, 1, 284),
new Vector3(218, 1, 285),
new Vector3(218, 1, 286),
new Vector3(280, 5, 337),
new Vector3(277, 4.5f, 340),
new Vector3(274, 4, 337),
new Vector3(286, 4, 336),
new Vector3(275, 4, 342),
new Vector3(278, 4, 343),
new Vector3(272, 3.5f, 339),
new Vector3(289, 3, 328),
new Vector3(281, 3, 347),
new Vector3(276, 3, 347),
new Vector3(290, 3, 333),
new Vector3(281, 3, 347),
new Vector3(271, 3, 328),
new Vector3(283, 3, 347),
new Vector3(271, 3, 346),
new Vector3(283, 2.5f, 325),
new Vector3(268, 2.5f, 337),
new Vector3(268, 2.5f, 340),
new Vector3(291, 2.5f, 326),
new Vector3(269, 2.5f, 348),
new Vector3(281, 2.5f, 325),
new Vector3(275, 2, 350),
new Vector3(275, 2, 351),
new Vector3(275, 2, 352),
new Vector3(276, 2, 350),
new Vector3(276, 2, 351),
new Vector3(276, 2, 352),
new Vector3(277, 2, 350),
new Vector3(277, 2, 351),
new Vector3(277, 2, 352),
new Vector3(292, 2, 349),
new Vector3(292, 2, 350),
new Vector3(292, 2, 351),
new Vector3(293, 2, 349),
new Vector3(293, 2, 350),
new Vector3(293, 2, 351),
new Vector3(294, 2, 349),
new Vector3(294, 2, 350),
new Vector3(294, 2, 351),
new Vector3(266, 2, 323),
new Vector3(266, 2, 324),
new Vector3(266, 2, 325),
new Vector3(267, 2, 323),
new Vector3(267, 2, 324),
new Vector3(267, 2, 325),
new Vector3(268, 2, 323),
new Vector3(268, 2, 324),
new Vector3(268, 2, 325),
new Vector3(266, 2, 323),
new Vector3(266, 2, 324),
new Vector3(266, 2, 325),
new Vector3(267, 2, 323),
new Vector3(267, 2, 324),
new Vector3(267, 2, 325),
new Vector3(268, 2, 323),
new Vector3(268, 2, 324),
new Vector3(268, 2, 325),
new Vector3(293, 2, 333),
new Vector3(293, 2, 334),
new Vector3(293, 2, 335),
new Vector3(294, 2, 333),
new Vector3(294, 2, 334),
new Vector3(294, 2, 335),
new Vector3(295, 2, 333),
new Vector3(295, 2, 334),
new Vector3(295, 2, 335),
new Vector3(292, 2, 323),
new Vector3(292, 2, 324),
new Vector3(292, 2, 325),
new Vector3(293, 2, 323),
new Vector3(293, 2, 324),
new Vector3(293, 2, 325),
new Vector3(294, 2, 323),
new Vector3(294, 2, 324),
new Vector3(294, 2, 325),
new Vector3(277, 2, 322),
new Vector3(277, 2, 323),
new Vector3(277, 2, 324),
new Vector3(278, 2, 322),
new Vector3(278, 2, 323),
new Vector3(278, 2, 324),
new Vector3(279, 2, 322),
new Vector3(279, 2, 323),
new Vector3(279, 2, 324),
new Vector3(263, 1.5f, 333),
new Vector3(263, 1.5f, 334),
new Vector3(263, 1.5f, 335),
new Vector3(264, 1.5f, 333),
new Vector3(264, 1.5f, 334),
new Vector3(264, 1.5f, 335),
new Vector3(265, 1.5f, 333),
new Vector3(265, 1.5f, 334),
new Vector3(265, 1.5f, 335),
new Vector3(294, 1.5f, 351),
new Vector3(294, 1.5f, 352),
new Vector3(294, 1.5f, 353),
new Vector3(295, 1.5f, 351),
new Vector3(295, 1.5f, 352),
new Vector3(295, 1.5f, 353),
new Vector3(296, 1.5f, 351),
new Vector3(296, 1.5f, 352),
new Vector3(296, 1.5f, 353),
new Vector3(263, 1.5f, 335),
new Vector3(263, 1.5f, 336),
new Vector3(263, 1.5f, 337),
new Vector3(264, 1.5f, 335),
new Vector3(264, 1.5f, 336),
new Vector3(264, 1.5f, 337),
new Vector3(265, 1.5f, 335),
new Vector3(265, 1.5f, 336),
new Vector3(265, 1.5f, 337),
new Vector3(294, 1.5f, 351),
new Vector3(294, 1.5f, 352),
new Vector3(294, 1.5f, 353),
new Vector3(295, 1.5f, 351),
new Vector3(295, 1.5f, 352),
new Vector3(295, 1.5f, 353),
new Vector3(296, 1.5f, 351),
new Vector3(296, 1.5f, 352),
new Vector3(296, 1.5f, 353),
new Vector3(264, 1.5f, 321),
new Vector3(264, 1.5f, 322),
new Vector3(264, 1.5f, 323),
new Vector3(265, 1.5f, 321),
new Vector3(265, 1.5f, 322),
new Vector3(265, 1.5f, 323),
new Vector3(266, 1.5f, 321),
new Vector3(266, 1.5f, 322),
new Vector3(266, 1.5f, 323),
new Vector3(263, 1.5f, 338),
new Vector3(263, 1.5f, 339),
new Vector3(263, 1.5f, 340),
new Vector3(264, 1.5f, 338),
new Vector3(264, 1.5f, 339),
new Vector3(264, 1.5f, 340),
new Vector3(265, 1.5f, 338),
new Vector3(265, 1.5f, 339),
new Vector3(265, 1.5f, 340),
new Vector3(295, 1, 318),
new Vector3(295, 1, 319),
new Vector3(295, 1, 320),
new Vector3(295, 1, 321),
new Vector3(295, 1, 322),
new Vector3(296, 1, 318),
new Vector3(296, 1, 319),
new Vector3(296, 1, 320),
new Vector3(296, 1, 321),
new Vector3(296, 1, 322),
new Vector3(297, 1, 318),
new Vector3(297, 1, 319),
new Vector3(297, 1, 320),
new Vector3(297, 1, 321),
new Vector3(297, 1, 322),
new Vector3(298, 1, 318),
new Vector3(298, 1, 319),
new Vector3(298, 1, 320),
new Vector3(298, 1, 321),
new Vector3(298, 1, 322),
new Vector3(299, 1, 318),
new Vector3(299, 1, 319),
new Vector3(299, 1, 320),
new Vector3(299, 1, 321),
new Vector3(299, 1, 322),
new Vector3(295, 1, 352),
new Vector3(295, 1, 353),
new Vector3(295, 1, 354),
new Vector3(295, 1, 355),
new Vector3(295, 1, 356),
new Vector3(296, 1, 352),
new Vector3(296, 1, 353),
new Vector3(296, 1, 354),
new Vector3(296, 1, 355),
new Vector3(296, 1, 356),
new Vector3(297, 1, 352),
new Vector3(297, 1, 353),
new Vector3(297, 1, 354),
new Vector3(297, 1, 355),
new Vector3(297, 1, 356),
new Vector3(298, 1, 352),
new Vector3(298, 1, 353),
new Vector3(298, 1, 354),
new Vector3(298, 1, 355),
new Vector3(298, 1, 356),
new Vector3(299, 1, 352),
new Vector3(299, 1, 353),
new Vector3(299, 1, 354),
new Vector3(299, 1, 355),
new Vector3(299, 1, 356),
new Vector3(277, 1, 353),
new Vector3(277, 1, 354),
new Vector3(277, 1, 355),
new Vector3(277, 1, 356),
new Vector3(277, 1, 357),
new Vector3(278, 1, 353),
new Vector3(278, 1, 354),
new Vector3(278, 1, 355),
new Vector3(278, 1, 356),
new Vector3(278, 1, 357),
new Vector3(279, 1, 353),
new Vector3(279, 1, 354),
new Vector3(279, 1, 355),
new Vector3(279, 1, 356),
new Vector3(279, 1, 357),
new Vector3(280, 1, 353),
new Vector3(280, 1, 354),
new Vector3(280, 1, 355),
new Vector3(280, 1, 356),
new Vector3(280, 1, 357),
new Vector3(281, 1, 353),
new Vector3(281, 1, 354),
new Vector3(281, 1, 355),
new Vector3(281, 1, 356),
new Vector3(281, 1, 357),
new Vector3(261, 1, 352),
new Vector3(261, 1, 353),
new Vector3(261, 1, 354),
new Vector3(261, 1, 355),
new Vector3(261, 1, 356),
new Vector3(262, 1, 352),
new Vector3(262, 1, 353),
new Vector3(262, 1, 354),
new Vector3(262, 1, 355),
new Vector3(262, 1, 356),
new Vector3(263, 1, 352),
new Vector3(263, 1, 353),
new Vector3(263, 1, 354),
new Vector3(263, 1, 355),
new Vector3(263, 1, 356),
new Vector3(264, 1, 352),
new Vector3(264, 1, 353),
new Vector3(264, 1, 354),
new Vector3(264, 1, 355),
new Vector3(264, 1, 356),
new Vector3(265, 1, 352),
new Vector3(265, 1, 353),
new Vector3(265, 1, 354),
new Vector3(265, 1, 355),
new Vector3(265, 1, 356),
new Vector3(295, 1, 318),
new Vector3(295, 1, 319),
new Vector3(295, 1, 320),
new Vector3(295, 1, 321),
new Vector3(295, 1, 322),
new Vector3(296, 1, 318),
new Vector3(296, 1, 319),
new Vector3(296, 1, 320),
new Vector3(296, 1, 321),
new Vector3(296, 1, 322),
new Vector3(297, 1, 318),
new Vector3(297, 1, 319),
new Vector3(297, 1, 320),
new Vector3(297, 1, 321),
new Vector3(297, 1, 322),
new Vector3(298, 1, 318),
new Vector3(298, 1, 319),
new Vector3(298, 1, 320),
new Vector3(298, 1, 321),
new Vector3(298, 1, 322),
new Vector3(299, 1, 318),
new Vector3(299, 1, 319),
new Vector3(299, 1, 320),
new Vector3(299, 1, 321),
new Vector3(299, 1, 322),
new Vector3(36, 7, 35),
new Vector3(35, 6.5f, 39),
new Vector3(32, 6.5f, 34),
new Vector3(40, 6.5f, 34),
new Vector3(35, 6.5f, 31),
new Vector3(40, 6.5f, 35),
new Vector3(35, 6, 41),
new Vector3(45, 5, 44),
new Vector3(38, 5, 25),
new Vector3(48, 4.5f, 35),
new Vector3(48, 4.5f, 38),
new Vector3(35, 4.5f, 47),
new Vector3(39, 4, 49),
new Vector3(52, 3.5f, 29),
new Vector3(51, 3.5f, 50),
new Vector3(20, 3.5f, 34),
new Vector3(53, 3, 18),
new Vector3(18, 3, 30),
new Vector3(18, 3, 37),
new Vector3(18, 3, 28),
new Vector3(16, 2.5f, 39),
new Vector3(55, 2.5f, 54),
new Vector3(56, 2.5f, 41),
new Vector3(56, 2.5f, 31),
new Vector3(55, 2.5f, 16),
new Vector3(56, 2.5f, 34),
new Vector3(39, 2.5f, 15),
new Vector3(56, 2, 13),
new Vector3(56, 2, 14),
new Vector3(56, 2, 15),
new Vector3(57, 2, 13),
new Vector3(57, 2, 14),
new Vector3(57, 2, 15),
new Vector3(58, 2, 13),
new Vector3(58, 2, 14),
new Vector3(58, 2, 15),
new Vector3(31, 2, 12),
new Vector3(31, 2, 13),
new Vector3(31, 2, 14),
new Vector3(32, 2, 12),
new Vector3(32, 2, 13),
new Vector3(32, 2, 14),
new Vector3(33, 2, 12),
new Vector3(33, 2, 13),
new Vector3(33, 2, 14),
new Vector3(59, 1.5f, 42),
new Vector3(59, 1.5f, 43),
new Vector3(59, 1.5f, 44),
new Vector3(60, 1.5f, 42),
new Vector3(60, 1.5f, 43),
new Vector3(60, 1.5f, 44),
new Vector3(61, 1.5f, 42),
new Vector3(61, 1.5f, 43),
new Vector3(61, 1.5f, 44),
new Vector3(24, 1.5f, 58),
new Vector3(24, 1.5f, 59),
new Vector3(24, 1.5f, 60),
new Vector3(25, 1.5f, 58),
new Vector3(25, 1.5f, 59),
new Vector3(25, 1.5f, 60),
new Vector3(26, 1.5f, 58),
new Vector3(26, 1.5f, 59),
new Vector3(26, 1.5f, 60),
new Vector3(35, 1.5f, 58),
new Vector3(35, 1.5f, 59),
new Vector3(35, 1.5f, 60),
new Vector3(36, 1.5f, 58),
new Vector3(36, 1.5f, 59),
new Vector3(36, 1.5f, 60),
new Vector3(37, 1.5f, 58),
new Vector3(37, 1.5f, 59),
new Vector3(37, 1.5f, 60),
new Vector3(59, 1.5f, 44),
new Vector3(59, 1.5f, 45),
new Vector3(59, 1.5f, 46),
new Vector3(60, 1.5f, 44),
new Vector3(60, 1.5f, 45),
new Vector3(60, 1.5f, 46),
new Vector3(61, 1.5f, 44),
new Vector3(61, 1.5f, 45),
new Vector3(61, 1.5f, 46),
new Vector3(58, 1.5f, 57),
new Vector3(58, 1.5f, 58),
new Vector3(58, 1.5f, 59),
new Vector3(59, 1.5f, 57),
new Vector3(59, 1.5f, 58),
new Vector3(59, 1.5f, 59),
new Vector3(60, 1.5f, 57),
new Vector3(60, 1.5f, 58),
new Vector3(60, 1.5f, 59),
new Vector3(59, 1.5f, 23),
new Vector3(59, 1.5f, 24),
new Vector3(59, 1.5f, 25),
new Vector3(60, 1.5f, 23),
new Vector3(60, 1.5f, 24),
new Vector3(60, 1.5f, 25),
new Vector3(61, 1.5f, 23),
new Vector3(61, 1.5f, 24),
new Vector3(61, 1.5f, 25),
new Vector3(38, 1.5f, 58),
new Vector3(38, 1.5f, 59),
new Vector3(38, 1.5f, 60),
new Vector3(39, 1.5f, 58),
new Vector3(39, 1.5f, 59),
new Vector3(39, 1.5f, 60),
new Vector3(40, 1.5f, 58),
new Vector3(40, 1.5f, 59),
new Vector3(40, 1.5f, 60),
new Vector3(59, 1.5f, 31),
new Vector3(59, 1.5f, 32),
new Vector3(59, 1.5f, 33),
new Vector3(60, 1.5f, 31),
new Vector3(60, 1.5f, 32),
new Vector3(60, 1.5f, 33),
new Vector3(61, 1.5f, 31),
new Vector3(61, 1.5f, 32),
new Vector3(61, 1.5f, 33),
new Vector3(12, 1.5f, 57),
new Vector3(12, 1.5f, 58),
new Vector3(12, 1.5f, 59),
new Vector3(13, 1.5f, 57),
new Vector3(13, 1.5f, 58),
new Vector3(13, 1.5f, 59),
new Vector3(14, 1.5f, 57),
new Vector3(14, 1.5f, 58),
new Vector3(14, 1.5f, 59),
new Vector3(26, 1.5f, 58),
new Vector3(26, 1.5f, 59),
new Vector3(26, 1.5f, 60),
new Vector3(27, 1.5f, 58),
new Vector3(27, 1.5f, 59),
new Vector3(27, 1.5f, 60),
new Vector3(28, 1.5f, 58),
new Vector3(28, 1.5f, 59),
new Vector3(28, 1.5f, 60),
new Vector3(11, 1.5f, 42),
new Vector3(11, 1.5f, 43),
new Vector3(11, 1.5f, 44),
new Vector3(12, 1.5f, 42),
new Vector3(12, 1.5f, 43),
new Vector3(12, 1.5f, 44),
new Vector3(13, 1.5f, 42),
new Vector3(13, 1.5f, 43),
new Vector3(13, 1.5f, 44),
new Vector3(9, 1, 58),
new Vector3(9, 1, 59),
new Vector3(9, 1, 60),
new Vector3(9, 1, 61),
new Vector3(9, 1, 62),
new Vector3(10, 1, 58),
new Vector3(10, 1, 59),
new Vector3(10, 1, 60),
new Vector3(10, 1, 61),
new Vector3(10, 1, 62),
new Vector3(11, 1, 58),
new Vector3(11, 1, 59),
new Vector3(11, 1, 60),
new Vector3(11, 1, 61),
new Vector3(11, 1, 62),
new Vector3(12, 1, 58),
new Vector3(12, 1, 59),
new Vector3(12, 1, 60),
new Vector3(12, 1, 61),
new Vector3(12, 1, 62),
new Vector3(13, 1, 58),
new Vector3(13, 1, 59),
new Vector3(13, 1, 60),
new Vector3(13, 1, 61),
new Vector3(13, 1, 62),
new Vector3(9, 1, 8),
new Vector3(9, 1, 9),
new Vector3(9, 1, 10),
new Vector3(9, 1, 11),
new Vector3(9, 1, 12),
new Vector3(10, 1, 8),
new Vector3(10, 1, 9),
new Vector3(10, 1, 10),
new Vector3(10, 1, 11),
new Vector3(10, 1, 12),
new Vector3(11, 1, 8),
new Vector3(11, 1, 9),
new Vector3(11, 1, 10),
new Vector3(11, 1, 11),
new Vector3(11, 1, 12),
new Vector3(12, 1, 8),
new Vector3(12, 1, 9),
new Vector3(12, 1, 10),
new Vector3(12, 1, 11),
new Vector3(12, 1, 12),
new Vector3(13, 1, 8),
new Vector3(13, 1, 9),
new Vector3(13, 1, 10),
new Vector3(13, 1, 11),
new Vector3(13, 1, 12),
new Vector3(59, 1, 8),
new Vector3(59, 1, 9),
new Vector3(59, 1, 10),
new Vector3(59, 1, 11),
new Vector3(59, 1, 12),
new Vector3(60, 1, 8),
new Vector3(60, 1, 9),
new Vector3(60, 1, 10),
new Vector3(60, 1, 11),
new Vector3(60, 1, 12),
new Vector3(61, 1, 8),
new Vector3(61, 1, 9),
new Vector3(61, 1, 10),
new Vector3(61, 1, 11),
new Vector3(61, 1, 12),
new Vector3(62, 1, 8),
new Vector3(62, 1, 9),
new Vector3(62, 1, 10),
new Vector3(62, 1, 11),
new Vector3(62, 1, 12),
new Vector3(63, 1, 8),
new Vector3(63, 1, 9),
new Vector3(63, 1, 10),
new Vector3(63, 1, 11),
new Vector3(63, 1, 12),
new Vector3(33, 1, 7),
new Vector3(33, 1, 8),
new Vector3(33, 1, 9),
new Vector3(33, 1, 10),
new Vector3(33, 1, 11),
new Vector3(34, 1, 7),
new Vector3(34, 1, 8),
new Vector3(34, 1, 9),
new Vector3(34, 1, 10),
new Vector3(34, 1, 11),
new Vector3(35, 1, 7),
new Vector3(35, 1, 8),
new Vector3(35, 1, 9),
new Vector3(35, 1, 10),
new Vector3(35, 1, 11),
new Vector3(36, 1, 7),
new Vector3(36, 1, 8),
new Vector3(36, 1, 9),
new Vector3(36, 1, 10),
new Vector3(36, 1, 11),
new Vector3(37, 1, 7),
new Vector3(37, 1, 8),
new Vector3(37, 1, 9),
new Vector3(37, 1, 10),
new Vector3(37, 1, 11),
new Vector3(324, 5, 373),
new Vector3(323, 4.5f, 377),
new Vector3(322, 4, 367),
new Vector3(318, 4, 371),
new Vector3(330, 4, 373),
new Vector3(326, 3, 363),
new Vector3(314, 3, 370),
new Vector3(335, 2.5f, 362),
new Vector3(312, 2.5f, 369),
new Vector3(336, 2.5f, 377),
new Vector3(317, 2, 358),
new Vector3(317, 2, 359),
new Vector3(317, 2, 360),
new Vector3(318, 2, 358),
new Vector3(318, 2, 359),
new Vector3(318, 2, 360),
new Vector3(319, 2, 358),
new Vector3(319, 2, 359),
new Vector3(319, 2, 360),
new Vector3(309, 2, 369),
new Vector3(309, 2, 370),
new Vector3(309, 2, 371),
new Vector3(310, 2, 369),
new Vector3(310, 2, 370),
new Vector3(310, 2, 371),
new Vector3(311, 2, 369),
new Vector3(311, 2, 370),
new Vector3(311, 2, 371),
new Vector3(322, 2, 358),
new Vector3(322, 2, 359),
new Vector3(322, 2, 360),
new Vector3(323, 2, 358),
new Vector3(323, 2, 359),
new Vector3(323, 2, 360),
new Vector3(324, 2, 358),
new Vector3(324, 2, 359),
new Vector3(324, 2, 360),
new Vector3(337, 2, 367),
new Vector3(337, 2, 368),
new Vector3(337, 2, 369),
new Vector3(338, 2, 367),
new Vector3(338, 2, 368),
new Vector3(338, 2, 369),
new Vector3(339, 2, 367),
new Vector3(339, 2, 368),
new Vector3(339, 2, 369),
new Vector3(309, 2, 376),
new Vector3(309, 2, 377),
new Vector3(309, 2, 378),
new Vector3(310, 2, 376),
new Vector3(310, 2, 377),
new Vector3(310, 2, 378),
new Vector3(311, 2, 376),
new Vector3(311, 2, 377),
new Vector3(311, 2, 378),
new Vector3(310, 2, 359),
new Vector3(310, 2, 360),
new Vector3(310, 2, 361),
new Vector3(311, 2, 359),
new Vector3(311, 2, 360),
new Vector3(311, 2, 361),
new Vector3(312, 2, 359),
new Vector3(312, 2, 360),
new Vector3(312, 2, 361),
new Vector3(309, 2, 375),
new Vector3(309, 2, 376),
new Vector3(309, 2, 377),
new Vector3(310, 2, 375),
new Vector3(310, 2, 376),
new Vector3(310, 2, 377),
new Vector3(311, 2, 375),
new Vector3(311, 2, 376),
new Vector3(311, 2, 377),
new Vector3(336, 2, 385),
new Vector3(336, 2, 386),
new Vector3(336, 2, 387),
new Vector3(337, 2, 385),
new Vector3(337, 2, 386),
new Vector3(337, 2, 387),
new Vector3(338, 2, 385),
new Vector3(338, 2, 386),
new Vector3(338, 2, 387),
new Vector3(339, 1.5f, 376),
new Vector3(339, 1.5f, 377),
new Vector3(339, 1.5f, 378),
new Vector3(340, 1.5f, 376),
new Vector3(340, 1.5f, 377),
new Vector3(340, 1.5f, 378),
new Vector3(341, 1.5f, 376),
new Vector3(341, 1.5f, 377),
new Vector3(341, 1.5f, 378),
new Vector3(307, 1.5f, 371),
new Vector3(307, 1.5f, 372),
new Vector3(307, 1.5f, 373),
new Vector3(308, 1.5f, 371),
new Vector3(308, 1.5f, 372),
new Vector3(308, 1.5f, 373),
new Vector3(309, 1.5f, 371),
new Vector3(309, 1.5f, 372),
new Vector3(309, 1.5f, 373),
new Vector3(329, 1.5f, 388),
new Vector3(329, 1.5f, 389),
new Vector3(329, 1.5f, 390),
new Vector3(330, 1.5f, 388),
new Vector3(330, 1.5f, 389),
new Vector3(330, 1.5f, 390),
new Vector3(331, 1.5f, 388),
new Vector3(331, 1.5f, 389),
new Vector3(331, 1.5f, 390),
new Vector3(320, 1.5f, 388),
new Vector3(320, 1.5f, 389),
new Vector3(320, 1.5f, 390),
new Vector3(321, 1.5f, 388),
new Vector3(321, 1.5f, 389),
new Vector3(321, 1.5f, 390),
new Vector3(322, 1.5f, 388),
new Vector3(322, 1.5f, 389),
new Vector3(322, 1.5f, 390),
new Vector3(308, 1.5f, 357),
new Vector3(308, 1.5f, 358),
new Vector3(308, 1.5f, 359),
new Vector3(309, 1.5f, 357),
new Vector3(309, 1.5f, 358),
new Vector3(309, 1.5f, 359),
new Vector3(310, 1.5f, 357),
new Vector3(310, 1.5f, 358),
new Vector3(310, 1.5f, 359),
new Vector3(328, 1.5f, 356),
new Vector3(328, 1.5f, 357),
new Vector3(328, 1.5f, 358),
new Vector3(329, 1.5f, 356),
new Vector3(329, 1.5f, 357),
new Vector3(329, 1.5f, 358),
new Vector3(330, 1.5f, 356),
new Vector3(330, 1.5f, 357),
new Vector3(330, 1.5f, 358),
new Vector3(305, 1, 388),
new Vector3(305, 1, 389),
new Vector3(305, 1, 390),
new Vector3(305, 1, 391),
new Vector3(305, 1, 392),
new Vector3(306, 1, 388),
new Vector3(306, 1, 389),
new Vector3(306, 1, 390),
new Vector3(306, 1, 391),
new Vector3(306, 1, 392),
new Vector3(307, 1, 388),
new Vector3(307, 1, 389),
new Vector3(307, 1, 390),
new Vector3(307, 1, 391),
new Vector3(307, 1, 392),
new Vector3(308, 1, 388),
new Vector3(308, 1, 389),
new Vector3(308, 1, 390),
new Vector3(308, 1, 391),
new Vector3(308, 1, 392),
new Vector3(309, 1, 388),
new Vector3(309, 1, 389),
new Vector3(309, 1, 390),
new Vector3(309, 1, 391),
new Vector3(309, 1, 392),
new Vector3(20, 5, 139),
new Vector3(23, 4.5f, 136),
new Vector3(17, 4.5f, 142),
new Vector3(23, 4.5f, 136),
new Vector3(26, 4, 140),
new Vector3(18, 4, 145),
new Vector3(25, 4, 144),
new Vector3(26, 4, 139),
new Vector3(26, 4, 138),
new Vector3(27, 3.5f, 146),
new Vector3(29, 3, 130),
new Vector3(11, 3, 130),
new Vector3(30, 3, 139),
new Vector3(29, 3, 148),
new Vector3(11, 3, 130),
new Vector3(10, 3, 142),
new Vector3(30, 3, 135),
new Vector3(29, 3, 130),
new Vector3(9, 2.5f, 150),
new Vector3(19, 2.5f, 151),
new Vector3(31, 2.5f, 150),
new Vector3(32, 2.5f, 139),
new Vector3(32, 2.5f, 138),
new Vector3(9, 2.5f, 128),
new Vector3(9, 2.5f, 128),
new Vector3(9, 2.5f, 150),
new Vector3(13, 2, 152),
new Vector3(13, 2, 153),
new Vector3(13, 2, 154),
new Vector3(14, 2, 152),
new Vector3(14, 2, 153),
new Vector3(14, 2, 154),
new Vector3(15, 2, 152),
new Vector3(15, 2, 153),
new Vector3(15, 2, 154),
new Vector3(6, 2, 151),
new Vector3(6, 2, 152),
new Vector3(6, 2, 153),
new Vector3(7, 2, 151),
new Vector3(7, 2, 152),
new Vector3(7, 2, 153),
new Vector3(8, 2, 151),
new Vector3(8, 2, 152),
new Vector3(8, 2, 153),
new Vector3(5, 2, 132),
new Vector3(5, 2, 133),
new Vector3(5, 2, 134),
new Vector3(6, 2, 132),
new Vector3(6, 2, 133),
new Vector3(6, 2, 134),
new Vector3(7, 2, 132),
new Vector3(7, 2, 133),
new Vector3(7, 2, 134),
new Vector3(33, 2, 143),
new Vector3(33, 2, 144),
new Vector3(33, 2, 145),
new Vector3(34, 2, 143),
new Vector3(34, 2, 144),
new Vector3(34, 2, 145),
new Vector3(35, 2, 143),
new Vector3(35, 2, 144),
new Vector3(35, 2, 145),
new Vector3(34, 1.5f, 123),
new Vector3(34, 1.5f, 124),
new Vector3(34, 1.5f, 125),
new Vector3(35, 1.5f, 123),
new Vector3(35, 1.5f, 124),
new Vector3(35, 1.5f, 125),
new Vector3(36, 1.5f, 123),
new Vector3(36, 1.5f, 124),
new Vector3(36, 1.5f, 125),
new Vector3(4, 1.5f, 153),
new Vector3(4, 1.5f, 154),
new Vector3(4, 1.5f, 155),
new Vector3(5, 1.5f, 153),
new Vector3(5, 1.5f, 154),
new Vector3(5, 1.5f, 155),
new Vector3(6, 1.5f, 153),
new Vector3(6, 1.5f, 154),
new Vector3(6, 1.5f, 155),
new Vector3(25, 1.5f, 154),
new Vector3(25, 1.5f, 155),
new Vector3(25, 1.5f, 156),
new Vector3(26, 1.5f, 154),
new Vector3(26, 1.5f, 155),
new Vector3(26, 1.5f, 156),
new Vector3(27, 1.5f, 154),
new Vector3(27, 1.5f, 155),
new Vector3(27, 1.5f, 156),
new Vector3(35, 1.5f, 143),
new Vector3(35, 1.5f, 144),
new Vector3(35, 1.5f, 145),
new Vector3(36, 1.5f, 143),
new Vector3(36, 1.5f, 144),
new Vector3(36, 1.5f, 145),
new Vector3(37, 1.5f, 143),
new Vector3(37, 1.5f, 144),
new Vector3(37, 1.5f, 145),
new Vector3(36, 1, 136),
new Vector3(36, 1, 137),
new Vector3(36, 1, 138),
new Vector3(36, 1, 139),
new Vector3(36, 1, 140),
new Vector3(37, 1, 136),
new Vector3(37, 1, 137),
new Vector3(37, 1, 138),
new Vector3(37, 1, 139),
new Vector3(37, 1, 140),
new Vector3(38, 1, 136),
new Vector3(38, 1, 137),
new Vector3(38, 1, 138),
new Vector3(38, 1, 139),
new Vector3(38, 1, 140),
new Vector3(39, 1, 136),
new Vector3(39, 1, 137),
new Vector3(39, 1, 138),
new Vector3(39, 1, 139),
new Vector3(39, 1, 140),
new Vector3(40, 1, 136),
new Vector3(40, 1, 137),
new Vector3(40, 1, 138),
new Vector3(40, 1, 139),
new Vector3(40, 1, 140),
new Vector3(2, 1, 133),
new Vector3(2, 1, 134),
new Vector3(2, 1, 135),
new Vector3(2, 1, 136),
new Vector3(2, 1, 137),
new Vector3(3, 1, 133),
new Vector3(3, 1, 134),
new Vector3(3, 1, 135),
new Vector3(3, 1, 136),
new Vector3(3, 1, 137),
new Vector3(4, 1, 133),
new Vector3(4, 1, 134),
new Vector3(4, 1, 135),
new Vector3(4, 1, 136),
new Vector3(4, 1, 137),
new Vector3(35, 1, 154),
new Vector3(35, 1, 155),
new Vector3(35, 1, 156),
new Vector3(35, 1, 157),
new Vector3(35, 1, 158),
new Vector3(36, 1, 154),
new Vector3(36, 1, 155),
new Vector3(36, 1, 156),
new Vector3(36, 1, 157),
new Vector3(36, 1, 158),
new Vector3(37, 1, 154),
new Vector3(37, 1, 155),
new Vector3(37, 1, 156),
new Vector3(37, 1, 157),
new Vector3(37, 1, 158),
new Vector3(38, 1, 154),
new Vector3(38, 1, 155),
new Vector3(38, 1, 156),
new Vector3(38, 1, 157),
new Vector3(38, 1, 158),
new Vector3(39, 1, 154),
new Vector3(39, 1, 155),
new Vector3(39, 1, 156),
new Vector3(39, 1, 157),
new Vector3(39, 1, 158),
new Vector3(2, 1, 154),
new Vector3(2, 1, 155),
new Vector3(2, 1, 156),
new Vector3(2, 1, 157),
new Vector3(2, 1, 158),
new Vector3(3, 1, 154),
new Vector3(3, 1, 155),
new Vector3(3, 1, 156),
new Vector3(3, 1, 157),
new Vector3(3, 1, 158),
new Vector3(4, 1, 154),
new Vector3(4, 1, 155),
new Vector3(4, 1, 156),
new Vector3(4, 1, 157),
new Vector3(4, 1, 158),
new Vector3(5, 1, 154),
new Vector3(5, 1, 155),
new Vector3(5, 1, 156),
new Vector3(5, 1, 157),
new Vector3(5, 1, 158),
new Vector3(23, 1, 119),
new Vector3(23, 1, 120),
new Vector3(23, 1, 121),
new Vector3(23, 1, 122),
new Vector3(23, 1, 123),
new Vector3(24, 1, 119),
new Vector3(24, 1, 120),
new Vector3(24, 1, 121),
new Vector3(24, 1, 122),
new Vector3(24, 1, 123),
new Vector3(25, 1, 119),
new Vector3(25, 1, 120),
new Vector3(25, 1, 121),
new Vector3(25, 1, 122),
new Vector3(25, 1, 123),
new Vector3(26, 1, 119),
new Vector3(26, 1, 120),
new Vector3(26, 1, 121),
new Vector3(26, 1, 122),
new Vector3(26, 1, 123),
new Vector3(27, 1, 119),
new Vector3(27, 1, 120),
new Vector3(27, 1, 121),
new Vector3(27, 1, 122),
new Vector3(27, 1, 123),
new Vector3(17, 1, 155),
new Vector3(17, 1, 156),
new Vector3(17, 1, 157),
new Vector3(17, 1, 158),
new Vector3(17, 1, 159),
new Vector3(18, 1, 155),
new Vector3(18, 1, 156),
new Vector3(18, 1, 157),
new Vector3(18, 1, 158),
new Vector3(18, 1, 159),
new Vector3(19, 1, 155),
new Vector3(19, 1, 156),
new Vector3(19, 1, 157),
new Vector3(19, 1, 158),
new Vector3(19, 1, 159),
new Vector3(20, 1, 155),
new Vector3(20, 1, 156),
new Vector3(20, 1, 157),
new Vector3(20, 1, 158),
new Vector3(20, 1, 159),
new Vector3(21, 1, 155),
new Vector3(21, 1, 156),
new Vector3(21, 1, 157),
new Vector3(21, 1, 158),
new Vector3(21, 1, 159),
new Vector3(35, 1, 154),
new Vector3(35, 1, 155),
new Vector3(35, 1, 156),
new Vector3(35, 1, 157),
new Vector3(35, 1, 158),
new Vector3(36, 1, 154),
new Vector3(36, 1, 155),
new Vector3(36, 1, 156),
new Vector3(36, 1, 157),
new Vector3(36, 1, 158),
new Vector3(37, 1, 154),
new Vector3(37, 1, 155),
new Vector3(37, 1, 156),
new Vector3(37, 1, 157),
new Vector3(37, 1, 158),
new Vector3(38, 1, 154),
new Vector3(38, 1, 155),
new Vector3(38, 1, 156),
new Vector3(38, 1, 157),
new Vector3(38, 1, 158),
new Vector3(39, 1, 154),
new Vector3(39, 1, 155),
new Vector3(39, 1, 156),
new Vector3(39, 1, 157),
new Vector3(39, 1, 158),
new Vector3(77, 4, 97),
new Vector3(81, 3.5f, 97),
new Vector3(80, 3.5f, 94),
new Vector3(82, 3, 92),
new Vector3(83, 3, 97),
new Vector3(72, 3, 102),
new Vector3(77, 2.5f, 105),
new Vector3(84, 2.5f, 90),
new Vector3(84, 2.5f, 90),
new Vector3(69, 2.5f, 99),
new Vector3(84, 2.5f, 104),
new Vector3(66, 2, 96),
new Vector3(66, 2, 97),
new Vector3(66, 2, 98),
new Vector3(67, 2, 96),
new Vector3(67, 2, 97),
new Vector3(67, 2, 98),
new Vector3(68, 2, 96),
new Vector3(68, 2, 97),
new Vector3(68, 2, 98),
new Vector3(76, 2, 86),
new Vector3(76, 2, 87),
new Vector3(76, 2, 88),
new Vector3(77, 2, 86),
new Vector3(77, 2, 87),
new Vector3(77, 2, 88),
new Vector3(78, 2, 86),
new Vector3(78, 2, 87),
new Vector3(78, 2, 88),
new Vector3(67, 2, 87),
new Vector3(67, 2, 88),
new Vector3(67, 2, 89),
new Vector3(68, 2, 87),
new Vector3(68, 2, 88),
new Vector3(68, 2, 89),
new Vector3(69, 2, 87),
new Vector3(69, 2, 88),
new Vector3(69, 2, 89),
new Vector3(67, 2, 105),
new Vector3(67, 2, 106),
new Vector3(67, 2, 107),
new Vector3(68, 2, 105),
new Vector3(68, 2, 106),
new Vector3(68, 2, 107),
new Vector3(69, 2, 105),
new Vector3(69, 2, 106),
new Vector3(69, 2, 107),
new Vector3(73, 2, 106),
new Vector3(73, 2, 107),
new Vector3(73, 2, 108),
new Vector3(74, 2, 106),
new Vector3(74, 2, 107),
new Vector3(74, 2, 108),
new Vector3(75, 2, 106),
new Vector3(75, 2, 107),
new Vector3(75, 2, 108),
new Vector3(65, 1.5f, 85),
new Vector3(65, 1.5f, 86),
new Vector3(65, 1.5f, 87),
new Vector3(66, 1.5f, 85),
new Vector3(66, 1.5f, 86),
new Vector3(66, 1.5f, 87),
new Vector3(67, 1.5f, 85),
new Vector3(67, 1.5f, 86),
new Vector3(67, 1.5f, 87),
new Vector3(73, 1.5f, 108),
new Vector3(73, 1.5f, 109),
new Vector3(73, 1.5f, 110),
new Vector3(74, 1.5f, 108),
new Vector3(74, 1.5f, 109),
new Vector3(74, 1.5f, 110),
new Vector3(75, 1.5f, 108),
new Vector3(75, 1.5f, 109),
new Vector3(75, 1.5f, 110),
new Vector3(71, 1.5f, 108),
new Vector3(71, 1.5f, 109),
new Vector3(71, 1.5f, 110),
new Vector3(72, 1.5f, 108),
new Vector3(72, 1.5f, 109),
new Vector3(72, 1.5f, 110),
new Vector3(73, 1.5f, 108),
new Vector3(73, 1.5f, 109),
new Vector3(73, 1.5f, 110),
new Vector3(61, 1, 97),
new Vector3(61, 1, 98),
new Vector3(61, 1, 99),
new Vector3(61, 1, 100),
new Vector3(61, 1, 101),
new Vector3(62, 1, 97),
new Vector3(62, 1, 98),
new Vector3(62, 1, 99),
new Vector3(62, 1, 100),
new Vector3(62, 1, 101),
new Vector3(63, 1, 97),
new Vector3(63, 1, 98),
new Vector3(63, 1, 99),
new Vector3(63, 1, 100),
new Vector3(63, 1, 101),
new Vector3(64, 1, 97),
new Vector3(64, 1, 98),
new Vector3(64, 1, 99),
new Vector3(64, 1, 100),
new Vector3(64, 1, 101),
new Vector3(65, 1, 97),
new Vector3(65, 1, 98),
new Vector3(65, 1, 99),
new Vector3(65, 1, 100),
new Vector3(65, 1, 101),
new Vector3(62, 1, 108),
new Vector3(62, 1, 109),
new Vector3(62, 1, 110),
new Vector3(62, 1, 111),
new Vector3(62, 1, 112),
new Vector3(63, 1, 108),
new Vector3(63, 1, 109),
new Vector3(63, 1, 110),
new Vector3(63, 1, 111),
new Vector3(63, 1, 112),
new Vector3(64, 1, 108),
new Vector3(64, 1, 109),
new Vector3(64, 1, 110),
new Vector3(64, 1, 111),
new Vector3(64, 1, 112),
new Vector3(65, 1, 108),
new Vector3(65, 1, 109),
new Vector3(65, 1, 110),
new Vector3(65, 1, 111),
new Vector3(65, 1, 112),
new Vector3(66, 1, 108),
new Vector3(66, 1, 109),
new Vector3(66, 1, 110),
new Vector3(66, 1, 111),
new Vector3(66, 1, 112),
new Vector3(78, 1, 81),
new Vector3(78, 1, 82),
new Vector3(78, 1, 83),
new Vector3(78, 1, 84),
new Vector3(78, 1, 85),
new Vector3(79, 1, 81),
new Vector3(79, 1, 82),
new Vector3(79, 1, 83),
new Vector3(79, 1, 84),
new Vector3(79, 1, 85),
new Vector3(80, 1, 81),
new Vector3(80, 1, 82),
new Vector3(80, 1, 83),
new Vector3(80, 1, 84),
new Vector3(80, 1, 85),
new Vector3(81, 1, 81),
new Vector3(81, 1, 82),
new Vector3(81, 1, 83),
new Vector3(81, 1, 84),
new Vector3(81, 1, 85),
new Vector3(82, 1, 81),
new Vector3(82, 1, 82),
new Vector3(82, 1, 83),
new Vector3(82, 1, 84),
new Vector3(82, 1, 85),
new Vector3(72, 1, 81),
new Vector3(72, 1, 82),
new Vector3(72, 1, 83),
new Vector3(72, 1, 84),
new Vector3(72, 1, 85),
new Vector3(73, 1, 82),
new Vector3(73, 1, 83),
new Vector3(73, 1, 84),
new Vector3(73, 1, 85),
new Vector3(74, 1, 81),
new Vector3(74, 1, 82),
new Vector3(74, 1, 83),
new Vector3(74, 1, 84),
new Vector3(74, 1, 85),
new Vector3(75, 1, 81),
new Vector3(75, 1, 82),
new Vector3(75, 1, 83),
new Vector3(75, 1, 84),
new Vector3(75, 1, 85),
new Vector3(76, 1, 81),
new Vector3(76, 1, 82),
new Vector3(76, 1, 83),
new Vector3(76, 1, 84),
new Vector3(76, 1, 85),
new Vector3(62, 1, 108),
new Vector3(62, 1, 109),
new Vector3(62, 1, 110),
new Vector3(62, 1, 111),
new Vector3(62, 1, 112),
new Vector3(63, 1, 108),
new Vector3(63, 1, 109),
new Vector3(63, 1, 110),
new Vector3(63, 1, 111),
new Vector3(63, 1, 112),
new Vector3(64, 1, 108),
new Vector3(64, 1, 109),
new Vector3(64, 1, 110),
new Vector3(64, 1, 111),
new Vector3(64, 1, 112),
new Vector3(65, 1, 108),
new Vector3(65, 1, 109),
new Vector3(65, 1, 110),
new Vector3(65, 1, 111),
new Vector3(65, 1, 112),
new Vector3(66, 1, 108),
new Vector3(66, 1, 109),
new Vector3(66, 1, 110),
new Vector3(66, 1, 111),
new Vector3(66, 1, 112),
new Vector3(61, 1, 92),
new Vector3(61, 1, 93),
new Vector3(61, 1, 94),
new Vector3(61, 1, 95),
new Vector3(61, 1, 96),
new Vector3(62, 1, 92),
new Vector3(62, 1, 93),
new Vector3(62, 1, 94),
new Vector3(62, 1, 95),
new Vector3(62, 1, 96),
new Vector3(63, 1, 92),
new Vector3(63, 1, 93),
new Vector3(63, 1, 94),
new Vector3(63, 1, 95),
new Vector3(63, 1, 96),
new Vector3(64, 1, 92),
new Vector3(64, 1, 93),
new Vector3(64, 1, 94),
new Vector3(64, 1, 95),
new Vector3(64, 1, 96),
new Vector3(65, 1, 92),
new Vector3(65, 1, 93),
new Vector3(65, 1, 94),
new Vector3(65, 1, 95),
new Vector3(65, 1, 96),
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
new Vector3(91, 1, 89),
new Vector3(91, 1, 90),
new Vector3(91, 1, 91),
new Vector3(91, 1, 92),
new Vector3(91, 1, 93),
new Vector3(92, 1, 89),
new Vector3(92, 1, 90),
new Vector3(92, 1, 91),
new Vector3(92, 1, 92),
new Vector3(92, 1, 93),
new Vector3(93, 1, 89),
new Vector3(93, 1, 90),
new Vector3(93, 1, 91),
new Vector3(93, 1, 92),
new Vector3(93, 1, 93),
new Vector3(297, 6, 378),
new Vector3(301, 5.5f, 377),
new Vector3(301, 5.5f, 377),
new Vector3(294, 5.5f, 381),
new Vector3(302, 5, 373),
new Vector3(303, 5, 377),
new Vector3(297, 5, 384),
new Vector3(304, 4.5f, 371),
new Vector3(296, 4.5f, 386),
new Vector3(297, 4.5f, 386),
new Vector3(290, 4.5f, 385),
new Vector3(304, 4.5f, 385),
new Vector3(307, 4, 375),
new Vector3(287, 4, 374),
new Vector3(299, 4, 388),
new Vector3(307, 4, 380),
new Vector3(287, 4, 378),
new Vector3(307, 4, 375),
new Vector3(306, 4, 387),
new Vector3(308, 3.5f, 367),
new Vector3(308, 3.5f, 389),
new Vector3(285, 3.5f, 377),
new Vector3(284, 3, 391),
new Vector3(310, 3, 391),
new Vector3(291, 3, 364),
new Vector3(283, 3, 379),
new Vector3(283, 3, 372),
new Vector3(284, 3, 391),
new Vector3(295, 3, 392),
new Vector3(296, 3, 364),
new Vector3(311, 3, 378),
new Vector3(283, 3, 379),
new Vector3(281, 2.5f, 380),
new Vector3(282, 2.5f, 363),
new Vector3(282, 2.5f, 393),
new Vector3(313, 2, 394),
new Vector3(313, 2, 395),
new Vector3(313, 2, 396),
new Vector3(314, 2, 394),
new Vector3(314, 2, 395),
new Vector3(314, 2, 396),
new Vector3(315, 2, 394),
new Vector3(315, 2, 395),
new Vector3(315, 2, 396),
new Vector3(290, 2, 359),
new Vector3(290, 2, 360),
new Vector3(290, 2, 361),
new Vector3(291, 2, 359),
new Vector3(291, 2, 360),
new Vector3(291, 2, 361),
new Vector3(292, 2, 359),
new Vector3(292, 2, 360),
new Vector3(292, 2, 361),
new Vector3(313, 2, 394),
new Vector3(313, 2, 395),
new Vector3(313, 2, 396),
new Vector3(314, 2, 394),
new Vector3(314, 2, 395),
new Vector3(314, 2, 396),
new Vector3(315, 2, 394),
new Vector3(315, 2, 395),
new Vector3(315, 2, 396),
new Vector3(315, 1.5f, 396),
new Vector3(315, 1.5f, 397),
new Vector3(315, 1.5f, 398),
new Vector3(316, 1.5f, 396),
new Vector3(316, 1.5f, 397),
new Vector3(316, 1.5f, 398),
new Vector3(317, 1.5f, 396),
new Vector3(317, 1.5f, 397),
new Vector3(317, 1.5f, 398),
new Vector3(276, 1.5f, 382),
new Vector3(276, 1.5f, 383),
new Vector3(276, 1.5f, 384),
new Vector3(277, 1.5f, 382),
new Vector3(277, 1.5f, 383),
new Vector3(277, 1.5f, 384),
new Vector3(278, 1.5f, 382),
new Vector3(278, 1.5f, 383),
new Vector3(278, 1.5f, 384),
new Vector3(274, 1, 355),
new Vector3(274, 1, 356),
new Vector3(274, 1, 357),
new Vector3(274, 1, 358),
new Vector3(274, 1, 359),
new Vector3(275, 1, 355),
new Vector3(275, 1, 356),
new Vector3(275, 1, 357),
new Vector3(275, 1, 358),
new Vector3(275, 1, 359),
new Vector3(276, 1, 355),
new Vector3(276, 1, 356),
new Vector3(276, 1, 357),
new Vector3(276, 1, 358),
new Vector3(276, 1, 359),
new Vector3(277, 1, 355),
new Vector3(277, 1, 356),
new Vector3(277, 1, 357),
new Vector3(277, 1, 358),
new Vector3(277, 1, 359),
new Vector3(278, 1, 355),
new Vector3(278, 1, 356),
new Vector3(278, 1, 357),
new Vector3(278, 1, 358),
new Vector3(278, 1, 359),
new Vector3(274, 1, 355),
new Vector3(274, 1, 356),
new Vector3(274, 1, 357),
new Vector3(274, 1, 358),
new Vector3(274, 1, 359),
new Vector3(275, 1, 355),
new Vector3(275, 1, 356),
new Vector3(275, 1, 357),
new Vector3(275, 1, 358),
new Vector3(275, 1, 359),
new Vector3(276, 1, 355),
new Vector3(276, 1, 356),
new Vector3(276, 1, 357),
new Vector3(276, 1, 358),
new Vector3(276, 1, 359),
new Vector3(277, 1, 355),
new Vector3(277, 1, 356),
new Vector3(277, 1, 357),
new Vector3(277, 1, 358),
new Vector3(277, 1, 359),
new Vector3(278, 1, 355),
new Vector3(278, 1, 356),
new Vector3(278, 1, 357),
new Vector3(278, 1, 358),
new Vector3(278, 1, 359),
new Vector3(293, 1, 398),
new Vector3(294, 1, 398),
new Vector3(295, 1, 398),
new Vector3(296, 1, 398),
new Vector3(297, 1, 398),
new Vector3(274, 1, 397),
new Vector3(274, 1, 398),
new Vector3(275, 1, 397),
new Vector3(275, 1, 398),
new Vector3(276, 1, 397),
new Vector3(276, 1, 398),
new Vector3(277, 1, 397),
new Vector3(277, 1, 398),
new Vector3(278, 1, 397),
new Vector3(278, 1, 398),
new Vector3(273, 1, 384),
new Vector3(273, 1, 385),
new Vector3(273, 1, 386),
new Vector3(273, 1, 387),
new Vector3(273, 1, 388),
new Vector3(274, 1, 384),
new Vector3(274, 1, 385),
new Vector3(274, 1, 386),
new Vector3(274, 1, 387),
new Vector3(274, 1, 388),
new Vector3(275, 1, 384),
new Vector3(275, 1, 385),
new Vector3(275, 1, 386),
new Vector3(275, 1, 387),
new Vector3(275, 1, 388),
new Vector3(276, 1, 384),
new Vector3(276, 1, 385),
new Vector3(276, 1, 386),
new Vector3(276, 1, 387),
new Vector3(276, 1, 388),
new Vector3(277, 1, 384),
new Vector3(277, 1, 385),
new Vector3(277, 1, 386),
new Vector3(277, 1, 387),
new Vector3(277, 1, 388),
new Vector3(316, 1, 397),
new Vector3(316, 1, 398),
new Vector3(317, 1, 397),
new Vector3(317, 1, 398),
new Vector3(318, 1, 397),
new Vector3(318, 1, 398),
new Vector3(319, 1, 397),
new Vector3(319, 1, 398),
new Vector3(320, 1, 397),
new Vector3(320, 1, 398),
new Vector3(168, 5, 390),
new Vector3(165, 4.5f, 387),
new Vector3(172, 4.5f, 390),
new Vector3(165, 4.5f, 393),
new Vector3(162, 4, 391),
new Vector3(173, 4, 385),
new Vector3(174, 4, 389),
new Vector3(163, 4, 395),
new Vector3(163, 4, 385),
new Vector3(166, 4, 396),
new Vector3(175, 3.5f, 383),
new Vector3(175, 3.5f, 383),
new Vector3(178, 3, 387),
new Vector3(177, 3, 381),
new Vector3(178, 3, 389),
new Vector3(157, 2.5f, 379),
new Vector3(180, 2.5f, 392),
new Vector3(157, 2.5f, 379),
new Vector3(180, 2, 376),
new Vector3(180, 2, 377),
new Vector3(180, 2, 378),
new Vector3(181, 2, 376),
new Vector3(181, 2, 377),
new Vector3(181, 2, 378),
new Vector3(182, 2, 376),
new Vector3(182, 2, 377),
new Vector3(182, 2, 378),
new Vector3(180, 2, 376),
new Vector3(180, 2, 377),
new Vector3(180, 2, 378),
new Vector3(181, 2, 376),
new Vector3(181, 2, 377),
new Vector3(181, 2, 378),
new Vector3(182, 2, 376),
new Vector3(182, 2, 377),
new Vector3(182, 2, 378),
new Vector3(181, 2, 384),
new Vector3(181, 2, 385),
new Vector3(181, 2, 386),
new Vector3(182, 2, 384),
new Vector3(182, 2, 385),
new Vector3(182, 2, 386),
new Vector3(183, 2, 384),
new Vector3(183, 2, 385),
new Vector3(183, 2, 386),
new Vector3(153, 2, 385),
new Vector3(153, 2, 386),
new Vector3(153, 2, 387),
new Vector3(154, 2, 385),
new Vector3(154, 2, 386),
new Vector3(154, 2, 387),
new Vector3(155, 2, 385),
new Vector3(155, 2, 386),
new Vector3(155, 2, 387),
new Vector3(153, 2, 386),
new Vector3(153, 2, 387),
new Vector3(153, 2, 388),
new Vector3(154, 2, 386),
new Vector3(154, 2, 387),
new Vector3(154, 2, 388),
new Vector3(155, 2, 386),
new Vector3(155, 2, 387),
new Vector3(155, 2, 388),
new Vector3(148, 1, 384),
new Vector3(148, 1, 385),
new Vector3(148, 1, 386),
new Vector3(148, 1, 387),
new Vector3(148, 1, 388),
new Vector3(149, 1, 384),
new Vector3(149, 1, 385),
new Vector3(149, 1, 386),
new Vector3(149, 1, 387),
new Vector3(149, 1, 388),
new Vector3(150, 1, 384),
new Vector3(150, 1, 385),
new Vector3(150, 1, 386),
new Vector3(150, 1, 387),
new Vector3(150, 1, 388),
new Vector3(151, 1, 384),
new Vector3(151, 1, 385),
new Vector3(151, 1, 386),
new Vector3(151, 1, 387),
new Vector3(151, 1, 388),
new Vector3(152, 1, 384),
new Vector3(152, 1, 385),
new Vector3(152, 1, 386),
new Vector3(152, 1, 387),
new Vector3(152, 1, 388),
new Vector3(148, 1, 391),
new Vector3(148, 1, 392),
new Vector3(148, 1, 393),
new Vector3(148, 1, 394),
new Vector3(148, 1, 395),
new Vector3(149, 1, 391),
new Vector3(149, 1, 392),
new Vector3(149, 1, 393),
new Vector3(149, 1, 394),
new Vector3(149, 1, 395),
new Vector3(150, 1, 391),
new Vector3(150, 1, 392),
new Vector3(150, 1, 393),
new Vector3(150, 1, 394),
new Vector3(150, 1, 395),
new Vector3(151, 1, 391),
new Vector3(151, 1, 392),
new Vector3(151, 1, 393),
new Vector3(151, 1, 394),
new Vector3(151, 1, 395),
new Vector3(152, 1, 391),
new Vector3(152, 1, 392),
new Vector3(152, 1, 393),
new Vector3(152, 1, 394),
new Vector3(152, 1, 395),
new Vector3(173, 1, 370),
new Vector3(173, 1, 371),
new Vector3(173, 1, 372),
new Vector3(173, 1, 373),
new Vector3(173, 1, 374),
new Vector3(174, 1, 370),
new Vector3(174, 1, 371),
new Vector3(174, 1, 372),
new Vector3(174, 1, 373),
new Vector3(174, 1, 374),
new Vector3(175, 1, 370),
new Vector3(175, 1, 371),
new Vector3(175, 1, 372),
new Vector3(175, 1, 373),
new Vector3(175, 1, 374),
new Vector3(176, 1, 370),
new Vector3(176, 1, 371),
new Vector3(176, 1, 372),
new Vector3(176, 1, 373),
new Vector3(176, 1, 374),
new Vector3(177, 1, 370),
new Vector3(177, 1, 371),
new Vector3(177, 1, 372),
new Vector3(177, 1, 373),
new Vector3(177, 1, 374),
new Vector3(148, 1, 387),
new Vector3(148, 1, 388),
new Vector3(148, 1, 389),
new Vector3(148, 1, 390),
new Vector3(148, 1, 391),
new Vector3(149, 1, 387),
new Vector3(149, 1, 388),
new Vector3(149, 1, 389),
new Vector3(149, 1, 390),
new Vector3(149, 1, 391),
new Vector3(150, 1, 387),
new Vector3(150, 1, 388),
new Vector3(150, 1, 389),
new Vector3(150, 1, 390),
new Vector3(150, 1, 391),
new Vector3(151, 1, 387),
new Vector3(151, 1, 388),
new Vector3(151, 1, 389),
new Vector3(151, 1, 390),
new Vector3(151, 1, 391),
new Vector3(152, 1, 387),
new Vector3(152, 1, 388),
new Vector3(152, 1, 389),
new Vector3(152, 1, 390),
new Vector3(152, 1, 391)};
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
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno3(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 2], y, 270) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno3(terrenos[x, z - 2], y - 0.5f, 0) == true)
        {
            PonerTerreno(rampas4rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarVacio(terrenos[x + 2, z]) == true && ComprobarTerreno1(terrenos[x, z - 2], y - 0.5f, 270) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true && ComprobarTerreno0(terrenos[x + 1, z], y - 0.5f, 0) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == true && ComprobarVacio(terrenos[x, z + 1]) == false)
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
        int idDebug = id;

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
            terreno2.idDebug = idDebug;
            
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
