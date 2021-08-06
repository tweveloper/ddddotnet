using System.Management.Automation;
using System.Text;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Module
{
    public static class PowerShellRunner
    {
        public static string Command(string command)
        {
            StringBuilder result = new StringBuilder();
            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript(command);

                // specify the parameters to pass into the script.
                //ps.AddParameters(scriptParameters);

                // execute the script and await the result.
                var pipelineObjects = ps.Invoke();

                // print the resulting pipeline objects to the console.
                foreach (var item in pipelineObjects)
                {
                    result.Append(item.BaseObject.ToString());
                }
            }

            return result.ToString();
        }
    }
}
