using System;
using System.Collections;
using System.Collections.Generic;

namespace Neu
{
	public class NeuMemory
	{
		public const ushort RamSize = 0x800;

		private NeuMemoryHandler[] _handlers;

		private byte[] _ram;

		public NeuMemory()
		{
			_handlers = new NeuMemoryHandler[ushort.MaxValue + 1];
			_ram = new byte[RamSize];

			this.InitializeRamHandler();
		}

		public void RegisterHandler( NeuMemoryHandler handler )
		{
			for( int i = handler.Start; i < handler.End; i++ )
			{
				_handlers[i] = handler;
			}
		}

		public byte Read( ushort address )
		{
			var handler = _handlers[address];
			return handler.Read( (ushort)( address & handler.Mask ) );
		}

		public void Write( ushort address, byte data )
		{
			var handler = _handlers[address];
			handler.Write( (ushort)( address & handler.Mask ), data );
		}

		private void InitializeRamHandler()
		{
			var handler = new NeuMemoryHandler_Ram( _ram, 0, RamSize * 4, RamSize - 1 );
			this.RegisterHandler( handler );
		}
	}
}