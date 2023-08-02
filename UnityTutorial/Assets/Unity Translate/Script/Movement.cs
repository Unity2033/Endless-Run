using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        #region 이동 공식
        // v = v0 + vt

        // transform.position : 자신의 위치
        // Vector3.forward = new Vector(0,0,1); 

        // Time.deltaTime : 프레임이 완료되기까지 걸리는 시간입니다.
        // transform.position += Vector3.forward * speed * Time.deltaTime;
        #endregion

        // Input.GetAxis( ) : 매개변수 Horizontal을 넣어주면 
        // x 좌표에 대한 정보 -1 ~ 1 사이의 값을 반환하는 함수입니다.
        // A, D, ←, →
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0, z);

        // 벡터의 정규화
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
