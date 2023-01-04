using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    private EnemyScript enemy;
    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemy = enemy.GetComponent<EnemyScript>();
  
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

    }

    public void addPoints()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
