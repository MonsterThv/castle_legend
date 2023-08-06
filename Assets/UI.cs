using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Button
    {
        public GameObject button;
        public Button(GameObject square)
        {
            button = square;
        }
        public bool is_clicked(Vector3 mouse_pos)
        {
            if (mouse_pos.x <= button.transform.position.x + button.transform.localScale.x / 2 && mouse_pos.x >= button.transform.position.x - button.transform.localScale.x / 2 && mouse_pos.y <= button.transform.position.y + button.transform.localScale.y / 2 && mouse_pos.y >= button.transform.position.y - button.transform.localScale.y / 2 && Input.GetMouseButtonDown(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}