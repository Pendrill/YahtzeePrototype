using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollUIManager : MonoBehaviour
{
    public GameObject[] rollChances;
    int rollCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveTry()
    {
        rollChances[rollCount].SetActive(false);
        rollCount += 1;
    }

    public void ResetRollCount(int count)
    {
        rollCount = count;
    }
}
