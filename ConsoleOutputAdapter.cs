//David Norvell
//OCCC C# Spring 2021 Online
//ConsoleOutputAdapter.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FinalExam2
{
    public class ConsoleOutputAdapter : TextWriter
    {
        RichTextBox _Output = null;

        public ConsoleOutputAdapter(RichTextBox Output)
        {
            _Output = Output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _Output.AppendText(value.ToString());
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        

      
    }
}
