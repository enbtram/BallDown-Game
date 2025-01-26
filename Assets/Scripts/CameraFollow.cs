using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    private Camera mainCamera;
    private float deltaPosition_down;
    private float deltaPosition_up;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballWorldPosition = ball.transform.position;
        Vector3 ballScreenPosition = mainCamera.WorldToScreenPoint(ballWorldPosition);
        if(ballScreenPosition.y < Screen.height * 3 / 7){
            deltaPosition_down = deltaPosition_down == 0 ? mainCamera.transform.position.y - ball.transform.position.y : deltaPosition_down;
            float y = ball.transform.position.y + deltaPosition_down;
            if (y < mainCamera.transform.position.y)
                mainCamera.transform.position = new Vector3(0, ball.transform.position.y + deltaPosition_down, -10);
        }
        if(ballScreenPosition.y > Screen.height * 5 / 6){
            deltaPosition_up = deltaPosition_up == 0 ? mainCamera.transform.position.y - ball.transform.position.y : deltaPosition_up;
            float y = ball.transform.position.y + deltaPosition_up;
            if (y > mainCamera.transform.position.y)
                mainCamera.transform.position = new Vector3(0, ball.transform.position.y + deltaPosition_up, -10);
        }
    }
}
