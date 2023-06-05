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
        Vector3 mooving_forward = new Vector3(0, 1, 0);
        Vector3 mooving_side = new Vector3(1, 0, 0);

        public void mooving(GameObject player)
        {
            Transform tr = player.GetComponent<Transform>();
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
        }
        public void rotation(GameObject player)
        {
            Transform tr = player.GetComponent<Transform>();
            if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.W)))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, -45);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.W)))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, 45);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.S)))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, 135);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, -135);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if (Input.GetKey(KeyCode.S))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, 180);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if (Input.GetKey(KeyCode.D))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, -90);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if (Input.GetKey(KeyCode.A))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, 90);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
            if (Input.GetKey(KeyCode.W))
            {
                float smooth = 60f;
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * smooth);
            }
        }
    }
}
