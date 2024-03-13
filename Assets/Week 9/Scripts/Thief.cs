using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform[] spawnPoints;
    
    protected override void Attack()
    {
        base.Attack();
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = destination;
        foreach (Transform point in spawnPoints)
        {
            Instantiate(knifePrefab, point.position, point.rotation);
        }
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
