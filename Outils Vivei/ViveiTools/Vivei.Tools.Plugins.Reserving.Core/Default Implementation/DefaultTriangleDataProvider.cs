using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vivei.Tools.Modules.Provisionnement.Model.Interfaces;

namespace Vivei.Tools.Plugins.Reserving.Core.Default_Implementation
{
    public class DefaultTriangleDataProvider : ITriangleDataProvider
    {
        public string RowUsage { get; set; }

        public bool Cumulative { get; set; }


        public ITriangleData Create(Func<int, int, double> generator, string[] rowlabels, string[] columnlabels)
        {
            throw new NotImplementedException();
        }

        public ITriangleData Create(Func<int, int, double> generator, Func<int, string> rowlabels, Func<int, string> columnlabels)
        {
            throw new NotImplementedException();
        }

        public ITriangleData Compute(IInternalData data)
        {
            throw new NotImplementedException();
        }

        public ITriangleData Compute(IInternalData data, string filter)
        {
            throw new NotImplementedException();
        }

        public ITriangleData Compute(IInternalData data, IDataSegment segment)
        {
            throw new NotImplementedException();
        }

        public ITriangleData Compute(System.Data.DataView data, IDictionary<System.Data.DataColumn, string> usages)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Initialize(bool noview, Modules.Provisionnement.Model.AnalysisStage stage)
        {
            throw new NotImplementedException();
        }

        public object View
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
