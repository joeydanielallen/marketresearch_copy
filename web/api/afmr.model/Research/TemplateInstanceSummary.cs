using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class TemplateInstanceSummary : ModelBase
    {
        public string Title { get; set; }

        public string OriginalName { get; set; }

        public int Id { get; set; }

        private DateTime _createdOn;
        public DateTime CreatedOnUtc
        {

            get { return _createdOn; }
            set
            {
                _createdOn = ValidateUtc(value);
            }
        }

        private DateTime? _completedOn;
        public DateTime? CompletedOnUtc
        {

            get { return _completedOn; }
            set
            {
                _completedOn = ValidateUtc(value);
            }
        }

        public AppUser CreatedByAppUser { get; set; }

        public string CreatedByAppUserInitials
        {
            get
            {
                return CreatedByAppUser == null ? string.Empty :
                    (CreatedByAppUser.FirstName + " ").Substring(0, 1).ToUpper() +
                    (CreatedByAppUser.LastName + " ").Substring(0, 1).ToUpper();
            }
        }

        public int ProgressComplete
        {
            get
            {
                Random random = new Random();
                return (int) (random.Next(1, 11) * 10);
            }
        }

        public IEnumerable<AppUser> AssignedUsers { get; set; } = new List<AppUser>();
    }
}
