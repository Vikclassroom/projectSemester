using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MusicDto
    {
        public int MusicId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int LinkId { get; set; }
    }
}
