using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject scoreManager;
    [SerializeField] GameObject healthManager;
    [SerializeField] GameObject cam;

    private ScoreManager sm;
    private HealthManager hm;
    private CameraShake cs;

    private void Start()
    {
        sm = scoreManager.GetComponent<ScoreManager>();
        hm = healthManager.GetComponent<HealthManager>();
        cs = cam.GetComponent<CameraShake>();
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
            hm.TakeDamage();
            cs.ShakeCamera();
            DestroyFood df = other.gameObject.AddComponent<DestroyFood>();
            df.ParticleEffects(particle, other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
