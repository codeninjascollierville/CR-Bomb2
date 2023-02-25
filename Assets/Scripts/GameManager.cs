using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    public float score = 0;
    private Vector2 screenBounds;
    private GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;

    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        player = playerPrefab;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                resetGame();
            }
        }
        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y)-12)
            {
                Destroy(bombObject);
            }
        }
    }
    void scoreUp()
    {
        score++;
    }
    void resetGame()
    {
        spawner.active = true;
        title.SetActive(false);
    }
    
}
