using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Domain.models
{
    public class Sprint:Entity
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Project Project { get; private set; }

        public Sprint(DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid().ToString();
            SetSprintDate(startDate, endDate);
        }
        public void SetSprintName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Ad kısmı boş geçilemez");
            }
            Name = name.Trim();
        }
        public void SetSprintDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new Exception("Bitiş tarihi başlangıç tarihinden önce olamaz.");
            }
            else if ((endDate - startDate).Days > 14)
            {
                throw new Exception("Başlangıç ile bitiş tarihi arası 2 haftadan fazla olamaz.");
            }
            StartDate = startDate.Date;
            EndDate = endDate.Date;
        }
    }
}
