using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class LinkDto
    {
        public int LinkId { get; set; }
        public int AccountId { get; set; }
        public int MusicId { get; set; }
    }
}
