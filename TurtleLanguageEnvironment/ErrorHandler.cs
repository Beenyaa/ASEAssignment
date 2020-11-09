using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TurtleLanguageEnvironment
{
    public class ErrorHandler
    {
        String[] errorArray;
        List<String> errorList;
        public ErrorHandler()
        {
            errorList = new List<string>();
        }

        public void AddError(String error)
        {
            errorList.Add(error);
        }

        public String[] GetErrorList()
        {
            errorArray = errorList.ToArray();
            return errorArray;
        }

        public void Clear()
        {
            errorArray = new string[] { };
            errorList.Clear();
        }



    }
}
