using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> coins;

    [SerializeField] float positionX = 4.0f;

    [SerializeField] float offset = 2.5f;
    [SerializeField] int createCount = 16;

    void Awake()
    {
        prefab = ResourceManager.instance.Load<GameObject>("Coin");

        coins.Capacity = 20;

        Create();
    }

    public void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate(prefab);

            clone.transform.SetParent(gameObject.transform);

            clone.transform.localPosition = new Vector3(0, 0, offset * i);

            int index = clone.name.IndexOf("(Clone)");

            if (index > 0)
            {
                clone.name = clone.name.Substring(0, index);
            }

            clone.SetActive(false);

            coins.Add(clone);
        }
    }

    public void InitializePosition()
    {
        transform.localPosition = new Vector3(positionX * Random.Range(-1, 2), 0, 0);
    }

}
