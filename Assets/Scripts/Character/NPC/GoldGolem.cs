using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGolem : AggressiveCharacter
{
    //Later we can put this in a larger controller that can act as a hive mind for all AI
    [SerializeField] private float moveCooldown = 1;
    [SerializeField] private float searchCooldown = 1;

    private float moveTimer = 0;
    private float searchTimer = 0;

    void Update()
    {
        moveTimer += Time.deltaTime;
        searchTimer += Time.deltaTime;

        if (moveTimer > moveCooldown)
        {
            DoMove();
            moveTimer = 0;
        }

        if (searchTimer > searchCooldown)
        {
            SearchForPlayer();
            searchTimer = 0;
        }
    }

    public override void DoMove()
    {
        base.DoMove();
        rigidBody.velocity += new Vector3(0, 2, 0);
    }
}
