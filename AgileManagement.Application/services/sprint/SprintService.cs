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
            var project = _projectRepository.GetQuery().Include(x => x.Sprints).Where(y => y.Id == projectId).Select(a => new ProjectDto
            {
                Name = a.Name,
                Description = a.Description,
                
                Sprints = a.Sprints.Select(b => new SprintDto
                {
                    Name = b.Name,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    SprintNumber = b.SprintNo
                }).ToList()
            }).ToList();

            var respone = new ListSprintResponseDto { Projects = project };
            return respone;
        }
    }
}
