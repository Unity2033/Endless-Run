using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // ���� å�� ��Ģ (Single Responsiblility Principle)
    // ���, Ŭ����, �Լ��� �ϳ��� å�Ӹ� ������ �մϴ�.
    class Goblin
    {
        private string name;
        private int attack;

        public Goblin(string name, int attack)
        {
            this.name = name;
            this.attack = attack;
        }

        public void Attack()
        {
            Debug.Log("�����ϴ�.");
        }

        public void Move()
        {
            Debug.Log("�����δ�.");
        }

        public string Representation()
        {
            return $"�̸� : {name}, ���ݷ� : {attack}";
        }
    }

    void MonsterInformation(Goblin goblin)
    {
        Debug.Log(goblin.Representation());
    }

    private void Start()
    {
        Goblin monster = new Goblin("Baron", 100);

        MonsterInformation(monster);
    }
}
