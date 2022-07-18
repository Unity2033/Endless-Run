using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.state == false) return;

        if (other.gameObject.tag == "Character")
        {
            SoundControl.Instance.SoundCall("Coin");
            GameManager.instance.coin += 10;
            gameObject.SetActive(false);
            GameManager.instance.Save();
        }
    }

    // ���� ������Ʈ�� ��Ȱ��ȭ �Ǿ��� �� ȣ��Ǵ� �Լ��Դϴ�.
    private void OnDisable()
    {
        Invoke("Delay", 1f);
    }

    public void Delay()
    {
        gameObject.SetActive(true);
    }
  
}
