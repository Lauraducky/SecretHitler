using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;

namespace SecretHitler {
    public class NetworkPlayer : NetworkBehaviour {

        void Start() {

        }

        void Update() {

        }

        static void sendMessages() {
            Queue<string> outbox = new Queue<string>();
            outbox.Enqueue("ROLE Fascist lauraducky taso cal-el");
            outbox.Enqueue("START evangelinexx");
            outbox.Enqueue("VOTE lauraducky");
            outbox.Enqueue("PASSED");
            outbox.Enqueue("POLICY true false");
            outbox.Enqueue("END");
            outbox.Enqueue("START lauraducky");
            outbox.Enqueue("VOTE taso");
            outbox.Enqueue("PASSED");
            outbox.Enqueue("POLICY true true false");
            outbox.Enqueue("POWER ExecutiveAction");
            outbox.Enqueue("END");

            Player player = new Player("lauraducky");
            while (outbox.Count > 0) {
                player.receiveMessage(outbox.Dequeue());
            }
            Console.Read();
        }
    }

    public class Player {

        public enum ROLE { Liberal, Fascist, Hitler }
        public enum GOVT { Spectator, President, Chancellor, PrevPresident, PrevChancellor }
        public enum POWERS { LookAtDeck, LookAtPlayer, ExecutiveAction, Kill }

        bool alive = true;

        List<string> playerNames;

        //Messages sent between the client and server, in the following format:
        //SERVER -> CLIENT
        //ROLE <rolename> [hitler [fascist1, fascist2...]]
        //START <president>
        //VOTE <chancellor>
        //FAILED
        //PASSED
        //POLICY <card1> <card2> [card3]
        //POWER <powername>
        //END
        //
        //CLIENT -> SERVER
        //DISCARD <card>
        //PLAY <card>
        //VOTE <ya/nein>
        //POWER <player>


        ROLE myRole;
        GOVT currGovt;
        string myName;
        string currPresident;
        string candidate;

        List<string> fascists = null;
        string hitler = null;

        //Use this for initialization
        public Player(string myName) {
            this.myName = myName;
        }

        public void receiveMessage(string message) {
            if (message == "PASSED") {
                if (myName == candidate) {
                    currGovt = GOVT.Chancellor;
                    Console.WriteLine("You are now the Chancellor!");
                } else {
                    Console.WriteLine("Vote for " + candidate + " passed");
                }
            } else if (message == "FAILED") {
                Console.WriteLine("Vote for " + candidate + " failed");
                candidate = null;
            } else if (message == "END") {
                resolveRound();
            } else {
                int index = message.IndexOf(' ');
                string command = message.Substring(0, index);
                string args = message.Substring(index + 1);
                handleCommand(command, args);
            }
        }

        private void handleCommand(string command, string args) {
            switch (command) {
                case "ROLE":
                    updateRole(args);
                    break;
                case "START":
                    Console.WriteLine("Start Round");
                    if (myName == args) {
                        Console.WriteLine("I am the President!");
                        currGovt = GOVT.President;
                    }
                    currPresident = args;
                    startRound();
                    break;
                case "VOTE":
                    promptVote(args);
                    break;
                case "POLICY":
                    promptPolicy(args);
                    break;
                case "POWER":
                    promptPower(args);
                    break;
            }
        }

        private void resolveRound() {
            switch (currGovt) {
                case GOVT.Chancellor:
                    currGovt = GOVT.PrevChancellor;
                    break;
                case GOVT.President:
                    currGovt = GOVT.PrevPresident;
                    break;
                default:
                    currGovt = GOVT.Spectator;
                    break;
            }
            Console.WriteLine("Round end. My role: " + currGovt.ToString());
        }

        private void startRound() {
            //TODO: Start Round
        }

        private void promptVote(string chancellor) {
            Console.WriteLine(currPresident + " nominates " + chancellor + " for Chancellor. Please Vote.");
            candidate = chancellor;
        }

        private void promptPolicy(string message) {
            if (currGovt == GOVT.President) {
                Console.WriteLine("Discard one of these to give to " + candidate + ": " + message);
            } else if (currGovt == GOVT.Chancellor) {
                Console.WriteLine("Enact one of these: " + message);
            }
        }

        private void promptPower(string message) {
            Console.WriteLine("Power: " + message);
        }

        private void updateRole(string args) {
            char[] delim = { ' ' };
            string[] argsSplit = args.Split(delim);

            switch (argsSplit[0]) {
                case "Hitler":
                    myRole = ROLE.Hitler;
                    break;
                case "Fascist":
                    myRole = ROLE.Fascist;
                    break;
                default:
                    myRole = ROLE.Liberal;
                    break;
            }
            Console.WriteLine(myRole.ToString());

            if (myRole == ROLE.Fascist || myRole == ROLE.Hitler) {
                fascists = new List<string>();
                hitler = argsSplit[1];
                for (int i = 2; i < argsSplit.Length; i++) {
                    fascists.Add(argsSplit[i]);
                }

                Console.WriteLine("Hitler: " + hitler);
                Console.Write("Fascists: ");
                foreach (string fascist in fascists) Console.Write(fascist + ", ");
                Console.WriteLine(" ");
            }
        }
    }
}