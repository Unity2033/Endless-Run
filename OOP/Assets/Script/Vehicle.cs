using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleCar
{
    // �����ϴ� ���
    public void Parking();

    // �ڵ��� �����ϴ� ���
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

// 4. �������� ���� ��Ģ
// ���� ���踦 ���� �� �ڽź��� ��ȭ�ϱ� ���� �ͺ��ٴ�
// ��ȭ���� �ʴ� �Ϳ� �����ؾ� �մϴ�.

// ��ȭ���� �ʴ� ���̶�?
// ��å �Ǵ� ���� ���� �帧�� �߻����� �����̸�, �߻� Ŭ������
// �������̽��� ǥ���� �� �ֽ��ϴ�.

// ��ȭ�ϱ� ���� ���̶�?
// ���� ���� �Ǵ� ������Ʈ�� ���� ��ü���� ���̸�, ��ü����
// Ŭ������ ǥ���� �� �ִ� ���Դϴ�.


// 5. �������� ġȯ ��Ģ
// ���α׷����� �ڷ��� S�� T�� �������̶�� ���α׷���
// �����ϴ� ������ ������� T�� ��ü�� S�� ��ü�� ��ü�ص�
// ���α׷��� ���������� �����ؾ� �մϴ�.



public class Vehicle : MonoBehaviour
{
    // �������̽� �и� ��Ģ
    // Ŭ���̾�Ʈ�� �ڽ��� ������� �ʴ�
    // �Լ��� ���� ������ ���� �ʾƾ� �մϴ�.

    // �߻����� �������̽��� ��ü���̰� ���� ������
    // ������ �������̽��� �и����� Ŭ���̾�Ʈ�� �� �ʿ���
    // �Լ��� �̿��� �� �ֵ��� �����ؾ� �մϴ�.

    class Horse : IVehicleHours
    {
        public void Eat()
        {
            Debug.Log("����� �Դ´�.");
        }
    }

    class Car : IVehicleCar
    {
        public void ControlHandle()
        {
            Debug.Log("�ڵ��� �ڵ� ����");
        }

        public void Parking()
        {
            Debug.Log("�ڵ��� ����");
        }
    }

    class Kickboard : IVehicleCar, IVehicleKickBoard
    {
        public void ControlHandle()
        {
            Debug.Log("ű���� �ڵ� ����");
        }

        public void Lock()
        {
            Debug.Log("�۸� ��� ��ġ");
        }

        public void Parking()
        {
            Debug.Log("ű���� ���ϴ� ��ġ�� ����");
        }
    }

}
