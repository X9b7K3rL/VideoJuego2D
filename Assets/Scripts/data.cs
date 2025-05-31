using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    public int puntaje = 0;
    public int vida = 3;

    void Awake()
    {
        // Singleton para que solo exista una instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: persiste entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }
}