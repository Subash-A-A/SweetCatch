using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject scoreManager;

    private ScoreManager sm;

    private void Start()
    {
        sm = scoreManager.GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Food")
        {
            other.transform.tag = "BowlFood";
            sm.IncrementScore();
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
