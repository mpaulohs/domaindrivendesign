using System.Collections.Generic;

namespace demo2.Domain.AggregatesModel
{
    public class Tag
    {
        public string TagId { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
