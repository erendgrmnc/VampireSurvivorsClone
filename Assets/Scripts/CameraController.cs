using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap tilemap;

    float halfHeight;
    float halfWidth;

    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;


    // Start is called before the first frame update
    void Start()
    {
        //target = Player.instance.transform;

        target = FindObjectOfType<Player>().transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = tilemap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = tilemap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        Player.Instance.SetBounds(tilemap.localBounds.min, tilemap.localBounds.max);
    }

    // Late Update is called once per frame after Update 
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        KeepTheCameraInside();
    }

    void KeepTheCameraInside()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
