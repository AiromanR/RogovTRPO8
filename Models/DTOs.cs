namespace RogovTRPO8.Models
{
    public partial class DTOs
    {
        public record TaskDTO(string title, string description);
        public record TaskDTOIsCompleted(string title, string description, bool isCompleted);
    }
}
