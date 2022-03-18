using UnityEngine;
using System.Collections;

public class SpwanFood : MonoBehaviour
{

    [Header("Food Types")]
    [SerializeField] GameObject food1;
    [SerializeField] GameObject food2;
    [SerializeField] GameObject food3;
    [SerializeField] GameObject bomb;

    [Header("Spawn Parameters")]
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

    GameObject ChooseFood()
    {
        GameObject[] spawnables = { food1, food2, food3, bomb };
        int index = Random.Range(0, spawnables.Length);
        return spawnables[index];
    }

    IEnumerator Spawn()
    {
        Vector2 position = new Vector2(GetXPos(), spawnYloc);
        Instantiate(ChooseFood(), position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine("Spawn");
    }

}
