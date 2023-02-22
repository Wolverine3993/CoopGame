using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredDoor : MonoBehaviour
{
    enum Player
    {
        Player1,
        Player2
    }
    [SerializeField] Player player;
    [SerializeField] SpriteRenderer lightObject;
    [SerializeField] Sprite off, on;
    ColouredDoorController controller;
    private void Start()
    {
        controller = transform.parent.GetComponent<ColouredDoorController>();
    }
    public void PlayerEnter(GameObject _player, string playerNumber)
    {
        if(playerNumber == "Player1")
            controller.PlayerEntered(_player, 1);
        else
            controller.PlayerEntered(_player, 2);
        lightObject.sprite = on;
    }
    public void PlayerExit(string playerNumber)
    {
        if (playerNumber == "Player1")
            controller.PlayerExited(1);
        else
            controller.PlayerExited(2);
        lightObject.sprite = off;
    }
    public string GetPlayer()
    {
        return player.ToString();
    }
}
