namespace CinemaTicketBooking.Models
{
    public class Auditorium :BaseEntity
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        //Navigation property
        public ICollection<ShowTime> Shows { get; set; }
    }
}
