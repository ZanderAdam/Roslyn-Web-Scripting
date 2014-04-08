using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roslyn.Scripting.CSharp;

namespace RoslynWebEngine
{
    public class WebEngine
    {
        private readonly HtmlDocument _document;

        ScriptEngine engine = new ScriptEngine();
        Roslyn.Scripting.Session session;

        public WebEngine(HtmlDocument document)
        {
            _document = document;

            session = engine.CreateSession(document);
            session.AddReference("System.Windows.Forms");

            RegisterEvents();

            var scriptFile = File.ReadAllText(@".\SampleWebApp\Scripts\index.csx");
            session.Execute(scriptFile);
        }

        private void RegisterEvents()
        {
            _document.MouseUp += Body_MouseDown;
        }

        private void Body_MouseDown(object sender, HtmlElementEventArgs e)
        {
            var element = _document.ActiveElement;

            if (element == null)
                return;

            string clickEvent = element.GetAttribute("onClickEvent");

            if (clickEvent != "")
            {
                session.Execute(clickEvent);
            }
        }
    }
}
