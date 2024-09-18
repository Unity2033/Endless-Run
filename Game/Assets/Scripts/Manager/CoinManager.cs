using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] float offset = 2.5f;
    [SerializeField] int createCount = 17;

    void Start()
    {
        Create();
    }

    public void Create()
    {
        for(int i = 0; i < createCount; i++)
        {
            coin = Instantiate(coin, new Vector3(0, 0, offset * i), Quaternion.identity);

            int index = coin.name.IndexOf("(Clone)");

            if (index > 0)
            {
                coin.name = coin.name.Substring(0, index);
            }

            coin.transform.SetParent(gameObject.transform);
        }
    }

}
