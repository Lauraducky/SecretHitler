using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {
    public static class Boards {
        public static Board[] FascistBoards;
        public static Board LiberalBoard;

        public static void SetUp () {
            FascistBoards = new Board[3];
            FascistBoards[0] = new Board(6);
                FascistBoards[0].SetPower(3, POWERS.PolicyCheck);
                FascistBoards[0].SetPower(4, POWERS.Assassination);
                FascistBoards[0].SetPower(5, POWERS.Assassination);
            FascistBoards[1] = new Board(6);
                FascistBoards[1].SetPower(2, POWERS.LoyaltyCheck);
                FascistBoards[1].SetPower(3, POWERS.SpecialElection);
                FascistBoards[1].SetPower(4, POWERS.Assassination);
                FascistBoards[1].SetPower(5, POWERS.Assassination);
            FascistBoards[2] = new Board(6);
                FascistBoards[2].SetPower(1, POWERS.LoyaltyCheck);
                FascistBoards[2].SetPower(2, POWERS.LoyaltyCheck);
                FascistBoards[2].SetPower(3, POWERS.SpecialElection);
                FascistBoards[2].SetPower(4, POWERS.Assassination);
                FascistBoards[2].SetPower(5, POWERS.Assassination);
            LiberalBoard = new Board(5);
        }

        public static void ClearAll() {
            foreach (Board b in FascistBoards)
                b.CardsPlayed = 0;
            LiberalBoard.CardsPlayed = 0;
        }
    }

    public class Board
    {
        private POWERS[] spaces;
        private int cardsPlayed;

        public Board(int boardLength) {
            spaces = new POWERS[boardLength];
            for (int i = 0; i < boardLength; i++)
                spaces[i] = POWERS.None;
            cardsPlayed = 0;
        }
        
        public void SetPower (int position, POWERS power) {
            spaces[position-1] = power;
        }

        public int BoardLength() {
            return spaces.Length;
        }

        public POWERS GetPower() {
            return spaces[cardsPlayed - 1];
        }

        public POWERS GetPower (int spaceNum) {
            return spaces[spaceNum - 1];
        }

        public int CardsPlayed {
            get {
                return cardsPlayed;
            }
            set {
                cardsPlayed = value;
            }
        }
    }
}
