using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class OstrichEgg : EggDrop
{
    // POLYMORPHISM
    [SerializeField] private int pointValue = 15;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfFrame();
    }

    protected override void PointValue()
    {
        MainManager.Instance.score += pointValue;
    }
}
