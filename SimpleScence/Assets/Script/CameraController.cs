using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 velocity;
    public float timeX, timeY;
    public GameObject player;
    public Vector2 minPosition, maxPosition;
    public bool bound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, timeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, timeY);
        this.transform.position = new Vector3(posX, posY, transform.position.z);
       
        if (bound)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y),
                transform.position.z
                );
        }
    }
}
