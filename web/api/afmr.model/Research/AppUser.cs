namespace afmr.model.Research
{
    public class AppUser
    {
        public int Id { get; set; }

        public int? TemplateInstanceUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}