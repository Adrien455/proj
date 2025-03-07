using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<ItemData> content = new List<ItemData>(); // Liste des objets dans l'inventaire

    [SerializeField]
    private GameObject inventoryPanel; // Le panneau de l'inventaire dans l'interface

    [SerializeField]
    private Transform inventorySlotsParent; // Parent des emplacements (slots) dans l'inventaire

    // Taille maximale de l'inventaire
    const int InventorySize = 24;

    private void Start()
    {
        RefreshContent(); // Met à jour l'affichage de l'inventaire au démarrage
    }

    private void Update()
    {
        // Vérifie si la touche "I" est appuyée
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Active ou désactive l'affichage du panneau de l'inventaire
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    // Ajoute un objet à l'inventaire
    public void AddItem(ItemData item)
    {
        content.Add(item); // Ajoute l'objet à la liste
        Debug.Log($"Ajouté : {item.name}"); // Affiche un message de débogage
        RefreshContent(); // Met à jour l'affichage après l'ajout
    }

    // Vérifie si l'inventaire est plein
    public bool IsFull()
    {
        return InventorySize == content.Count; // Retourne vrai si la taille maximale est atteinte
    }

    // Met à jour l'affichage des objets dans les slots
    private void RefreshContent()
    {
        // Parcourt tous les objets de l'inventaire
        for (int i = 0; i < content.Count; i++)
        {
            // Vérifie qu'il y a assez de slots pour afficher l'objet
            if (i < inventorySlotsParent.childCount)
            {
                Transform slot = inventorySlotsParent.GetChild(i); // Récupère le slot
                Image image = slot.GetChild(0).GetComponent<Image>(); // Récupère l'image dans le slot

                // Vérifie si l'image est disponible
                if (image != null)
                {
                    image.sprite = content[i].visual; // Assigne l'image de l'objet
                    image.enabled = true; // Active l'image
                    Debug.Log($"Sprite '{content[i].visual?.name}' assigné au slot {i}."); // Log pour vérification
                }
                else
                {
                    Debug.LogWarning($"Pas d'image pour le slot {i}."); // Log si l'image est absente
                }
            }
            else
            {
                Debug.LogWarning($"Pas assez de slots pour afficher l'item {content[i].name}."); // Log si plus d'objets que de slots
            }
        }
    }
}
