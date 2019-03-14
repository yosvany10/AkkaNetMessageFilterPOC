using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
    class AmAvailable
    {
		public string Key { get; set; }

		public AmAvailable(string key)
		{
			Key = key;
		}
	}
}
