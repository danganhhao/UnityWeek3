using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenuCameraController : MonoBehaviour
{
    private float x = 0, y = 0, temp = 0.01f, temp2 = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (x > -2.58f && x < 2.58f)
        {
            x += temp;
        }
        
        if (x > 2.58f || x < -2.58f)
        {
            temp = -temp;
            x += temp;
        }
        if (y > -2.42f && y < -1.75f)
        {
            y += temp2;
        }

        if (y > -1.75f || y < -2.42f)
        {
            temp2 = -temp2;
            y += temp2;
        }

        transform.position = new Vector3(x, y, transform.position.z);

    }
}
