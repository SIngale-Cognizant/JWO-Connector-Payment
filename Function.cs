using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using PaymentMethodPublisher.EventPublisher;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace JWO_PaymentsConnector
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n"+ request.Body);
            AddCardRequestUI requestUI = JsonConvert.DeserializeObject<AddCardRequestUI>(request?.Body);
           
            await EventPublisher.EventBridgeConnect(request, context);
           
            context.Logger.LogLine("Request UI =" + requestUI);

            //context.Logger.LogLine(b + " Dictionary = " + JsonConvert.SerializeObject(b));
            return new APIGatewayHttpApiV2ProxyResponse
            {
                Body = request.Body.ToString(),
                StatusCode = 200
            };
        }
    }
}
