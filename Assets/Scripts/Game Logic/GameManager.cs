using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {
    public static class GameManager {
        public static PoliciesDeck policies = new PoliciesDeck();
        public static int gameMode = 0;
        private static List<PlayerLogic> players;

        private static PlayerLogic PrevPrez; //For selecting special elections and chancellor selection
        private static PlayerLogic CurrentPrez; // For Drawing cards
        private static PlayerLogic NextPrez; // For president cycle
        private static PlayerLogic PrevChan; // For selecting chancellor
        private static PlayerLogic CurrentChan; // For Passing cards

        private static int fascistCards = 0; //On board
        private static int liberalCards = 0; //On board

        public static int NumOfPlayers() {
            return players.Count;
        }

        /// <summary>
        /// Used once all players have joined lobby
        /// </summary>
        public static void GameStart() {
            int playercount = NumOfPlayers();
            if (playercount < 5)
                return; // Too few players
            else if (playercount < 7)
                gameMode = 0;
            else if (playercount < 9)
                gameMode = 1;
            else if (playercount < 11)
                gameMode = 2;
            else
                return; // Too many players

            //Set Hitler
            //Use GameModes.RULES[gameMode].NumOfFascists() to set fascists
            //Set remaining as Liberal
            //Reset deck of cards
            //Clear boards
            //Randomly select president

            //No need to make users communicate roles, as info will be available on devices
        }
    }
}