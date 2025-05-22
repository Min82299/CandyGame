using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCandy : MonoBehaviour
{
    public int bonusPoints = 5;
    public CandyMananger manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.AddCandy(bonusPoints);
            manager.DisplayCandyAmount();
            Destroy(gameObject);
        }
    }
}
