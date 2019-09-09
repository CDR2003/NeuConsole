using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public class NeuCpuRegisters
	{
		public ushort PC;

		public byte SP;

		public byte A;

		public byte X;

		public byte Y;

		public NeuCpuStatusRegister P;

		public NeuCpuRegisters()
		{
			this.PC = 0;
			this.SP = 0;
			this.A = 0;
			this.X = 0;
			this.Y = 0;
			this.P = new NeuCpuStatusRegister();
		}
	}
}