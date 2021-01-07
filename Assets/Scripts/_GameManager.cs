using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{

    public GameObject[] allPossibleDice;
    public DiceManager[] dices = new DiceManager[5];
    // Start is called before the first frame update
    void Start()
    {
        SelectDiceImages();
        CheckDiceValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RollDice()
    {

    }

    void SelectDiceImages()
    {
        int index = 0;
        while(index != 5)
        {
            int diceIndex = Random.Range(0, allPossibleDice.Length);
            DiceManager dm = allPossibleDice[diceIndex].GetComponent<DiceManager>();
            if(!dm._currentlyDisplayed)
            {
                dm.ActivateDiceVisual(true);
                dices[index] = dm;
                index += 1;
            }
        }
    }
    
    void CheckDiceValue()
    {
        for(int i = 1; i <= 6; i++)
        {
            int value = CheckNumbers(i);
            Debug.Log(i + ": " + value);
        }
    }


    int CheckNumbers(int number)
    {
        int value = 0;
        for(int i = 0; i < dices.Length; i++)
        {
            if(dices[i].diceValue == number)
            {
                value += number;
            }
        }

        return value;
    }

    void checkTwos()
    {

    }

    void checkThrees()
    {

    }

    void checkFours()
    {

    }

    void checkFivess()
    {

    }

    void checkSixes()
    {

    }

}
