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
                FascistBoards[0].SetPower(3, Board.POWERS.PolicyCheck);
                FascistBoards[0].SetPower(4, Board.POWERS.Assassination);
                FascistBoards[0].SetPower(5, Board.POWERS.Assassination);
            FascistBoards[1] = new Board(6);
                FascistBoards[1].SetPower(2, Board.POWERS.LoyaltyCheck);
                FascistBoards[1].SetPower(3, Board.POWERS.SpecialElection);
                FascistBoards[1].SetPower(4, Board.POWERS.Assassination);
                FascistBoards[1].SetPower(5, Board.POWERS.Assassination);
            FascistBoards[2] = new Board(6);
                FascistBoards[2].SetPower(1, Board.POWERS.LoyaltyCheck);
                FascistBoards[2].SetPower(2, Board.POWERS.LoyaltyCheck);
                FascistBoards[2].SetPower(3, Board.POWERS.SpecialElection);
                FascistBoards[2].SetPower(4, Board.POWERS.Assassination);
                FascistBoards[2].SetPower(5, Board.POWERS.Assassination);
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
        public enum POWERS { None, PolicyCheck, SpecialElection, LoyaltyCheck, Assassination };
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
