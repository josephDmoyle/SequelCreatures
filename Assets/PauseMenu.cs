using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    public SpriteRenderer Pause;
    public Sprite idle;
    public Sprite resumeHover;
    public Sprite resumeClicked;
    public Sprite quitHover;
    public Sprite quitClicked;

    private bool paused = false;

    // Start is called before the first frame update
    public void Awake()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        Pause.sprite = idle;
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
            Time.timeScale = 0f;
            Invoke("changeSprite", .1f);
        }

        if (!paused)
        {
            pauseCanvas.gameObject.SetActive(paused);
            Time.timeScale = 1f;
        }
    }

    void changeSprite()
    {
        Pause.sprite = resumeClicked;
        Invoke("returnSprite", .3f);
    }

    void returnSprite()
    {
        Pause.sprite = idle;

    }
}
