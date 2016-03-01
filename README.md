# Splat Contributions

[![NuGet Stats](https://img.shields.io/nuget/dt/splat.contrib.svg)](https://www.nuget.org/packages/splat.contrib) [![Issue Stats](http://www.issuestats.com/github/dhgms-solutions/splatcontrib/badge/issue?style=flat)](http://www.issuestats.com/github/dhgms-solutions/splatcontrib) [![Pull Request Stats](http://www.issuestats.com/github/dhgms-solutions/splatcontrib/badge/pr?style=flat)](http://www.issuestats.com/github/dhgms-solutions/splat.contrib) 

Splat Contrib is a small library aimed at providing some extensions to the excellent Splat library by Paul Betts.

## Mission Statement
* Provide logic for Feature Usage Tracking in Applications
* Provide logging extensions that allow Func&lt;string&gt; to be passed in and only be evaluated if the relevant logging level is enabled.
* Look to feed contributions back to the main splat project once they've reached a point of maturity.

## Viewing the documentation

[See the main documentation for Splat](https://github.com/paulcbetts/splat)

### Functional Logging ###

These methods are extensions to the current Splat logging mechanism. They simply need you to change your logging methods to pass a Func&lt;string&gt; \ Lambda into them.

```cs
this.Log().Debug(() => "Something that will only evaluate if the debug log level is enabled");
```

### Feature Usage Tracking ###

```cs
TODO
```

## Contributing to the code

### 1\. Fork the code

See the [github help page for instructions on how to create a fork](http://help.github.com/fork-a-repo/).

### 2\. Apply desired changes

Use your preffered method for carrying out work.

### 3\. Send a pull request

See the [github help page for instructions on how to send pull requests](http://help.github.com/send-pull-requests/)
