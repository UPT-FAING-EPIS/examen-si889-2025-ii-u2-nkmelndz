using System;
using Xunit;
using DocumentExporterApp;

public class DocumentExporterTests
{
    [Fact]
    public void ExportarAPdf_DeberiaRetornarMensajeCorrecto()
    {
        var exporter = DocumentExporterFactory.CreateExporter("pdf");
        var resultado = exporter.Export("Contenido de prueba");

        Assert.Equal("Exportando a PDF: Contenido de prueba", resultado);
    }

    [Fact]
    public void ExportarAWord_DeberiaRetornarMensajeCorrecto()
    {
        var exporter = DocumentExporterFactory.CreateExporter("word");
        var resultado = exporter.Export("Contenido de prueba");

        Assert.Equal("Exportando a Word: Contenido de prueba", resultado);
    }

    [Fact]
    public void ExportarFormatoNoSoportado_DeberiaLanzarExcepcion()
    {
        Assert.Throws<ArgumentException>(() => DocumentExporterFactory.CreateExporter("excel"));
    }
}