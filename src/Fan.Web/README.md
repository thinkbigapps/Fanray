# Fan.Web

## client

The **client** folder contains js and scss files for the client facing site. All resources are managed by the package.json under Fan.Web, these resources are either copied or transpiled into wwwroot. This will be migrated into a theme later.

## package.json

### devDependencies

| **Package** | **Description** |
|--------|-------|
| [cpx](https://github.com/mysticatea/cpx) | Copies resources from client to wwwroot. |
| [minifier](https://github.com/fizker/minifier) | Minimizes site.css after scss transpiles. |
| [node-sass](https://github.com/sass/node-sass) | The scss transpiler. |
| [npm-run-all](https://github.com/mysticatea/npm-run-all) | Runs all tasks like copy. |

### scripts

| **Scripts** | **Description** |
|--------|-------|
| Copy | Copies resources from client to wwwroot. |
| Scss | Transpiles and min site.css to wwwroot. |

 You can consider to bind Copy and Scss to After Build binding, so they will execute after you build.  Or you can just manually execute them.

## Visual Studio Extensions

| **Extensions** | **Description** |
|--------|-------|
| [NPM Task Runner](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.NPMTaskRunner) | Helps with executing package.json scripts in VS. |
| [Web Essentials 2017](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebExtensionPack2017) | Gives emmet, better file icon, markdown preview, css tools etc. |

## How To

### How to get latest npm

https://docs.npmjs.com/getting-started/installing-node

## Gotcha

### VS Task Runner Explorer only works with package.json under proj root

Currently, there is a package.json under Fan.Web used for client.  When I migrate the client and package.json into its own theme, Task Runner won't be able to be used.

### "npm install" gives an error after installing node.js v9.0.0

Fix: https://github.com/npm/npm/issues/19019

Uninstall Node and delete C:\Users\ray\AppData\Roaming\npm and npm-cache folders, then re-install Node. After that you could do things like `npm install -g @angular/cli` However, I had to install my globally installed packages again.

### Files have different encodings, Western Europen (Windows)

You can either [save file as with encoding](https://msdn.microsoft.com/en-us/library/dxfdkfke(v=vs.140).aspx) or just create a new file and copy content.

### Visual Studio debugging/loading very slow

Delete C:\Users\{USER_NAME}\AppData\Local\Temp\Temporary ASP.NET Files\
https://stackoverflow.com/questions/12567984/visual-studio-debugging-loading-very-slow
https://stackoverflow.com/a/18617320/32240

### To run in https://localhost

There needs to be `"launchUrl": "https://localhost:44381/",` in Profiles > IIS Express.

### Visual Studio loads sln very slow

If you put the spa project as part of Fan.Web, it has a node_modules folder with over 800 sub folders.