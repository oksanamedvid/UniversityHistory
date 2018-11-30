using System.Collections.Generic;
using System.Linq;
using TimelineDLL.Models;
using TimelineDLL.ViewModels;

namespace TimelineDLL.Repositories
{
    public interface IHistoryRepository
    {
        List<TimePeriodViewModel> GetTimePeriods();
        List<PostViewModel> GetPosts(int timePeriodId, PersonaTypes? persona = null, EventTypes? eventType = null, bool? isKeyEvent = null);
        bool AddPost(PostViewModel post);
        bool AddPeriod(TimePeriodViewModel period);
    }
}
