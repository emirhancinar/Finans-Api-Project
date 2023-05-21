namespace Finance_Api_Project.Models
{
    
        public class ExchangeRate
        {
            public bool success { get; set; }
            public QueryData query { get; set; }
            public InfoData info { get; set; }
            public DateTime date { get; set; }
            public decimal result { get; set; }
        }

        public class QueryData
        {
            public string from { get; set; }
            public string to { get; set; }
            public int amount { get; set; }
        }
        public class InfoData
        {
            public long timestamp { get; set; }
            public decimal rate { get; set; }
        }
}

