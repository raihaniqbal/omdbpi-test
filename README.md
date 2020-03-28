## Overview
The purpose of this project is to demonstrate the following uses cases

### Integration with OMDB API
The [OMDb API]((http://www.omdbapi.com)) is a RESTful web service to obtain movie information, all content and images on the site are contributed and maintained by our users. 

### Search presence using JSON-LD Structed Data
Websites can define Structured Data in the head section of their html to enable search engines to show richer information in their search results. Here is an example of how Google can display extended metadata about your site in it's search results.

## Getting Started

The OMDB API requires a unique API key. You will need to generate one from [here](http://www.omdbapi.com/apikey.aspx). Once you have a key, update the appSettings.json file in the `WOTest.Web` project.

```JSON
"Settings": {
    "APIKey": "[YOUR_API_KEY]"
}
```
