using AgileManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application
{
    public class SprintService : ISprintService
    {
        IProjectRepository _projectRepository;

        public SprintService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ListSprintResponseDto OnProcess(string projectId)
        {
            var project = _projectRepository.GetQuery().Include(x => x.Sprints).Where(y => y.Id == projectId).SelectMany(a => a.Sprints).Select(z => new SprintDto
            {
                Name = z.Name + z.SprintNo.ToString(),
                StartDate = z.StartDate,
                EndDate = z.EndDate,
            }).ToList();

            var respone = new ListSprintResponseDto { Sprints = project };
            return respone;
        }
    }
}
