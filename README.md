This repository contains the source code for the .net client access library for Conical.

For more details on Conical, please see the main website - https://conical.cloud

## Usage
In order to use the library, construct a fresh instance of `AccessLayer` passing in the root URL (e.g. https://demo.conical.cloud) and an optional access token for user authentication. If no token is provided, then anonymous acccess will be used.

#### Uploading Data
To upload data, construct the `AcessLayer` instance as usual and then obtain the target product. From there, call `CreateTestRunSet` to create the test run set and then further methods on that object may be called to create test runs and subsequently publish data to the tool. Note that it's the responsibility of the caller to call `SetStatus` on the newly created TRS once publishing is complete in order to correctly set the status on the server.

## Built binaries
A built version of this library is available on [Nuget](https://nuget.org) under BorsukSoftware.Conical.Client

## Design choices
The access library is primarily intended to allow data to be published / subsequently downloaded from the tool rather than, currently, being 100% complete in terms of all of the functionality, especially around system mangement. All of this functionality is available through the documented Swagger page on an instance (URL - {server}/swagger) if programmatic access is needed and so users can call the functionality appropriately. If specific functionality is required through this library, then please raise an issue above and optionally the PR for your feature.

The library is designed to target .net standard in order to be consumable through .net core and .net framework apps.

## Implementation details
The library targets .net standard 2.0 in order to be consumable by both .net core and .net framework apps. This does come at the potential cost of not being able to use some of the later optimisations but that trade off is assumed to be worth it. If this is not the case for your use-case then the code is made available for you to make the appropriate customisations.