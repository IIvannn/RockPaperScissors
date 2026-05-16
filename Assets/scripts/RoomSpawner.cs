using Unity.AI.Navigation;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject endRoom;
    public static int numberOfRooms;
    public int totalRooms = 4;
    int randomRoom;
    public static Transform nextRoomTransform;
    public NavMeshSurface navSurface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextRoomTransform = transform;
        for (int i = 0; i < totalRooms; i++)
        {
            Debug.Log("room: " + i);
            randomRoom = Random.Range(0, rooms.Length);
            GameObject nextRoom = Instantiate(rooms[randomRoom], nextRoomTransform.position, nextRoomTransform.rotation);

            nextRoomTransform = nextRoom.GetComponent<RoomScript>().nextroompoint;

            if (i == totalRooms-1)
            {
                navSurface.BuildNavMesh();
                GameObject finalRoom = Instantiate(endRoom, nextRoomTransform.position, nextRoomTransform.rotation);
                
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
