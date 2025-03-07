using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public int vie = 50; // Points de vie de l'ennemi

    // Méthode pour recevoir des dégâts
    public void PrendreDegats(int degats)
    {
        vie -= degats;
        Debug.Log(gameObject.name + " a pris " + degats + " dégâts. Vie restante: " + vie);

        if (vie <= 0)
        {
            Mourir();
        }
    }

    void Mourir()
    {
        Debug.Log(gameObject.name + " est mort !");
        Destroy(gameObject); // Détruit l'ennemi
    }
}
