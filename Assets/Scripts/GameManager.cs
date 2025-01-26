using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject[] obstaticsArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake(){
        gameManager = this;
        ObstaticGenerator();
    }
    void Start()
    {
        Time.timeScale = 1.7f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void ObstaticGenerator(){
        int num;
        for(num = 0; num < 100; num++){
            var obstatic = obstaticsArray[Random.Range(0,obstaticsArray.Length)];
            Instantiate(obstatic, new Vector3(0, num * -4.5f,0), Quaternion.identity);
        }
    }
    public void OnRestart(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
