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
        private readonly string _webRoot;

        ScriptEngine engine = new ScriptEngine();
        Roslyn.Scripting.Session session;

        public WebEngine(HtmlDocument document, string webRoot)
        {
            _document = document;
            _webRoot = webRoot;

            session = engine.CreateSession(document);
            session.AddReference("System.Windows.Forms");

            RegisterEvents();
            CompileScripts();
        }

        private void CompileScripts()
        {
            var scripts = _document.GetElementsByTagName("script");

            foreach (HtmlElement script in scripts)
            {
                if (script.GetAttribute("type") == "text/csx")
                {
                    var source = script.GetAttribute("src");

                    if (source != "")
                    {
                        CompileScriptFromFile(source);
                    }
                    else
                    {
                        CompileSource(script.InnerHtml);
                    }
                }
            }
        }

        private void CompileScriptFromFile(string sourcePath)
        {
            sourcePath = sourcePath.Replace(@"/", @"\");
            sourcePath = Path.Combine(_webRoot, sourcePath);
            var source = File.ReadAllText(sourcePath);

            session.Execute(source);
        }

        private void CompileSource(string source)
        {
            session.Execute(source);
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
