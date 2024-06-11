// TransliterationGrpcService/Services/TransliterationService.cs
using Grpc.Core; 
using TransliterationLib;

namespace TransliterationGrpcService.Services
{
    public class TransliterationService : TransliterationOnProto.TransliterationOnProtoBase
    {
        private readonly ILogger<TransliterationService> _logger;
        private readonly Transliterator _transliterator;
      
        public TransliterationService(ILogger<TransliterationService> logger)
        {
            _logger = logger;
            _transliterator = new Transliterator();
        }

        public override Task<TransliterateResponse> Transliterate(TransliterateRequest request, ServerCallContext context)
        {
            var result = _transliterator.Transliterate(request.Text);
            return Task.FromResult(new TransliterateResponse { Result = result });
        }



    }
}
