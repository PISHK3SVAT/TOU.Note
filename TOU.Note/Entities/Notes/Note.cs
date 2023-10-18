namespace TOU.Note.Entities.Notes
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        //label list
        //insert time
        //insert date
        //owner user
    }
}
