# Backend

This application is constructed using .NET, the following instructions detail how to utilize and execute the application.

## Table of Contents

- [Application structure](#application-structure)
  - [APIs](#apis)
  - [API_Menu](#api_menu)
- [Using the application](#using-the-application)
  - [Dependencies](#dependencies)
  - [Build](#build)
  - [Testing](#testing)

## Application structure

The application is split into two distinct parts: "APIs" and "API_Menu". 
This is due to the fact that we decided to split up our API into multiple, but as this would take a while and the API still needed updates the original API and split API got seperated.
Both can be run independetly.

### APIs

This is the "old" API. It contains all the functions, but it is not split up unlike API_Menu.
It consists of an API, business layer and data layer, with interfaces and models to connect them.
It also includes unit tests for the data layer and business layer.

### API_Menu

TODO: Niels

## Using the application

First of all, depending on which one you want to use, go into the "APIs" or "API_menu" folder in this directory before you run any code!

### Dependencies

Start with installing the dependencies with:

```
dotnet restore
```

### Build

To build the application for development, run:

```
dotnet build
```

To build the application for production, run:

```
dotnet publish -c Release
```

### Testing

To run unit tests use:

```
dotnet test
```
