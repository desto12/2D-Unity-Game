using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {

    public GameObject skeleton;
    public GameObject spider;
    //public GameObject giant;
    public Collider2D SpawnPoint1;
    public int skeletonCount, spiderCount;//, giantCount;
    public float skeletonPos, spiderPos;
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "gracz")
        {
            
            SpawnPoint1.enabled = false;
            for (int i = 0; i<skeletonCount; i++ )
            {
                Instantiate(skeleton, collision.transform.position + new Vector3(skeletonPos+(2*i),0,0), Quaternion.identity);
            }
            for (int i = 0; i < spiderCount; i++)
            {
                Instantiate(spider, collision.transform.position + new Vector3(spiderPos + (2*1), 0, 0)*-1, Quaternion.identity);
            }
        }
    }
}
