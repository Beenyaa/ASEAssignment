using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguageEnvironment.commands.logicOperators
{
    class Variable
    {
        private String name;
        private String value;

        public Variable(String name, String value)
        {
            this.name = name;
            this.value = value;
        }

        public String Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public String Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
