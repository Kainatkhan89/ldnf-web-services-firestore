namespace learndotnetfast_web_services.DTOs
{
    public class ProgressDTO
    {

        public string? Id { get; set; }
        public string UserId { get; set; }
        public List<int> CompletedTutorialIds { get; set; }
    }

}
