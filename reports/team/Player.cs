using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somReporter.team
{
    [Serializable()]
    public class Player : IComparable<Player>
    {
        public long Id { get; set; }

        public Player(Boolean empty) { Empty = empty;  }

        public Player( ) {
            Empty = false;
        }

        public string Name { get; set; }

        public string Throws { get; set; }

        public int Actual { get; set; }

        public int PreviousReplay { get; set; }

        public int Replay { get; set; }

        public int TargetUsage { get; set; }
        public int Games { get; set; }

        public Team Team { get; set; }

        public bool IsHitter { get; set; }

        public int TeamRank { get; set; }
        public String primaryPos { get; set; }

        public bool Empty { get;  }

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

        public String Bal { get; set; }
        public int IP { get; set; }
        public int Hits { get; set; }
        public int BB { get; set; }
        public int GS { get; set; }

        public int SAVE { get; set; }

        public String PowerL { get; set; }
        public String PowerR { get; set; }

        public Defense Def { get; set; }


        // Initial Version:  Only Sorting by Pitcher, then Hitter. 
        //                   Pitchers are sorted by SP Rank, Closer Rank (Only One), Relief Rank
        //
        // Less than zero	 This instance IS BEFORE other.
        // Zero              This instance has the same position in the sort as in other.
        // Greater than zero This instance follows other
        //
        // Pitchers First, Hitters Last
        public int CompareTo(Player other)
        {
            if (this.primaryPos == null) this.primaryPos = "";
            if (other.primaryPos == null) other.primaryPos = "";

            return PlayerSortingUtil.calculatePlayerComparedTo(this, other);
        }
    }

    [Serializable()]
    public class Defense
    {
        public long Id { get; set; }

        String c = "";
        String b1 = "";
        String b2 = "";
        String b3 = "";
        String ss = "";
        String lf = "";
        String rf = "";
        String cf = "";
        String ofarm = "";

        /**
         *      CF  RF  LF
         *  CF  --   0   0
         *  RF  +1  --   0
         *  LF  +2  +1  --
         *  
         *  From this page: http://www.baseballthinkfactory.org/btf/pages/basesim/somrules.htm
         */
        public Defense(long Id, String c, String b1, String b2, String b3, String ss, String lf, String cf, String rf, String ofarm)
        {
            this.Id = Id;
            this.c = c;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.ss = ss;
            this.lf = lf;
            this.rf = rf;
            this.cf = cf;

            if( this.cf.Length > 0 )
            {
                if (this.lf.Length == 0)
                    this.lf = this.cf + "#";
                if (this.rf.Length == 0)
                    this.rf = this.cf + "#";
            } 
            else if ( this.rf.Length > 0)
            {
                if (this.lf.Length == 0)
                    this.lf = this.rf+ "#";
                if (this.cf.Length == 0)
                {
                    int def = getDefRating(this.rf);
                    if (def < 4)
                    {
                        this.cf = String.Format("{0}e{1}#", def + 1, getERating(this.rf));
                    }
                }
            }
            else if (this.lf.Length > 0)
            {
                int def = getDefRating(this.lf);
                if (this.cf.Length == 0 && def < 3)
                {
                    this.cf = String.Format("{0}e{1}#", def + 2, getERating(this.lf));
                }
                if (this.rf.Length == 0 && def < 4)
                {
                    this.rf = String.Format("{0}e{1}#", def + 1, getERating(this.lf));
                }
            }


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

        public int getDefRating( String def )
        {
            return int.Parse(def.Substring(0, 1));
        }
        public int getERating(String def)
        {
            def = def.Replace("#", "");
            return int.Parse(def.Substring(2, def.Length-2));
        }

    }
}
