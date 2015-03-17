# MvxPlugins
MVVMCross plugins

## MvxForms aka MvvmCross - Xamarin Forms plugin

### Install
It's a simple plugin allowing you to work with both MvvmCross and Xamarin Forms and based on Cheesebaron FormsPresenters code.
Install the plugin and follow the "ToDo - MvxForms" instuctions on each platform.

### Use
You can work either with Xaml or cs views, it doens't matter.
By default, the plugin will look for views with "View" suffix but anyway, you can tell the plugin to work with your own suffix (like "Page" as many prefer) by writing it into the presenter initialization (Setup file) like that (example for Android but the same for iOS or WinPhone):

    var presenter = new MvxFormsAndroidViewPresenter(new MvxFormsApp(), viewSuffix: "Page");

Please let me know about bugs registering an issue as I'm human and human make mistakes :)
