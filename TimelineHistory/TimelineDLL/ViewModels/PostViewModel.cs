using System;
using System.Collections.Generic;
using System.Text;
using TimelineDLL.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TimelineDLL.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public Image ImageContent { get; set; }
        public int TimePeriodId { get; set; }

        public Boolean IsKeyEvent { get; set; }
        public PersonaTypes? Persona { get; set; }
        public EventTypes? Event { get; set; }
    }
}
