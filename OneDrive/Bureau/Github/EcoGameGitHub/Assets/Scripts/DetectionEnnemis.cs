using UnityEngine;

public class DetectionEnnemis : MonoBehaviour
{
    public AudioSource musiqueCombat;  
    public AudioSource musiqueNormale;
    private int nbEnnemisDansZone = 0; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            nbEnnemisDansZone++;
            musiqueNormale.Stop();
            if (!musiqueCombat.isPlaying)
            {
                musiqueCombat.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            nbEnnemisDansZone--;
            if (nbEnnemisDansZone <= 0)
            {
                musiqueCombat.Stop();
                musiqueNormale.Play();
            }
        }
    }
}
