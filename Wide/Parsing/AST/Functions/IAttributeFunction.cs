﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Parsing.AST.Functions
{
    public interface IAttributeFunction : IFunction
    {
        IEnumerable<Attribute> Attributes { get; }
    }
}