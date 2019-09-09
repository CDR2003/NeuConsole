using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neu
{
	public class NeuMemoryHandler_Ram : NeuMemoryHandler
	{
		private byte[] _ram;

		public NeuMemoryHandler_Ram( byte[] ram, ushort start, ushort end, ushort mask )
			: base( start, end, mask )
		{
			_ram = ram;
		}

		public override byte Read( ushort address )
		{
			return _ram[address];
		}

		public override void Write( ushort address, byte data )
		{
			_ram[address] = data;
		}
	}
}