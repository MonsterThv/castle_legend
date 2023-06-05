using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace subjects.cs
{
    class Player
    {
        public int HP = 100;
        public string Name = "";
        public float speed = 5f;

        public void mooving(GameObject player)
        {
            Transform tr = player.GetComponent<Transform>();
            if (Input.GetKey(KeyCode.W))
            {
                tr.Translate(0, speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                tr.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                tr.Translate(speed * Time.deltaTime,0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                tr.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
