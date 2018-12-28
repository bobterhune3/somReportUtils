using System;


namespace somReporter
{
    public class RecordIndex
    {
        public enum INDEX { TeamId, PlayerId, LineupItemId, LineupDataId, DefenseId, TestTeamId, TestDefenseId, TestLineupDataId };

        public static long getNextId(INDEX index) {

            long nextId = getValue(index);
            storeValue(index, nextId+1);
            return nextId;
        }

        public static void resetIndex(INDEX index)
        {
            storeValue(index, 1);
        }

        public static void resetAllIndexs()
        {
            foreach(INDEX index in INDEX.GetValues(typeof(INDEX)))
            {
                storeValue(index, 1);
            }
        }

        private static long getValue(INDEX index)
        {
            long nextId = 1;
            switch (index)
            {
                case INDEX.TeamId:
                    nextId = somReportUtils.Properties.Settings.Default.TeamId;
                    break;
                case INDEX.PlayerId:
                    nextId = somReportUtils.Properties.Settings.Default.PlayerId;
                    break;
                case INDEX.LineupItemId:
                    nextId = somReportUtils.Properties.Settings.Default.LineupItemId;
                    break;
                case INDEX.LineupDataId:
                    nextId = somReportUtils.Properties.Settings.Default.LineupDataId;
                    break;
                case INDEX.TestTeamId:
                    nextId = somReportUtils.Properties.Settings.Default.TestTeamId;
                    break;
                case INDEX.DefenseId:
                    nextId = somReportUtils.Properties.Settings.Default.DefenseId;
                    break;
            }
            return nextId;
        }

        private static void storeValue(INDEX index, long storeId)
        {
            switch (index)
            {
                case INDEX.TeamId:
                    somReportUtils.Properties.Settings.Default.TeamId = storeId;
                    break;
                case INDEX.PlayerId:
                    somReportUtils.Properties.Settings.Default.PlayerId = storeId;
                    break;
                case INDEX.LineupItemId:
                    somReportUtils.Properties.Settings.Default.LineupItemId = storeId;
                    break;
                case INDEX.LineupDataId:
                    somReportUtils.Properties.Settings.Default.LineupDataId = storeId;
                    break;
                case INDEX.TestTeamId:
                    somReportUtils.Properties.Settings.Default.TestTeamId = storeId;
                    break;
                case INDEX.DefenseId:
                    somReportUtils.Properties.Settings.Default.DefenseId = storeId;
                    break;
            }
            somReportUtils.Properties.Settings.Default.Save();
        }
    }
}
