using UnityEngine;

public class LancerGraineExplosive : MonoBehaviour
{
    public GameObject grainePrefab; // Assigne le prefab ici
    public Transform pointDeLancement; // Position de départ de la graine
    public float forceDeLancement = 10f; // Ajuste la force du lancer



void Start()
{
    Rigidbody rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.useGravity = true; // Active la gravité
        rb.linearVelocity = Vector3.zero; // Annule toute vitesse initiale
        rb.angularVelocity = Vector3.zero; // Annule toute rotation initiale
    }
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Change "G" par la touche que tu veux
        {
            LancerGraine();
        }
    }

    void LancerGraine()
    {
       

        GameObject graineInstance = Instantiate(grainePrefab, pointDeLancement.position, Quaternion.identity);
        Rigidbody rb = graineInstance.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = transform.forward + Vector3.up * 0.2f; // Ajoute une légère courbe vers le haut
            rb.AddForce(direction * forceDeLancement, ForceMode.Impulse);

            // Limiter la vitesse pour éviter que ça aille trop vite
            float maxSpeed = 15f;
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
}
