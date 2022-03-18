using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    [SerializeField] int layerNumber = 6;
    [SerializeField] ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == layerNumber)
        {
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
