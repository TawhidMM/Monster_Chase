using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    private Vector3 tempPos;
    [SerializeField] private float maxX = 60;
    [SerializeField] private float minX = -60;
   
   
    void Start()
    {
        playerTransform = GameObject.
            FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!playerTransform)
            return;        
        
        tempPos = transform.position;

        if (playerTransform.position.x > maxX) {
            tempPos.x = maxX;
        }
        else if (playerTransform.position.x < minX) {
            tempPos.x = minX;
        }
        else {
            tempPos.x = playerTransform.position.x;
        }

        transform.position = tempPos;
    }
}
