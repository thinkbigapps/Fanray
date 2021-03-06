<p align="center">
  <a href="https://www.fanray.com/">
    <img src="https://user-images.githubusercontent.com/633119/33040809-0fec23d8-cdf1-11e7-8543-5b666e78f5b4.png" alt="" width=72 height=72>
  </a>
  <h3 align="center">Fanray</h3>
  <p align="center">
    A blog built with <a href="https://github.com/aspnet/Home">ASP.NET Core</a>.
  </p>
</p>
<br>

## Table of contents

- [Status](#status)
- [Quick Start](#quick-start)
- [Features](#features)
- [Open Live Writer](#open-live-writer)
- [Shortcodes](#shortcodes)
- [Contributing](#contributing)
- [Roadmap](#roadmap)
- [License](#license)

## Status

| Branch | Status |
| ------ | ------ |
| Stable (master) | [![Build status](https://ci.appveyor.com/api/projects/status/25ifr0ahvcxn48f5/branch/master?svg=true)](https://ci.appveyor.com/project/FanrayMedia/fanray/branch/master) |
| Weekly (dev) | [![Build status](https://ci.appveyor.com/api/projects/status/25ifr0ahvcxn48f5/branch/dev?svg=true)](https://ci.appveyor.com/project/FanrayMedia/fanray/branch/dev) |
| Nightly (feature) | [![Build status](https://ci.appveyor.com/api/projects/status/25ifr0ahvcxn48f5?svg=true)](https://ci.appveyor.com/project/FanrayMedia/fanray) |

## Quick Start

Fanray requires [.NET Core 2.0](https://www.microsoft.com/net/core/) and [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).  Clone the repo, then run from either [Visual Studio 2017](https://www.visualstudio.com/vs/community/) or command line.

- VS2017: open Fanray.sln, make sure Fan.Web is the startup project, ctrl + F5
- Command line: do the following, then go to http://localhost:5001
 ```
cd <sln folder>
dotnet restore
cd src/Fan.Web
dotnet run
```

Database is created for you on app initial launch. Below is the default connection string, to adjust it go to `appsettings.json`

```
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Fanray;Trusted_Connection=True;MultipleActiveResultSets=true"
},
```

You will see the blog setup page on the first launch.

## Features

Fanray v1.0 highlights:

- Supports [Open Live Writer](#open-live-writer) through MetaWeblog API
- Easily posts source code and YouTube videos with [Shortcodes](#shortcodes)
- Provides main and per category RSS feeds, e.g.
  - Main feed: https://www.fanray.com/feed
  - Category feed: https://www.fanray.com/posts/categorized/technology/feed
- Easily configures URL forwarding to https and preferred domain (either www or non-www)
- Infrastructure
  - Logging with Serilog to Console, Files, Seq and Application Insights
  - Caching
  - File storages on File Sytem and Azure Blob Storage
  - xUnit tests with SQLite in-memory database
- Uses Disqus for comments

## Open Live Writer

With Fanray v1.0 to start posting a client like [Open Live Writer](http://openlivewriter.org/) is required. To get started,

- Launch the web app
- Install and open OLW > Add blog account... > Other services > type in
  - Web address of your blog
  - User name
  - Password

The login credentials here are created on the blog setup page.

## Shortcodes

When writing a post, you may need to post things like source code or youtube videos, shortcodes make this really easy.

### Source code

Fanray uses [SyntaxHighlighter](https://github.com/syntaxhighlighter/syntaxhighlighter) to highlgith source code, here are the [supported languages](http://alexgorbatchev.com/SyntaxHighlighter/manual/brushes/). For example, to post C# code
```
[code lang=cs]
paste your code here...
[/code]
```

The following attributes are supported
- `highlight`: (comma-seperated list of numbers) - You can list the line numbers you want to be highlighted.
  ```
  [code lang=cs highlight=1,3]
  your source code line 1 and 3 will be highlighted
  [/code]
  ```
- `gutter`: (true/false) - If false, the line numbers on the left side will be hidden. Defaults to true.
  ```
  [code lang=cs gutter=false]
  you won't see line numbers on the left
  [/code]
  ```
- `firstline`: (number) - Use this to change what number the line numbering starts at. It defaults to 1.
  ```
  [code lang=cs firstline=87]
  the line number on the left starts at 87
  [/code]
  ```
- `htmlscript`: (true/false) - If true, any HTML/XML in your code will be highlighted. This is useful when you are mixing code into HTML, such as razor content. Defaults to false. Only works with certain languages. Don't use this attribute when lang is already html or xml.
  ```
  [code lang=cs htmlscript=true]
  paste your cshtml code here
  [/code]
  ```

### YouTube videos

To post a youtube video, get the video's url, any of the two formats will do.
```
[youtube https://www.youtube.com/watch?v=MNor4dYXa6U] or 
[youtube https://youtu.be/MNor4dYXa6U]
```

To embed the video with default width and height (560 x 315)
```
[youtube https://www.youtube.com/watch?v=MNor4dYXa6U]
```

To specify the width and height explicitly
```
[youtube https://www.youtube.com/watch?v=MNor4dYXa6U&w=800&h=400]
```

To specify the width only
```
[youtube https://www.youtube.com/watch?v=MNor4dYXa6U&w=800]
```

To start at a certain point in the video, convert the time of that point from minutes and seconds to all seconds, then add that number as shown (using an example start point of 1 minute 15 seconds)
```
[youtube https://www.youtube.com/watch?v=MNor4dYXa6U&start=75]
```

## Contributing

Any participation from the community is welcoming, please read the [contributing guidelines](CONTRIBUTING.md).

## Roadmap
* **v1.0** _mvp_ (Nov 2017)
* **v1.1** _admin console_ 

## License

This project is licensed under the [Apache 2.0](LICENSE).