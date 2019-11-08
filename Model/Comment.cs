
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FAQApi.Model
{
    public class Comment
    {
        
        [Key]
        public int comment_id { get; set; }
        public string comment_body { get; set; }
        public Comment? comment_parent { get; set; }
        public ICollection<Comment> comment_children { get; set; }


    }
}
