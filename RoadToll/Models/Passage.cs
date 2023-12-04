using RoadToll.Models;

namespace RoadToll.Models
{
    public class Passage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
