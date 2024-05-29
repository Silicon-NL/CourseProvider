using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CourseProvider.Functions
{
    public class Playground
    {
        private readonly ILogger<Playground> _logger;

        public Playground(ILogger<Playground> logger)
        {
            _logger = logger;
        }

        [Function("Playground")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "graphql")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            await response.WriteStringAsync(PlaygroundPage());
            return response;
        }

        private string PlaygroundPage()
        {
            return @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                    <title>HotChocolate Playground</title>
                    <style>
                        body { font-family: Arial, sans-serif; margin: 0; padding: 0; }
                        .container { width: 100%; height: 100vh; display: flex; justify-content: center; align-items: center; background-color: #f5f5f5; }
                        .playground { width: 90%; height: 90%; border: 1px solid #ccc; background-color: #fff; }
                    </style>
                    <script src='https://unpkg.com/@apollographql/graphql-playground-react/build/static/js/middleware.js'></script>
                </head>
                <body>
                    <div id='root'></div>
                    <script>
                        window.addEventListener('load', function (event) {
                            GraphQLPlayground.init(document.getElementById('root'), {
                                endpoint: '/api/graphql'
                            })
                        })
                    </script>
                </body>
                </html>";
        }
    }
}
