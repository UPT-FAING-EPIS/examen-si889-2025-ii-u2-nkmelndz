using System;

namespace DocumentExporterApp
{
    public abstract class DocumentExporter
    {
        public abstract string Export(string content);
    }

    public class PdfExporter : DocumentExporter
    {
        public override string Export(string content)
        {
            return $"Exportando a PDF: {content}";
        }
    }

    public class WordExporter : DocumentExporter
    {
        public override string Export(string content)
        {
            return $"Exportando a Word: {content}";
        }
    }

    public class HtmlExporter : DocumentExporter
    {
        public override string Export(string content)
        {
            return $"Exportando a HTML: {content}";
        }
    }

    public class DocumentExporterFactory
    {
        public static DocumentExporter CreateExporter(string type)
        {
            return type.ToLower() switch
            {
                "pdf" => new PdfExporter(),
                "word" => new WordExporter(),
                "html" => new HtmlExporter(),
                _ => throw new ArgumentException("Tipo de exportación no soportado")
            };
        }
    }
}