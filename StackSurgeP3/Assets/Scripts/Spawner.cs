using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject tile, bottomTile, startButton;

    TMP_Text scoreText;
    List<GameObject> stack;

    bool hasGameStarted, hasGameFinished;
    
    List<Color32> spectrum = new List<Color32>()
    {
        new Color32(0, 255, 33, 255), new Color32(167, 255, 0, 255), new Color32(230, 255, 0, 255), new Color32(255, 237, 0, 255), new Color32(255, 206, 0, 255), new Color32(255, 185, 0, 255), new Color32(255, 142, 0, 255), new Color32(255, 111, 0, 255), new Color32(255, 58, 0, 255), new Color32(255, 0, 0, 255), new Color32(255, 0, 121, 255), new Color32(255, 0, 164, 255), new Color32(241, 0, 255, 255), new Color32(209, 0, 255, 255), new Color32(178, 0, 255, 255)
    };
    int modifier;
    int colorIndex;
    
    public static Spawner instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        stack = new List<GameObject>();
        hasGameFinished = false;
        hasGameStarted = true;
       
        modifier = 1;
        colorIndex = 0;
        stack.Add(bottomTile);
        stack[0].GetComponent<Renderer>().material.color = spectrum[0];
        
        CreateTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGameFinished || !hasGameStarted) return;
        if (Input.GetMouseButtonDown(0))
        {
            if(stack.Count > 1)
            {
                stack[stack.Count - 1].GetComponent<Tile>().ScaleTile();
            }
            if (hasGameFinished) return;
            scoreText.text = (stack.Count - 1).ToString();
            CreateTile();
        }
    }

    void CreateTile()
    {
        GameObject previousTile = stack[stack.Count - 1];
        GameObject activeTile;
        Tile tileScript;

        activeTile = Instantiate(tile);
        tileScript = activeTile.GetComponent<Tile>();
        stack.Add(activeTile);

        if(stack.Count > 2)
        {
            activeTile.transform.localScale = previousTile.transform.localScale;

        }

        activeTile.transform.position = new Vector3(previousTile.transform.position.x + previousTile.transform.localScale.y, previousTile.transform.position.y + previousTile.transform.localScale.y, previousTile.transform.position.z);
        
        colorIndex += modifier;
        if(colorIndex == spectrum.Count || colorIndex == -1)
        {
            modifier *= -1;
            colorIndex += 2 * modifier;
        }

        activeTile.GetComponent<Renderer>().material.color = spectrum[colorIndex];
        
    }

    public void GameOver()
    {

    }
}
