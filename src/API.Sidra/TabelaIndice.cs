using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.IBGE.API.SIDRA
{
	public class TabelaIndiceIBGE
	{
		public const String BaseAddressAPI = "http://api.sidra.ibge.gov.br";
		public Int32 Tabela { get; private set; }
		private String Periodo { get; set; } = "last";
		public Dictionary<Int32, String> Variavel { get; private set; }
		public KeyValuePair<Int32, String> Agrupamento { get; private set; }

		private String T => $"/t/{Tabela}";
		private String P => $"/p/{Periodo}";
		private String V => $"/v/{Variavel.First().Key}";
		private String C315 => $"/c315/{Agrupamento.Key}";
		private String N1 => $"/n1/1";
		public String Help => $"{BaseAddressAPI}/desctabapi.aspx?c={Tabela}";
		public String ApiURL => $"/values{T}{P}{V}{C315}{N1}";

		public TabelaIndiceIBGE De(DateTime? competencia = null)
		{
			Periodo = competencia?.ToString("yyyyMM") ?? "last";
			return this;
		}

		public static readonly TabelaIndiceIBGE INPC = new TabelaIndiceIBGE
		{
			Tabela = 1100,
			Variavel = new Dictionary<Int32, String>() {
				{0044, "INPC - Variação mensal(%)" },
				{0068, "INPC - Variação acumulada no ano(%)" },
				{2292, "INPC - Variação acumulada em 12 meses(%)"},
				{0045, "INPC - Peso mensal(%)"}
			},
			Agrupamento = new KeyValuePair<Int32, String>(7169, "Índice geral"),
		};

		public static readonly TabelaIndiceIBGE IPCA = new TabelaIndiceIBGE
		{
			Tabela = 1419,
			Variavel = new Dictionary<Int32, String>() {
				{0063, "IPCA - Variação mensal(%)" },
				{0069, "IPCA - Variação acumulada no ano(%)" },
				{2265, "IPCA - Variação acumulada em 12 meses(%)"},
				{0066, "IPCA - Peso mensal(%)"}
			},
			Agrupamento = new KeyValuePair<Int32, String>(7169, "Índice geral"),
		};
	}
}