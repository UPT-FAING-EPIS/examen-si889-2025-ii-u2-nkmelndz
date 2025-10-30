using DocumentExporterApp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(@"<html>
        <body>
            <h1>Exportador de Documentos</h1>
            <form method='post' action='/export'>
                <label for='type'>Tipo de Exportación:</label>
                <select name='type' id='type'>
                    <option value='pdf'>PDF</option>
                    <option value='word'>Word</option>
                    <option value='html'>HTML</option>
                </select>
                <br>
                <label for='content'>Contenido:</label>
                <textarea name='content' id='content'></textarea>
                <br>
                <button type='submit'>Exportar</button>
            </form>
        </body>
    </html>");
});

app.MapPost("/export", async context =>
{
    var form = await context.Request.ReadFormAsync();
    var type = form["type"];
    var content = form["content"];

    try
    {
        var exporter = DocumentExporterFactory.CreateExporter(type);
        var result = exporter.Export(content);
        await context.Response.WriteAsync(result);
    }
    catch (ArgumentException ex)
    {
        await context.Response.WriteAsync(ex.Message);
    }
});

app.Run();
