using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShakeCamera()
    {
        anim.SetTrigger("camShake");
    }
}
