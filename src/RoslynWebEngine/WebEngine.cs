using System;
using System.Collections.Generic;
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
            session = engine.CreateSession();

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _document.Body.MouseDown += Body_MouseDown;
        }

        private void Body_MouseDown(object sender, HtmlElementEventArgs e)
        {
            var element = (HtmlElement)sender;
        }
    }
}
