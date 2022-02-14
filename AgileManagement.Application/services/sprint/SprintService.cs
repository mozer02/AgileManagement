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

        public ProjectDto OnProcess(string projectId)
        {
            var project = _projectRepository.GetQuery().Where(y => y.Id == projectId).Include(x => x.Sprints).Select(a => new ProjectDto
            {
                Name = a.Name,
                Description = a.Description,
                ProjectId = a.Id,

                Sprints = a.Sprints.Select(b => new SprintDto
                {
                    Name = b.Name,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,

                }).ToList()
            }).FirstOrDefault();

           
            return project;
        }
    }
}
