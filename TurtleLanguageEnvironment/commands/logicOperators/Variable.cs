using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguageEnvironment.commands.logicOperators
{
    /// <summary>
    /// The class of a Variable
    /// </summary>
    class Variable
    {
        private string name;
        private string value;
        private string operation;
        /// <summary>
        /// Gets the variable value
        /// </summary>
        /// <returns>Returns the variable value</returns>
        public string GetValue()
        {
            return value;
        }

        /// <summary>
        /// Sets the vairable value
        /// </summary>
        /// <param name="tempValue">The value to be stored in the variable</param>
        public void SetValue(string tempValue)
        {
            value = tempValue;
        }

        /// <summary>
        /// Gets the name of the variable
        /// </summary>
        /// <returns>Gets the variable</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Sets the variable name
        /// </summary>
        /// <param name="tempName">The name for the variable. </param>
        public void SetName(string tempName)
        {
            name = tempName;
        }

        /// <summary>
        /// Sets the mathematical operation to be performed on the variable values
        /// </summary>
        /// <param name="op">Sets the mathematical operation (=, +=, -=)</param>
        public void setOperation(string op)
        {
            operation = op;
        }
        /// <summary>
        /// Runs the mathematical equation on the variable value
        /// </summary>
        public void runEquation(string tempValue)
        {
            int tempMaths;
            switch (operation)
            {
                case "=":
                    SetValue(tempValue);
                    break;
                case "-=":
                    tempMaths = int.Parse(GetValue()) - int.Parse(tempValue);
                    SetValue(tempMaths.ToString());
                    break;
                case "+=":
                    tempMaths = int.Parse(GetValue()) + int.Parse(tempValue);
                    SetValue(tempMaths.ToString());
                    break;
            }
                
        }

    }
}
