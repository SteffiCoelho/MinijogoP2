using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    
    public List<string> inventory = new List<string>();
    public float rayDistance = 5f;
    public LayerMask itemLayer; // só itens
    public TextController inventoryManager;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, itemLayer))
            {
                if (hit.collider.CompareTag("Item")) // verificar object = item
                {
                    GameObject itemInstancia = hit.collider.gameObject;
                    ItemComponent itemComp = itemInstancia.GetComponent<ItemComponent>();
                    if (itemComp != null && !string.IsNullOrEmpty(itemComp.itemName))
                    {
                        inventory.Add(itemComp.itemName);
                        Destroy(hit.collider.gameObject);
                        inventoryManager.updateInventory();

                        Debug.Log("Item coletado: " + itemComp.itemName);
                    }
                    else
                    {
                        Debug.LogWarning("item nao coletado");
                    }
                }
            }
        }
    }
}