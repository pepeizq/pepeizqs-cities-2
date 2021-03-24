using UnityEngine;

public class Terreno : MonoBehaviour
{
    public int id;
    public int idDebug;

    public bool edificable;     

    [HideInInspector]
    public Vector3 posicion;

    [HideInInspector]
    public int rotacion;

    public Arbol arbol;

    public Terreno(int ID, int Rotacion, Vector3 Posicion)
    {
        id = ID;
        rotacion = Rotacion;
        posicion = Posicion;
    }
}
