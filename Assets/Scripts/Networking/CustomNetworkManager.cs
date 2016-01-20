using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

namespace SecretHitler {
    public class CustomNetworkManager : NetworkManager {

        //Use this for initialization
        void Start() {

        }

        //Update is called once per frame
        void Update() {

        }
        
        /*******************
        ** SERVER METHODS **
        *******************/

        // called when a client connects 
        public override void OnServerConnect(NetworkConnection conn) {

        }

        // called when a client disconnects
        public override void OnServerDisconnect(NetworkConnection conn) {
            NetworkServer.DestroyPlayersForConnection(conn);
        }

        // called when a client is ready
        public override void OnServerReady(NetworkConnection conn) {
            NetworkServer.SetClientReady(conn);
        }

        // called when a new player is added for a client
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
            var player = (GameObject)GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }

        // called when a player is removed for a client
        public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player) {
            if (player.unetView != null && player.gameObject != null)
                    NetworkServer.Destroy(player.gameObject);
        }

        // called when a network error occurs
        public override void OnServerError(NetworkConnection conn, int errorCode) {

        }

        /*******************
        ** CLIENT METHODS **
        *******************/
        // called when connected to a server
        public override void OnClientConnect(NetworkConnection conn) {
            ClientScene.Ready(conn);
            ClientScene.AddPlayer(0);
        }

        // called when disconnected from a server
        public override void OnClientDisconnect(NetworkConnection conn) {
            StopClient();
        }

        // called when a network error occurs
        public override void OnClientError(NetworkConnection conn, int errorCode) {

        }

        // called when told to be not-ready by a server
        public override void OnClientNotReady(NetworkConnection conn) {

        }

        /***********************
        ** MATCHMAKER METHODS **
        ***********************/

        // called when a match is created
        public override void OnMatchCreate(CreateMatchResponse matchInfo) {

        }

        // called when a list of matches is received
        public override void OnMatchList(ListMatchResponse matchList) {

        }

        // called when a match is joined
        public new void OnMatchJoined(JoinMatchResponse matchInfo) {

        }
    }
}