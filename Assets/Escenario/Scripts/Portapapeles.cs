using System;
using UnityEngine;

public class Portapapeles : MonoBehaviour
{
    [Header("Debug")]
    public bool estado;

    public void Limpiar()
    {
        if (estado == true)
        {
            GUIUtility.systemCopyBuffer = null;
        }       
    }

    public void Texto(string texto)
    {
        if (estado == true)
        {
            GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + texto + Environment.NewLine;
        }
    }

    public void Vector3(Vector3 vector)
    {
        if (estado == true)
        {
            string y = vector.y.ToString("0.00");
            y = y.Replace(",00", null);
            y = y.Replace(",50", ".5f");

            GUIUtility.systemCopyBuffer = GUIUtility.systemCopyBuffer + "new Vector3(" + vector.x.ToString() + ", " + y + ", " + vector.z.ToString() + ")," + Environment.NewLine;
        }
    }
}
