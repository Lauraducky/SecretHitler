using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {
    public class GameModes {
        static List<GameMode> GAMEMODES;

        public GameModes () {
            GAMEMODES = new List<GameMode>();
            GAMEMODES.Add(new GameMode(false, false, false, true, true, 1));
            GAMEMODES.Add(new GameMode(false, true, true, false, false, 2));
            GAMEMODES.Add(new GameMode(true, true, true, false, false, 3));
        }
    }

    public class GameMode
    {
        private bool F1A; //Look at other player's party card when 1st fascist card is played
        private bool F2A; //Look at other player's party card when 2nd fascist card is played
        private bool F3A; //Hold a special election when 3rd fascist card is played
        private bool F3B; //Look at future policies when 3rd fascist card is played
        private bool HK; //Whether Hitler knows who other fascists are
        private int numF; //Num of Fascists

        public GameMode(bool F1A, bool F2A, bool F3A, bool F3B, bool HK, int numF) {
            this.F1A = F1A;
            this.F2A = F2A;
            this.F3A = F3A;
            this.F3B = F3B;
            this.HK = HK;
            this.numF = numF;
        }

        public bool PartyCheck1() {
            return F1A;
        }

        public bool PartyCheck2() {
            return F2A;
        }

        public bool SpecialElection() {
            return F3A;
        }

        public bool PolicyPeek() {
            return F3B;
        }

        public bool HitlerKnows() {
            return HK;
        }

        public int NumOfFascists() {
            return numF;
        }
    }
}
