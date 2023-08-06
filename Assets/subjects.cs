using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UI;


namespace subjects.cs
{

    public class Player : MonoBehaviour
    {
        public int bullets = 30;
        public bool building_mod = false;
        public bool was_build_chousen = false;
        public int HP = 100;
        public string Name = "";
        public float speed = 5f;
        public bool moov_build = false;
        public bool build_menu_is_active = false;
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

        private Vector3 get_x_and_y_for_bialding_1()
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouse_x = mouse.x;
            float mouse_y = mouse.y;
            float build_x = 0f;
            float build_y = 0f;
            double temp_x = Math.Round(mouse_x);
            double temp_y = Math.Round(mouse_y);
            if(mouse_x > temp_x)
            {
                build_x = Convert.ToSingle(temp_x) + 0.5f;
            }
            else
            {
                build_x = Convert.ToSingle(temp_x) - 0.5f;
            }
            if (mouse_y > temp_y)
            {
                build_y = Convert.ToSingle(temp_y) + 0.5f;
            }
            else
            {
                build_y = Convert.ToSingle(temp_y) - 0.5f;
            }
            return new Vector3(build_x, build_y, 0);
        }

        public void create_building(GameObject build)
        {
            GameObject fl_build = null;
            if (Input.GetKeyDown(KeyCode.F))
            {
                building_mod = true;
            }
            if(was_build_chousen)
            {
                fl_build = Instantiate(build, get_x_and_y_for_bialding(), Quaternion.identity) as GameObject;
                add_in_arr(fl_build);
                moov_build = true;
                was_build_chousen = false;
            }
        }
        public void moov_building(GameObject build_menu)
        {
            if (moov_build && arr_of_buildings.Length != 0)
            {
                build_menu.SetActive(false);
                GameObject fl_build = arr_of_buildings[arr_of_buildings.Length - 1];
                if (fl_build.transform.localScale.x % 2 == 0)
                {
                    fl_build.transform.position = get_x_and_y_for_bialding();
                }
                else
                {
                    fl_build.transform.position = get_x_and_y_for_bialding_1();
                }
            }
            if(building_mod && Input.GetMouseButtonDown(0) && build_menu_is_active)
            {
                building_mod = false;
                moov_build = false;
            }
        }
        public void add_in_arr(GameObject build)
        {
            Array.Resize(ref arr_of_buildings, arr_of_buildings.Length + 1);
            arr_of_buildings[arr_of_buildings.Length - 1] = build;
        }
        public GameObject chose_build(GameObject[] buildings, Button[] buttons)
        {
            if(building_mod && !was_build_chousen)
            {
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (buttons[0].is_clicked(mouse))
                {
                    was_build_chousen = true;
                    build_menu_is_active = false;
                    return buildings[0];
                }
                if (buttons[1].is_clicked(mouse))
                {
                    was_build_chousen = true;
                    build_menu_is_active = false;
                    return buildings[1];
                }
                if (buttons[2].is_clicked(mouse))
                {
                    was_build_chousen = true;
                    build_menu_is_active = false;
                    return buildings[2];
                }
            }
            return null;
        }
        public void show_build_menu(GameObject build_menu)
        {
            if (building_mod && !was_build_chousen)
            {
                build_menu.SetActive(true);
                build_menu_is_active = true;
            }
        }
    }
}


