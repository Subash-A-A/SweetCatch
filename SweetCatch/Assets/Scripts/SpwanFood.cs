using UnityEngine;
using System.Collections;

public class SpwanFood : MonoBehaviour
{

    [SerializeField] GameObject food;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] float spawnYloc = 6f;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    int GetXPos()
    {
        return Random.Range(-6, 7);
    }

    IEnumerator Spawn()
    {
        Vector2 position = new Vector2(GetXPos(), spawnYloc);
        Instantiate(food, position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine("Spawn");
    }

}
