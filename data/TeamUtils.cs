using System;
using System.Collections.Generic;

namespace somReportUtils
{
    public class TeamUtils
    {
        public static Dictionary<String, String> teamAbrvMap = null;

        public static void registerTeamAbvMapping(Dictionary<String, String> teamAbrvMap)
        {
            TeamUtils.teamAbrvMap = teamAbrvMap;
        }

        public static string prettyTeamName(string teamName)
        {
            if (TeamUtils.teamAbrvMap == null)
            {
                     if (teamName.StartsWith("Los Angeles(A")) return "LAA";
                else if (teamName.StartsWith("Atlanta Brave")) return "ATN";
                else if (teamName.StartsWith("Arizona Diamo")) return "ARN";
                else if (teamName.StartsWith("Baltimore Ori")) return "BAA";
                else if (teamName.StartsWith("Boston Red Sp")) return "BOS";
                else if (teamName.StartsWith("Chicago (AL)")) return "CHA";
                else if (teamName.StartsWith("Chicago (NL)")) return "CHN";
                else if (teamName.StartsWith("Cincinnati Re")) return "CNN";
                else if (teamName.StartsWith("Cleveland Inf")) return "CLA";
                else if (teamName.StartsWith("Detroit Tiger")) return "DTA";
                else if (teamName.StartsWith("Houston Astrp")) return "HSA";
                else if (teamName.StartsWith("Kansas City R")) return "KCA";
                else if (teamName.StartsWith("Los Angeles(N")) return "LAN";
                else if (teamName.StartsWith("Miami Marlin")) return "MMN";
                else if (teamName.StartsWith("Milwaukee Bre")) return "MLN";
                else if (teamName.StartsWith("Minnesota Twi")) return "MNA";
                else if (teamName.StartsWith("New York (AL)")) return "NYA";
                else if (teamName.StartsWith("New York (NL)")) return "NYN";
                else if (teamName.StartsWith("Oakland Athle")) return "OAA";
                else if (teamName.StartsWith("Philadelphia")) return "PHN";
                else if (teamName.StartsWith("Pittsburgh Pi")) return "PIN";
                else if (teamName.StartsWith("San Diego Pad")) return "SDN";
                else if (teamName.StartsWith("San Francisco")) return "SFN";
                else if (teamName.StartsWith("Seattle Marin")) return "SEA";
                else if (teamName.StartsWith("St. Louis Car")) return "SLN";
                else if (teamName.StartsWith("Tampa Bay Ray")) return "TBA";
                else if (teamName.StartsWith("Texas Rangers")) return "TXA";
                else if (teamName.StartsWith("Toronto Blue")) return "TOA";
                else if (teamName.StartsWith("Washington Na")) return "WSN";
                return "UNK";
            }
            else
            {
                String key = teamName.Substring(0, 12).Trim();
                if (TeamUtils.teamAbrvMap.ContainsKey(key))
                { 
                    return TeamUtils.teamAbrvMap[key];
                }
                else
                    return "UNK";
            }
        }
    }
}
