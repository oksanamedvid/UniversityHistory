using System;
using System.Collections.Generic;
using System.Linq;
using TimelineDLL.Models;
using TimelineDLL.ViewModels;

namespace TimelineDLL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {

        private readonly HistoryContext _context;

        public HistoryRepository(HistoryContext context)
        {
            this._context = context;
        }

        public List<TimePeriodViewModel> GetTimePeriods()
        {
            try
            {
                return _context.TimePeriods.Select(p => p.MapToViewModel()).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<PostViewModel> GetPosts(int timePeriodId, PersonaTypes? persona = null, EventTypes? eventType = null,
            bool? isKeyEvent = null)
        {
            try
            {
                return _context.Posts.Where(p => p.TimePeriodId == timePeriodId && (persona == null || p.Persona == persona)
                && (eventType == null || p.Event == eventType) && (isKeyEvent == null || p.IsKeyEvent))
                .Select(p => p.MapToViewModel()).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool AddPost(PostViewModel postViewModel)
        {
            try
            {
                _context.Posts.Add(new Post
                {
                    PostId = postViewModel.PostId,
                    Title = postViewModel.Title,
                    Content = postViewModel.Content,
                    TimePeriodId = postViewModel.TimePeriodId,
                    Persona = postViewModel.Persona,
                    Event = postViewModel.Event,
                    IsKeyEvent = postViewModel.IsKeyEvent
                });
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AddPeriod(TimePeriodViewModel period)
        {
            try
            {
                _context.TimePeriods.Add(new TimePeriod
                {
                    TimePeriodId = period.TimePeriodId,
                    StartDate = period.StartDate,
                    EndDate = period.EndDate,
                    Name = period.Name
                });
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }

    public static class Mapper
    {
        public static PostViewModel MapToViewModel(this Post post)
        {
            return new PostViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                TimePeriodId = post.TimePeriodId
            };
        }

        public static TimePeriodViewModel MapToViewModel(this TimePeriod period)
        {
            return new TimePeriodViewModel
            {
                TimePeriodId = period.TimePeriodId,
                StartDate = period.StartDate,
                EndDate = period.EndDate,
                Name = period.Name
            };
        }
    }
}
