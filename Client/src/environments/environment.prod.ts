const noSchemaApiUrlBase = "localhost:5001";
const schema = "https";
const apiUrlBase = `${schema}://${noSchemaApiUrlBase}`;

export const environment = {
  production: true,
  noSchemaApiUrlBase: noSchemaApiUrlBase,
  apiUrlBase: apiUrlBase,
  apiUrl: `${apiUrlBase}/api`,
  apiImageUrl: `${apiUrlBase}/images`,
};