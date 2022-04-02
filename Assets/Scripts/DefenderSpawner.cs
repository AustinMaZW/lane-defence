using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders"; //creating a constant name so it can easily be accessed
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        // method to call creating defender parent child relationship
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME); //if defenderparent doesn't exist then create one
        }
    }

    private void OnMouseDown()
    {
        if (defender!=null)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)  //before spawning, check if have resource to spawn
    {
        var ResourceDisplay = FindObjectOfType<ResourceDisplay>();
        int defenderCost = defender.GetResourceCost();
        if (ResourceDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos); //spawn defender
            ResourceDisplay.SpendResource(defenderCost); //Spend amount of resources for the defender
        }

    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform; //instantiate new defender as child of parent
    }
}
