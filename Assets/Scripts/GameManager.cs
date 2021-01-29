using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int currentItem;
    public Text itemText;

    public void AddItem(int itemToAdd)
    {
        currentItem += itemToAdd;
        itemText.text = "Paint: " + currentItem + "/4";
    }
}
