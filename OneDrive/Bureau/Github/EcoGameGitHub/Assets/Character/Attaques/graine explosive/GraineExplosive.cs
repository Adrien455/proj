using UnityEngine;

public class GraineExplosive : MonoBehaviour
{
    public GameObject explosionEffect;
    public AudioClip explosionSound;

    public float explosionRadius = 3f;
    public int damage = 30;
    private bool hasExploded = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded && collision.gameObject.CompareTag("Ennemi"))
        {
            Explode();
        }
    }

    void Explode()
    {
        hasExploded = true;

        // Fonctionne, problème dans unity
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

       
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Ennemi")) 
            {
                Ennemi ennemi = hit.GetComponent<Ennemi>();
                if (ennemi != null)
                {
                    ennemi.PrendreDegats(damage);
                }
            }
        }

       
        Destroy(gameObject);
    }
}
