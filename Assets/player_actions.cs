using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using subjects.cs;

public class player_actions : MonoBehaviour
{
    public GameObject player;
    Player player1 = new Player();
    void Start()
    {
    }

    void Update()
    {
        player1.mooving(player);
    }
}
