using System;
using System.Threading.Tasks;
using Grpc.Core;
using TransliterationGrpcService;

namespace TransliterationClient
{
    public class GrpcTransliterationClient : ITransliterationClient
    {
        private readonly TransliterationOnProto.TransliterationOnProtoClient _client;

        public GrpcTransliterationClient(TransliterationOnProto.TransliterationOnProtoClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public string Transliterate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be null or empty", nameof(text));
            }

            var request = new TransliterateRequest { Text = text };
            var response = _client.Transliterate(request);
            return response.Result;
        }

        public async Task<string> TransliterateAsync(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be null or empty", nameof(text));
            }

            var request = new TransliterateRequest { Text = text };
            var response = await _client.TransliterateAsync(request);
            return response.Result;
        }
    }
}
