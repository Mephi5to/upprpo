let converter = require('oas-raml-converter');
let raml10ToOas20 = new converter.Converter(converter.Formats.RAML, converter.Formats.OAS20);

raml10ToOas20.convertFile('./api/v1/birds.api.raml').then(raml => {
    console.log(raml);
});
