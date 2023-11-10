using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Percentage : MonoBehaviour
{
    private int value = 0;
    public int Rand(int percentage, out bool flag)
    {   
        int rand = Random.Range(0, 10);        

        if (rand <= percentage)
        {
            value = Random.Range(0, 15);
            flag = true;
        }
        else 
        {
            flag = false;
        }

        return value;
    }
}
