using UnityEngine;

public class Terreno : MonoBehaviour
{
    public int id;
    public bool edificable;

    [HideInInspector]
    public int idDebug;

    [HideInInspector]
    public Vector3 posicion;

    [HideInInspector]
    public int rotacion;

    public Terreno(int ID, int Rotacion, Vector3 Posicion)
    {
        id = ID;
        rotacion = Rotacion;
        posicion = Posicion;
    }
}
