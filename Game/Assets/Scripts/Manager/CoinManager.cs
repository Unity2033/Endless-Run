using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Percentage))]
public class CoinManager : MonoBehaviour
{
    private Percentage percentage;
    
    [SerializeField] int ItemCount;
    [SerializeField] int createCount = 15;
    [SerializeField] int zIndex = 2;
    [SerializeField] GameObject prefab;
    [SerializeField] RotationManager rotationManager;
    [SerializeField] ItemManager itemManager;

    List<GameObject> coins = new List<GameObject>();
    GameObject coin;

    bool itemFlag = false;

    public static System.Action coinCallBack;

    void Start()
    {
        percentage = GetComponent<Percentage>();

        itemManager = GameObject.Find("Item Manager").GetComponent<ItemManager>();

        CreateCoin();

        ActiveCoin();


        //coins[createCount - 1].GetComponentInChildren<MeshFilter>().mesh = Resources.Load<Mesh>("Magnet");
        //coins[createCount - 1].GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>("Magnet");
        //coinCallBack = CreateCoin;
    }

    public void CreateCoin()
    {
        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);        

        for (int i = 0; i < createCount; i++) 
        {
            coin = Instantiate(prefab);
            NewPosition(roadLine, coin);
            coin.transform.localPosition = new Vector3(coin.transform.position.x, coin.transform.position.y, i * zIndex);
            
            coins.Add(coin);
        }
    }

    public void ActiveCoin()
    {
        foreach (var element in coins)
        {
            element.GetComponentInChildren<MeshRenderer>().enabled = true;
            element.transform.rotation = Quaternion.Euler(90,0,rotationManager.transform.rotation.z);
        }
        
        ItemCount = percentage.Rand(20, out itemFlag);  
        
        if(itemFlag==true)
        {
            //Debug.Log(ItemCount);
            coins[ItemCount].SetActive(false);

            GameObject item = itemManager.CloneItem(); 
            item.transform.position = coins[ItemCount].transform.position;

            coins[ItemCount] = item;
        }

    }

    public void NewPosition(RoadLine roadLine, GameObject prefab)
    {
        float directValue = 3.5f;
        //ActiveCoin();        
        
        switch(roadLine)
        {
            case RoadLine.LEFT:
                prefab.transform.localPosition = new Vector3(-directValue, prefab.transform.position.y, prefab.transform.position.x);
                break;
            case RoadLine.MIDDLE:
                prefab.transform.localPosition = new Vector3(prefab.transform.position.x, prefab.transform.position.y, prefab.transform.position.x);
                break;
            case RoadLine.RIGHT:
                prefab.transform.localPosition = new Vector3(directValue, prefab.transform.position.y, prefab.transform.position.x);
                break;
        }
    }

    

   
}
