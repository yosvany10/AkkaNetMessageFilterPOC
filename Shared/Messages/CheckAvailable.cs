using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
    class CheckAvailable
    {
		public string Key { get; set; }

		public CheckAvailable(string key)
		{
			Key = key;
		}
	}
}
