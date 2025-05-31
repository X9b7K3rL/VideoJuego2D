using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public GameObject kunaiPrefab;      // Prefab del kunai
    public Transform firePoint;         // Punto de aparición del kunai
    public float kunaiSpeed = 10f;

    private bool kunaiHabilitado = false;
    

    void Update()
    {
        // Habilitar kunai con la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            kunaiHabilitado = true;
        }

        // Lanzar kunai solo si está habilitado y se presiona la tecla de disparo (ejemplo: L)
        if (kunaiHabilitado && Input.GetKeyDown(KeyCode.L))
        {
            LanzarKunai();
        }
    }

    // Método para lanzar el kunai
    public void LanzarKunai()
    {
        if (kunaiPrefab != null && firePoint != null)
        {
            GameObject kunai = Instantiate(kunaiPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = kunai.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.right * kunaiSpeed;
            }
        }
    }

}