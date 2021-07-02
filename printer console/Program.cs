using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using bpac;

namespace printer_console
{
	class Program
	{
		// arg 0: device serial number
		// arg 1: template name ends in .LBX
		static void Main(string[] args)
		{
			

			// string TEMPLATE_DIRECTORY = @"C:\Users\upreptech\Downloads\"; 
			// string DELL_3100 = "Chromebook Dell 3100.LBX";    
			string templatePath = @"C:\Users\upreptech\Downloads\" + args[1];
			string serial_number = args[0];

			DocumentClass doc = new DocumentClass();

			if (doc.Open(templatePath) != false) {
				try
				{
					doc.GetObject("barcode").Text = serial_number;
					doc.GetObject("qrcode").Text = "https://uprep.org/helpdesk/" + serial_number;
				}
				catch
                {
					Debug.WriteLine("Could not find template object named barcode or qrcode");
                }

				// doc.SetMediaById(doc.Printer.GetMediaId(), true);
				doc.StartPrint("", PrintOptionConstants.bpoDefault);
				doc.PrintOut(1, PrintOptionConstants.bpoDefault);
				doc.EndPrint();
				doc.Close();
            }
            else
            {
				Debug.WriteLine("Could not find/open file " + templatePath);
            }
		}
	}
}

			