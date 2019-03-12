using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MPSC.PlenoSoft.IBGE.API.SIDRA
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var client = new HttpClient { BaseAddress = new Uri(TabelaIndiceIBGE.BaseAddressAPI) };
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			ObterValores(client, TabelaIndiceIBGE.IPCA.De().ApiURL);
			ObterValores(client, TabelaIndiceIBGE.INPC.De().ApiURL);

			Console.ReadLine();
		}

		private static void ObterValores(HttpClient client, String apiURL)
		{
			var response = client.GetAsync(apiURL).Result;
			if (!response.IsSuccessStatusCode)
				Console.WriteLine("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
			else
			{
				var valores = response.Content.ReadAsAsync<IEnumerable<ValorDescritoPorSuasDimensoes>>().Result;
				foreach (var valor in valores)
					Console.WriteLine($"{valor.D2N} {valor.D4N} - {valor.D1N} - {valor.V} {valor.MN} ");
			}
			Console.WriteLine();
		}
	}
}