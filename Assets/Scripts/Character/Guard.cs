using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    [SerializeField] float detectionRange;


    [SerializeField] Transform playerModel;
    [SerializeField] PlayerController player;
    [SerializeField] LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, detectionRange, playerMask)){
            player.ReloadLevel();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.5f);
        Gizmos.DrawSphere(GetComponent<Transform>().position, detectionRange);
    }
}
