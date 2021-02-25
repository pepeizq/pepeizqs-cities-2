using UnityEngine.SceneManagement;

namespace Interfaz
{
    public static class Reiniciar
    {
        public static void Escena()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
