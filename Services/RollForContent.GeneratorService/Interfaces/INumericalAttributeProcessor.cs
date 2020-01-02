using RollForContent.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollForContent.GeneratorService.Interfaces
{
    public interface INumericalAttributeProcessor
    {
        ISelectedAttribute DetermineValue(NumericalAttribute input);
    }
}
