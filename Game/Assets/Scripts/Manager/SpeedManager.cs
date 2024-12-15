using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] UnityEvent callback;

    [SerializeField] static float speed;
    [SerializeField] float limitSpeed = 50.0f;

    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Awake()
    {
        speed = 20.0f;

        StartCoroutine(Increase());
    }
 
    IEnumerator Increase()
    {
        while (GameManager.instance.State == true && limitSpeed > speed)
        {
            if (callback != null)
            {
                callback.Invoke();
            }

            yield return new WaitForSeconds(2.5f);

            speed++;
        }
    }
}
