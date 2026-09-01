namespace CinemaTicketBooking.Dtos.ShowTimeDtos
{
    public class ShowTimeResponseDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public int AuditoriumId { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
    }
}
