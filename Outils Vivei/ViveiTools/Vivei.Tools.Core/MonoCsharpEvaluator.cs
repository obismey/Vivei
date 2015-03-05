using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core
{
    public static class MonoCsharpEvaluator
    {
        public static Tuple< Mono.CSharp.Evaluator, System.IO.StringWriter>  Create()
        {
            var writer = new System.IO.StringWriter();

            var evaluator =  new Mono.CSharp.Evaluator(
                    new Mono.CSharp.CompilerContext(
                    new  Mono.CSharp.CompilerSettings(), 
                    new  Mono.CSharp.StreamReportPrinter(writer)));

            return new Tuple<Mono.CSharp.Evaluator, System.IO.StringWriter>(evaluator, writer);
        }
    }
}
