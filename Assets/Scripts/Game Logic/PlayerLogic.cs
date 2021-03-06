﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {
    /// <summary>
    /// Class for receiving information from the server/gamemanager and for the GUI to recieve
    /// </summary>
    public class PlayerLogic {
        private string name;
        private int id;

        private ROLES role;
        
        private PLAYERSTATES playerState;

        private List<bool> hand;
        private bool isDead;
        private bool hasVoted;
        private bool vote;

        public PlayerLogic(int id, string name) {
            this.name = name;
            this.id = id;
            this.hand = new List<bool>();
            this.role = ROLES.Liberal;
            this.playerState = PLAYERSTATES.Idle;
            this.isDead = false;
        }

        public int ID {
            get {
                return id;
            }
        }

        public string Name {
            get {
                return name;
            }
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

        public bool IsDead {
            get {
                return isDead;
            }
            set {
                isDead = value;
            }
        }

        public List<bool> Hand {
            get {
                return hand;
            }
            set {
                hand = value;
            }
        }

        public bool HasVoted {
            get {
                return hasVoted;
            }
            set {
                if(value == false)
                    hasVoted = value;
            }
        }

        public bool Vote {
            get {
                return vote;
            }
            set {
                hasVoted = true;
                vote = value;
            }
        }
    }
}
