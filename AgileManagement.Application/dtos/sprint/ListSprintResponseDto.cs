using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application
{
    public class SprintDto
    {
        public string Name { get; set; }
        public int SprintNumber { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(14);

    }
    public class ListSprintResponseDto
    {
        public List<ProjectDto> Projects = new List<ProjectDto>();
    }
}
