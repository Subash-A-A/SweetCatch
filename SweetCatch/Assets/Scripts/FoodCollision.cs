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
            FindObjectOfType<AudioManager>().Play("Food");
            FindObjectOfType<DestroyFood>().ParticleEffects(particle, other.gameObject);
            other.transform.tag = "BowlFood";
            sm.IncrementScore();
            Destroy(other.gameObject, 5f);
        }

        else if (other.transform.tag == "Bomb")
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            hm.TakeDamage();
            cs.ShakeCamera();
            FindObjectOfType<DestroyFood>().ParticleEffects(particle, other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
