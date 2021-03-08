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
    public float alturaMaxima;

    private int limitesMapa = 3;

    public void Start()
    {
        terrenos = new Terreno[arranque.tamañoEscenarioX, arranque.tamañoEscenarioZ];

        List<Vector3> listadoTerrenoInicial = new List<Vector3>();

        if (aleatorio == true)
        {
            listadoTerrenoInicial = vectores.GenerarTerreno(terrenos, (int)arranque.tamañoEscenarioX, (int)arranque.tamañoEscenarioZ, alturaMaxima, limitesMapa);
        }
        else
        {
            listadoTerrenoInicial = new List<Vector3> {
new Vector3(5, 4, 37),
new Vector3(4, 3.5f, 33),
new Vector3(8, 3.5f, 34),
new Vector3(2, 3.5f, 40),
new Vector3(5, 3.5f, 41),
new Vector3(8, 3.5f, 40),
new Vector3(4, 3, 31),
new Vector3(11, 3, 35),
new Vector3(13, 2.5f, 36),
new Vector3(14, 2, 36),
new Vector3(14, 2, 37),
new Vector3(14, 2, 38),
new Vector3(15, 2, 36),
new Vector3(15, 2, 37),
new Vector3(15, 2, 38),
new Vector3(16, 2, 36),
new Vector3(16, 2, 37),
new Vector3(16, 2, 38),
new Vector3(3, 1.5f, 48),
new Vector3(3, 1.5f, 49),
new Vector3(3, 1.5f, 50),
new Vector3(4, 1.5f, 48),
new Vector3(4, 1.5f, 49),
new Vector3(4, 1.5f, 50),
new Vector3(5, 1.5f, 48),
new Vector3(5, 1.5f, 49),
new Vector3(5, 1.5f, 50),
new Vector3(15, 1.5f, 25),
new Vector3(15, 1.5f, 26),
new Vector3(15, 1.5f, 27),
new Vector3(16, 1.5f, 25),
new Vector3(16, 1.5f, 26),
new Vector3(16, 1.5f, 27),
new Vector3(17, 1.5f, 25),
new Vector3(17, 1.5f, 26),
new Vector3(17, 1.5f, 27),
new Vector3(5, 1, 49),
new Vector3(5, 1, 50),
new Vector3(5, 1, 51),
new Vector3(5, 1, 52),
new Vector3(5, 1, 53),
new Vector3(6, 1, 49),
new Vector3(6, 1, 50),
new Vector3(6, 1, 51),
new Vector3(6, 1, 52),
new Vector3(6, 1, 53),
new Vector3(7, 1, 49),
new Vector3(7, 1, 50),
new Vector3(7, 1, 51),
new Vector3(7, 1, 52),
new Vector3(7, 1, 53),
new Vector3(8, 1, 49),
new Vector3(8, 1, 50),
new Vector3(8, 1, 51),
new Vector3(8, 1, 52),
new Vector3(8, 1, 53),
new Vector3(9, 1, 49),
new Vector3(9, 1, 50),
new Vector3(9, 1, 51),
new Vector3(9, 1, 52),
new Vector3(9, 1, 53),
new Vector3(33, 5, 19),
new Vector3(36, 4.5f, 16),
new Vector3(30, 4.5f, 22),
new Vector3(30, 4.5f, 22),
new Vector3(32, 4, 13),
new Vector3(31, 4, 25),
new Vector3(38, 4, 14),
new Vector3(27, 4, 19),
new Vector3(38, 4, 24),
new Vector3(40, 3.5f, 12),
new Vector3(41, 3.5f, 18),
new Vector3(40, 3.5f, 12),
new Vector3(43, 3, 22),
new Vector3(43, 3, 19),
new Vector3(21, 2.5f, 15),
new Vector3(45, 2.5f, 19),
new Vector3(44, 2.5f, 30),
new Vector3(44, 2.5f, 8),
new Vector3(21, 2.5f, 21),
new Vector3(31, 2.5f, 7),
new Vector3(45, 2.5f, 22),
new Vector3(21, 2.5f, 20),
new Vector3(37, 2, 4),
new Vector3(37, 2, 5),
new Vector3(37, 2, 6),
new Vector3(38, 2, 4),
new Vector3(38, 2, 5),
new Vector3(38, 2, 6),
new Vector3(39, 2, 4),
new Vector3(39, 2, 5),
new Vector3(39, 2, 6),
new Vector3(46, 2, 14),
new Vector3(46, 2, 15),
new Vector3(46, 2, 16),
new Vector3(47, 2, 14),
new Vector3(47, 2, 15),
new Vector3(47, 2, 16),
new Vector3(48, 2, 14),
new Vector3(48, 2, 15),
new Vector3(48, 2, 16),
new Vector3(34, 2, 32),
new Vector3(34, 2, 33),
new Vector3(34, 2, 34),
new Vector3(35, 2, 32),
new Vector3(35, 2, 33),
new Vector3(35, 2, 34),
new Vector3(36, 2, 32),
new Vector3(36, 2, 33),
new Vector3(36, 2, 34),
new Vector3(29, 2, 32),
new Vector3(29, 2, 33),
new Vector3(29, 2, 34),
new Vector3(30, 2, 32),
new Vector3(30, 2, 33),
new Vector3(30, 2, 34),
new Vector3(31, 2, 32),
new Vector3(31, 2, 33),
new Vector3(31, 2, 34),
new Vector3(45, 2, 5),
new Vector3(45, 2, 6),
new Vector3(45, 2, 7),
new Vector3(46, 2, 5),
new Vector3(46, 2, 6),
new Vector3(46, 2, 7),
new Vector3(47, 2, 5),
new Vector3(47, 2, 6),
new Vector3(47, 2, 7),
new Vector3(30, 1.5f, 34),
new Vector3(30, 1.5f, 35),
new Vector3(30, 1.5f, 36),
new Vector3(31, 1.5f, 34),
new Vector3(31, 1.5f, 35),
new Vector3(31, 1.5f, 36),
new Vector3(32, 1.5f, 34),
new Vector3(32, 1.5f, 35),
new Vector3(32, 1.5f, 36),
new Vector3(14, 1, 34),
new Vector3(14, 1, 35),
new Vector3(14, 1, 36),
new Vector3(14, 1, 37),
new Vector3(14, 1, 38),
new Vector3(15, 1, 34),
new Vector3(15, 1, 35),
new Vector3(15, 1, 36),
new Vector3(15, 1, 37),
new Vector3(15, 1, 38),
new Vector3(16, 1, 34),
new Vector3(16, 1, 35),
new Vector3(16, 1, 36),
new Vector3(16, 1, 37),
new Vector3(16, 1, 38),
new Vector3(17, 1, 34),
new Vector3(17, 1, 35),
new Vector3(17, 1, 36),
new Vector3(17, 1, 37),
new Vector3(17, 1, 38),
new Vector3(18, 1, 34),
new Vector3(18, 1, 35),
new Vector3(18, 1, 36),
new Vector3(18, 1, 37),
new Vector3(18, 1, 38),
new Vector3(49, 1, 20),
new Vector3(49, 1, 21),
new Vector3(49, 1, 22),
new Vector3(49, 1, 23),
new Vector3(49, 1, 24),
new Vector3(50, 1, 20),
new Vector3(50, 1, 21),
new Vector3(50, 1, 22),
new Vector3(50, 1, 23),
new Vector3(50, 1, 24),
new Vector3(51, 1, 20),
new Vector3(51, 1, 21),
new Vector3(51, 1, 22),
new Vector3(51, 1, 23),
new Vector3(51, 1, 24),
new Vector3(52, 1, 20),
new Vector3(52, 1, 21),
new Vector3(52, 1, 22),
new Vector3(52, 1, 23),
new Vector3(52, 1, 24),
new Vector3(53, 1, 20),
new Vector3(53, 1, 21),
new Vector3(53, 1, 22),
new Vector3(53, 1, 23),
new Vector3(53, 1, 24),
new Vector3(48, 1, 34),
new Vector3(48, 1, 35),
new Vector3(48, 1, 36),
new Vector3(48, 1, 37),
new Vector3(48, 1, 38),
new Vector3(49, 1, 34),
new Vector3(49, 1, 35),
new Vector3(49, 1, 36),
new Vector3(49, 1, 37),
new Vector3(49, 1, 38),
new Vector3(50, 1, 34),
new Vector3(50, 1, 35),
new Vector3(50, 1, 36),
new Vector3(50, 1, 37),
new Vector3(50, 1, 38),
new Vector3(51, 1, 34),
new Vector3(51, 1, 35),
new Vector3(51, 1, 36),
new Vector3(51, 1, 37),
new Vector3(51, 1, 38),
new Vector3(52, 1, 34),
new Vector3(52, 1, 35),
new Vector3(52, 1, 36),
new Vector3(52, 1, 37),
new Vector3(52, 1, 38),
new Vector3(37, 1, 35),
new Vector3(37, 1, 36),
new Vector3(37, 1, 37),
new Vector3(37, 1, 38),
new Vector3(37, 1, 39),
new Vector3(38, 1, 35),
new Vector3(38, 1, 36),
new Vector3(38, 1, 37),
new Vector3(38, 1, 38),
new Vector3(38, 1, 39),
new Vector3(39, 1, 35),
new Vector3(39, 1, 36),
new Vector3(39, 1, 37),
new Vector3(39, 1, 38),
new Vector3(39, 1, 39),
new Vector3(40, 1, 35),
new Vector3(40, 1, 36),
new Vector3(40, 1, 37),
new Vector3(40, 1, 38),
new Vector3(40, 1, 39),
new Vector3(41, 1, 35),
new Vector3(41, 1, 36),
new Vector3(41, 1, 37),
new Vector3(41, 1, 38),
new Vector3(41, 1, 39),
new Vector3(48, 1, 2),
new Vector3(48, 1, 3),
new Vector3(48, 1, 4),
new Vector3(49, 1, 2),
new Vector3(49, 1, 3),
new Vector3(49, 1, 4),
new Vector3(50, 1, 2),
new Vector3(50, 1, 3),
new Vector3(50, 1, 4),
new Vector3(51, 1, 2),
new Vector3(51, 1, 3),
new Vector3(51, 1, 4),
new Vector3(52, 1, 2),
new Vector3(52, 1, 3),
new Vector3(52, 1, 4),
new Vector3(14, 1, 34),
new Vector3(14, 1, 35),
new Vector3(14, 1, 36),
new Vector3(14, 1, 37),
new Vector3(14, 1, 38),
new Vector3(15, 1, 34),
new Vector3(15, 1, 35),
new Vector3(15, 1, 36),
new Vector3(15, 1, 37),
new Vector3(15, 1, 38),
new Vector3(16, 1, 34),
new Vector3(16, 1, 35),
new Vector3(16, 1, 36),
new Vector3(16, 1, 37),
new Vector3(16, 1, 38),
new Vector3(17, 1, 34),
new Vector3(17, 1, 35),
new Vector3(17, 1, 36),
new Vector3(17, 1, 37),
new Vector3(17, 1, 38),
new Vector3(18, 1, 34),
new Vector3(18, 1, 35),
new Vector3(18, 1, 36),
new Vector3(18, 1, 37),
new Vector3(18, 1, 38),
new Vector3(37, 1, 35),
new Vector3(37, 1, 36),
new Vector3(37, 1, 37),
new Vector3(37, 1, 38),
new Vector3(37, 1, 39),
new Vector3(38, 1, 35),
new Vector3(38, 1, 36),
new Vector3(38, 1, 37),
new Vector3(38, 1, 38),
new Vector3(38, 1, 39),
new Vector3(39, 1, 35),
new Vector3(39, 1, 36),
new Vector3(39, 1, 37),
new Vector3(39, 1, 38),
new Vector3(39, 1, 39),
new Vector3(40, 1, 35),
new Vector3(40, 1, 36),
new Vector3(40, 1, 37),
new Vector3(40, 1, 38),
new Vector3(40, 1, 39),
new Vector3(41, 1, 35),
new Vector3(41, 1, 36),
new Vector3(41, 1, 37),
new Vector3(41, 1, 38),
new Vector3(41, 1, 39),
new Vector3(28, 1, 2),
new Vector3(28, 1, 3),
new Vector3(29, 1, 2),
new Vector3(29, 1, 3),
new Vector3(30, 1, 2),
new Vector3(30, 1, 3),
new Vector3(31, 1, 2),
new Vector3(31, 1, 3),
new Vector3(32, 1, 2),
new Vector3(32, 1, 3),
new Vector3(49, 1, 17),
new Vector3(49, 1, 18),
new Vector3(49, 1, 19),
new Vector3(49, 1, 20),
new Vector3(49, 1, 21),
new Vector3(50, 1, 17),
new Vector3(50, 1, 18),
new Vector3(50, 1, 19),
new Vector3(50, 1, 20),
new Vector3(50, 1, 21),
new Vector3(51, 1, 17),
new Vector3(51, 1, 18),
new Vector3(51, 1, 19),
new Vector3(51, 1, 20),
new Vector3(51, 1, 21),
new Vector3(52, 1, 17),
new Vector3(52, 1, 18),
new Vector3(52, 1, 19),
new Vector3(52, 1, 20),
new Vector3(52, 1, 21),
new Vector3(53, 1, 17),
new Vector3(53, 1, 18),
new Vector3(53, 1, 19),
new Vector3(53, 1, 20),
new Vector3(53, 1, 21),
new Vector3(48, 1, 2),
new Vector3(48, 1, 3),
new Vector3(48, 1, 4),
new Vector3(49, 1, 2),
new Vector3(49, 1, 3),
new Vector3(49, 1, 4),
new Vector3(50, 1, 2),
new Vector3(50, 1, 3),
new Vector3(50, 1, 4),
new Vector3(51, 1, 2),
new Vector3(51, 1, 3),
new Vector3(51, 1, 4),
new Vector3(52, 1, 2),
new Vector3(52, 1, 3),
new Vector3(52, 1, 4),
new Vector3(14, 1, 34),
new Vector3(14, 1, 35),
new Vector3(14, 1, 36),
new Vector3(14, 1, 37),
new Vector3(14, 1, 38),
new Vector3(15, 1, 34),
new Vector3(15, 1, 35),
new Vector3(15, 1, 36),
new Vector3(15, 1, 37),
new Vector3(15, 1, 38),
new Vector3(16, 1, 34),
new Vector3(16, 1, 35),
new Vector3(16, 1, 36),
new Vector3(16, 1, 37),
new Vector3(16, 1, 38),
new Vector3(17, 1, 34),
new Vector3(17, 1, 35),
new Vector3(17, 1, 36),
new Vector3(17, 1, 37),
new Vector3(17, 1, 38),
new Vector3(18, 1, 34),
new Vector3(18, 1, 35),
new Vector3(18, 1, 36),
new Vector3(18, 1, 37),
new Vector3(18, 1, 38),
new Vector3(27, 1, 2),
new Vector3(27, 1, 3),
new Vector3(28, 1, 2),
new Vector3(28, 1, 3),
new Vector3(29, 1, 2),
new Vector3(29, 1, 3),
new Vector3(30, 1, 2),
new Vector3(30, 1, 3),
new Vector3(31, 1, 2),
new Vector3(31, 1, 3),
};
        }

        int k = 0;
        float alturaMaxima2 = alturaMaxima;
        int tope = (int)alturaMaxima * 2;
        while (k < tope)
        {
            if (alturaMaxima2 == 0.5f)
            {               
                break;
            }

            alturaMaxima2 -= 0.5f;

            if (alturaMaxima2 < 0.5f)
            {
                alturaMaxima2 = 0.5f;
            }

            try
            {
                GenerarNivel(alturaMaxima2, listadoTerrenoInicial);                
            }
            catch (Exception fallo)
            {
                Debug.Log(fallo);
                k -= 1;
            }

            k += 1;        
        }

        //----------------------------------------------------------

        if (agua == true)
        {
            List<Vector3> listadoAguaInicial = new List<Vector3>();

            if (aleatorio == true)
            {
                listadoAguaInicial = vectores.GenerarAgua(terrenos, (int)arranque.tamañoEscenarioX, (int)arranque.tamañoEscenarioZ, alturaMaxima, limitesMapa);
            }
            else
            {
                listadoAguaInicial = new List<Vector3> {
new Vector3(31, 0, 3),
new Vector3(30, 0, 3),
new Vector3(32, 0, 3),
new Vector3(31, 0, 3),
new Vector3(30, 0, 3),
new Vector3(32, 0, 3),
new Vector3(31, 0, 4),
new Vector3(30, 0, 4),
new Vector3(32, 0, 4),
new Vector3(31, 0, 5),
new Vector3(30, 0, 5),
new Vector3(32, 0, 5),
new Vector3(31, 0, 6),
new Vector3(30, 0, 6),
new Vector3(32, 0, 6),
new Vector3(31, 0, 7),
new Vector3(30, 0, 7),
new Vector3(32, 0, 7),
new Vector3(31, 0, 8),
new Vector3(30, 0, 8),
new Vector3(32, 0, 8),
new Vector3(31, 0, 9),
new Vector3(30, 0, 9),
new Vector3(32, 0, 9),
new Vector3(32, 0, 9),
new Vector3(31, 0, 8),
new Vector3(33, 0, 7),
new Vector3(33, 0, 10),
new Vector3(32, 0, 9),
new Vector3(34, 0, 8),
new Vector3(34, 0, 11),
new Vector3(33, 0, 10),
new Vector3(34, 0, 11),
new Vector3(56, 0, 30),
new Vector3(56, 0, 33),
new Vector3(57, 0, 31),
new Vector3(56, 0, 35),
new Vector3(57, 0, 35),
new Vector3(56, 0, 36),
new Vector3(57, 0, 36),
new Vector3(56, 0, 37),
new Vector3(57, 0, 37),
new Vector3(56, 0, 38),
new Vector3(57, 0, 38),
new Vector3(56, 0, 39),
new Vector3(57, 0, 39),
new Vector3(57, 0, 39),
new Vector3(56, 0, 38),
new Vector3(58, 0, 37),
new Vector3(57, 0, 41),
new Vector3(56, 0, 41),
new Vector3(58, 0, 41),
new Vector3(57, 0, 42),
new Vector3(56, 0, 42),
new Vector3(58, 0, 42),
new Vector3(58, 0, 42),
new Vector3(57, 0, 41),
new Vector3(59, 0, 40),
new Vector3(59, 0, 43),
new Vector3(58, 0, 42),
new Vector3(60, 0, 41),
new Vector3(60, 0, 44),
new Vector3(59, 0, 43),
new Vector3(61, 0, 42),
new Vector3(60, 0, 44),
new Vector3(70, 0, 51),
new Vector3(70, 0, 54),
new Vector3(71, 0, 52),
new Vector3(70, 0, 56),
new Vector3(71, 0, 56),
new Vector3(70, 0, 57),
new Vector3(71, 0, 57),
new Vector3(70, 0, 58),
new Vector3(71, 0, 58),
new Vector3(70, 0, 59),
new Vector3(71, 0, 59),
new Vector3(70, 0, 60),
new Vector3(69, 0, 60),
new Vector3(71, 0, 60),
new Vector3(70, 0, 61),
new Vector3(69, 0, 61),
new Vector3(71, 0, 61),
new Vector3(70, 0, 62),
new Vector3(69, 0, 62),
new Vector3(71, 0, 62),
new Vector3(70, 0, 63),
new Vector3(69, 0, 63),
new Vector3(71, 0, 63),
new Vector3(70, 0, 64),
new Vector3(69, 0, 64),
new Vector3(71, 0, 64),
new Vector3(70, 0, 65),
new Vector3(69, 0, 65),
new Vector3(71, 0, 65),
new Vector3(70, 0, 66),
new Vector3(69, 0, 66),
new Vector3(71, 0, 66),
new Vector3(70, 0, 67),
new Vector3(69, 0, 67),
new Vector3(71, 0, 67),
new Vector3(70, 0, 68),
new Vector3(69, 0, 68),
new Vector3(71, 0, 68),
new Vector3(70, 0, 69),
new Vector3(69, 0, 69),
new Vector3(71, 0, 69),
new Vector3(70, 0, 70),
new Vector3(69, 0, 70),
new Vector3(71, 0, 70),
new Vector3(70, 0, 71),
new Vector3(69, 0, 71),
new Vector3(71, 0, 71),
new Vector3(70, 0, 72),
new Vector3(69, 0, 72),
new Vector3(71, 0, 72),
new Vector3(70, 0, 73),
new Vector3(69, 0, 73),
new Vector3(71, 0, 73),
new Vector3(70, 0, 74),
new Vector3(69, 0, 74),
new Vector3(71, 0, 74),
new Vector3(70, 0, 75),
new Vector3(69, 0, 75),
new Vector3(71, 0, 75),
new Vector3(70, 0, 76),
new Vector3(69, 0, 76),
new Vector3(71, 0, 76),
new Vector3(70, 0, 77),
new Vector3(69, 0, 77),
new Vector3(71, 0, 77),
new Vector3(70, 0, 78),
new Vector3(69, 0, 78),
new Vector3(71, 0, 78),
new Vector3(70, 0, 79),
new Vector3(69, 0, 79),
new Vector3(71, 0, 79),
new Vector3(70, 0, 80),
new Vector3(69, 0, 80),
new Vector3(71, 0, 80),
new Vector3(70, 0, 81),
new Vector3(69, 0, 81),
new Vector3(71, 0, 81),
new Vector3(70, 0, 82),
new Vector3(69, 0, 82),
new Vector3(71, 0, 82),
new Vector3(70, 0, 83),
new Vector3(69, 0, 83),
new Vector3(71, 0, 83),
new Vector3(70, 0, 84),
new Vector3(69, 0, 84),
new Vector3(71, 0, 84),
new Vector3(70, 0, 85),
new Vector3(69, 0, 85),
new Vector3(71, 0, 85),
new Vector3(70, 0, 86),
new Vector3(69, 0, 86),
new Vector3(71, 0, 86),
new Vector3(70, 0, 87),
new Vector3(69, 0, 87),
new Vector3(71, 0, 87),
new Vector3(70, 0, 88),
new Vector3(69, 0, 88),
new Vector3(71, 0, 88),
new Vector3(70, 0, 89),
new Vector3(69, 0, 89),
new Vector3(71, 0, 89),
new Vector3(70, 0, 90),
new Vector3(69, 0, 90),
new Vector3(71, 0, 90),
new Vector3(70, 0, 91),
new Vector3(69, 0, 91),
new Vector3(71, 0, 91),
new Vector3(70, 0, 92),
new Vector3(69, 0, 92),
new Vector3(71, 0, 92),
new Vector3(70, 0, 93),
new Vector3(69, 0, 93),
new Vector3(71, 0, 93),
new Vector3(70, 0, 94),
new Vector3(69, 0, 94),
new Vector3(71, 0, 94),
new Vector3(70, 0, 95),
new Vector3(69, 0, 95),
new Vector3(71, 0, 95),
new Vector3(70, 0, 96),
new Vector3(69, 0, 96),
new Vector3(71, 0, 96),
new Vector3(70, 0, 97),
new Vector3(69, 0, 97),
new Vector3(71, 0, 97),
};
            }

            GenerarAgua(listadoAguaInicial);
        }

        //----------------------------------------------------------

        if (ponerLlano == true)
        {
            PonerLlano2(alturaMaxima2);
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

                if ((y > 0) && (altura == subcasilla.posicion.y) && Limites.Comprobar(x, 2, arranque.tamañoEscenarioX) == true && Limites.Comprobar(z, 2, arranque.tamañoEscenarioZ) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 180) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true)
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
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno1(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno0(terrenos[x + 2, z + 1], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 2], y, 180) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z], y, 270) == true && ComprobarTerreno0(terrenos[x + 1, z + 2], y, 0) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 2], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 2], y, 180) == true)
        {
            PonerTerreno(plano);
        }
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x, z + 1], y, 90) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 180) == true)
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
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z - 1], y, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == false && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x, z + 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true && ComprobarVacio(terrenos[x + 1, z]) == false)
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
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z + 2], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z + 1], y, 270) == true)
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
        else if (ComprobarTerreno0(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true && ComprobarTerreno2(terrenos[x + 1, z + 1], y, 180) == true)
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

        if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno0(terrenos[x + 1, z - 1], y, 0) == true && ComprobarTerreno0(terrenos[x + 2, z - 1], y, 0) == true)
        {
            PonerTerreno(esquina3rotacion0);
        }
        else if (ComprobarTerreno2(terrenos[x, z], y, 0) == true && ComprobarTerreno2(terrenos[x + 2, z - 1], y, 270) == true)
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

        foreach (Terreno subcasilla in terrenos)
        {
            if (subcasilla != null)
            {
                if (subcasilla.id == 40)
                {
                    int x = (int)subcasilla.posicion.x;
                    int z = (int)subcasilla.posicion.z;
                  
                    if (Limites.Comprobar(x, 2, arranque.tamañoEscenarioX) == true && Limites.Comprobar(z, 2, arranque.tamañoEscenarioZ) == true)
                    {
                        if (terrenos[x + 1, z - 1] == null)
                        {
                            CalcularAgua_Xmas1_Zmenos1(x, z);
                        }

                        if (terrenos[x, z - 1] == null)
                        {
                            CalcularAgua_X0_Zmenos1(x, z);
                        }

                        if (terrenos[x, z + 1] == null)
                        {
                            CalcularAgua_X0_Zmas1(x, z);
                        }

                        if (terrenos[x - 1, z] == null)
                        {
                            CalcularAgua_Xmenos1_Z0(x, z);
                        }

                        if (terrenos[x + 1, z] == null)
                        {
                            CalcularAgua_Xmas1_Z0(x, z);
                        }
                    }
                }
            }
        }
    }

    private void CalcularAgua_Xmas1_Zmenos1(int x, int z)
    {
        Terreno esquina3rotacion270 = new Terreno(43, 270, new Vector3(x + 1, 0, z - 1));

        if (terrenos[x + 1, z] == null && terrenos[x, z - 1] == null)
        {
            PonerTerreno(esquina3rotacion270);
        }     
    }

    private void CalcularAgua_Xmas1_Zmas1(int x, int z)
    {
        Terreno esquina3rotacion180 = new Terreno(43, 180, new Vector3(x + 1, 0, z + 1));

        PonerTerreno(esquina3rotacion180);
    }

    private void CalcularAgua_X0_Zmenos1(int x, int z)
    {
        Terreno rampa1rotacion270 = new Terreno(41, 270, new Vector3(x, 0, z - 1));

        PonerTerreno(rampa1rotacion270);
    }

    private void CalcularAgua_X0_Zmas1(int x, int z)
    {
        Terreno rampa1rotacion90 = new Terreno(41, 90, new Vector3(x, 0, z + 1));

        PonerTerreno(rampa1rotacion90);
    }

    private void CalcularAgua_Xmenos1_Z0(int x, int z)
    {
        Terreno rampa1rotacion0 = new Terreno(41, 0, new Vector3(x - 1, 0, z));

        PonerTerreno(rampa1rotacion0);
    }

    private void CalcularAgua_Xmas1_Z0(int x, int z)
    {
        Terreno esquina3rotacion270 = new Terreno(42, 270, new Vector3(x + 1, 0, z));

        if (ComprobarAgua(x + 1, z + 1) == true)
        {
            PonerTerreno(esquina3rotacion270);
        }
      
        //---------------------------------------

        Terreno rampa1rotacion180 = new Terreno(41, 180, new Vector3(x + 1, 0, z));

        PonerTerreno(rampa1rotacion180);
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
            if (ComprobarLimiteX((int)terreno.posicion.x, limitesMapa) == true && ComprobarLimiteZ((int)terreno.posicion.z, limitesMapa) == true)
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
            if (ComprobarLimiteX((int)terreno.posicion.x, limitesMapa) == true && ComprobarLimiteZ((int)terreno.posicion.z, limitesMapa) == true)
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
            if (ComprobarLimiteX((int)terreno.posicion.x, limitesMapa) == true && ComprobarLimiteZ((int)terreno.posicion.z, limitesMapa) == true)
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
            if (ComprobarLimiteX((int)terreno.posicion.x, limitesMapa) == true && ComprobarLimiteZ((int)terreno.posicion.z, limitesMapa) == true)
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

    private bool ComprobarAgua(int x, int z)
    {
        if (ComprobarLimiteX(x, limitesMapa) == true && ComprobarLimiteZ(z, limitesMapa) == true)
        {
            if (terrenos[x, z] != null)
            {
                if (terrenos[x, z].id == 40)
                {
                    return true;
                }
            }
        }

        return false;
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
