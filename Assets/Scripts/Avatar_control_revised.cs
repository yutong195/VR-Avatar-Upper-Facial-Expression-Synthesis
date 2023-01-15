using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Avatar_control_revised : NetworkManager
    {
        public Transform position1;
        public Transform position2;
        
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            Transform start = numPlayers == 0 ? position1 : position2;
            if(numPlayers == 1){
                GameObject player1 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "WomenAvatar_3"));
                NetworkServer.AddPlayerForConnection(conn, player1);
            }else{
                GameObject player = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "ManAvatar_2"));
                NetworkServer.AddPlayerForConnection(conn, player);
            }
            // base.OnServerAddPlayer(conn);
            // // add player at correct spawn position
            // Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            // GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            // NetworkServer.AddPlayerForConnection(conn, player);

            // // spawn ball if two players
            // if (numPlayers == 2)
            // {
            //     ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            //     NetworkServer.Spawn(ball);
            // }
        }
        // public override void OnClientReady(NetworkConnectionToClient conn)
        // {
        //     Transform start = numPlayers == 0 ? position1 : position2;
        //     if(numPlayers == 1){
        //         GameObject player1 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Women1"));
        //         NetworkServer.AddPlayerForConnection(conn, player1);
        //     }else{
        //         GameObject player = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Man1"));
        //         NetworkServer.AddPlayerForConnection(conn, player);
        //     }
        //     // base.OnServerAddPlayer(conn);
        //     // // add player at correct spawn position
        //     // Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        //     // GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        //     // NetworkServer.AddPlayerForConnection(conn, player);

        //     // // spawn ball if two players
        //     // if (numPlayers == 2)
        //     // {
        //     //     ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
        //     //     NetworkServer.Spawn(ball);
        //     // }
        // }

        // public override void OnServerDisconnect(NetworkConnectionToClient conn)
        // {
        //     // // destroy ball
        //     // if (ball != null)
        //     // NetworkServer.Destroy(player);

        //     // // call base functionality (actually destroys the player)
        //     // base.OnServerDisconnect(conn);
        // }
    }