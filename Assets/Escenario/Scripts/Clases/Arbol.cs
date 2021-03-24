using UnityEngine;

public class Arbol : MonoBehaviour
{
    public int id;

    [HideInInspector]
    public Vector3 posicion;

    [HideInInspector]
    public int rotacion;

    [HideInInspector]
    public bool visibilidad = true;

    public Arbol(int ID, int Rotacion, Vector3 Posicion)
    {
        id = ID;
        rotacion = Rotacion;
        posicion = Posicion;
    }
}