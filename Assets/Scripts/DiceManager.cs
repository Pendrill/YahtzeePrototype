using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public GameObject dice;
    public GameObject diceBG;
    public GameObject highlight;
    public GameObject[] diceRollValue;

    private bool _selected = false;
    public bool _currentlyDisplayed = false;
    public int diceValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Returns a random number between 0-6 for the dice value;
    /// </summary>
    /// <returns>The dice.</returns>
    public int RollDice()
    {
        int rInt = (int)Random.Range(1, 7);
        return rInt;
    }

    /// <summary>
    /// Displays side of dice rolled based on index
    /// </summary>
    /// <param name="index">Index.</param>
    void ActivateDiceSide(int index)
    {
        GameObject selectedSide = diceRollValue[index - 1];
        _ActivateDiceSide(selectedSide, true);
    }

    /// <summary>
    /// Activates side of dice on/off
    /// </summary>
    /// <param name="side">Side.</param>
    /// <param name="value">If set to <c>true</c> value.</param>
    void _ActivateDiceSide(GameObject side, bool value)
    {
        Debug.Log("side");
        side.SetActive(value);
    }

    /// <summary>
    /// Turn the highlight around the dice on/off
    /// </summary>
    /// <param name="value">If set to <c>true</c> value.</param>
    public void ManageHighlight(bool value)
    {
        highlight.SetActive(value);
    }

    void DiceClicked()
    {
        _selected = !_selected;
        ManageHighlight(_selected);
        //do stuff in the game manger here
    }

    /// <summary>
    /// Called when dice is clicked on
    /// </summary>
    private void OnMouseDown()
    {
        DiceClicked();
    }

    public void ActivateDiceVisual(bool value)
    {
        dice.SetActive(value);
        _currentlyDisplayed = true;
        if(value)
        {
            diceValue = RollDice();
            ActivateDiceSide(diceValue);
        }
    }
}
