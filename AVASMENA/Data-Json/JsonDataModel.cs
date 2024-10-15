namespace AVASMENA.API.DataStore
{
    public static class DataStore
    {
        public static Dictionary<string, long> Users { get; private set; } = [];
        public static Dictionary<string, int> Names { get; private set; } = [];
        public static Dictionary<string, int> ZarpNames { get; private set; } = [];
        public static List<string> NameList { get; private set; } = [];
        public static string? TokenBot { get; set; }
        public static long ForwardChat { get; set; }
        public static long ChatId { get; set; }
        public static long PhotoChat { get; set; }
        public static int TraidSmena { get; set; }
        public static int TreidShtraph { get; set; }
        public static int TraidRashod { get; set; }
        public static int TraidPostavka { get; set; }
        public static int TraidPhoto { get; set; }
        public static string Password { get; set; }

        public static void Initialize()
        {
            JsonConfig.LoadData();
        }
    }
}