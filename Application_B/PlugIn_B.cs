using SeeSharpCore.Interfaces;

namespace Application_B
{
    public class PlugIn_B : IPlugIn
    {
        private string Value = "This is PlugIn B";
        public void DoProcess()
        {
            Console.WriteLine(Value);
        }
    }
}