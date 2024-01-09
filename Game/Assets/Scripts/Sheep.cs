using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] GameObject [] childObjects;

    private void Start()
    {
        if(DataManager.instance.QuestScore >= 100000)
        {
            for(int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i].SetActive(false);
            }
        }
    }
}
