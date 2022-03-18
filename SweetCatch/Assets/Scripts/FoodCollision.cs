using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Food")
        {
            Destroy(other.gameObject, 5f);
        }

        else if (other.transform.tag == "Bomb")
        {
            DestroyFood df = other.gameObject.AddComponent<DestroyFood>();
            df.ParticleEffects(particle, other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
