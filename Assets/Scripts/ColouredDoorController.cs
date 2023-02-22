using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredDoorController : MonoBehaviour
{
    int playersIn = 0;
    GameObject player1, player2;
    void Update()
    {
        if (playersIn == 2)
        {
            player1.GetComponent<PlayerMovement>().EnterDoor();
            player2.GetComponent<PlayerMovement>().EnterDoor();
        }
            
    }
    public void PlayerEntered(GameObject _player, int _num)
    {
        playersIn++;
        switch (_num)
        {
            case 1: player1 = _player; break;
            case 2: player2 = _player; break;
        }
    }
    public void PlayerExited(int _num)
    {
        playersIn--;
        switch (_num)
        {
            case 1: player1 = null; break;
            case 2: player2 = null; break;
        }
    }
}
