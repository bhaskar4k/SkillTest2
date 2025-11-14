using System.Text;
using Microsoft.SemanticKernel;

string yourDeploymentName = "gpt";
string yourEndpoint = "https://openai56429111.openai.azure.com/";
string yourKey = "5af8a5ec932f409d8492bb92c44f553b";

//TODO 1.2 - Create a Kernel builder by using the CreateBuilder method of the Kernel object
var builder = Kernel.CreateBuilder();
//TODO 1.3 - Configure access to gpt using the AddAzureOpenAIChatCompletion method of the builder's services object
builder.Services.AddAzureOpenAIChatCompletion(yourDeploymentName, yourEndpoint, yourKey);

var kernel = builder.Build();

string input;

do {
    Console.WriteLine("Do you have a question?");
    //TODO 1.4 - Gather user input
    input = Console.ReadLine() ?? string.Empty;
    
    //TODO 1.5 - Provide response based on the user input
    if (!string.IsNullOrWhiteSpace(input))    
    {
        var result = await kernel.InvokePromptAsync(input);
        Console.WriteLine(result);
    }
}
while (!string.IsNullOrWhiteSpace(input));
