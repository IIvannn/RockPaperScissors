using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public Transform nextroompoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        RoomSpawner.nextRoomTransform = nextroompoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
