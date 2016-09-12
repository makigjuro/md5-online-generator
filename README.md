# MD5 Checksum Generator for WebSite Content 

This application allows the user to insert some URL and to receive a MD5 Checksum generated from the content located on specified url.
The application contains a Rest API built with ServiceStack Side techology. Also there is a Single Page Application built with AngularJS including Gulp and Bower.
Both the RestAPI and the SPA are hosted inside a Console Application with help of Self-Host mode from ServiceStack.

## Installation

clone this repository https://github.com/npejo/mysp.git


Install the development dependencies listed in `package.json`
```shell
npm install
```

Install the development dependencies listed in `bower.json`
```shell
bower install
```

There is couple of gulp task that are used in the development process. For example: 
```shell
gulp inject
```
With running this task, the less is compiled into css and all js, and css files are being injected into index.html




