﻿using System.Text;
using Tokens.Enumerators;

namespace Tokens.Exceptions
{
    public class ParsingException : TokenizerException
    {
        internal ParsingException(string message, RawTokenEnumerator enumerator) : this(message, enumerator.Column, enumerator.Line)
        {
        }

        public ParsingException(string message, int character, int line) : base(message)
        {
            Column = character;
            Line = line;
        }

        public int Line { get; set; }

        public int Column { get; set; }

        public override string Message
        {
            get
            {
                var sb = new StringBuilder();

                sb.AppendLine(base.Message);
                sb.AppendLine();
                sb.AppendLine($"Column: {Column}");
                sb.AppendLine($"Line: {Line}");

                return sb.ToString();
            }
        }
    }
}
