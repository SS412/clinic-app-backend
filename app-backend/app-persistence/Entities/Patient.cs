using app_persistence.Enums;
using System.ComponentModel.DataAnnotations;

namespace app_persistence.Entities
{
    /// <summary>
    /// Entity representing the patients that visit the clinic for consultation
    /// </summary>
    public class Patient
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public Schooling Schooling { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
}
