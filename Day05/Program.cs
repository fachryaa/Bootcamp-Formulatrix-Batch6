using System.Diagnostics;
using System.Text;
using Day05;
using Day05.Generic;

namespace Day05;

class Program
{
	static void Main(string[] Args)
	{
		// Value type and Reference Type
		ValueAndReference.Run();
		
		// Object, Var, Dynamic
		ObjVarDynamic.Run();

		// Generic Collector
		GenericCollector.Run();		
		
		// Generuc Constraint
		GenericConstraint.Run();		
	}

	
}