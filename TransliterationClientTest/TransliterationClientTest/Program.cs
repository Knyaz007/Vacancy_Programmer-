using Grpc.Net.Client;
using System;
using TransliterationClient;
using TransliterationGrpcService;

class Program
{
    static void Main(string[] args)
    {
        // gRPC Client
        using var channel = GrpcChannel.ForAddress("https://localhost:7120");
        var grpcClient = new TransliterationOnProto.TransliterationOnProtoClient(channel);
        var client = new GrpcTransliterationClient(grpcClient);
        var result1 = client.Transliterate("Пример текста для транслитерации");
        Console.WriteLine("Результат транслитерации (gRPC): " + result1);

        // REST API Client
        var apiClient = new ApiTransliterationClient("http://localhost:5202/Transliteration");
        string text = "Пример текста для транслитерации";

        try
        {
            var result = apiClient.Transliterate(text);
            Console.WriteLine("Transliterated text (REST API): " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Прямое использование
        var directClient = new DirectTransliterationClient();
        Console.WriteLine("Direct Client: " + directClient.Transliterate("Пример текста для транслитерации"));
        Console.ReadLine();
    }
}
