using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace subjects.cs
{

    public class Player : MonoBehaviour
    {
        public int bullets = 10;
        public bool building_mod = false;
        public int HP = 100;
        public string Name = "";
        public float speed = 5f;
        public GameObject[] arr_of_buildings = new GameObject[0];
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
            if (Input.GetMouseButtonDown(0) && bullets > 0 && building_mod == false)
            {
                Transform tr = player.GetComponent<Transform>();
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var direction = tr.position - mouse;
                if (direction.x >= 0)
                {
                    var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
                    Instantiate(bullet, new Vector3(tr.position.x, tr.position.y, 0), Quaternion.Euler(0, 0, angle + 90));
                }
                else
                {
                    var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
                    Instantiate(bullet, new Vector3(tr.position.x, tr.position.y, 0), Quaternion.Euler(0, 0, angle - 90));
                }
                
                bullets -= 1;

            }
        }

        private string sort_str(string str)
        {
            string number = "";
            for(int i = 0; i <= str.Length; i++)
            {
                if (str[i] != ',')
                {
                    number += str[i];
                }
                else
                {
                    return number;
                }
            }
            return "Ooops!";
        }

        private Vector3 get_x_and_y_for_bialding()
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouse_x = mouse.x;
            float mouse_y = mouse.y;
            float build_x = 0f;
            float build_y = 0f;
            if (mouse_x < 0f)
            {
                mouse_x -= 0.5f;
                string temp_x = mouse_x.ToString();
                build_x = float.Parse(sort_str(temp_x) + "," + "0");
            }
            else
            {
                mouse_x += 0.5f;
                string temp_x = mouse_x.ToString();
                build_x = float.Parse(sort_str(temp_x) + "," + "0");
            }
            if (mouse_y < 0f)
            {
                mouse_y -= 0.5f;
                string temp_y = mouse_y.ToString();
                build_y = float.Parse(sort_str(temp_y) + "," + "0");

            }
            else
            {
                mouse_y += 0.5f;
                string temp_y = mouse_y.ToString();
                build_y = float.Parse(sort_str(temp_y) + "," + "0");
            }
            return new Vector3(build_x, build_y, 0);
        }

        public void create_building(GameObject build)
        {
            GameObject fl_build = null;
            if (Input.GetKeyDown(KeyCode.F))
            {
                fl_build = Instantiate(build, get_x_and_y_for_bialding(), Quaternion.identity) as GameObject;
                add_in_arr(fl_build);
                building_mod = true;
            }
        }
        public void moov_building()
        {
            if (building_mod == true)
            {
                arr_of_buildings[arr_of_buildings.Length - 1].transform.position = get_x_and_y_for_bialding();
            }
            if(building_mod && Input.GetMouseButtonDown(0))
            {
                building_mod = false;
            }
        }
        public void add_in_arr(GameObject build)
        {
            Array.Resize(ref arr_of_buildings, arr_of_buildings.Length + 1);
            arr_of_buildings[arr_of_buildings.Length - 1] = build;
        }
    }
}


