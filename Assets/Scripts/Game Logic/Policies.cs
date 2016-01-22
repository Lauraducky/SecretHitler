using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {
    public class PoliciesDeck {
        const int libCards = 6;
        const int fasCards = 11;

        private List<bool> discardPile;
        private List<bool> drawPile;

        public PoliciesDeck () {
            drawPile = new List<bool>();
            discardPile = new List<bool>();

            for (int i = 0; i < libCards; i++) {
                drawPile.Add(false);
            }

            for (int i = 0; i < fasCards; i++) {
                drawPile.Add(true);
            }
            drawPile.Shuffle();
        }

        public List<bool> drawCards (int numCards) {
            if (drawPile.Count < numCards) {
                collectDiscard();
            }

            List<bool> result = new List<bool>();
            for (int i = 0; i < numCards; i++) {
                result.Add(drawPile[0]);
                drawPile.RemoveAt(0);
            }
            return result;
        }

        public List<bool> showTopThree () {
            if (drawPile.Count < 3) {
                collectDiscard();
            }

            List<bool> result = new List<bool>();
            for (int i = 0; i < 3; i++) {
                result.Add(drawPile[i]);
            }
            return result;
        }

        private void collectDiscard() {
            foreach (bool card in discardPile) {
                drawPile.Add(card);
            }
            discardPile = new List<bool>();
            drawPile.Shuffle();
        }

        public void discard (bool card) {
            discardPile.Add(card);
        }
    }

    public static class ThreadSafeRandom {
        [ThreadStatic]
        private static System.Random Local;

        public static System.Random ThisThreadsRandom {
            get { return Local ?? (Local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class MyExtensions {
        public static void Shuffle<T>(this IList<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
