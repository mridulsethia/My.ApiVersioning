# API versioning

Being an API provider, managing multiple API versions is inevitable. The art is to keep the maintenance cost in check and lessen the burden of the legacy in a given project.

## Resource versioning
	
Professionals have been discussing a lot on how to request a specific resource with its version number: 
- As a part of resource path
- As a querystring parameter
- As a custom request header (vs. accept header)

I prefer a hybrid approach to provide the maximum flexibility to everyone, both for the in-house and for the external users alike.

- **Bleeding edge _Beta_**: This is the most current version of an API. Any software based on this version implicitly requires updates at the same pace as the API changes. Typically, a case for in-house users (Or for those enthusiasts who lives on the bleeding edge and do not care if their software is broken until the API changes are implemented).
- **Custom request header**: More _“controlled method”_ to get a specific version as it lessens the chances of request tampering.
- **Querystring**: Most common and the simplest method of all. Easy to share a resource as a link and easy to change the parameter value to see and compare different versions.

The **_hybrid approach_**: if the version number is supplied via both, the _request header_ and the _querystring_, then the querystring _completely_ overrules the request header. The _Beta_ version is served is the absense (or empty) of a version number.

## Maintenance of versioned resources

It is hard to find some material on how people have addressed the core issue of **code maintenance**! Let us face it, defining how to access a resource is a minor issue, the main problem is how to keep the code repository healthy. 

Either we are forced to _manage several branches_ Or are _handcuffed while cleaning up/ refactoring_. Both cases demands heavy maintenance and is a subject of frustration for many. Following approach reduces the maintenance concerns by lifting some constrains that comes with the requirements of backward compatibility.

### A "Lightweight maintenance (LM)" approach: 

This approach uses _dynamic type_ and _ExpandoObject_ to manually construct the data structure (skeleton) of an API and then adapt the data model to fit the structure. Fabricating the API structure allows us to limit the maintenance efforts (mainly) to a single file. Preserving specific objects tied to a specific version is no longer required. This loose coupling of objects from API allows us to remove heaps of obsolete objects from a project and effectively eliminating the practice of _”forced branching”_.

*Note*: Also consider a _”version support” plan_ in advance: (e.g. how many versions, for how long, support and maintenance guidelines etc.)

# My.ApiVersioning Web API application

This .NET Core Web API application (https://github.com/mridulsethia/My.ApiVersioning) illustrates following:

- Configuring supported versions and their expiry date. _(appSettings.json)_
- Accessing API without any version number (Beta): returns latest data structure _(/api/values)_
- Accessing API via custom request header: returns data structure bound to the requested version _(api-version:2)_
- Accessing API via querystring - overrides request header, returns data structure bound to the requested version _(?v=2)_
- Response object with proper status codes and messages
- Constructing an API structure for a published version and later updated to adapt the latest data model

