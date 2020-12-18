using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguageEnvironment.commands
{
    /// <summary>
    /// Class to create the program logic
    /// </summary>
    class Factory
    {
        object returnLogic = null;
        /// <summary>
        /// Creates a nw If Statement
        /// </summary>
        /// <param name="firstParam">the first value, the logical operation</param>
        /// <param name="secondParam">The second value, the polished integer values.</param>
        /// <returns></returns>
        public logicOperators.IfStatement createIfStatement(string firstParam, string secondParam)
        {
            logicOperators.IfStatement returnLogic = new logicOperators.IfStatement();
            returnLogic.setFirstValue(firstParam);
            String[] strlist = secondParam.Split(',');
            returnLogic.setOperation(strlist[0]);
            returnLogic.setSecondValue(strlist[1]);
            return returnLogic;
        }
        /// <summary>
        /// Creates a new Method
        /// </summary>
        /// <param name="name">the first value, the name</param>
        /// <param name="pointer">The second value, the pointer.</param>
        /// <returns></returns>
        public logicOperators.Method createMethod(string name, string pointer)
        {
            logicOperators.Method returnLogic = new logicOperators.Method();
            returnLogic.SetName(name);
            returnLogic.SetPointer(int.Parse(pointer));
            return returnLogic;
        }
        /// <summary>
        /// Creates a new Variable
        /// </summary>
        /// <param name="name">the first value, the name</param>
        /// <param name="value">The second valu, the variable value.</param>
        /// <returns></returns>
        public logicOperators.Variable createVarariable(string name, string value)
        {
            logicOperators.Variable returnLogic = new logicOperators.Variable();
            returnLogic.SetName(name);
            returnLogic.SetValue(value);
            return returnLogic;
        }
    }
}
