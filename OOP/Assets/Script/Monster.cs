using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // 단일 책임 원칙 (Single Responsiblility Principle)
    // 모듈, 클래스, 함수는 하나의 책임만 가져야 합니다.
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
            Debug.Log("공격하다.");
        }

        public void Move()
        {
            Debug.Log("움직인다.");
        }

        public string Representation()
        {
            return $"이름 : {name}, 공격력 : {attack}";
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
