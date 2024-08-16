using UnityEngine; 
public class MonsterFollow : MonoBehaviour {
     public Transform player; 
     public float monspeed = 2f; 
     void Update() { 
        if (player != null) { 
            // Move towards the player 
            Vector3 direction = player.position - transform.position; direction.y = 0; 
            // Ensure the monster doesn't move up/down too much
             transform.position += direction.normalized * speed * Time.deltaTime; 
             // Jump if the player is on a higher platform 
             if (direction.y > 0.5f) {
                 Jump(); } } } 
                 void Jump() { 
                    Rigidbody rb = GetComponent<Rigidbody>(); 
                    if (rb != null && Mathf.Abs(rb.velocity.y) < 0.01f) 
                    // Check if the monster is grounded 
                    { rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); 
                    // Adjust the jump force as needed 
                    } } }