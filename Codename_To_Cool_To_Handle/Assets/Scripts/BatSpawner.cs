using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    private bool isSpawnerOn = false;
    [SerializeField] private GameObject bats;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spanwPoint2;
    [SerializeField] private Transform spawnPoint3;
    private Transform parent;

    private void Start()
    {
        Instantiate(bats, spawnPoint1);
    }
    private void Update()
    {
        if (!isSpawnerOn)
        {
            StartCoroutine(waitForBats());
        }
      
    }

    private IEnumerator waitForBats()
    {
        isSpawnerOn = true;
        yield return new WaitForSeconds(Random.Range(15f, 10f));
        switch (Random.Range(0, 3))
        {
            case 0:
                parent = spawnPoint1;
                break;
            case 1:
                parent = spanwPoint2;
                break;
            case 2:
                parent = spawnPoint3;
                break;
        }
       GameObject temp = Instantiate(bats,parent);

        switch (Random.Range(0, 2))
        {
            case 0:
                temp.transform.localScale = new Vector3(.51f, .51f, .51f);
                break;
            case 1:
                temp.transform.localScale = new Vector3(.30f, .30f, .30f);
                break;
        }

        yield return new WaitForSeconds(Random.Range(15f, 22f));
        isSpawnerOn = false;
    }


}
