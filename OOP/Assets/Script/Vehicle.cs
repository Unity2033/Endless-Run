using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleCar
{
    // 주차하는 기능
    public void Parking();

    // 핸들을 조작하는 기능
    public void ControlHandle();
}

public interface IVehicleHours
{
    public void Eat();
}

public interface IVehicleKickBoard
{
    public void Lock();
}

// 4. 의존관계 역전 원칙
// 의존 관계를 맺을 때 자신보다 변화하기 쉬운 것보다는
// 변화하지 않는 것에 의존해야 합니다.

// 변화하지 않는 것이란?
// 정책 또는 전략 같은 흐름의 추상적인 개념이며, 추상 클래스와
// 인터페이스로 표현할 수 있습니다.

// 변화하기 쉬운 것이란?
// 세부 사항 또는 오브젝트와 같은 구체적인 것이며, 구체적인
// 클래스로 표현할 수 있는 것입니다.


// 5. 리스코프 치환 원칙
// 프로그램에서 자료형 S가 T의 하위형이라면 프로그램이
// 수행하는 업무의 변경없이 T형 객체를 S형 객체로 교체해도
// 프로그램이 정상적으로 동작해야 합니다.



public class Vehicle : MonoBehaviour
{
    // 인터페이스 분리 원칙
    // 클라이언트는 자신이 사용하지 않는
    // 함수에 대해 영향을 받지 않아야 합니다.

    // 추상적인 인터페이스를 구체적이고 작은 단위로
    // 역할을 인터페이스로 분리시켜 클라이언트가 꼭 필요한
    // 함수만 이용할 수 있도록 설계해야 합니다.

    class Horse : IVehicleHours
    {
        public void Eat()
        {
            Debug.Log("당근을 먹는다.");
        }
    }

    class Car : IVehicleCar
    {
        public void ControlHandle()
        {
            Debug.Log("자동차 핸들 조작");
        }

        public void Parking()
        {
            Debug.Log("자동차 주차");
        }
    }

    class Kickboard : IVehicleCar, IVehicleKickBoard
    {
        public void ControlHandle()
        {
            Debug.Log("킥보드 핸들 조작");
        }

        public void Lock()
        {
            Debug.Log("핼멧 잠금 장치");
        }

        public void Parking()
        {
            Debug.Log("킥보드 원하는 위치에 주차");
        }
    }

}
