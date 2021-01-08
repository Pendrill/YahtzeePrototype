using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{

    public GameObject[] allPossibleDice;
    public List<DiceManager> dices = new List<DiceManager>();
    public RollUIManager uiManager;
    Dictionary<string, int> currentValues = new Dictionary<string, int>();
    Dictionary<string, int> chosenValues = new Dictionary<string, int>();
    Dictionary<string, int> selectedValues = new Dictionary<string, int>();


    int tries = 3;
    int diceInUse = 0;
    int diceNeeded = 5;
    // Start is called before the first frame update
    void Start()
    {
        SetupScoreDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupScoreDictionary()
    {
        string[] names = new string[] { "1", "2", "3", "4", "5", "6", "3k", "4k", "fh", "ss", "ls", "yt", "ch" };
        for(int i = 0; i < names.Length; i++)
        {
            currentValues.Add(names[i], 0);
            chosenValues.Add(names[i], 0);
            selectedValues.Add(names[i], 0);
        }
    }



    public void RollDice()
    {
        if(tries > 0)
        {
            tries -= 1;
            _RollDice();
        }
    }

    void _RollDice()
    {
        RemoveUnusedDice();
        SelectDiceImages();
        CheckDiceValue();
        uiManager.RemoveTry();

    }

    void RemoveUnusedDice()
    {
        for(var i = 0; i < dices.Count; i++)
        {
            DiceManager dice = dices[i];
            if(dice)
            {
                if (!dice.Selected)
                {
                    dice.ResetActiveDice();
                    dices.Remove(dice);
                    i -= 1;
                }
                else
                {
                    dice.DeselectDice();
                }
            }
        }
    }

    void SelectDiceImages()
    {
        int index = 0;
        while(index != (diceNeeded - diceInUse))
        {
            int diceIndex = Random.Range(0, allPossibleDice.Length);
            DiceManager dm = allPossibleDice[diceIndex].GetComponent<DiceManager>();
            if(!dm._currentlyDisplayed)
            {
                dm.ActivateDiceVisual(true);
                dices.Add(dm);
                index += 1;
            }
        }
        diceInUse = 0;
    }

    public void DiceClicked(bool selected)
    {
        diceInUse = selected ? diceInUse + 1 : diceInUse - 1;
    }

    void CheckDiceValue()
    {
        for(int i = 1; i <= 6; i++)
        {
            int value = CheckNumbers(i);
            currentValues[i.ToString()] = value;
            //Debug.Log(i + ": " + value);
        }
        currentValues["ss"] = CheckStraight(3);
        currentValues["ls"] = CheckStraight(4);
    }


    int CheckNumbers(int number)
    {
        int value = 0;
        for(int i = 0; i < dices.Count; i++)
        {
            if(dices[i] && dices[i].diceValue == number)
            {
                value += number;
            }
        }
        return value;
    }

    int CheckStraight(int length)
    {
        int neededLength = length;
        int currentLength = 0;
        int currentValue = 0;
        for (int i = 1; i <= 6; i++)
        {
            if(currentLength == 0)
            {
                currentValue = dices[i].diceValue;
                currentLength += 1;
            }
            else if(currentLength > 0)
            {
                if(dices[i].diceValue == currentValue + 1)
                {
                    currentValue = dices[i].diceValue;
                    currentLength += 1;
                }
                else
                {
                    currentValue = dices[i].diceValue;
                    currentLength = 1;

                }
            }
            if (currentLength >= neededLength)
            {
                return neededLength == 3 ? 30 : 40;
            }
        }
        return 0;
    }

    int Check3OfAKind()
    {
        return 0;
    }

}
