using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using subjects.cs;
using objects;
using UnityEngine.UIElements;


public class player_actions : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject camera;
    public GameObject build1;
    public GameObject build2;
    public GameObject build3;
    private Player player1 = new Player();
    void Start()
    {
    }

    void Update()
    {
        player1.mooving(player, camera);
        player1.rotation(player);
        player1.shut(bullet, player);
        player1.create_building(player1.chose_build(new GameObject[] { build1, build2, build3 }));
        player1.moov_building();
    }
}
