using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace subjects.cs
{
    class Player
    {
        public int bullets = 10;
        public int HP = 100;
        public string Name = "";
        public float speed = 5f;
        Vector3 mooving_forward = new Vector3(0, 1, 0);
        Vector3 mooving_side = new Vector3(1, 0, 0);

        public void mooving(GameObject player, GameObject camera)
        {
            Transform tr = player.GetComponent<Transform>();
            Transform tr_cam = camera.GetComponent<Transform>();
            if (Input.GetKey(KeyCode.W))
            {
                tr.position += mooving_forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                tr.position += mooving_forward * -speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                tr.position += mooving_side * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                tr.position += mooving_side * -speed * Time.deltaTime;
            }
            tr_cam.position = tr.position - new Vector3(0,0,20);
        }
        public void rotation(GameObject player)
        {
            Transform tr = player.GetComponent<Transform>();
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = tr.position - mouse;
            var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;

            if (direction.x >= 0) tr.rotation = Quaternion.Euler(0, 0, angle + 90);
            else tr.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        public void shut(GameObject bullet, GameObject player)
        {
            if (Input.GetMouseButtonDown(0) && bullets > 0)
            {
                Transform tr = player.GetComponent<Transform>();
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var direction = tr.position - mouse;
                if (direction.x >= 0)
                {
                    var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
                    InstantiateExample.Instantiate(bullet, new Vector3(tr.position.x, tr.position.y, 0), Quaternion.Euler(0, 0, angle + 90));
                }
                else
                {
                    var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
                    InstantiateExample.Instantiate(bullet, new Vector3(tr.position.x, tr.position.y, 0), Quaternion.Euler(0, 0, angle - 90));
                }
                
                bullets -= 1;

            }
        }
    }
}
public class InstantiateExample : MonoBehaviour
{
}

