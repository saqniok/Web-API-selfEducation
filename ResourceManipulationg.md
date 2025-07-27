# Manipulating Resources

All pretty common functionality for an API
- Creating resources
- Updating resources
- Deleting resources
---

# Validating input

For `creating` and `updating` resources, we need to be able to pass through complex data to the API.

## Passing Data to API
- Data can be passed to an API by various means
- Binding source attributes tell the model binding engine where to find the binding source.

`[FromeBody]` - Requost body is deserialized into the model

`[FromQuery]` - Query string parameters

`[FromRoute]` - Route data from the current request

`[FromHeader]` - HTTP headers

`[FromForm]` - Form data is in the request body

`[FromServices]` - Dependency injection

`[AsParameters]` - Method parameters

Use binding source attributes to explicitly state where the action parameter should be bound from

```csharp
public ActionResult<ExampleDto> GetExample(
	[FromRoute] int exampleId,
	[FromHeader] string authorization,
	[FromBody] ExampleDto exampleDto)
{
	// Your logic here
})
```

Here we can change our GetExample action by expliicity stating that the exampleId is coming from the Route.
We do that by applying to `[FromeRoute]` attribute.

---
#### NOTE: 
- by default, ASP.NET Core attempts to use the complex objet model binder, which pulls data from value providers in a defined order.
- We are using the `[ApiController]` attribute, this changes the rules to better fit APIs.

`[FromBody]` - inferred for complex types parameters. Good example - adding a DescriptionOfExample, 
which will immediately tackle types with special meaning like `CancellationToken`, `IFormFile`, `IFormFileCollection`,
`Stream`, and `HttpRequest` will not be inferred as `[FromBody]` but rather as `[FromServices]`.

`[FromForm]` - Inferred for action parameters of type `IFormFile`, `IFormFileCollection`, and `Stream` when the request is a form data request.

`[FromRoute]` - Inferred for any action parameter name matching a parameter in the route template. 
When more than one route matches an action parameter, any route calue is considered from route

`[FromQuery]` - Inferred for any other action parameters.


#### This rules in most cases arewill save us from having to identify binding sources mannually.