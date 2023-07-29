using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    // ����-��� ��Ģ
    // ���, Ŭ����, �Լ��� Ȯ�忡 ���� �����־�� �ϰ�,
    // ������ ���ؼ��� ���� �־�� �մϴ�.

    // Ȯ�忡 ���� ���� �ִ�?
    // ���� �䱸 ������ ����� �� ���濡 �°� 
    // ���ο� ������ �߰��Ͽ� ����� Ȯ���� �� �־�� �մϴ�.

    // ������ ���� ���� �ִ�?
    // ����� �ڵ带 �������� �ʾƵ� ����� Ȯ���ϰų�
    // ������ �� �־�� �մϴ�.

    public abstract class Item
    {
        public abstract void Effect();
    }

    public class WaterRocket : Item
    {
        public override void Effect()
        {
            Debug.Log("������ �߻�!");
        }
    }

    public class Magnet : Item
    {
        public override void Effect()
        {
            Debug.Log("Ư���� �÷��̾ ���󰩴ϴ�.");
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
