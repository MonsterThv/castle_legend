using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using subjects.cs;
using objects;

public class player_actions : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject camera;
    public GameObject build;
    Player player1 = new Player();
    void Start()
    {
    }

    void Update()
    {
        player1.mooving(player, camera);
        player1.rotation(player);
        player1.shut(bullet, player);
        player1.building(build);
    }
}
