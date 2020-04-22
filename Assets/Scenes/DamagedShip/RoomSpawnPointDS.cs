using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawnPointDS : MonoBehaviour
{
   public int door;
   private RoomsDS rooms;
   private bool spawned = false;
   private string[] savedRooms;
   private void Start()
   {
      rooms = GameObject.FindWithTag("DamagedShipRoom").GetComponent<RoomsDS>();
      Invoke("Spawn", 0.1f);
   }

   private void Spawn()
   {
      if (!spawned)
      {
         GameObject[] type = null;
         if (door == 3)
         {
            type = rooms.topDoor;
         }
         else if (door == 4)
         {
            type = rooms.rightDoor;
         }
         else if (door == 1)
         {
            type = rooms.botDoor;
         }
         else if (door == 2)
         {
            type = rooms.leftDoor;
         }
         if (type != null)
         {
            //Random.seed = 5;
            int index = Random.Range(0, type.Length);
            Instantiate(type[index], transform.position, type[index].transform.rotation);
            spawned = true;
            Debug.Log("Spawned Room: " + type[index].name + "[" + index + "]");
            //Random.seed = (int) Time.time;
         }
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("DamagedShipRoomSpawnPoint"))
      {
         if (other.GetComponent<RoomSpawnPointDS>().spawned == false && spawned == false)
         {
           //Instantiate(rooms.closedRoom, transform.position, Quaternion.identity);
         }
         Destroy(gameObject);
         spawned = true;
         Debug.Log("Destroyed Room");
      }
   }
}
