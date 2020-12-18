using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguageEnvironment.commands.logicOperators
{
    /// <summary>
    /// The class intended for variable creation
    /// </summary>
    class Variable
    {
        private string name;
        private string value;
        private string operation;
        /// <summary>
        /// Gets the value
        /// </summary>
        /// <returns>Returns the variables value</returns>
        public string GetValue()
        {
            return value;
        }

        /// <summary>
        /// Sets the vairables value
        /// </summary>
        /// <param name="operand">The value to be stored in the variable</param>
        public void SetValue(string operand)
        {
            value = operand;
        }

        /// <summary>
        /// Gets the name of the variable
        /// </summary>
        /// <returns>Sets the variable</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Sets the variables name
        /// </summary>
        /// <param name="operand">The name for the variable. </param>
        public void SetName(string operand)
        {
            name = operand;
        }

        /// <summary>
        /// Sets the mathematical operation to be performed on the variable values
        /// </summary>
        /// <param name="op">Sets the mathematical operation (=, +=, -=)</param>
        public void setOperation(string op) { operation = op; }
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
