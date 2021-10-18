using System;

namespace Api
{
    public class Character
    {
        public Guid Id {  get; set; }
        public int CharId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Origin { get; set; }
        public string Species { get; set; }
        public string Status { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
