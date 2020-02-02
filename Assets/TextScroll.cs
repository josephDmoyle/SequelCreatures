using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroll : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        transform.Translate(0, .5f, 0);
    }
}
