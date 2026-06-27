using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] Obstacle obstacle;

    [SerializeField] float distance = 5f;
    [SerializeField] float radius = 0.5f;
    [SerializeField] LayerMask layerMask;

    public bool blocked;

    private void Awake()
    {
        obstacle = GetComponent<Obstacle>();
    }

    void Update()
    {
        if (blocked || GameManager.instance.State == false) return;

        if (Physics.SphereCast(transform.position, radius, transform.forward, out RaycastHit raycastHit, distance, layerMask))
        {
            blocked = true;

            obstacle.Speed = raycastHit.collider.GetComponent<Obstacle>().Speed;
        }

        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
    }

    private void OnDisable()
    {
        blocked = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position + transform.forward * distance, radius);
    }
}
