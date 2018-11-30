using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimelineDLL.Models
{
    public enum EventTypes
    {
        Foundation,
        Creation, 
        Goverment
    }

    public enum PersonaTypes
    {
        Student,
        Lector,
        Scientist,
        Rector
    }

    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options)
            : base(options) { }

        public DbSet<TimePeriod> TimePeriods { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    public class TimePeriod
    {
        public int TimePeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Boolean IsKeyEvent { get; set; }
        public byte[] ImageContent { get; set; }
        public PersonaTypes? Persona { get; set; }
        public EventTypes? Event { get; set; }

        public int TimePeriodId { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
