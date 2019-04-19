using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public int[] table = { };

    public int total;
    public int randomNumber;
    private void Start()
    {
        
        foreach(var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total + 1);

        for(int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                //Drop Item here
                Debug.Log("You got: " + table[i]);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}
