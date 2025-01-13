using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.TryGetComponent<ICollectables>(out ICollectables icoll))
        {
            icoll.Collect();
        }
    }
}
