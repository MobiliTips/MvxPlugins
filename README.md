# MvxPlugins
MVVMCross plugins

## MvxForms aka MvvmCross - Xamarin Forms plugin

MvvmCross plugin to work with Xamarin Forms on iOS, Android, WinPhone SL, WinStore 8.1 & WinPhone 8.1 projects.

### Release notes:

1.2.0:
* [Update] Xamarin.Forms nuget packages updated to 1.4.2
* [New] Now Base presenter public methods like Show or ChangePresentation are virtual so that you can override it on each platform presenter
* [New] Forms.Init added to Android MvxFormsApplicationMainActivity

### Install

It's a simple plugin allowing you to work with both MvvmCross and Xamarin Forms and based on Cheesebaron FormsPresenters code.
Install the plugin and follow the "ToDo - MvxForms" instuctions on each platform.

### Use

You can work either with Xaml or cs views, it doens't matter.
By default, the plugin will look for views with "View" suffix but anyway, you can tell the plugin to work with your own suffix (like "Page" as many prefer) by writing it into the presenter initialization (Setup file) like that (example for Android but the same for iOS, WinPhone or WinStore):

    var presenter = new MvxFormsAndroidViewPresenter(new MvxFormsApp(), "Page");

Full tutorial aviable:
* English: https://mobilitips.wordpress.com/2015/04/14/use-mvvmcross-with-xamarin-forms-thanks-to-mvxforms-plugin/
* French: https://mobilitips.wordpress.com/2015/04/13/utiliser-mvvmcross-avec-xamarin-forms-grace-au-plugin-mvxforms/


## MvxAms aka MvvmCross - Azure Mobile Services plugin

Work with Azure Mobile Services thanks to MvvmCross framework with almost 1 line call to manage remote as local data (local data management need you to install the MvvmCross - Azure Mobile Services plugin Local Store extension), authenticate users or send custom API requests.

### Release notes:

1.1.0-beta1:
* [New] Initialization configurable at global and platform specific level
* [New] Transparent auto initialization
* [New] Manage remote data
* [New] Manage local data (with plugin extension)
* [New] Manage data synchronization (with plugin extension)
* [New] Authenticate users directly from a PCL call
* [New] Send custom API request

### Install

Aviable soon...

### Use

Aviable soon...

Already working but private beta testing in progress.


## MvxAms.LocalStore aka MvvmCross - Azure Mobile Services plugin Local Store extension

This plugin extend possibilities of the MvvmCross - Azure Mobile Services plugin to manage local data.

### Release notes

1.0.0-beta1:
* [New] Manage local data
* [New] Manage data synchronization

### Install

Aviable soon...

### Use

Aviable soon...

Already working but private beta testing in progress.

Stay tuned!
