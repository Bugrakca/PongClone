using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public AudioClip hit;
    //* Create button to start the game and count down from 3 to 0 then start the game. Send the ball to random vector2.
    public float speed = 350f;
    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = hit;
        Invoke("GoBall", 2);
    }


    private void OnCollisionEnter2D(Collision2D col) {
        BallColDirection(col);
        GetComponent<AudioSource> ().Play ();
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight){
        // 1 - Top of the racket
        // 0 - Racket center
        // -1 - Bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    public Vector2 RandomPostion(Vector2 min, Vector2 max){
        if (min.y > -0.5 || max.y < 0.5){
            min.y = -1;
            max.y = 1;
        }

        if (min.x > -0.5 || max.x < 1){ // Topun x ve y koordinaylarinin 0 a yakin olmamasini sagla.
            min.x = -1;
            max.x = 1;
        }

        Vector2 newPos = new Vector2();
        newPos.x = Random.Range(min.x, max.x);
        newPos.y = Random.Range(min.y, max.y);
        return newPos;
    }

    public void GoBall(){
        GetComponent<Rigidbody2D>().velocity = RandomPostion(Vector2.one, Vector2.right).normalized * speed;
    }

    public void ResetBall(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

    public void BallColDirection(Collision2D col){
        if (col.gameObject.name == "Player1"){
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 direction = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed * 1.2f;
        }

        if (col.gameObject.name == "Player2"){
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 direction = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed * 1.2f;
        }
    }


}
