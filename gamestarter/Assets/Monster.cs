using UnityEngine; 
public class MonsterFollow : MonoBehaviour {
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5;
    private Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        target = GameObject.Find("GoodSquare").transform;
    }

    private void Update() {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
    }

    private void FixedUpdate() {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    public void TakeDamage(float damageAmount)
    {
        health -=  damageAmount;

        if( health <= 0) {
            Destroy(gameObject);
        } 

    }
}