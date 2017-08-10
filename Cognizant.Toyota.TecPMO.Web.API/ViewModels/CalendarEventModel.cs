using System;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class CalendarEventModel
    {

        public string Title { get; set; }
        public string Status { get; set; }
        public string EventTypeDate { get; set; }

        public string ProjectID { get; set; }
        public string Stage { get; set; }
        public long ID { get; set; }



        public CalendarEventModel()
        {

        }
        public CalendarEventModel(string title, DateTime date, string status, string projectID, string Stage, long ID)
        {
            this.Title = title;
            this.EventTypeDate = date.ToString("yyyy-MM-dd");
            this.Status   = status;
            this.ProjectID = projectID;
            this.Stage = Stage;
            this.ID = ID;
           
        }
      
    }
}