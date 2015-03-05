using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core.Scripting
{
    public interface IScriptingService : IService
    {
        ScriptingProject CreateProject(string name);
        ScriptingProject LoadProject(string name);

        ICollection<ScriptingProject> Projects { get; }

        UI.IDocumentWindow OpenModule( ScriptingModule Module , object BottomView = null);
    }



    public class ScriptingProject
    {
        protected ScriptingProject()
        {
            this.References = new List<ScriptingReference>();

            this.Modules = new List<ScriptingModule>();

           
        }

        public virtual string Name { get; set; }

        public virtual string Language { get; private set; }

        public virtual ICollection<ScriptingReference> References { get; private set; }

        public virtual ICollection<ScriptingModule> Modules { get; private set; }

        public virtual ScriptingReference AddAssemblyReference( string Location )
        {
            return null;
        }
        public virtual ScriptingReference AddAssemblyReference(System.Reflection.Assembly Assembly)
        {
            return null;
        }
        public virtual ScriptingModule AddModule(string Name)
        {
            return null;
        }

        public virtual void Compile()
        {
        }       
    }
    public  class ScriptingReference
    {
        protected ScriptingReference()
        {

        }

        public virtual string Location { get; private set; }

        public virtual string Type { get; private set; }
    }
    public class ScriptingModule
    {
        protected ScriptingModule()
        {
            ImportedNamespaces = new List<string>();
        }

        public virtual List<string> ImportedNamespaces { get; private set; }

        public virtual ScriptingProject ScriptingProject { get; set; }

        public virtual int Index { get; set; }

        public virtual string Name { get; set; }
       
        public virtual string Code { get; set; }

        public virtual void InsertCode(string code)
        {
        }
        public virtual void Run()
        {
        }
        public virtual void Compile()
        {
        }
    }

    public static class GUI
    {
        public static void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }
    }

    public static class ENV
    {
        public static string DomainName
        {
            get { return Environment.UserDomainName; }
        }

        public static string UserName
        {
            get { return Environment.UserName; }
        }

        public static string MachineName
        {
            get { return Environment.MachineName; }
        }
    }
}
