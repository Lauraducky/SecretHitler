using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SecretHitler {

    public enum ROLES { Liberal, Fascist, Hitler };
    public enum PLAYERSTATES { Idle, Voting, SelectingChance, PresPolicy, ChanPolicy, Investigate, SpecialElection, PolicyPeek, Assassinate };
    public enum GAMESTATES { NOT_STARTED, SELECTING_CHAN, VOTING, PRES_POLICY, CHAN_POLICY, VETOING, LOYALTY_CHECK, SPECIAL_ELECTION, POLICY_PEEK, ASSASSINATE, ENDED };
    public enum SIZE { SML, MED, LGE };
    public enum POWERS { None, PolicyCheck, SpecialElection, LoyaltyCheck, Assassination };

    public static class Utility {
        public const bool FASCIST = true;
        public const bool LIBERAL = false;
        public const bool JA = true;
        public const bool NEIN = false;
    }
}
