using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float boundY = 183f;
    public float speed = 270f;

    public string axis = "Vertical";
    private void FixedUpdate() {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

        var pos = transform.position;
        if (pos.y > boundY){
            pos.y = boundY;
        }
        else if (pos.y < -boundY){
            pos.y = -boundY;
        }
        transform.position = pos;
    }

}
