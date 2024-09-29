using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjetoFinal.Helpers
{
    public static class JsonHelpers
    {
        //O código serializa o objeto retorno em uma string JSON, mantendo referências e formatando a saída de forma legível.
        //É útil quando tem objetos que se referem uns aos outros (ciclos de referência) e deseja evitar problemas de duplicação ou exceções.
        public static string SerializarCiclosParaJson<T>(T objeto)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(objeto, options);
            return json;
        }
    }
}


