using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    // Range 
    public float collectRange = 5f;

    // loot collected
    private int lootCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CollectLoot();
        }
    }

    void CollectLoot()
    {
        // Find all loot objects in the scene
        GameObject[] loots = GameObject.FindGameObjectsWithTag("Loot");

        foreach (GameObject loot in loots)
        {
            // Check if loot is within collect range
            if (Vector3.Distance(transform.position, loot.transform.position) <= collectRange)
            {
                // Collect loot
                Destroy(loot);
                lootCount++; // Increase loot count
                Debug.Log("Loot collected! Total loot: " + lootCount);
            }
        }
    }
}
