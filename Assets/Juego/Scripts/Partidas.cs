using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Juego
{
    public class Partidas : MonoBehaviour
    {
        public List<Partida> ListadoPartidas()
        {
            List<Partida> partidas = new List<Partida>();

            DirectoryInfo carpeta = new DirectoryInfo(Application.persistentDataPath);
            FileInfo[] ficheros = carpeta.GetFiles();

            foreach (FileInfo fichero in ficheros)
            {
                if (fichero.Name.Contains(".save"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fichero2 = File.Open(Application.persistentDataPath + "/" + fichero.Name, FileMode.Open);
                    partidas.Add((Partida)bf.Deserialize(fichero2));
                    fichero2.Close();
                }
            }

            return partidas;
        }


    }
}
