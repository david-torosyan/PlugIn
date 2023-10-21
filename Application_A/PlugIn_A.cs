using SeeSharpCore.Interfaces;

namespace Application_A
{
    public class PlugIn_A : IPlugIn
    {
        private string Value = "This is PlugIn A";
        public void DoProcess()
        {
            Console.WriteLine(Value);
        }
    }
}