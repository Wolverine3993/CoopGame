using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Vector2 player1Respawn;
    [SerializeField] Vector2 player2Respawn;
    private void Start()
    {
        player1Respawn = GameObject.Find("Player1").transform.position;
        player2Respawn = GameObject.Find("Player2").transform.position;
    }
    public Vector2 GetRespawn(string player)
    {
        if(player == "Player1")
            return player1Respawn;
        return player2Respawn;
    }
}
