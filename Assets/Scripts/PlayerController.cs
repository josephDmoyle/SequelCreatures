using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Controllable player;
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();
    [SerializeField] private List<GameObject> characters = new List<GameObject>();

    int currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            player.Control();
        }

        if(Input.GetButtonDown("Camera"))
        {
            SelectCharacter(currentCharacter + 1);
        }
    }

    public void SelectCharacter(int newCharacter)
    {
        if(newCharacter > 3)
        {
            newCharacter = 0;
        }
        cameras[newCharacter].SetActive(true);

        cameras[currentCharacter].SetActive(false);
        player = characters[newCharacter].GetComponent<Controllable>();
        currentCharacter = newCharacter;
    }
}
