namespace lotr_sdk.Models;


public class Movie: BaseResponse
{
        public string name { get; set; }
        public int runtimeInMinutes { get; set; }
        public double budgetInMillions { get; set; }
        public double boxOfficeRevenueInMillions { get; set; }
        public int academyAwardNominations { get; set; }
        public int academyAwardWins { get; set; }
        public double rottenTomatoesScore { get; set; }
}
