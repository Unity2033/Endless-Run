using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 클래스
    // 사용자 정의 데이터 유형으로 속성과 함수가 포함되어
    // 있으며, 클래스를 통해 객체를 생성하여 접근하고 사용할 수 있는
    // 집합체입니다.
public class Item
{
    // 생성자란?
    // 클래스의 인스턴스가 생성되는 시점에서 자동으로
    // 호출되는 특수한 멤버 함수입니다.
    public Item()
    {
        Debug.Log("Item이 생성되었습니다.");
    }
}

#endregion

public class Monster : MonoBehaviour
{
    Item item = new Item();

    public GameObject prefab;

    public void Create()
    {
        // prefab : 생성하고 싶은 게임 오브젝트
        // new Vector3(0,0,-5) : 게임 오브젝트를 생성했을 때 (위치)
        // Quaternion.Euler(0,180,0) : 게임 오브젝트를 생성했을 때 (회전)

        int x = Random.Range(0, 10); // 0 ~ 9 까지의 랜덤한 값 
        int y = Random.Range(0, 5);  // 0 ~ 4 까지의 랜덤한 값
        int z = Random.Range(-5, 0); // -5 ~ -1 까지의 랜덤한 값 

        Instantiate(prefab, new Vector3(x, y, z), Quaternion.Euler(0, 180, 0));
    }
}
