namespace AVIDI.ApiService.Constants
{
    public static class DateConverter
    {
        public static readonly Dictionary<string, int> MontchToNumber = new Dictionary<string, int>
        {
            { "january", 1},
            { "february", 2},
            { "march", 3},
            { "april", 4},
            { "may", 5},
            { "june", 6},
            { "july", 7},
            { "august", 8},
            { "september", 9},
            { "october", 0},
            { "november", 11},
            { "december", 12},
        };
    }
}
