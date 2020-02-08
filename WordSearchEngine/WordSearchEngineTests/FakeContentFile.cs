using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchEngineTests
{
	class FakeContentFile
	{
		private readonly static string text1 = $"Esto es un ejemplo de prueba del contenido de un fichero. " +
			$"Como fichero de prueba que es, debe contener varias veces una palabra repetida para que " +
			$"la prueba sea satisfactoria." +
			$"Si el fichero no contuviera la palabra buscada, deberá devolver cero coincidencias";

		public static string GetContentFile()
		{
			return text1;
		}

		public static string GetEmptyContentFile()
		{
			return string.Empty;
		}
	}
}
