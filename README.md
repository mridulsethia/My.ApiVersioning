# API Versioning

It is a luxury if you the only consumer of your services, but the responsibility becomes manifold if your services are consumed outside your organization. 

Since you are here, I assume that you are in a situation where you need to manage different versions of your API and the thought of creating and maintaining different branches of your API is giving you/your team few nightmares.

## Resource Versioning

Internet has been discussing a lot on whether version number should be a part of:

1. The Route 
2. The Querystring 
3. Request Headers

While we are at it, I'll add my five cents. I personally prefer a combined approach:

1. **Bleeding edge *BETA***: The most recent version of the API, without any version number. Any software based on this version implicitly requires changes at the same pace as the API changes. Typically, a case for internal projects and enthusiasts who like to live on the edge! 
2. **Request Headers**: Recommended way to access versioned resource provided.
3. **Query-string**: Intended to allow service-consumers to quickly check-out different versions available. This overrules the version you might have requested via headers! It is expected that you know what you are doing and which version you want to use. 

## Maintenance of versioned resources

It's hard to material on how to people have addressed the real issue: Code Maintenance! 
Let's face it, how resources are accessed is the least of the problems, the main issue is either to:

1. *Manage various branches* that are dedicated to specific version
2. *Code refactoring and cleanup* horrors! Obsolete classes/object are held to support legacy versions, which no one know whether they are at all in use!

Both above mentioned approaches demand heavy maintenance and subject of pain for the most. 

Following suggestion reduces the maintenance concerns and lifts the constrains that might hold you back from cleaning up/ refactoring.

### A "Lightweight maintenance (LM)" Approach: 
LM neither requires branching OR preserve heaps of obsolete classes/objects. In most cases, just one file (C# class) would do the job.

This approach uses dynamic type and ExpandoObject to manually construct the data structure (skeleton) of an API and then adapt the data model into the existing structure.

*Note*: It is also suggested to consider and planning on how many versions and how for how long they should be supported. This way you 

Download the .netcore application (https://github.com/mridulsethia/My.ApiVersioning) which illustrates the following:

- Configuring supported versions and their expiry date. *(appSettings.json)*
- Accessing API without any version number (BETA) - latest data structure *(/api/values)*
- Accessing API with Request headers - data structure bound to the requested version *(api-version:2)*
- Accessing API with query-string - overrides request header, gets data structure bound to the requested version *(?v=2)*
- Response object with proper status codes and messages


