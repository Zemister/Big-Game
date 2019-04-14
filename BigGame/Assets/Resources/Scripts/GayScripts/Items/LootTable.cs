using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour {

    [System.Serializable]
    public class DropCurrency
    {
        public string name;
        public GameObject item;
        public int dropChance;
    }

    public List <DropCurrency> Loot_Table = new List<DropCurrency>();
    public int dropChance;

    public void calculateLoot()
    {
        int calc_dropChance = Random.Range(0, 101);

        if (calc_dropChance > dropChance)
        {
            Debug.Log("Nothing");
            return;
        }

        if (calc_dropChance <= dropChance)
        {
            int itemWeight = 0;

            for(int i = 0; i < Loot_Table.Count; i++)
            {
                itemWeight += Loot_Table[i].dropChance;
            }
            Debug.Log("Item Weight = " + itemWeight);

            int randomValue = Random.Range(0, itemWeight);

            for (int j = 0; j < Loot_Table.Count; j++)
            {
                if (randomValue <= Loot_Table[j].dropChance)
                {
                    Instantiate(Loot_Table[j].item, transform.position, Quaternion.identity);
                    return;
                }
                randomValue -= Loot_Table[j].dropChance;
                Debug.Log("Random Value Decreased " + randomValue);
            }
        }

    }
}
