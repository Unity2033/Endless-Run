using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    class Compare : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float hash)
        {
            return hash.GetHashCode();
        }
    }

    static readonly Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>(new Compare());

    public static WaitForSeconds WaitForSecond(float time)
    {
        WaitForSeconds waitForSeconds;

        if (dictionary.TryGetValue(time, out waitForSeconds) == false)
        {
            dictionary.Add(time, new WaitForSeconds(time));

            waitForSeconds = dictionary[time];
        }

        return waitForSeconds;
    }
}
