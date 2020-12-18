using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguageEnvironment.commands.logicOperators
{
    /// <summary>
    /// This contains the method logic.
    /// </summary>
    class Method
    {
        private string name;
        private int pointer;
        /// <summary>
        /// Gets the pointer from memory.
        /// </summary>
        /// <returns>The pointer for the start of the function.</returns>
        public int GetPointer()
        {
            return pointer;
        }

        /// <summary>
        /// Sets the pointer
        /// </summary>
        /// <param name="tempPointer">The line for the start of the function</param>
        public void SetPointer(int tempPointer)
        {
            pointer = tempPointer;
        }

        /// <summary>
        /// Gets the name of the Method
        /// </summary>
        /// <returns>Returns the Method name</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Sets the name of the Method
        /// </summary>
        /// <param name="tempName">The methods name.</param>
        public void SetName(string tempName)
        {
            name = tempName;
        }
    }
}
