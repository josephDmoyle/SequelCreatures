using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;


    private bool paused;

    // Start is called before the first frame update
    public void Awake()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            swapPause();
        }
        
    }
    public void swapPause()
    {
        paused = !paused;

        if (paused)
        {
            pauseCanvas.gameObject.SetActive(paused);
            Time.timeScale = 0f;        }

        if (!paused)
        {
            pauseCanvas.gameObject.SetActive(paused);
            Time.timeScale = 1f;
        }
    }
}
