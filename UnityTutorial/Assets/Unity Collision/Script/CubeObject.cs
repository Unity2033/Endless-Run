using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{

    // OnCollisionEnter : 충돌을 했을 때 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌...");
    }

    // OnCollisionEnter : 충돌 중일 때 호출되는 함수
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("충돌 중...");
    }

    // OnCollisionExit : 충돌을 벗어났을 때 호출되는 함수
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 종료");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            Debug.Log("Trigger 충돌");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            Debug.Log("Trigger 충돌 중...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main Cube")
        {
            Debug.Log("Trigger 충돌 종료...");
        }
    }
}
