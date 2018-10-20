using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somReporter.team
{
    public class Player
    {
        private string name = "";
        private int actual = 0;
        private int replay = 0;
        private int targetUsage = 0;
        private Team team;
        private bool hitter = false;
        private int previousReplay = 0;
        private String throws = "R";
        private int games = 0;
        private String bal = "E";
        private int ip = 0;
        private int hits = 0;
        private int gs = 0;
        private String powerL = "";
        private String powerR = "";
        private Defense def = null;

        public Player( ) { }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Throws
        {
            get { return throws; }
            set { throws = value; }
        }

        public int Actual
        {
            get { return actual; }
            set { actual = value; }
        }

        public int PreviousReplay
        {
            get { return previousReplay; }
            set { previousReplay = value; }
        }

        public int Replay
        {
            get { return replay; }
            set { replay = value; }
        }

        public int TargetUsage
        {
            get { return targetUsage; }
            set { targetUsage = value; }
        }

        public int Games
        {
            get { return games; }
            set { games = value; }
        }

        public Team Team
        {
            get { return team; }
            set { team = value; }
        }

        public bool IsHitter
        {
            get { return hitter; }
            set { hitter = value; }
        }

        public double Usage
        {
            get
            {
                if (Actual == 0)
                    Actual = 1;
                return Report.RoundToSignificantDigits((double)Replay / (double)Actual, 3);
            }
        }

        public string buildStorageData()
        {

            String data = String.Format("PreviousReplay={0}",this.Replay);
            return data;
        }


        public String Bal
        {
            get { return bal; }
            set { bal = value; }
        }
        public int IP
        {
            get { return ip; }
            set { ip = value; }
        }
        public int Hits
        {
            get { return hits; }
            set { hits = value; }
        }
        public int GS
        {
            get { return gs; }
            set { gs = value; }
        }

        public String PowerL
        {
            get { return powerL; }
            set { powerL = value; }
        }
        public String PowerR
        {
            get { return powerR; }
            set { powerR = value; }
        }

        public Defense Def {
            get { return def; }
            set { def = value; }
        }

    }

    public class Defense
    {
        String c = "";
        String b1 = "";
        String b2 = "";
        String b3 = "";
        String ss = "";
        String lf = "";
        String rf = "";
        String cf = "";
        String ofarm = "";

        public Defense(String c, String b1, String b2, String b3, String ss, String lf, String cf, String rf, String ofarm)
        {
            this.c = c;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.ss = ss;
            this.lf = lf;
            this.rf = rf;
            this.cf = cf;
            this.ofarm = ofarm;
        }

        public String CatcherRating { get { return c; } }
        public String FirstBaseRating { get { return b1; } }
        public String SecondBaseRating { get { return b2; } }
        public String ThirdBaseRating { get { return b3; } }
        public String ShortstopRating { get { return ss; } }
        public String LeftFieldRating { get { return lf; } }
        public String CenterFieldRating { get { return cf; } }
        public String RightFieldRating { get { return rf; } }
        public String OutfieldArm { get { return ofarm; } }

    }
}
