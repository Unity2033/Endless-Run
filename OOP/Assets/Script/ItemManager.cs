using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    // 개방-폐쇄 원칙
    // 모듈, 클래스, 함수는 확장에 대해 열려있어야 하고,
    // 수정에 대해서는 닫혀 있어야 합니다.

    // 확장에 대해 열려 있다?
    // 앱의 요구 사항이 변경될 때 변경에 맞게 
    // 새로운 동작을 추가하여 모듈을 확장할 수 있어야 합니다.

    // 수정에 대해 닫혀 있다?
    // 모듈의 코드를 수정하지 않아도 기능을 확장하거나
    // 변경할 수 있어야 합니다.

    public abstract class Item
    {
        public abstract void Effect();
    }

    public class WaterRocket : Item
    {
        public override void Effect()
        {
            Debug.Log("물로켓 발사!");
        }
    }

    public class Magnet : Item
    {
        public override void Effect()
        {
            Debug.Log("특정한 플레이어를 따라갑니다.");
        }
    }

    private void TriggerItem(Item item)
    {
        item.Effect();
    }

    private void Start()
    {
        WaterRocket waterRocket = new WaterRocket();
        TriggerItem(waterRocket);

        Magnet magnet = new Magnet();
        TriggerItem(magnet);
    }

}
