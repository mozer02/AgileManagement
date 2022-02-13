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
        public string Name { get; private set; } = "Sprint-";
        public int SprintNo { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Project Project { get; private set; }
        public bool isActive { get;private set; }

        public Sprint(DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid().ToString();
            SetSprintDate(startDate, endDate);
            isActive = true;
        }
        public void SetIsActive(bool IsActive)
        {
            if (isActive==IsActive)
            {
                throw new Exception("Hatalı işlem.");
            }
            isActive = IsActive;
        }
        
        public void SetSprintNo(int sprintno)
        {
            if (sprintno<=0)
            {
                throw new Exception("Sprint No 0 ve 0'dan küçük olamaz.");
            }
            SprintNo = sprintno;
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
