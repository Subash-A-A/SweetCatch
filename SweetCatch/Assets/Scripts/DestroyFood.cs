using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    [SerializeField] int layerNumber = 6;
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject healthManager;
    [SerializeField] GameObject cam;

    private HealthManager hm;
    private CameraShake cs;

    private void Start()
    {
        hm = healthManager.GetComponent<HealthManager>();
        cs = cam.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == layerNumber)
        {
            if (other.gameObject.tag == "Food" || other.gameObject.tag == "BowlFood")
            {
                FindObjectOfType<AudioManager>().Play("Explosion");
                hm.TakeDamage();
            }
            else if (other.gameObject.tag == "Bomb")
            {
                FindObjectOfType<AudioManager>().Play("BombDestroy");
            }
            cs.ShakeCamera();
            ParticleEffects(particle, other.gameObject);
            Destroy(other.gameObject);
        }
    }

    public void ParticleEffects(ParticleSystem particle, GameObject target)
    {
        ParticleSystem.MainModule psmain = particle.main;
        psmain.startColor = target.GetComponentInChildren<SpriteRenderer>().color;
        ParticleSystem parti = Instantiate(particle, target.transform.position, Quaternion.identity);
        Destroy(parti.gameObject, 0.5f);
    }
}
