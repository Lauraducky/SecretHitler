using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {
    /// <summary>
    /// Class for receiving information from the server/gamemanager and for the GUI to recieve
    /// </summary>
    public class PlayerLogic {
        public enum ROLES { Liberal, Fascist, Hitler };
        private ROLES role;
        
        public enum PLAYERSTATES { Idle, Voting, SelectingChance, PresPolicy, ChanPolicy, Investigate, SpecialElection, PolicyPeek, Assassinate };
        private PLAYERSTATES playerState;

        private bool isPres;
        private bool isChan;
        private List<bool> hand;

        public PlayerLogic() {
            hand = new List<bool>();
            role = ROLES.Liberal;
            playerState = PLAYERSTATES.Idle;
            isPres = false;
            isChan = false;
        }

        public ROLES Role {
            get {
                return role;
            }
            set {
                role = value;
            }
        }

        public PLAYERSTATES PlayerState {
            get {
                return playerState;
            }
            set {
                playerState = value;
            }
        }

        public bool IsPres {
            get {
                return isPres;
            }
            set {
                isPres = value;
            }
        }

        public bool IsChan {
            get {
                return isChan;
            }
            set {
                isChan = value;
            }
        }

        public void AddToHand (bool card) {
            hand.Add(card);
        }

        private void DiscardCard (bool b) {
            hand.Remove(b);
            GameManager.policies.discard(b);
        }
    }
}
