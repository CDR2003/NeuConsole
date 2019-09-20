using System.Collections;
using System.Collections.Generic;

namespace Neu.Instructions
{
	public class NeuADC : NeuInstruction
	{
		public override string Name
		{
			get
			{
				return "ADC";
			}
		}

		public override void Run( NeuCpu cpu, ushort operandValue )
		{

		}
	}
}