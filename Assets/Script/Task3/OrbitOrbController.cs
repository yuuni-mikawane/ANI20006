using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitOrbController : MonoBehaviour
{
    public GameObject orbitOrbPrefab;
    public List<OrbitOrb> orbitOrbs;
    public Vector3 target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                target = hit.point;
            }
            LaunchOrb();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnOrb();
        }
    }

    private void SpawnOrb()
    {
        OrbitOrb spawnedOrb = Instantiate(orbitOrbPrefab, gameObject.transform).GetComponent<OrbitOrb>();
        orbitOrbs.Add(spawnedOrb);
        spawnedOrb.gameObject.transform.rotation = 
            Quaternion.Euler(0, Random.Range(-180f, 180f), Random.Range(-20f, 20f));


    }

    private void LaunchOrb()
    {
        if(orbitOrbs.Count != 0)
        {
            orbitOrbs[0].LaunchAtTarget(target);
            Destroy(orbitOrbs[0].gameObject);
            orbitOrbs.RemoveAt(0);
        }
    }
}
