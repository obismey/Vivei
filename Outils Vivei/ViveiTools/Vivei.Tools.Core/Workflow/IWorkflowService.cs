using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core.Workflow
{
    public interface IWorkflowService : IService
    {
        UI.IDocumentWindow OpenWorflow(string name, WorkflowDocument document);
    }

    public class WorkflowDocument
    {
    }
}
