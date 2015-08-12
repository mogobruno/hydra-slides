using System;

namespace Hydra.Domain
{
    public class Slide
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual User Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
