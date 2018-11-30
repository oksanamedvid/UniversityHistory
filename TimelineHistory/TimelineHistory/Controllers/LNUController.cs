using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TimelineDLL.Models;
using TimelineDLL.Repositories;
using TimelineDLL.ViewModels;

namespace TimelineHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LNUController : Controller
    {
        private readonly IHistoryRepository _repository;
        public LNUController(IHistoryRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("[action]")]
        public IEnumerable<PostViewModel> GetPosts(int timePeriodId, PersonaTypes? persona = null, EventTypes? eventType = null,
            bool? isKeyEvent = null)
        {
            try
            {
                return _repository.GetPosts(timePeriodId, persona, eventType, isKeyEvent);
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        [HttpGet("[action]/")]
        public IEnumerable<TimePeriodViewModel> GetTimePeriods()
        {
            try
            {
                return _repository.GetTimePeriods();
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        [HttpPost("[action]")]
        public bool AddPost(PostViewModel postViewModel)
        {
            try
            {
                return _repository.AddPost(postViewModel);
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        [HttpPost("[action]")]
        public bool AddTimePeriod(TimePeriodViewModel timePeriodViewModel)
        {
            try
            {
                return _repository.AddPeriod(timePeriodViewModel);
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}