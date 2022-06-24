using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDrop : MonoBehaviour
{
    private float yMin = -25;


    public void DestroyOutOfFrame()
    {
        if (transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void PointValue() 
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PointValue();
        Destroy(gameObject);
    }


}
