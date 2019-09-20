using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public abstract class NeuInstruction
	{
		public abstract string Name { get; }

		public abstract void Run( NeuCpu cpu, ushort operand, ushort value );
	}
}