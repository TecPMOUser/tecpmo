﻿using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Interface
{
    public interface IProjectDetailsRepository : IRepository
    {
        IList<ProjectDetails> GetAllProjectDetails();

        int UpdateProjectDetails(ProjectDetails projectdetails);
        int SaveProjectDocumentDetails(DocumentDetails projectdocuemntdetails);
        int SaveProjectDetails(List<ProjectDetails> projectdetails);

        int DeleteProjectDetails(int ID);
        IList<DocumentDetails> GetDocumentsForProject(string ProjectID);
    }
}
