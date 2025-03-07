using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioSource musiqueNormale;
    public AudioSource musiqueCombat;
    public float rayonDetection = 10f;
    public float dureeFondu = 1f; // Durée du fondu

    private AudioSource musiqueActuelle;
    private bool ennemiDetecte = false;
    private Coroutine fonduActuel = null;

    void Start()
    {
        musiqueActuelle = musiqueNormale;
        musiqueActuelle.volume = 1f;
        musiqueCombat.volume = 0f;
        musiqueActuelle.Play();
        musiqueCombat.Play();
    }

    void Update()
    {
        DetecterEnnemis();
    }

    void DetecterEnnemis()
    {
        Collider[] ennemis = Physics.OverlapSphere(transform.position, rayonDetection);
        bool ennemiPresent = false;

        foreach (Collider ennemi in ennemis)
        {
            if (ennemi.CompareTag("Ennemi"))
            {
                ennemiPresent = true;
                break;
            }
        }

        if (ennemiPresent && !ennemiDetecte)
        {
            ChangerMusique(musiqueCombat);
            ennemiDetecte = true;
        }
        else if (!ennemiPresent && ennemiDetecte)
        {
            ChangerMusique(musiqueNormale);
            ennemiDetecte = false;
        }
    }

    void ChangerMusique(AudioSource nouvelleMusique)
    {
        if (musiqueActuelle != nouvelleMusique)
        {
            if (fonduActuel != null)
                StopCoroutine(fonduActuel);

            fonduActuel = StartCoroutine(FonduMusique(musiqueActuelle, nouvelleMusique));
            musiqueActuelle = nouvelleMusique;
        }
    }

    IEnumerator FonduMusique(AudioSource ancienneMusique, AudioSource nouvelleMusique)
    {
        float temps = 0f;

        while (temps < dureeFondu)
        {
            temps += Time.deltaTime;
            ancienneMusique.volume = Mathf.Lerp(1f, 0f, temps / dureeFondu);
            nouvelleMusique.volume = Mathf.Lerp(0f, 1f, temps / dureeFondu);
            yield return null;
        }

        ancienneMusique.volume = 0f;
        nouvelleMusique.volume = 1f;
    }
}
