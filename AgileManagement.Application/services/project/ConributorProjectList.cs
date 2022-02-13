using AgileManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application
{
    public class ConributorProjectList : IConributorProjectList
    {
        IProjectRepository _projectRepository;


        public ConributorProjectList(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ProjectWithContributorsResponseDto OnProcess(string request)
        {
            var project = _projectRepository.GetQuery().Include(x => x.Contributers).SelectMany(b => b.Contributers)
                .Where(a => a.UserId == request && a.Status == 101).Select(c => new ProjectDto
                {
                    Name = c.Project.Name,
                    Description = c.Project.Description
                }).ToList();

            var response = new ProjectWithContributorsResponseDto
            {
                Projects = project
            };

            return response;
        }
    }
}
