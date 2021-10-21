using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void setHealtPercentage(float percentage)
    {
        bar.localScale = new Vector3(percentage, bar.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
