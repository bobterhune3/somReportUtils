using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somReporter.team
{
    public class PlayerSortingUtil
    {
        private const int PLAYER_IS_BEFORE = -1;
        private const int EQUAL = 0;
        private const int PLAYER_IS_AFTER = 1;
        private const int MINIMUM_TO_BE_SP = 3;
        private const int MINIMUM_TO_BE_CLOSER = 5;

        public static int calculatePlayerComparedTo(Player player, Player other)
        {
            if (player.IsHitter) return PLAYER_IS_AFTER;
            if (other.IsHitter) return PLAYER_IS_BEFORE;

            if (player.IP < 26) return PLAYER_IS_AFTER;
            if (other.IP < 26) return PLAYER_IS_BEFORE;

            if (player.GS > MINIMUM_TO_BE_SP && other.GS > MINIMUM_TO_BE_SP)
            {
                return compareTwoStartingPitchers(player, other);
            }
            else
            {
                if (player.GS > MINIMUM_TO_BE_SP && other.GS <= MINIMUM_TO_BE_SP)
                    return PLAYER_IS_BEFORE;
                if (other.GS > MINIMUM_TO_BE_SP && player.GS <= MINIMUM_TO_BE_SP)
                    return PLAYER_IS_AFTER;
            }

            if (player.SAVE > MINIMUM_TO_BE_CLOSER && other.SAVE > MINIMUM_TO_BE_CLOSER)
            {
                return compareTwoClosers(player, other);
            }
            else
            {
                if (player.SAVE > MINIMUM_TO_BE_CLOSER && other.SAVE <= MINIMUM_TO_BE_CLOSER)
                {
                    player.primaryPos = "CL";
                    return PLAYER_IS_BEFORE;
                }
                if (other.SAVE > MINIMUM_TO_BE_CLOSER && player.SAVE <= MINIMUM_TO_BE_CLOSER)
                    return PLAYER_IS_AFTER;
            }

            return compareTwoReliefPitchers(player, other);
        }

        private static bool playersPlaytheSamePosition(Player player, Player other, String pos)
        {
            if (player.primaryPos.Length > 0 && !player.primaryPos.Equals(pos)) return false;
            if (other.primaryPos.Length > 0 && !other.primaryPos.Equals(pos)) return false;
            return true;
        }

        public static int compareTwoStartingPitchers(Player player, Player other)
        {
            // Factor in IP
            int pointsPlayer = player.IP * 2;
            int pointsOther = other.IP * 2;

            // Factor in WHIP
            int whip1 = (int)((150 - (150 * calculateWHIP(player))) * 3);
            int whip2  = (int)((150 - (150 * calculateWHIP(other))) * 3);

            pointsPlayer += whip1;
            pointsOther += whip2;

            // Factor in GS
            int gs1 = player.GS * 5;
            int gs2 = other.GS * 5;

            pointsPlayer += gs1;
            pointsOther += gs2;

            player.primaryPos = "SP";
            other.primaryPos = "SP";

            Console.WriteLine(player.Name + "=" + pointsPlayer + ", " + other.Name + "=" + pointsOther);
            return pointsOther - pointsPlayer;
        }

        public static int compareTwoClosers(Player player, Player other)
        {

            // Factor in IP
            int pointsPlayer = player.IP * 2;
            int pointsOther = other.IP * 2;

            // Factor in WHIP
            pointsPlayer += (int)(150 - (150 * calculateWHIP(player)));
            pointsOther += (int)(150 - (150 * calculateWHIP(other)));

            // Factor in GS
            pointsPlayer += player.SAVE * 5;
            pointsOther += other.SAVE * 5;

            if (pointsPlayer > pointsOther)
            {
                if (other.primaryPos == null || other.primaryPos.Equals("CL"))
                {
                    player.primaryPos = "CL";
                    other.primaryPos = "RP";
                }
                else
                    player.primaryPos = "CL";
            }

            Console.WriteLine(player.Name + "=" + pointsPlayer + ", " + other.Name + "=" + pointsOther);
            return pointsOther - pointsPlayer;
        }

        public static int compareTwoReliefPitchers(Player player, Player other)
        {
            // Factor in IP
            int pointsPlayer = player.IP;
            int pointsOther = other.IP;

            // Factor in WHIP
            pointsPlayer += (int)(90 - (75 * calculateWHIP(player)));
            pointsOther += (int)(90 - (75 * calculateWHIP(other)));

            player.primaryPos = "RP";
            other.primaryPos = "RP";

            return pointsOther - pointsPlayer;
        }

        public static double calculateWHIP(Player player)
        {
            double bb = player.BB;
            double hit = player.Hits;
            double ip = player.IP;
            return (bb + hit) / ip;
        }
    }
}
