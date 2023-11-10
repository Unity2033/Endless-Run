using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static int IncreaseValue(int n)
    {
        int a = 0;
        int b = 1;
        for(int i = 3; i <= n; i++)
        {
            int c = a + b;
            a = b;
            b = c;
        }
        return a;
    }

}
