using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace SecretHitler {
    public class NetworkPlayer : NetworkBehaviour {

        public enum ROLE { Liberal, Fascist, Hitler }


        [SyncVar]
        bool alive = true;

        ROLE myRole;

        //Use this for initialization
        void Start() {

        }

        //Update is called once per frame
        void Update() {

        }
    }
}