﻿using System;

namespace IzracunKamataException
{
	class Program
	{
		static double IznosKamata(double glavnica, double stopa)
		{
			if (stopa < 0 || stopa > 20)
				throw new ArgumentOutOfRangeException("Stopa nije u rasponu 0-20");
			return glavnica * stopa / 100;
		}

		static void Main(string[] args)
		{
			var nastavi = true;
			do
			{
				try
				{
					Console.Write("Unesite glavnicu: ");
					var unos = Console.ReadLine();
					if (string.IsNullOrEmpty(unos))
					{
						nastavi = false;
					}
					else
					{
						var ok = double.TryParse(unos, out double glavnica);
						if (!ok)
						{
							Console.WriteLine("Broj je u pogrešnom formatu.");
							continue;
						}
						Console.Write("Unesite stopu (0-20%): ");
						unos = Console.ReadLine();
						ok = double.TryParse(unos, out double stopa);
						if (!ok)
						{
							Console.WriteLine("Broj je u pogrešnom formatu.");
							continue;
						}
						var kamata = IznosKamata(glavnica, stopa);
						Console.WriteLine("Za unesenu glavnicu {0} i kamatnu stopu {1} iznos kamata u jednom obračunskom razdoblju je {2}", glavnica, stopa, kamata);
					}
				}
				catch(ArgumentOutOfRangeException ex)
				{
					Console.WriteLine("Dogodila se pogreška. Tekst: {0}", ex.ParamName);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Dogodila se pogreška. Tekst: {0}", ex.Message);
				}

			} while (nastavi);
		}
	}
}
