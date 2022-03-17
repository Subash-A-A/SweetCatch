using UnityEngine;

public class FoodCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Food")
        {
            Destroy(other.gameObject, 5f);
        }

        else if (other.transform.tag == "Bomb")
        {
            Debug.Log("TakeDamage");
            Destroy(other.gameObject);
        }
    }
}
