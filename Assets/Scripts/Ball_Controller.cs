using System.Runtime.CompilerServices;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField] private enum BallState {left, right, vertical}
    private BallState currentBall;
    [SerializeField] private GameObject ball_particle;
    // private BallState previousBall;
    [SerializeField] private float force;
    // private Vector3 previousPosition;
    private Rigidbody2D ballRB2;
    private  Vector2 direction;
    // public GameManager gameManager;
    void Start()
    {
        // previousPosition = transform.position;
        currentBall = BallState.vertical;
        // previousBall = BallState.vertical;
        ballRB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 movementDirection = transform.position - previousPosition;
        // if(movementDirection.x > 0){
        //     // Debug.Log("Ball is moving right");
        //     currentBall = BallState.right;
        // }
        // else if(movementDirection.x < 0){
        //     // Debug.Log("Ball is moving left");
        //     currentBall = BallState.left;
        // }else{
        //     // Debug.Log("Ball is moving vertical");
        //     currentBall = BallState.vertical;
        // }
        ball_particle.transform.position = transform.position;
        if (Input.GetMouseButtonDown(0)){
            AddBallForce();
        }
    }
    void AddBallForce(){
        switch (currentBall){
        case BallState.right:
            direction = new Vector2(-2,6).normalized;
            currentBall = BallState.left;
            break;
        case BallState.left:
            direction = new Vector2(2,6).normalized;
            currentBall = BallState.right;
            break;
        case BallState.vertical:
            // if(previousBall == BallState.left){
            //     direction = new Vector2(1,3).normalized;
            // }else if(previousBall == BallState.right){
            //     direction = new Vector2(-1,3).normalized;
            // }else if(previousBall == BallState.vertical){
            //     direction = new Vector2(1,3).normalized;
            // }
            direction = new Vector2(2,6).normalized;
            currentBall = BallState.right;
            break;
        }
        ballRB2.velocity = new Vector2(0,0);
        ballRB2.AddForce(direction * force*ballRB2.mass, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D obs){
        
        if(obs.transform.tag == "DEATH"){
            Debug.Log("death");
            GameManager.gameManager.OnRestart();
        }
    }
}
