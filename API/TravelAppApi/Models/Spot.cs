namespace TravelAppApi.Models
{
    public class Spot
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public string? ImagePath { get; set; }
        public string Category{ get; set; }
        public string District { get; set; }

        public Spot(string name, string category, string district)
        {
            Name = name;
            Rating = 0.0;
            Category = category;
            District = district;
        }
    }
}
