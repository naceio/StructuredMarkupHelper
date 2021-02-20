# Structured Markup Helper

## Build & Run

Download and install [.NET 5.0](https://dotnet.microsoft.com/download) SDK

### CLI

Open `StructuredMarkupHelper.Cli` directory and run the following command:

```bash
# use osx-x64 or linux-x64 base on your os
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=True --self-contained True
```

You can find the executable at `bin/Release/net5.0/win-x64/publish`

Generate markup with the following command:
```bash
StructuredMarkupHelper.Cli --generate-markup --base-path wdir --document document.txt --vocab-mapping iptc_schemaorg_map.json --expertai-config expertai-config.json --markup-output markup-mapping.json

# run `StructuredMarkupHelper.Cli -h` to what are all inputs:
# --base-path -> working directory
# --document  -> the input text file
# --vocab-mapping -> generated mapping file between iptc and schema.org(run `StructuredMarkupHelper.Cli -h` to see how this mapping can be generated)
# --expertai-config -> expert.ai API configuration
# --markup-output -> output of the markup
```

Inside `wdir` directory you will find examples of inputs and configurations, as an example this is expert.ai configuration:
```json
{
  "token": "",
  "username": "",
  "password": "",
  "tokenRequestEndpoint": "https://developer.expert.ai/oauth2/token"
}
```


### Web

To run the web interface open the `StructuredMarkupHelper` directory and set configurations inside `appsettings.json` file:

```json
{
  "EXPERTAI_USERNAME": "",
  "EXPERTAI_PASSWORD": "",
  "EXPERTAI_TOKEN_ENDPOINT": "https://developer.expert.ai/oauth2/token",
  "IPTC_SCHEMA_MAP": "iptc_schemaorg_map_truncated.json",
  "PHANTOM_API": "https://PhantomJScloud.com/api/browser/v2/your-api-key"
}
```

To generate iframe pages you need to get an api key from https://phantomjscloud.com/. it has a free quota which is more than enough for testing purposes 

You can start the web application by:

```
dotnet restore
dotnet build
dotnet run --no-build
```

and open https://localhost:5001/ from the browser


## Integrating expert.ai APIs

Expert.ai provides [Open API specs](https://raw.githubusercontent.com/therealexpertai/nlapi-openapi-specification/master/nlapi.yaml) which can be used to generate clients codes and integrating the API.

https://openapi-generator.tech/ is a tool to generate client code in many programming languages, in our case we used the csharp one:

Open `ApiGenerator` directory to see configs and the command to generate the client code, there you will see:

```
openapi-generator-cli generate -i nlapi.yaml -g csharp -o ./expertio --config csharp-config.json
```
