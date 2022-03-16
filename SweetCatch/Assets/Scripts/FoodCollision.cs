using UnityEngine;

public class FoodCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Food")
        {
            // Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            // rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Destroy(other.gameObject, 5f);
        }
    }
}
