using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpStrenght;
    [SerializeField] float lifeTime;
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(transform.forward.x * MoveSpeed, rb.linearVelocity.y, transform.forward.z * MoveSpeed);
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(transform.up * JumpStrenght, ForceMode.Impulse);
    }
}
