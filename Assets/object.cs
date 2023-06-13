using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace objects { 
    public class InstantiateExample : MonoBehaviour { 
    class Bow
    {
        float speed = 1.0f;
        void shut(int count, GameObject player, GameObject bulet) {
            if (Input.GetMouseButtonDown(0) && count > 0)
            {
                Transform tr = player.GetComponent<Transform>();
                Vector3 mouse = Input.mousePosition;
                float x_p = tr.position.x;
                float y_p = tr.position.y;
                float x_c = mouse.x;
                float y_c = mouse.y;
                float b = (x_p * y_c) - (x_c * y_p) / (x_p - x_c);
                float k = (y_c - b) / x_c;
                double z = Math.Atan(k) * 180 / Math.PI;
                Quaternion rotation = Quaternion.Euler(0, 0, Convert.ToSingle(z));
                Instantiate(bulet, new Vector3(tr.position.x, tr.position.y, 0), rotation);
            }
        }
    }
}
}