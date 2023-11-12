using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int createCount = 15;
    [SerializeField] int newZ = 2;

    [SerializeField] GameObject prefab;

    List<GameObject> coins = new List<GameObject>();

    private GameObject rotatePrefab; 

    void Start()
    {
        rotatePrefab = GameObject.Find("Origin Rotation Object");

        CreateCoin();

        ActiveCoin();
    }

    public void CreateCoin()
    {
        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);        

        for (int i = 0; i < createCount; i++) 
        {
            GameObject coin = Instantiate(prefab);

            NewPosition(roadLine, coin);

            coin.transform.localPosition = new Vector3(coin.transform.position.x, coin.transform.position.y, i * newZ);
            
            coins.Add(coin);
        }
    }

    public void ActiveCoin()
    {
        foreach (var element in coins)
        {
            element.GetComponentInChildren<MeshRenderer>().enabled = true;

            element.transform.rotation = Quaternion.Euler(90, 0, rotatePrefab.transform.rotation.z);
        }     
    }

    public void NewPosition(RoadLine roadLine, GameObject prefab)
    {
        float positionX = 3.5f;

        switch(roadLine)
        {
            case RoadLine.LEFT:
                prefab.transform.localPosition = new Vector3(-positionX, prefab.transform.position.y, prefab.transform.position.x);
                break;
            case RoadLine.MIDDLE:
                prefab.transform.localPosition = new Vector3(prefab.transform.position.x, prefab.transform.position.y, prefab.transform.position.x);
                break;
            case RoadLine.RIGHT:
                prefab.transform.localPosition = new Vector3(positionX, prefab.transform.position.y, prefab.transform.position.x);
                break;
        }
    }

    

   
}
