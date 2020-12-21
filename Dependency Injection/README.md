| Built – in IoC Container: ServiceLifetime.Transient  services.AddTransient<,>              |
| Autofac IoC Container: InstancePerDependency()                                             |
| Description: A unique instance will be returned from each object request.                  |
| -------------------------------------------------------------------------------------------|
| Built – in IoC Container: ServiceLifetime.Scoped services.AddScope<,>                      |
| Autofac IoC Container: InstancePerLifetimeScope()                                          |
| Description:  A component with per-lifetime scope will have at most a single               |
| instance per nested lifetime scope. This is useful for objects specific to a               |
| single unit of work that may need to nest additional logical units of work.                |
| Each nested lifetime scope will get a new instance of the registered dependency.           |
| For example, this type of lifetime scope is useful for Entity Framework DbContext          |
| objects (Unit of Work pattern) to be shared across the object scope so you can run         |
| transactions across multiple objects.                                                      |
| -------------------------------------------------------------------------------------------|
| Built – in IoC Container: ServiceLifetime.Scoped services.AddScope<,>                      |
| Autofac IoC Container: InstancePerRequest()                                                |
| Description: Application types like ASP.NET Core naturally lend themselves to “request”    |
| type semantics. You have the ability to have a sort of “singleton per request.”            |
| Instance per request builds on top of instance per matching lifetime scope by providing    |
| a well-known lifetime scope tag, a registration convenience method, and integration for    |
| common application types. Behind the scenes, though, it’s still just instance per matching |
| lifetime scope.                                                                            |
| -------------------------------------------------------------------------------------------|
| Built – in IoC Container: ServiceLifetime.Singleton services.AddSingleton<,>               |
| Autofac IoC Container: SingleInstance()                                                    |
| Description: One instance is returned from all requests in the root and all nested scopes  |
| -------------------------------------------------------------------------------------------|
| Built – in IoC Container: No                                                               |
| Autofac IoC Container: InstancePerMatchingLifetimeScope()                                  |
| Description:  you have the ability to “tag” or “name” the scope. A component with          |
| per-matching-lifetime scope will have at most a single instance per nested lifetime        |
| scope that matches a given name. This allows you to create a sort of “scoped singleton”    |
| -------------------------------------------------------------------------------------------|
| Built – in IoC Container: No                                                               |
| Autofac IoC Container: InstancePerOwned()                                                  |
| Description: The Owned<T> implicit relationship type creates new nested lifetime scopes.   |
| It is possible to scope dependencies to the owned instance using the instance-per-owned    |
| registrations.                                                                             |
| -------------------------------------------------------------------------------------------|
| Built – in IoC Container: No                                                               |
| Autofac IoC Container: Thread Scope (based on lifetime scopes)                             |
| Description: Autofac can enforce that objects bound to one thread will not satisfy the     |
| dependencies of a component bound to another thread. While there is not a convenience      |
| method for this, you can do it using lifetime scopes.                                      |


