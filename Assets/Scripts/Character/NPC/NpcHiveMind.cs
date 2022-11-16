using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHiveMind : MonoBehaviour
{
    [SerializeField] public List<Character> walkingCharacters = new List<Character>();
    [SerializeField] public List<AggressiveCharacter> aggressiveCharacters = new List<AggressiveCharacter>();
    
    [SerializeField] private float moveCooldown = 1;
    [SerializeField] private float searchCooldown = 1;

    private float moveTimer = 0;
    private float searchTimer = 0;


    void Start()
    {
        walkingCharacters.AddRange(FindObjectsOfType<Character>());
        aggressiveCharacters.AddRange(FindObjectsOfType<AggressiveCharacter>());
    }


    void Update()
    {
        moveTimer += Time.deltaTime;
        searchTimer += Time.deltaTime;

        if (moveTimer > moveCooldown)
        {
            moveTimer = 0;
            foreach (IWalkingCharacter character in walkingCharacters){
                character.DoMove();
            }
        }

        if (searchTimer > searchCooldown)
        {
            searchTimer = 0;
            foreach (IAggressiveEnemy character in aggressiveCharacters) 
            {
                character.SearchForPlayer();
                character.CheckPlayerCaught();
            }
        }
    }
}
